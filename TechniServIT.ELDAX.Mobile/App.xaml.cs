using Prism;
using Prism.Ioc;
using Prism.Modularity;
using System;
using TechniServIT.ELDAX.Mobile.Eldax.Common;
using TechniServIT.ELDAX.Mobile.Eldax.Common.Services;
using TechniServIT.ELDAX.Mobile.WebApi.Service;

namespace TechniServIT.ELDAX.Mobile
{
    public partial class App
    {
        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var result = await NavigationService.NavigateAsync($"MasterDetailPageEldax/NavigationPage/DashboardPage");
            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var key = "DateTimeNow";
            if (!ApplicationPropertiesService.IsValue(key))
                ApplicationPropertiesService.SetProperty(key,
                    value: DateTime.Now);
            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<WebApiServiceModule>();
            moduleCatalog.AddModule<CommonModule>();
            moduleCatalog.AddModule<MainModule>();
        }
    }
}

//  xmlns:local="clr-namespace:TechniServIT.ELDAX.Mobile.Extensions"