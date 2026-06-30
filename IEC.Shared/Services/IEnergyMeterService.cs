using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEC.Shared.Services
{
    public interface IEnergyMeterService : IDisposable
    {
        void Connect(string portName, int baudRate, byte slaveId);
        Task<EnergyMeterReading> ReadAsync();
        void Disconnect();
    }
}
