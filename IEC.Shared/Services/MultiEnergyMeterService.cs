using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using NModbus;
using NModbus.Serial;
using NModbus.Utility;
using System.Diagnostics;

namespace IEC.Shared.Services
{
    public class MultiEnergyMeterService : IMultiEnergyMeterService
    {
        // One physical port shares one SerialPort + one master, serving multiple slave IDs
        private class PortConnection
        {
            public bool IsConnected { get; set; }
            public string Error { get; set; }
            public SerialPort Port;
            public IModbusSerialMaster Master;
        }

        private readonly Dictionary<string, PortConnection> _portConnections = new();
        private readonly Dictionary<string, MeterConfig> _meters = new(); // keyed by MeterName
        private readonly object _lock = new();

        public void Configure(IEnumerable<MeterConfig> meters)
        {
            foreach (var meter in meters)
            {
                _meters[meter.MeterName] = meter;

                // Open the physical port once per unique PortName (shared across meters on that bus)
                if (!_portConnections.ContainsKey(meter.PortName))
                {
                    var port = new SerialPort(meter.PortName)
                    {
                        BaudRate = meter.BaudRate,
                        DataBits = 8,
                        Parity = meter.Parity,
                        StopBits = StopBits.One
                    };

                    try
                    {
                        port.Open();

                        _portConnections[meter.PortName] =  new PortConnection { IsConnected = true, Port = port};
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        _portConnections[meter.PortName] =
                            new PortConnection
                            {
                                IsConnected = false,
                                Error = ex.Message
                            };
                    }

                    var factory = new ModbusFactory();
                    var transport = factory.CreateRtuTransport(port);
                    var master = factory.CreateMaster(transport);

                    master.Transport.ReadTimeout = 1000;   // ms
                    master.Transport.Retries = 2;

                    _portConnections[meter.PortName] = new PortConnection
                    {
                        Port = port,
                        Master = master
                    };
                }
            }
        }

        public async Task<Dictionary<string, EnergyMeterReading>> ReadAllAsync()
        {
            var results = new Dictionary<string, EnergyMeterReading>();
            
            foreach (var meter in _meters.Values)
            {
                try
                {
                    results[meter.MeterName] = await ReadOneAsync(meter.MeterName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Read failed for {meter.MeterName}: {ex.Message}");
                    results[meter.MeterName] = null; // or a reading with an IsOnline=false flag
                }

                await Task.Delay(50); // settle time before switching to next slave on the bus
            }

            return results;
        }

        public Task<EnergyMeterReading> ReadOneAsync(string meterName)
        {
            if (!_meters.TryGetValue(meterName, out var meter))
                throw new InvalidOperationException($"Meter '{meterName}' is not configured.");

            if (!_portConnections.TryGetValue(meter.PortName, out var conn) || !conn.Port.IsOpen)
                throw new InvalidOperationException($"Port for meter '{meterName}' is not connected.");

            return Task.Run(() =>
            {
                // Lock per physical port so concurrent slave reads on the same bus don't collide
                lock (_lock)
                {
                    return new EnergyMeterReading
                    {
                        VoltageA_N = ReadFloat(conn.Master, meter.SlaveId, 3028),
                        VoltageB_N = ReadFloat(conn.Master, meter.SlaveId, 3030),
                        VoltageC_N = ReadFloat(conn.Master, meter.SlaveId, 3032),
                        VoltageL_N_Avg = ReadFloat(conn.Master, meter.SlaveId, 3036),
                        CurrentA = ReadFloat(conn.Master, meter.SlaveId, 3000),
                        CurrentB = ReadFloat(conn.Master, meter.SlaveId, 3002),
                        CurrentC = ReadFloat(conn.Master, meter.SlaveId, 3004),
                        CurrentAvg = ReadFloat(conn.Master, meter.SlaveId, 3010),
                        TotalActivePower = ReadFloat(conn.Master, meter.SlaveId, 3060),
                        TotalReactivePower = ReadFloat(conn.Master, meter.SlaveId, 3068),
                        TotalApparentPower = ReadFloat(conn.Master, meter.SlaveId, 3076),
                        Frequency = ReadFloat(conn.Master, meter.SlaveId, 3042),
                        TotalPowerFactor = ReadFloat(conn.Master, meter.SlaveId, 3084)
                    };
                }
            });
        }

        private float ReadFloat(IModbusSerialMaster master, byte slaveId, ushort address)
        {
            ushort[] registers = master.ReadHoldingRegisters(slaveId, address, 2);
            Thread.Sleep(10); // tiny gap between register reads
            return ModbusUtility.GetSingle(registers[1], registers[0]);
        }

        public void DisconnectAll()
        {
            foreach (var conn in _portConnections.Values)
                conn.Port?.Close();
            _portConnections.Clear();
        }

        public void Dispose() => DisconnectAll();
    }
}
