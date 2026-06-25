using IECGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IECGUI.Services
{
    public interface INavigationService
    {
        BaseViewModel CurrentViewModel { get; set; }

        void NavigateTo(BaseViewModel viewModel);
    }
}
