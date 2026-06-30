using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEC.Shared.Services
{
    public interface IMultiEnergyMeterService : IDisposable
    {
        void Configure(IEnumerable<MeterConfig> meters);
        Task<Dictionary<string, EnergyMeterReading>> ReadAllAsync();
        Task<EnergyMeterReading> ReadOneAsync(string meterName);
        void DisconnectAll();
    }
}
