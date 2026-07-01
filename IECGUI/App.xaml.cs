using IEC.Shared.Services;
using IECGUI.Services;
using IECGUI.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace IECGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            // Services
            services.AddSingleton<IEnergyMeterService, EnergyMeterService>();
            services.AddSingleton<IMultiEnergyMeterService, MultiEnergyMeterService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<ConfigurationManagerService>();

            // ViewModels
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<Dashboard1ViewModel>();
            services.AddTransient<EnergyMonitorViewModel>();
            services.AddTransient<EnergyMonitorViewModel2>();            
            services.AddSingleton<ConfigurationViewModel>();
            services.AddSingleton<HomePageViewModel>();
            // Views
            services.AddTransient<MainWindow>();

            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
