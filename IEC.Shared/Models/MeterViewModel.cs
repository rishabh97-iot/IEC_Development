using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IEC.Shared.Models
{
    public class MeterViewModel : ObservableObjectVM
    {
        public string _metername;
        public double _energy;
        public double _realpower;
        public double _reactivepower;
        public double _voltageab;
        public double _currenta;
        public string MeterName
        {
            get => _metername;
            set => SetProperty(ref _metername, value);
        }
        public double Energy
        {
            get => _energy;
            set => SetProperty(ref _energy, value);
        }

        public double RealPower
        {
            get => _realpower;
            set => SetProperty(ref _realpower, value);
        }
        public double ReactivePower
        {
            get => _reactivepower;
            set => SetProperty(ref _reactivepower, value);
        }

        public double VoltageAB
        {
            get => _voltageab;
            set => SetProperty(ref _voltageab, value);
        }
        public double CurrentA
        {
            get => _currenta;
            set => SetProperty(ref _currenta, value);
        }
    }
}
