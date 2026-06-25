using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IECGUI.ViewModel;
using IECGUI.Services;
using System.Windows.Input;
using System.Windows;

namespace IECGUI.ViewModel
{
    public class Dashboard1ViewModel : BaseViewModel
    {
        private readonly INavigationService _navigation;
        public ICommand EventsCommand { get; }

        public ICommand HomeCommand { get; }

        public ICommand AlarmCommand { get; }

        public ICommand TrendingCommand { get; }

        public ICommand ReportsCommand { get; }

        public ICommand INCBRK1OPEN { get; set; }
        public ICommand INCBRK2OPEN { get; set; }

        public ICommand INCBRK3OPEN { get; set; }
        public ICommand INCBRK4OPEN { get; set; }
        public ICommand INCBRK5OPEN { get; set; }
        public ICommand INCBRK6OPEN { get; set; }

        public ICommand INCBRK7OPEN { get; set; }
        public ICommand INCBRK8OPEN { get; set; }

        public ICommand INCBRK9OPEN { get; set; }


        //Breaker Status Close
        private Visibility _breakerstatusclose1;
        public Visibility breakerstatusclose1
        {
            get => _breakerstatusclose1;
            set => SetProperty(ref _breakerstatusclose1, value);
        }

        private Visibility _breakerstatusclose2;
        public Visibility breakerstatusclose2
        {
            get => _breakerstatusclose2;
            set => SetProperty(ref _breakerstatusclose2, value);
        }
        private Visibility _breakerstatusclose3;
        public Visibility breakerstatusclose3
        {
            get => _breakerstatusclose3;
            set => SetProperty(ref _breakerstatusclose3, value);
        }

        private Visibility _breakerstatusclose4;
        public Visibility breakerstatusclose4
        {
            get => _breakerstatusclose4;
            set => SetProperty(ref _breakerstatusclose4, value);
        }

        private Visibility _breakerstatusclose5;
        public Visibility breakerstatusclose5
        {
            get => _breakerstatusclose5;
            set => SetProperty(ref _breakerstatusclose5, value);
        }

        private Visibility _breakerstatusclose6;
        public Visibility breakerstatusclose6
        {
            get => _breakerstatusclose6;
            set => SetProperty(ref _breakerstatusclose6, value);
        }
        private Visibility _breakerstatusclose7;
        public Visibility breakerstatusclose7
        {
            get => _breakerstatusclose7;
            set => SetProperty(ref _breakerstatusclose7, value);
        }

        private Visibility _breakerstatusclose8;
        public Visibility breakerstatusclose8
        {
            get => _breakerstatusclose8;
            set => SetProperty(ref _breakerstatusclose8, value);
        }

        private Visibility _breakerstatusclose9;
        public Visibility breakerstatusclose9
        {
            get => _breakerstatusclose9;
            set => SetProperty(ref _breakerstatusclose9, value);
        }


        // Braker Status Open

        private Visibility _breakerstatusopen1;

        public Visibility breakerstatusopen1
        {
            get => _breakerstatusopen1;
            set => SetProperty(ref _breakerstatusopen1, value)   ;
        }

        private Visibility _breakerstatusopen2;

        public Visibility breakerstatusopen2
        {
            get => _breakerstatusopen2;
            set => SetProperty(ref _breakerstatusopen2, value);
        }

        private Visibility _breakerstatusopen3;

        public Visibility breakerstatusopen3
        {
            get => _breakerstatusopen3;
            set => SetProperty(ref _breakerstatusopen3, value);
        }

        private Visibility _breakerstatusopen4;

        public Visibility breakerstatusopen4
        {
            get => _breakerstatusopen4;
            set => SetProperty(ref _breakerstatusopen4, value);
        }


        private Visibility _breakerstatusopen5;

        public Visibility breakerstatusopen5
        {
            get => _breakerstatusopen5;
            set => SetProperty(ref _breakerstatusopen5, value);
        }

        private Visibility _breakerstatusopen6;

        public Visibility breakerstatusopen6
        {
            get => _breakerstatusopen6;
            set => SetProperty(ref _breakerstatusopen6, value);
        }

        private Visibility _breakerstatusopen7;
        public Visibility breakerstatusopen7
        {
            get => _breakerstatusopen7;
            set => SetProperty(ref _breakerstatusopen7, value);
        }

