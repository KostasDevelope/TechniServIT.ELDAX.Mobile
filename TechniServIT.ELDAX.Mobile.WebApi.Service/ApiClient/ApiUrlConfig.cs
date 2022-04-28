using System;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.ApiClient
{
    public class ApiUrlConfig
    {
        private string _baseUrl;
        public ApiUrlConfig(string baseUrl)
        {
            _baseUrl = NormalizeUrl(baseUrl);
        }

        public string GetBaseUrl { get => _baseUrl; }

        private string NormalizeUrl(string baseUrl)
        {
            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var uriResult) ||
                (uriResult.Scheme != "http" && uriResult.Scheme != "https"))
            {
                throw new ArgumentException("Unexpected base URL: " + baseUrl);
            }

            return $"{uriResult}/";
        }
    }
}