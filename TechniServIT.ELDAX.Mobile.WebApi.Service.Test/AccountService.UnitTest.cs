using NUnit.Framework;
using System.Threading.Tasks;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Services;
using service = TechniServIT.ELDAX.Mobile.WebApi.Service.ApiClient;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Test
{
    public class AccountServiceTests
    {
        private IAccountService _accountService;

        [SetUp]
        public void Setup()
        {
            //var url = "http://localhost:3800/";
            var url = "https://212.47.6.57:14443/";
            var apiUrlConfig = new service.ApiUrlConfig(url);
            var client = new service.ApiClient(apiUrlConfig);
            _accountService = new AccountService(client);
        }

        [Test]
        public async Task AuthenticateExTestAsync()
        {
            var result = await _accountService.AuthenticateEx("sa", "123");
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task LoginTestAsync()
        {
            var result = await _accountService.Login("sa", "123");
            Assert.IsNotNull(result);
        }
    }
}