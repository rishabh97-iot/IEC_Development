using IEC.Shared.Models;
using IECGUI.Services;
using IPCSoftware.Common.CommonExtensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace IECGUI.ViewModel
{
    public class EnergyMonitorViewModel : BaseViewModel
    {
        public ICommand ReturnToHome { get; }

        private readonly SafePoller _liveDataTimer;
        private int NoOfMeters=50;

        public ObservableCollection<MeterViewModel> Meters { get; }
        private readonly INavigationService _navigation;

        private CancellationTokenSource _cts;
        public EnergyMonitorViewModel(INavigationService navigation)
        {
            _liveDataTimer = new SafePoller(TimeSpan.FromMilliseconds(500), RunBackgroundService, ex => Console.WriteLine(ex.Message));
            _liveDataTimer.Start();

            _navigation = navigation;
            Meters = new ObservableCollection<MeterViewModel>();

            for (int i = 1; i <= NoOfMeters; i++)
            {
                Meters.Add(new MeterViewModel()
                {
                    MeterName = $"Meter-{i:00}",
                    Energy = 12345,
                    RealPower = 450,
                    ReactivePower = 120,
                    VoltageAB = 100+i*i,
                    CurrentA = 53+i*i,
                });
            }
            //_cts = new CancellationTokenSource();
            //_ = RunBackgroundService(_cts.Token);

            ReturnToHome = new RelayCommand(NavigateToHome);

            _ =  MetersRuntime();

        }

        public async Task MetersRuntime()
        {
            for(int i = 0; i < NoOfMeters; i++)
            {
                Meters[i].CurrentA = 45 + new Random().NextDouble() * 3;
                Meters[i].VoltageAB = 220 + new Random().NextDouble() * 3;
                Meters[i].Energy = 120 + new Random().Next(0, 10);
                Meters[i].RealPower = 450 + new Random().Next(0, 10);
                Meters[i].ReactivePower = 120 + new Random().Next(0, 10);
            }
         
        }

        public async Task RunBackgroundService(Dictionary<int, object> parameters)
        {
            await MetersRuntime();
        }

        private void NavigateToHome()
        {
            _navigation.NavigateTo(new Dashboard1ViewModel(_navigation));
        }
    }
}
