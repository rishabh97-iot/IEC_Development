using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IECGUI.ViewModel;

namespace IECGUI.Services
{
    public class NavigationService : BaseViewModel, INavigationService 
    {
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public void NavigateTo(BaseViewModel viewModel) 
        {
            CurrentViewModel = viewModel;
        }
    }
}
