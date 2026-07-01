using IEC.Shared.Models;
using IEC.Shared.Services;
using IECGUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IECGUI.ViewModel
{
    public class ConfigurationViewModel : BaseViewModel
    {
        private readonly ConfigurationManagerService _config;

        private readonly INavigationService _navigation;

        private MetersConfig _selectedMeter;

        public MetersConfig SelectedMeter
        {
            get => _selectedMeter;
            set => SetProperty(ref _selectedMeter, value);
        }

        public ObservableCollection<MetersConfig> Meters { get; }

        public ICommand MenuCommand { get; }

        public ICommand AddMeterCommand { get; }
        public ICommand DeleteMeterCommand { get; }
        public ICommand SaveCommand { get; }

        public ConfigurationViewModel(INavigationService navigation, ConfigurationManagerService config)
        {
            _config =config;
            _navigation = navigation;
            Meters = new ObservableCollection<MetersConfig>(
                _config.Configuration.Meters);

            AddMeterCommand =
                new RelayCommand(AddMeter);

            DeleteMeterCommand =
                new RelayCommand(DeleteMeter);

            SaveCommand =
                new RelayCommand(Save);

            MenuCommand = new RelayCommand(() => _navigation.NavigateTo<HomePageViewModel>());
        }





        private void AddMeter()
        {
            var meter = new MetersConfig()
            {
                MeterId = Meters.Count + 1,
                MeterName = $"Meter-{Meters.Count + 1}",
                Communication = new CommunicationConfig() { ComPort = "COM6", BaudRate = 19200, DataBits = 8, Parity = "Even", SlaveId = 10, StopBits = 1 }



            };

            Meters.Add(meter);

            SelectedMeter = meter;
        }


        private void DeleteMeter()
        {
            if (SelectedMeter == null)
                return;

            Meters.Remove(SelectedMeter);
        }

        private void Save()
        {
            _config.Configuration.Meters.Clear();

            foreach (var meter in Meters)
                _config.Configuration.Meters.Add(meter);

            _config.Save();
        }







    }
}
