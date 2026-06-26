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

        public ICommand BCBRKOPEN { get; set; }

        public ICommand OUTBRK1OPEN { get; set; }
        public ICommand OUTBRK2OPEN { get; set; }

        public ICommand OUTBRK3OPEN { get; set; }
        public ICommand OUTBRK4OPEN { get; set; }
        public ICommand OUTBRK5OPEN { get; set; }
        public ICommand OUTBRK6OPEN { get; set; }

        public ICommand OUTBRK7OPEN { get; set; }
        public ICommand OUTBRK8OPEN { get; set; }

        public ICommand OUTBRK9OPEN { get; set; }


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

        private Visibility _breakerstatusclose10;
        public Visibility breakerstatusclose10
        {
            get => _breakerstatusclose10;
            set => SetProperty(ref _breakerstatusclose10, value);
        }

        private Visibility _breakerstatusclose11;
        public Visibility breakerstatusclose11
        {
            get => _breakerstatusclose11;
            set => SetProperty(ref _breakerstatusclose11, value);
        }

        private Visibility _breakerstatusclose12;

        public Visibility breakerstatusclose12
        {
            get => _breakerstatusclose12;
            set => SetProperty(ref _breakerstatusclose12, value);
        }

        private Visibility _breakerstatusclose13;
        public Visibility breakerstatusclose13
        {   get => _breakerstatusclose13;
            set => SetProperty(ref _breakerstatusclose13, value);
        }

        private Visibility _breakerstatusclose14;
        public Visibility breakerstatusclose14
        {
            get => _breakerstatusclose14;
            set => SetProperty(ref _breakerstatusclose14, value);
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


        private Visibility _breakerstatusopen10;
        public Visibility breakerstatusopen10
        {
            get => _breakerstatusopen10;
            set => SetProperty(ref _breakerstatusopen10, value);
        }


        private Visibility _breakerstatusopen11;
        public Visibility breakerstatusopen11
        {
            get => _breakerstatusopen11;
            set => SetProperty(ref _breakerstatusopen11, value);
        }

        private Visibility _breakerstatusopen12;
        public Visibility breakerstatusopen12
        {
            get => _breakerstatusopen12; 
            set => SetProperty(ref _breakerstatusopen12, value);
        }



        private Visibility _breakerstatusopen13;
        public Visibility breakerstatusopen13
        {
            get => _breakerstatusopen13;
            set => SetProperty(ref _breakerstatusopen13, value);
        }


        private Visibility _breakerstatusopen14;
        public Visibility breakerstatusopen14
        {
            get => _breakerstatusopen14;
            set => SetProperty(ref _breakerstatusopen14, value);
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
        private bool _status10 = false;
        private bool _status11 = false;
        private bool _status12 = false;
        private bool _status13 = false;
        private bool _status14 = false;


        public Dashboard1ViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            EventsCommand = new RelayCommand(OpenRelayCard);
            HomeCommand = new RelayCommand(() => _navigation.NavigateTo( new EnergyMonitorViewModel(_navigation))); //_navigation.NavigateTo(new Dashboard1ViewModel(_navigation));
            AlarmCommand = new RelayCommand(() => _navigation.NavigateTo(new EnergyMonitorViewModel2(_navigation)));
            // TrendingCommand = new RelayCommand(() => _navigation.NavigateTo<TrendingViewModel>());
            // ReportsCommand = new RelayCommand(() => _navigation.NavigateTo<ReportsViewModel>());

            OUTBRK1OPEN = new RelayCommand(OUTBRK1OPEN_Execute);
            OUTBRK2OPEN = new RelayCommand(OUTBRK2OPEN_Execute);
            OUTBRK3OPEN = new RelayCommand(OUTBRK3OPEN_Execute);
            OUTBRK4OPEN = new RelayCommand(OUTBRK4OPEN_Execute);
            OUTBRK5OPEN = new RelayCommand(OUTBRK5OPEN_Execute);
            OUTBRK6OPEN = new RelayCommand(OUTBRK6OPEN_Execute);
            OUTBRK7OPEN = new RelayCommand(OUTBRK7OPEN_Execute);
            OUTBRK8OPEN = new RelayCommand(OUTBRK8OPEN_Execute);
            OUTBRK9OPEN = new RelayCommand(OUTBRK9OPEN_Execute);

            INCBRK1OPEN = new RelayCommand(INCBRK10OPEN_Execute);
            INCBRK2OPEN = new RelayCommand(INCBRK20OPEN_Execute);
            INCBRK3OPEN = new RelayCommand(INCBRK30OPEN_Execute);
            BCBRKOPEN = new RelayCommand(BCBRK30OPEN_Execute);

            breakerstatusclose1 = Visibility.Hidden;
            breakerstatusclose2 = Visibility.Hidden;
            breakerstatusclose3 = Visibility.Hidden;
            breakerstatusclose4 = Visibility.Hidden;
            breakerstatusclose5 = Visibility.Hidden;
            breakerstatusclose6 = Visibility.Hidden;
            breakerstatusclose7 = Visibility.Hidden;
            breakerstatusclose8 = Visibility.Hidden;
            breakerstatusclose9 = Visibility.Hidden;
            breakerstatusclose10 = Visibility.Hidden;
            breakerstatusclose11 = Visibility.Hidden;
            breakerstatusclose12 = Visibility.Hidden;
            breakerstatusclose13 = Visibility.Hidden;



        }

        public void OpenRelayCard()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var win = new IECGUI.View.RelayCard();
                win.DataContext = new IECGUI.ViewModel.RelayCardViewModel(win, _navigation);
                win.ShowDialog();
            });

        }
        public void ExecuteEvents()
        {

        }

        public void OUTBRK1OPEN_Execute()
        {
            _status1 = !_status1;
            breakerstatusopen1 = !_status1 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose1 = _status1 ? Visibility.Visible : Visibility.Hidden;
        }
        public void OUTBRK2OPEN_Execute()
        {
            _status2 = !_status2;
            breakerstatusopen2 = !_status2 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose2 = _status2 ? Visibility.Visible : Visibility.Hidden;
        }

        public void OUTBRK3OPEN_Execute()
        {
            _status3 = !_status3;
            breakerstatusopen3 = !_status3 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose3 = _status3 ? Visibility.Visible : Visibility.Hidden;
        }
        public void OUTBRK4OPEN_Execute()
        {
            _status4 = !_status4;
            breakerstatusopen4 = !_status4 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose4 = _status4 ? Visibility.Visible : Visibility.Hidden;
        }

        public void OUTBRK5OPEN_Execute()
        {
            _status5 = !_status5;
            breakerstatusopen5 = !_status5 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose5 = _status5 ? Visibility.Visible : Visibility.Hidden;
        }
        public void OUTBRK6OPEN_Execute()
        {
            _status6 = !_status6;
            breakerstatusopen6 = !_status6 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose6 = _status6 ? Visibility.Visible : Visibility.Hidden;
        }
        public void OUTBRK7OPEN_Execute()
        {
            _status7 = !_status7;
            breakerstatusopen7 = !_status7 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose7 = _status7 ? Visibility.Visible : Visibility.Hidden;
        }
        public void OUTBRK8OPEN_Execute()
        {
            _status8 = !_status8;
            breakerstatusopen8 = !_status8 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose8 = _status8 ? Visibility.Visible : Visibility.Hidden;
        }
        public void OUTBRK9OPEN_Execute()
        {
            _status9 = !_status9;
            breakerstatusopen9 = !_status9 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose9 = _status9 ? Visibility.Visible : Visibility.Hidden;
        }

        public void INCBRK10OPEN_Execute()
        {
            _status10 = !_status10;
            breakerstatusopen10 = !_status10 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose10 = _status10 ? Visibility.Visible : Visibility.Hidden;
        }

        public void INCBRK20OPEN_Execute()
        {
            _status11 = !_status11;
            breakerstatusopen11 = !_status11 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose11 = _status11 ? Visibility.Visible : Visibility.Hidden;
        }

        public void INCBRK30OPEN_Execute()
        {
            _status12 = !_status12;
            breakerstatusopen12 = !_status12 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose12 = _status12 ? Visibility.Visible : Visibility.Hidden;
        }

        public void BCBRK30OPEN_Execute()
        {
            _status13 = !_status13;
            breakerstatusopen13 = !_status13 ? Visibility.Visible : Visibility.Hidden;
            breakerstatusclose13 = _status13 ? Visibility.Visible : Visibility.Hidden;
        }


    }
}
