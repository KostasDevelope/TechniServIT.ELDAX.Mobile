using Flurl.Http.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Models;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.ApiClient
{
    public interface IApiClient
    {
        #region PostAsync<T>

        Task<WebApiResultT<T>> PostAsync<T>(string endpoint);

        Task<WebApiResultT<T>> PostAnonymousAsync<T>(string endpoint);

        Task<WebApiResultT<T>> PostAsync<T>(string endpoint, object inputDto);

        Task<WebApiResultT<T>> PostAsync<T>(string endpoint, object inputDto, object queryParameters);

        Task<WebApiResultT<T>> PostAnonymousAsync<T>(string endpoint, object inputDto);

        Task<WebApiResultT<T>> PostAsync<T>(string endpoint, object inputDto, object queryParameters, Dictionary<string, string> authenticationContext);

        Task<WebApiResultT<T>> PostMultipartAsync<T>(string endpoint, Action<CapturedMultipartContent> buildContent, Dictionary<string, string> authenticationContext);

        Task<WebApiResultT<T>> PostMultipartAsync<T>(string endpoint, Stream stream, string fileName, Dictionary<string, string> authenticationContext);

        #endregion PostAsync<T>

        #region GetAsync<T>

        Task<WebApiResultT<T>> GetAsync<T>(string endpoint);

        Task<WebApiResultT<T>> GetAnonymousAsync<T>(string endpoint);

        Task<WebApiResultT<T>> GetAsync<T>(string endpoint, object queryParameters);

        Task<WebApiResultT<T>> GetAsync<T>(string endpoint, object queryParameters, Dictionary<string, string> authenticationContext);

        #endregion GetAsync<T>

        #region DeleteAsync

        Task<WebApiResult> DeleteAsync(string endpoint);

        Task<WebApiResult> DeleteAsync(string endpoint, object queryParameters);

        Task<WebApiResult> DeleteAsync(string endpoint, object queryParameters, Dictionary<string, string> authenticationContext);

        #endregion DeleteAsync

        #region DeleteAsync<T>

        Task<WebApiResultT<T>> DeleteAsync<T>(string endpoint);

        Task<WebApiResultT<T>> DeleteAsync<T>(string endpoint, object queryParameters);

        Task<WebApiResultT<T>> DeleteAsync<T>(string endpoint, object queryParameters, Dictionary<string, string> authenticationContext);

        #endregion DeleteAsync<T>

        #region PutAsync<T>

        Task<WebApiResultT<T>> PutAsync<T>(string endpoint);

        Task<WebApiResultT<T>> PutAsync<T>(string endpoint, object inputDto);

        Task<WebApiResultT<T>> PutAsync<T>(string endpoint, object inputDto, object queryParameters);

        Task<WebApiResultT<T>> PutAsync<T>(string endpoint, object inputDto, object queryParameters, Dictionary<string, string> authenticationContext);

        #endregion PutAsync<T>

        #region PutAsync

        Task<WebApiResult> PutAsync(string endpoint);

        Task<WebApiResult> PutAsync(string endpoint, object inputDto);

        Task<WebApiResult> PutAsync(string endpoint, object inputDto, object queryParameters);

        Task<WebApiResult> PutAsync(string endpoint, object inputDto, object queryParameters, Dictionary<string, string> authenticationContext);

        #endregion PutAsync
    }
}