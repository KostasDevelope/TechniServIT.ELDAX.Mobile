using System.Threading.Tasks;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Models;
using apiClient = TechniServIT.ELDAX.Mobile.WebApi.Service.ApiClient;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Services
{
    public interface IAccountService
    {
        Task<WebApiResultT<AuthenticationContext>> Login(string userName, string password);

        Task<WebApiResultT<AuthenticationContext>> AuthenticateEx(string userName, string password);
    }

    public class AccountService : BaseService, IAccountService
    {
        private const string urlApi = "api/account/";

        public AccountService(apiClient.ApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<WebApiResultT<AuthenticationContext>> Login(string userName, string password)
        {
            var inputDto = new
            {
                UserName = userName,
                Password = password
            };
            var model = await _apiClient.PostAsync<AuthenticationContext>($"{urlApi}login", inputDto, null, GetHeaders);
           
            return model;
        }

        public async Task<WebApiResultT<AuthenticationContext>> AuthenticateEx(string userName, string password)
        {
            var headers = GetHeaders;
            headers.Add(AuthenticationContextConstants.Login, userName);
            headers.Add(AuthenticationContextConstants.Password, password);

            var model = await _apiClient.PostAsync<AuthenticationContext>($"{urlApi}authenticate/", headers);
                        
            return model;
        }
    }
}