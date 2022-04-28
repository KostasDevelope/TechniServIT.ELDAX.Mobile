using ELDAXService;
using System;
using System.Threading.Tasks;

namespace TechniServIT.ELDAX.Mobile.Eldax.Service.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationContext> CreateAuthenticationContextAsync(string userLogin, string hashedData);
        Task<bool> IsAuthenticatedAsync(AuthenticationContext ctx);
        Task<AuthenticationContext> AuthenticateExAsync(string userLogin, string password);
    }

    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public AuthenticationService(ELDAXServiceClient eLDAXServiceClient) : base(eLDAXServiceClient)
        {
        }

        public async Task<AuthenticationContext> CreateAuthenticationContextAsync(string userLogin, string hashedData)
        {
            var ctx = GetAuthenticationContext;

            try
            {
                ctx.UserLogin = userLogin;
                ctx.HashedData = hashedData;
                ctx = await _client.AuthenticateExAsync(ctx);
            }
            catch (Exception ex)
            {
            }

            return ctx;
        }

        public async Task<AuthenticationContext> AuthenticateExAsync(string userLogin, string password)
        {
            var ctx = GetAuthenticationContext;

            try
            {
                ctx.ApplicationLogin = userLogin;
                ctx.UserLogin = userLogin;
                ctx.Password = password;
                ctx =  _client.AuthenticateEx(ctx);
            }
            catch (Exception ex)
            {
            }

            return ctx;
        }

        public async Task<bool> IsAuthenticatedAsync(AuthenticationContext ctx)
        {
            var data = await _client.IsAuthenticatedAsync(ctx);
            return data;
        }

        protected AuthenticationContext GetAuthenticationContext
        {
            get
            {
                var ctx = new AuthenticationContext();
                ctx.AuthenticationType = AuthenticationType.Classic;
                ctx.ClientVersion = $"{(int)ClientVersion.Major}.{(int)ClientVersion.Minor}.{(int)ClientVersion.Build}";
                ctx.CultureCode = "cs-CZ";
                ctx.TimeZoneId = "Central Europe Standard Time";
                ctx.IPAddress = "127.0.0.1";
                ctx.InstanceName = "TechniServIT.ELDAX.Mobile";

                return ctx;
            }
        }
    }
}