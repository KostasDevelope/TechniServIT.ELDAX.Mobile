using Flurl.Http.Configuration;
using System.Net.Http;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Services
{
    public class UntrustedCertClientFactory : DefaultHttpClientFactory
    {
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (a, b, c, d) => true
            };
        }
    }
}