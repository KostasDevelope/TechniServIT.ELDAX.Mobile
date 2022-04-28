using Flurl.Http;
using Flurl.Http.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Models;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Services;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Helpers;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.ApiClient
{
    public class ApiClient : IApiClient, IDisposable
    {
        private FlurlClient _client;
        private readonly ApiUrlConfig _apiUrlConfig;
        public static int? TimeoutSeconds { get; set; } = 100;

        public void Dispose()
        {
            _client?.Dispose();
        }

        public ApiClient(ApiUrlConfig apiUrlConfig)
        {
            _apiUrlConfig = apiUrlConfig;
        }

        #region PostAsync<T>

        public async Task<WebApiResultT<T>> PostAsync<T>(string endpoint)
        {
            return await PostAsync<T>(endpoint, null, null, null);
        }

        public async Task<WebApiResultT<T>> PostAnonymousAsync<T>(string endpoint)
        {
            return await PostAsync<T>(endpoint, null, null, null);
        }

        public async Task<WebApiResultT<T>> PostAsync<T>(string endpoint, object inputDto)
        {
            return await PostAsync<T>(endpoint, inputDto, null, null);
        }

        public async Task<WebApiResultT<T>> PostAsync<T>(string endpoint, object inputDto, object queryParameters)
        {
            return await PostAsync<T>(endpoint, inputDto, queryParameters, null);
        }

        public async Task<WebApiResultT<T>> PostAnonymousAsync<T>(string endpoint, object inputDto)
        {
            return await PostAsync<T>(endpoint, inputDto, null, null);
        }

        public async Task<WebApiResultT<T>> PostAsync<T>(string endpoint, object inputDto, object queryParameters, Dictionary<string, string> authenticationContext)
        {
            var result = new WebApiResultT<T>();
            try
            {
                var httpResponse = GetClient(authenticationContext)
                .AllowAnyHttpStatus()
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .PostJsonAsync(inputDto);

                result.Model = await httpResponse.ReceiveJson<T>();
                result.Success = true;
            }
            catch (FlurlHttpException ex)
            {
                await result.GetErrorMessage(ex);
            }
            return result;
        }

        public async Task<WebApiResultT<T>> PostAsync<T>(string endpoint, Dictionary<string, string> authenticationContext)
        {
            var result = new WebApiResultT<T>();
            try
            {
                var httpResponse = GetClient(authenticationContext)
                .Request(endpoint)
                .PostAsync();

                result.Model = await httpResponse.ReceiveJson<T>();
                result.Success = true;
            }
            catch (FlurlHttpException ex)
            {
                await result.GetErrorMessage(ex);
            }
            return result;
        }

        public async Task<WebApiResultT<T>> PostMultipartAsync<T>(string endpoint, Action<CapturedMultipartContent> buildContent, Dictionary<string, string> authenticationContext)
        {
            var result = new WebApiResultT<T>();
            try
            {
                var httpResponse = GetClient(authenticationContext)
                .Request(endpoint)
                .PostMultipartAsync(buildContent);

                result.Model = await httpResponse.ReceiveJson<T>();
                result.Success = true;
            }
            catch (FlurlHttpException ex)
            {
                await result.GetErrorMessage(ex);
            }
            return result;
        }

        public async Task<WebApiResultT<T>> PostMultipartAsync<T>(string endpoint, Stream stream, string fileName, Dictionary<string, string> authenticationContext)
        {
            var result = new WebApiResultT<T>();
            try
            {
                var httpResponse = GetClient(authenticationContext)
                    .Request(endpoint)
                    .PostMultipartAsync(multiPartContent => multiPartContent.AddFile("file", stream, fileName));

                result.Model = await httpResponse.ReceiveJson<T>();
                result.Success = true;
            }
            catch (FlurlHttpException ex)
            {
                await result.GetErrorMessage(ex);
            }
            return result;
        }

        #endregion PostAsync<T>

        #region GetAsync<T>

        public async Task<WebApiResultT<T>> GetAsync<T>(string endpoint)
        {
            return await GetAsync<T>(endpoint, null);
        }

        public async Task<WebApiResultT<T>> GetAnonymousAsync<T>(string endpoint)
        {
            return await GetAsync<T>(endpoint, null, null);
        }

        public async Task<WebApiResultT<T>> GetAsync<T>(string endpoint, object queryParameters)
        {
            return await GetAsync<T>(endpoint, queryParameters, null);
        }

        public async Task<WebApiResultT<T>> GetAsync<T>(string endpoint, object queryParameters, Dictionary<string, string> authenticationContext)
        {
            var result = new WebApiResultT<T>();
            try
            {
                var httpResponse = GetClient(authenticationContext)
                .Request(endpoint)
                .SetQueryParams(queryParameters);

                result.Model = await httpResponse.GetJsonAsync<T>();
                result.Success = true;
            }
            catch (FlurlHttpException ex)
            {
                await result.GetErrorMessage(ex);
            }
            return result;
        }

        #endregion GetAsync<T>

        #region DeleteAsync

        public async Task<WebApiResult> DeleteAsync(string endpoint)
        {
            return await DeleteAsync(endpoint, null, null);
        }

        public async Task<WebApiResult> DeleteAsync(string endpoint, object queryParameters)
        {
            return await DeleteAsync(endpoint, queryParameters, null);
        }

        public async Task<WebApiResult> DeleteAsync(string endpoint, object queryParameters, Dictionary<string, string> authenticationContext)
        {
            var result = new WebApiResult();
            try
            {
                await GetClient(authenticationContext)
                    .Request(endpoint)
                    .SetQueryParams(queryParameters)
                    .DeleteAsync();
                result.Success = true;
            }
            catch (FlurlHttpException ex)
            {
                await result.GetErrorMessage(ex);
            }
            return result;
        }

        #endregion DeleteAsync

        #region DeleteAsync<T>

        public async Task<WebApiResultT<T>> DeleteAsync<T>(string endpoint)
        {
            return await DeleteAsync<T>(endpoint, null);
        }

        public async Task<WebApiResultT<T>> DeleteAsync<T>(string endpoint, object queryParameters)
        {
            return await DeleteAsync<T>(endpoint, queryParameters, null);
        }

        public async Task<WebApiResultT<T>> DeleteAsync<T>(string endpoint, object queryParameters, Dictionary<string, string> authenticationContext)
        {
            var result = new WebApiResultT<T>();
            try
            {
                var httpResponse = GetClient(authenticationContext)
                .Request(endpoint)
                .SetQueryParams(queryParameters)
                .DeleteAsync();
                result.Model = await httpResponse.ReceiveJson<T>();
                result.Success = true;
            }
            catch (FlurlHttpException ex)
            {
                await result.GetErrorMessage(ex);
            }
            return result;
        }

        #endregion DeleteAsync<T>

        #region PutAsync<T>

        public async Task<WebApiResultT<T>> PutAsync<T>(string endpoint)
        {
            return await PutAsync<T>(endpoint, null, null, null);
        }

        public async Task<WebApiResultT<T>> PutAsync<T>(string endpoint, object inputDto)
        {
            return await PutAsync<T>(endpoint, inputDto, null, null);
        }

        public async Task<WebApiResultT<T>> PutAsync<T>(string endpoint, object inputDto, object queryParameters)
        {
            return await PutAsync<T>(endpoint, inputDto, queryParameters, null);
        }

        public async Task<WebApiResultT<T>> PutAsync<T>(string endpoint, object inputDto, object queryParameters, Dictionary<string, string> authenticationContext)
        {
            var result = new WebApiResultT<T>();
            try
            {
                var httpResponse = GetClient(authenticationContext)
                 .Request(endpoint)
                .SetQueryParams(queryParameters)
                .PutJsonAsync(inputDto);
                result.Model = await httpResponse.ReceiveJson<T>();
                result.Success = true;
            }
            catch (FlurlHttpException ex)
            {
                await result.GetErrorMessage(ex);
            }
            return result;
        }

        #endregion PutAsync<T>

        #region PutAsync

        public async Task<WebApiResult> PutAsync(string endpoint)
        {
            return await PutAsync(endpoint, null, null, null);
        }

        public async Task<WebApiResult> PutAsync(string endpoint, object inputDto)
        {
            return await PutAsync(endpoint, inputDto, null, null);
        }

        public async Task<WebApiResult> PutAsync(string endpoint, object inputDto, object queryParameters)
        {
            return await PutAsync(endpoint, inputDto, queryParameters, null);
        }

        public async Task<WebApiResult> PutAsync(string endpoint, object inputDto, object queryParameters, Dictionary<string, string> authenticationContext)
        {
            var result = new WebApiResult();
            try
            {
                await GetClient(authenticationContext)
                  .Request(endpoint)
                  .SetQueryParams(queryParameters)
                  .PutJsonAsync(inputDto);
                result.Success = true;
            }
            catch (FlurlHttpException ex)
            {
                result.Status = ex.Call.Response?.StatusCode;
                result.Message = await ex.GetResponseStringAsync();
            }
            return result;
        }

        #endregion PutAsync

        public FlurlClient GetClient(Dictionary<string, string> authenticationContext)
        {
            if (_client == null)
            {
                CreateClient();
            }

            AddHeaders(authenticationContext);
            return _client;
        }

        private void CreateClient()
        {
            _client = new FlurlClient(_apiUrlConfig.GetBaseUrl);
            _client.Configure(cli => cli.HttpClientFactory = new UntrustedCertClientFactory());

            if (TimeoutSeconds.HasValue)
            {
                _client.WithTimeout(TimeoutSeconds.Value);
            }
        }

        private void AddHeaders(Dictionary<string, string> authenticationContext)
        {
            _client.HttpClient.DefaultRequestHeaders.Clear();
            authenticationContext?
                .Keys?
                .ToList()
                .ForEach(key =>
            {
                if (!string.IsNullOrWhiteSpace(authenticationContext[key]))
                    _client.WithHeader(key, authenticationContext[key]);
            });
        }

    }
}