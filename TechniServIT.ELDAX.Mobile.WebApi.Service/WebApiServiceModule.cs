using Prism.Ioc;
using Prism.Modularity;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Services;
using service = TechniServIT.ELDAX.Mobile.WebApi.Service.ApiClient;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service
{
    //[ModuleDependency("TechniServIT.ELDAX.Mobile.Eldax.Common.CommonModule")]
    public class WebApiServiceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<service.ApiClient>(() =>
            {
                //var url = "http://localhost:3800/";
                var url = "https://212.47.6.57:14443/";
                var apiUrlConfig = new service.ApiUrlConfig(url);
                var client = new service.ApiClient(apiUrlConfig);
                return client;
            });
            containerRegistry.RegisterSingleton<IAccountService, AccountService>();
            containerRegistry.RegisterSingleton<IChartsOperationsService, ChartsOperationsService>();
        }
    }
}