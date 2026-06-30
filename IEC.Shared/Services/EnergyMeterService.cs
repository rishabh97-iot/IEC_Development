using System.IO.Ports;
using NModbus;
using NModbus.Serial;
using NModbus.Utility;

namespace IEC.Shared.Services
{
    public class EnergyMeterService : IEnergyMeterService
    {
        private SerialPort _port;
        private IModbusSerialMaster _master;
        private byte _slaveId;

        public void Connect(string portName, int baudRate, byte slaveId)
        {
            if (_port != null && _port.IsOpen)
                return; // already connected, don't try again

            _slaveId = slaveId;
            _port = new SerialPort(portName)
            {
                BaudRate = baudRate,
                DataBits = 8,
                Parity = Parity.Even,
                StopBits = StopBits.One
            };
            try
            {
                _port.Open();
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new InvalidOperationException(
                    $"Port '{portName}' is already in use by another process or connection. " +
                    "Make sure only one service instance opens this port.", ex);
            }

            var factory = new ModbusFactory();
            var transport = factory.CreateRtuTransport(_port);
            _master = factory.CreateMaster(transport);
        }

        public Task<EnergyMeterReading> ReadAsync()
        {

            if (_master == null || _port == null || !_port.IsOpen)
                throw new InvalidOperationException("Meter is not connected. Call Connect() first.");

            return Task.Run(() =>
            {
                return new EnergyMeterReading
                {
                    VoltageA_N = ReadFloat(3028),
                    VoltageB_N = ReadFloat(3030),
                    VoltageC_N = ReadFloat(3032),
                    VoltageL_N_Avg = ReadFloat(3036),

                    CurrentA = ReadFloat(3000),
                    CurrentB = ReadFloat(3002),
                    CurrentC = ReadFloat(3004),
                    CurrentAvg = ReadFloat(3010),

                    TotalActivePower = ReadFloat(3060),
                    TotalReactivePower = ReadFloat(3068),
                    TotalApparentPower = ReadFloat(3076),

                    Frequency = ReadFloat(3042),
                    TotalPowerFactor = ReadFloat(3084)
                };
            });
        }

        private float ReadFloat(ushort address)
        {
            ushort[] registers = _master.ReadHoldingRegisters(_slaveId, address, 2);
            return ModbusUtility.GetSingle(registers[1], registers[0]);
        }

        public void Disconnect() => _port?.Close();
        public void Dispose() => Disconnect();
    }
}
