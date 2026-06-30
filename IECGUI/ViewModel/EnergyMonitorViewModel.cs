using IEC.Shared.Models;
using IEC.Shared.Services;
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
        private int NoOfMeters=6;
        private readonly IEnergyMeterService _energyMeterService;

        public ObservableCollection<MeterViewModel> Meters { get; }
        private readonly INavigationService _navigation;

        private CancellationTokenSource _cts;
        public EnergyMonitorViewModel(INavigationService navigation , IEnergyMeterService energyMeterService)
        {
            _liveDataTimer = new SafePoller(TimeSpan.FromMilliseconds(500), RunBackgroundService, ex => Console.WriteLine(ex.Message));
            _liveDataTimer.Start();
            
            _navigation = navigation;
            _energyMeterService = energyMeterService;
            _energyMeterService.Connect("COM6", 19200, 10);
            Meters = new ObservableCollection<MeterViewModel>();
         


            for (int i = 1; i <= NoOfMeters; i++)
            {
                Meters.Add(new MeterViewModel()
                {
                    MeterName = $"Meter-{i:00}",

                    VoltageA_N = 0,
                    VoltageB_N = 0,
                    VoltageC_N = 0,
                    VoltageL_N_Avg = 0,

                    CurrentA = 0,
                    CurrentB = 0,
                    CurrentC = 0,
                    CurrentAvg = 0,

                    TotalActivePower = 0,
                    TotalReactivePower = 0,
                    TotalApparentPower = 0,
                    Frequency = 0,
                    TotalPowerFactor = 0,
                });
            }
            //_cts = new CancellationTokenSource();
            //_ = RunBackgroundService(_cts.Token);

            ReturnToHome = new RelayCommand(NavigateToHome);

            _ =  MetersRuntime();

        }

        public async Task MetersRuntime()
        {
            try
            {
                var reading = await _energyMeterService.ReadAsync();

                for (int i = 0; i < Meters.Count; i++)
                {
                    Meters[i].VoltageA_N = reading.VoltageA_N;
                    Meters[i].VoltageB_N = reading.VoltageB_N;
                    Meters[i].VoltageC_N = reading.VoltageC_N;
                    Meters[i].VoltageL_N_Avg = reading.VoltageL_N_Avg;

                    Meters[i].CurrentA = reading.CurrentA;
                    Meters[i].CurrentB = reading.CurrentB;
                    Meters[i].CurrentC = reading.CurrentC;
                    Meters[i].CurrentAvg = reading.CurrentAvg;

                    Meters[i].TotalActivePower = reading.TotalActivePower;
                    Meters[i].TotalReactivePower = reading.TotalReactivePower;
                    Meters[i].TotalApparentPower = reading.TotalApparentPower;

                    Meters[i].Frequency = reading.Frequency;
                    Meters[i].TotalPowerFactor = reading.TotalPowerFactor;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MetersRuntime error: {ex.Message}");
            }
        }

        public async Task RunBackgroundService(Dictionary<int, object> parameters)
        {
            await MetersRuntime();
        }

        private void NavigateToHome()
        {
            _navigation.NavigateTo<Dashboard1ViewModel>();
        }
    }
}
