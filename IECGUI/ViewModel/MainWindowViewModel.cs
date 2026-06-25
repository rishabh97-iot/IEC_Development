using IECGUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IECGUI.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private object _currentView;

        public INavigationService Navigation { get; set; }
        public ICommand CloseAppCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        private readonly INavigationService _navigation;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            
            CloseAppCommand = new RelayCommand(ExecuteCloseApp);

            LogoutCommand = new RelayCommand(ExecuteLogout);

            Navigation = new NavigationService();

            Navigation.NavigateTo(new  LoginViewModel(Navigation));
            
        }

        private void ExecuteCloseApp()
        {
          if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
          {
              System.Windows.Application.Current.Shutdown();
          }
        }

        private void ExecuteLogout() 
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Navigation.NavigateTo(new LoginViewModel(Navigation));
            }
        }

    }
}
