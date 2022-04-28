using ELDAXService;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Net;
using System.ServiceModel;
using TechniServIT.ELDAX.Mobile.Eldax.Service.Services;

namespace TechniServIT.ELDAX.Mobile.Eldax.Service
{
    public class ServiceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ELDAXServiceClient>(() =>
            {
                var binding = new BasicHttpBinding();

                binding.Name = "binding1";
                binding.CloseTimeout = TimeSpan.FromMinutes(5);
                binding.OpenTimeout = TimeSpan.FromMinutes(5);
                binding.ReceiveTimeout = TimeSpan.FromMinutes(5);
                binding.SendTimeout = TimeSpan.FromMinutes(10);
                binding.MaxBufferSize = 2147483647;
                binding.MaxReceivedMessageSize = 2147483647;
                binding.Security.Mode = BasicHttpSecurityMode.Transport;

                var client = new ELDAXServiceClient(binding, new EndpointAddress("https://192.168.52.31/ELDAX/Service"));

                ServicePointManager.ServerCertificateValidationCallback +=
                      (sender, cert, chain, sslPolicyErrors) => true;

                return client;
            });

            containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
        }
    }
}