        private Visibility _breakerstatusopen8;
        public Visibility breakerstatusopen8
        {
            get => _breakerstatusopen8;
            set => SetProperty(ref _breakerstatusopen8, value);
        }


        private Visibility _breakerstatusopen9;
        public Visibility breakerstatusopen9
        {
            get => _breakerstatusopen9;
            set => SetProperty(ref _breakerstatusopen9, value);
        }

        private bool _status1 =false;
        private bool _status2 = false;
        private bool _status3 = false;
        private bool _status4 = false;
        private bool _status5 = false;
        private bool _status6 = false;
        private bool _status7 = false;
        private bool _status8 = false;
        private bool _status9 = false;
       
        public Dashboard1ViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            EventsCommand = new RelayCommand(ExecuteEvents);
            HomeCommand = new RelayCommand(() => _navigation.NavigateTo( new EnergyMonitorViewModel(_navigation))); //_navigation.NavigateTo(new Dashboard1ViewModel(_navigation));
            AlarmCommand = new RelayCommand(() => _navigation.NavigateTo(new EnergyMonitorViewModel2(_navigation)));
            // TrendingCommand = new RelayCommand(() => _navigation.NavigateTo<TrendingViewModel>());
            // ReportsCommand = new RelayCommand(() => _navigation.NavigateTo<ReportsViewModel>());

            INCBRK1OPEN = new RelayCommand(INCBRK1OPEN_Execute);
            INCBRK2OPEN = new RelayCommand(INCBRK2OPEN_Execute);
            INCBRK3OPEN = new RelayCommand(INCBRK3OPEN_Execute);
            INCBRK4OPEN = new RelayCommand(INCBRK4OPEN_Execute);
            INCBRK5OPEN = new RelayCommand(INCBRK5OPEN_Execute);
            INCBRK6OPEN = new RelayCommand(INCBRK6OPEN_Execute);
            INCBRK7OPEN = new RelayCommand(INCBRK7OPEN_Execute);
            INCBRK8OPEN = new RelayCommand(INCBRK8OPEN_Execute);
            INCBRK9OPEN = new RelayCommand(INCBRK9OPEN_Execute);
        }

        public void ExecuteEvents()
        {

        }

        public void INCBRK1OPEN_Execute()
        {
            _status1 = !_status1;
            breakerstatusopen1 = _status1 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose1 = !_status1 ? Visibility.Visible : Visibility.Hidden;
        }
        public void INCBRK2OPEN_Execute()
        {
            _status2 = !_status2;
            breakerstatusopen2 = _status2 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose2 = !_status2 ? Visibility.Visible : Visibility.Hidden;
        }

        public void INCBRK3OPEN_Execute()
        {
            _status3 = !_status3;
            breakerstatusopen3 = _status3 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose3 = !_status3 ? Visibility.Visible : Visibility.Hidden;
        }
        public void INCBRK4OPEN_Execute()
        {
            _status4 = !_status4;
            breakerstatusopen4 = _status4 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose4 = !_status4 ? Visibility.Visible : Visibility.Hidden;
        }

        public void INCBRK5OPEN_Execute()
        {
            _status5 = !_status5;
            breakerstatusopen5 = _status5 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose5 = !_status5 ? Visibility.Visible : Visibility.Hidden;
        }
        public void INCBRK6OPEN_Execute()
        {
            _status6 = !_status6;
            breakerstatusopen6 = _status6 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose6 = !_status6 ? Visibility.Visible : Visibility.Hidden;
        }
        public void INCBRK7OPEN_Execute()
        {
            _status7 = !_status7;
            breakerstatusopen7 = _status7 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose7 = !_status7 ? Visibility.Visible : Visibility.Hidden;
        }
        public void INCBRK8OPEN_Execute()
        {
            _status8 = !_status8;
            breakerstatusopen8 = _status8 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose8 = !_status8 ? Visibility.Visible : Visibility.Hidden;
        }
        public void INCBRK9OPEN_Execute()
        {
            _status9 = !_status9;
            breakerstatusopen9 = _status9 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose9 = !_status9 ? Visibility.Visible : Visibility.Hidden;
        }



    }
}
