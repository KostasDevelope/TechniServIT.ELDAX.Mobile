using System.Collections.Generic;
using TechniServIT.ELDAX.Mobile.Eldax.Common.Services;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Helpers;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Models;
using apiClient = TechniServIT.ELDAX.Mobile.WebApi.Service.ApiClient;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Services
{
    public class BaseService
    {
        protected readonly apiClient.ApiClient _apiClient;

        public BaseService(apiClient.ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        protected AuthenticationContext _authenticationContext
        {
            get => ApplicationPropertiesService.GetPropertyJson<AuthenticationContext>("AuthenticationContext");
            set => ApplicationPropertiesService.SetPropertyJson("AuthenticationContext", value);
        }

        protected Dictionary<string, string> GetHeadersFromStore
        {
            get
            {
                Dictionary<string, string> headers = null;
                if (_authenticationContext != null)
                {
                    headers.Add(AuthenticationContextConstants.Accept, "application/json");
                    headers.Add(AuthenticationContextConstants.UserAgent, "AbpApiClient");
                    headers.Add(AuthenticationContextConstants.ClientVersion, _authenticationContext.ClientVersion);
                    headers.Add(AuthenticationContextConstants.Type, _authenticationContext.AuthenticationType);
                    headers.Add(AuthenticationContextConstants.Culture, _authenticationContext.CultureCode);
                    headers.Add(AuthenticationContextConstants.TimeZoneId, _authenticationContext.TimeZoneId);
                    headers.Add(AuthenticationContextConstants.IpAddress, _authenticationContext.IpAddress);
                    headers.Add(AuthenticationContextConstants.InstanceName, "TechniServIT.ELDAX.Mobile");
                    headers.Add(AuthenticationContextConstants.Login, _authenticationContext.UserLogin);
                    headers.Add(AuthenticationContextConstants.Password, _authenticationContext.Password);
                    headers.Add(AuthenticationContextConstants.Token, _authenticationContext.Token);
                }
                else headers = GetHeaders;
                return headers;
            }
        }

        protected Dictionary<string, string> GetHeaders
        {
            get
            {
                var headers = new Dictionary<string, string>();

                headers = new Dictionary<string, string>();
                headers.Add(AuthenticationContextConstants.Accept, "application/json");
                headers.Add(AuthenticationContextConstants.UserAgent, "AbpApiClient");
                headers.Add(AuthenticationContextConstants.ClientVersion, ClientVersionHelper.GetClientVersion());
                headers.Add(AuthenticationContextConstants.Type, "Classic");
                headers.Add(AuthenticationContextConstants.Culture, "cs-CZ");
                headers.Add(AuthenticationContextConstants.TimeZoneId, "Central Europe Standard Time");
                headers.Add(AuthenticationContextConstants.IpAddress, "127.0.0.1");
                headers.Add(AuthenticationContextConstants.InstanceName, "TechniServIT.ELDAX.Mobile");

                return headers;
            }
        }

        protected void SaveAuthenticationContext(AuthenticationContext authenticationContext)
        {
            var headers = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(authenticationContext.ClientVersion))
                headers.Add(AuthenticationContextConstants.ClientVersion, authenticationContext.ClientVersion);

            if (!string.IsNullOrWhiteSpace(authenticationContext.AuthenticationType))
                headers.Add(AuthenticationContextConstants.AuthenticationType, authenticationContext.AuthenticationType);

            if (!string.IsNullOrWhiteSpace(authenticationContext.CultureCode))
                headers.Add(AuthenticationContextConstants.Culture, authenticationContext.CultureCode);

            if (!string.IsNullOrWhiteSpace(authenticationContext.TimeZoneId))
                headers.Add(AuthenticationContextConstants.TimeZoneId, authenticationContext.TimeZoneId);

            if (!string.IsNullOrWhiteSpace(authenticationContext.IpAddress))
                headers.Add(AuthenticationContextConstants.IpAddress, authenticationContext.IpAddress);

            if (!string.IsNullOrWhiteSpace(authenticationContext.UserLogin))
                headers.Add(AuthenticationContextConstants.Login, authenticationContext.UserLogin);

            if (!string.IsNullOrWhiteSpace(authenticationContext.Password))
                headers.Add(AuthenticationContextConstants.Password, authenticationContext.Password);

            if (!string.IsNullOrWhiteSpace(authenticationContext.Token))
                headers.Add(AuthenticationContextConstants.Token, authenticationContext.Token);

            headers.Add(AuthenticationContextConstants.InstanceName, "TechniServIT.ELDAX.Mobile");
        }
    }
}