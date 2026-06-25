using IECGUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IECGUI.ViewModel
{
    public class HomePageViewModel :BaseViewModel
    {
        private readonly INavigationService _navigation;
        public HomePageViewModel(INavigationService navigation)
        {
            _navigation = navigation;
        }
    }
}
