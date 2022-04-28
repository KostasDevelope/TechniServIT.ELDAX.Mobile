using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Models;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Helpers
{
    public enum ClientVersion : int
    {
        Major = 2,
        Minor = 0,
        Build = 0
    }

    public class ClientVersionHelper
    {
        public static string GetClientVersion()
        {
            return $"{(int)ClientVersion.Major}.{(int)ClientVersion.Minor}.{(int)ClientVersion.Build}";
        }
    }

    public static class ApiClientHelper
    {
        public static async Task GetErrorMessage(this WebApiResult result, FlurlHttpException ex)
        {
            result.Status = ex.Call.Response?.StatusCode;
            result.Message = await ex.GetResponseStringAsync();
            if (string.IsNullOrWhiteSpace(result.Message))
                result.Message = ex.Message;
        }

    }
}
