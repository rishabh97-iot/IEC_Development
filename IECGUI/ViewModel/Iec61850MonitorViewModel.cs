using IEC.Shared.IECInterface;
using IEC.Shared.IECModels;
using IEC.Shared.IECServices;
using IECGUI.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace IECGUI.ViewModel
{
    public class Iec61850MonitorViewModel : BaseViewModel
    {
        private readonly IIec61850MeterService _service;
        private readonly INavigationService _navigation;
        private readonly IecConfigManagerService _configManager;

        // ── readonly nahi — InitializeAsync mein assign hoga ──
        private DispatcherTimer _pollTimer;

        // ── Connection Status ──────────────────────────────────
        private bool _isOnline;
        public bool IsOnline
        {
            get => _isOnline;
            set { _isOnline = value; OnPropertyChanged(); }
        }

        private string _statusMessage = "Disconnected";
        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        // ── Multi Relay Readings ───────────────────────────────
        public ObservableCollection<RelayReadingModel> RelayReadings { get; }
            = new ObservableCollection<RelayReadingModel>();

        // ── Commands ───────────────────────────────────────────
        public ICommand BackCommand { get; }

        public ICommand ConfigurationCommand { get; }
        public Iec61850MonitorViewModel(
            INavigationService navigation,
            IIec61850MeterService service,
            IecConfigManagerService configManager)
        {
            _navigation = navigation;
            _service = service;
            _configManager = configManager;

            BackCommand = new RelayCommand(() =>
                _navigation.NavigateTo<EnergyMonitorViewModel2>());

            ConfigurationCommand = new RelayCommand(NavigateToConfigView);

            // Async init — constructor se fire karo
            _ = InitializeAsync();
        }

        private void NavigateToConfigView()
        {             _navigation.NavigateTo<IecConfigViewModel>();
        }
        private async Task InitializeAsync()
        {
            try
            {
                // Config load karo
                var config = _configManager.Load();

                if (!config.Relays.Any())
                {
                    config.Relays.Add(IecDefaultConfig.GetDefault());
                    _configManager.Save(config);
                }

                StatusMessage = "Connecting to relays...";

                // Sab relays connect karo
                await _service.ConnectAllAsync(config.Relays);

                IsOnline = true;
                StatusMessage = $"Connected — {config.Relays.Count(r => r.IsEnabled)} relay(s)";

                // Polling start — sabse chhota interval use karo
                _pollTimer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(
                        config.Relays.Min(r => r.PollIntervalMs))
                };
                _pollTimer.Tick += async (s, e) => await PollAsync();
                _pollTimer.Start();
            }
            catch (Exception ex)
            {
                IsOnline = false;
                StatusMessage = $"Init Failed: {ex.Message}";
            }
        }

        private async Task PollAsync()
        {
            try
            {
                var results = await _service.ReadAllAsync();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    RelayReadings.Clear();

                    foreach (var reading in results.Values)
                        RelayReadings.Add(reading);

                    IsOnline = results.Values.Any(r => r.IsOnline);
                    StatusMessage = IsOnline ? "Live" : "Connection Lost";
                });
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    IsOnline = false;
                    StatusMessage = $"Poll Error: {ex.Message}";
                });
            }
        }

        public void Cleanup()
        {
            _pollTimer?.Stop();
            _service?.Disconnect();
        }
    }
}