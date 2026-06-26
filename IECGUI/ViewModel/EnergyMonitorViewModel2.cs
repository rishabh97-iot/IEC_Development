using IEC.Shared.Models;
using IECGUI.Services;
using IPCSoftware.Common.CommonExtensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using System.Windows.Media;

namespace IECGUI.ViewModel
{
    public class EnergyMonitorViewModel2 : BaseViewModel
    {
        private Brush _brush1 = Brushes.Green;
        public Brush Brush1
        {   get => _brush1;
            set => SetProperty(ref _brush1, value);
        }

        private Brush _brush2 = Brushes.Green;
        public Brush Brush2
        {
            get => _brush2;
            set => SetProperty(ref _brush2, value);
        }

        public double INC1AMP
        {
            get => _inc1amp;
            set => SetProperty(ref _inc1amp, value);
        }
        private double _inc1amp;


        public double INC2AMP
        {
            get => _inc2amp;
            set => SetProperty(ref _inc2amp, value);
        }
        private double _inc2amp;


        public double INC3AMP
        {
            get => _inc3amp;
            set => SetProperty(ref _inc3amp, value);
        }
        private double _inc3amp;

        public double INC1VOLT
        {
            get => _inc1volt;
            set => SetProperty(ref _inc1volt, value);
        }
        private double _inc1volt;

        public double INC2VOLT
        {
            get => _inc2volt;
            set => SetProperty(ref _inc2volt, value);
        }
        private double _inc2volt;


        public double INC3VOLT
        {
            get => _inc3volt;
            set => SetProperty(ref _inc3volt, value);
        }
        private double _inc3volt;



        public ICommand BackCommand { get; }

        private readonly SafePoller _liveDataTimer;

        public ObservableCollection<MeterViewModel> Meters { get; }
        private readonly INavigationService _navigation;

        private CancellationTokenSource _cts;
        public EnergyMonitorViewModel2(INavigationService navigation)
        {
            _navigation = navigation;
            _liveDataTimer = new SafePoller(TimeSpan.FromMilliseconds(1000), LiveDataTimerTick, ex=>Console.WriteLine(ex.Message));
            _liveDataTimer.Start();

            BackCommand = new RelayCommand(NavigateToHome);

            INC1AMP = 12.34;
            INC2AMP = 56.34;
            INC3AMP = 45.34;
            INC1VOLT = 10.9;
            INC2VOLT = 9.89;
            INC3VOLT = 11.02;

        }

        private void NavigateToHome()
        {
            _navigation.NavigateTo(new Dashboard1ViewModel(_navigation));
        }


        private async Task LiveDataTimerTick(Dictionary<int, object> parameters)
        {
            // Simulate updating live data
            INC1AMP = 45 + new Random().NextDouble() * 6;
            INC2AMP = 35 + new Random().NextDouble() * 6;
            INC3AMP = 40 + new Random().NextDouble() * 4;
            INC1VOLT = 9 + new Random().NextDouble() * 2;
            INC2VOLT = 8 + new Random().NextDouble() * 2;
            INC3VOLT = 10 + new Random().NextDouble() * 2;
            await Task.CompletedTask; // Placeholder for any asynchronous operations

            if (INC1AMP > 50 )
            {
                Brush1 = Brushes.Red;
                
            }
            if(INC1AMP < 48 && INC1AMP > 45)
            {
                Brush1 = Brushes.Orange;
            }
            else
            {
                Brush1 = Brushes.LimeGreen;

            }



            if (INC2AMP > 40)
            {
                Brush2 = Brushes.Red;

            }
            if (INC2AMP < 38 && INC2AMP > 36)
            {
                Brush2 = Brushes.Orange;
            }
            else
            {
                Brush2 = Brushes.LimeGreen;

            }


        }

        public void Dispose() => _liveDataTimer?.Dispose();
    }
}
