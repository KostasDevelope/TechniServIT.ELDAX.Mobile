using Prism.Ioc;
using Prism.Modularity;
using TechniServIT.ELDAX.Mobile.Commands;
using TechniServIT.ELDAX.Mobile.ViewModels;
using TechniServIT.ELDAX.Mobile.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace TechniServIT.ELDAX.Mobile
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MasterDetailPageEldax, MasterDetailPageEldaxViewModel>();
            containerRegistry.RegisterForNavigation<DashboardPage, DashboardPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
            containerRegistry.RegisterForNavigation<RadMapPage, RadMapPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MonkeyPage, MonkeyPageViewModel>();

            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();

        }
    }
}