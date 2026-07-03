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

        private RegisterConfig _selectedRegister;

        public RegisterConfig SelectedRegister
        {
            get => _selectedRegister;
            set => SetProperty(ref _selectedRegister, value);
        }

        public ObservableCollection<RegisterConfig> Registers => SelectedMeter?.Registers;

        public ObservableCollection<MetersConfig> Meters { get; }

        public ICommand MenuCommand { get; }

        public ICommand AddMeterCommand { get; }
        public ICommand DeleteMeterCommand { get; }
        public ICommand SaveCommand { get; }

        public ICommand AddRegisterCommand { get; }
        public ICommand DeleteRegisterCommand { get; }

        public ICommand EditRegisterCommand { get; }

        public ICommand SaveRegisterCommand { get; }

        public ObservableCollection<string> DataTypes { get; } = new() { "Float", "Int16", "UInt16", "Int32", "UInt32", "Double" };

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


            //Register mapping Tab commands->

            AddRegisterCommand = new RelayCommand(AddRegister);

            DeleteRegisterCommand = new RelayCommand(DeleteRegister);
                  

            MenuCommand = new RelayCommand(() => _navigation.NavigateTo<HomePageViewModel>());
        }




        // Add Communincation Confiuration//
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

        //Add Register Mapping//

        private void AddRegister()
        {
            if (SelectedMeter == null)
                return;

            var reg = new RegisterConfig()
            {
                ParameterName = "Voltage A-N",
                RegisterAddress = 40001,
                DataType = "Float",
                Unit = "V",
                ScaleFactor = 1,
                Length = 2,
                IsEnabled = true
            };

            SelectedMeter.Registers.Add(reg);

            SelectedRegister = reg;
        }

        private void DeleteRegister()
        {
            if (SelectedRegister == null)
                return;

            SelectedMeter.Registers.Remove(SelectedRegister);
        }





    }
}
