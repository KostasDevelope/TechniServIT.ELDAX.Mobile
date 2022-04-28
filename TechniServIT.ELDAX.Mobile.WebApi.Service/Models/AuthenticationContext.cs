namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Models
{
    public class AuthenticationContext
    {
        public string AuthenticationType { get; set; }
        public string Token { get; set; }
        public string TntityId { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public string ApplicationLogin { get; set; }
        public string CultureCode { get; set; }
        public string TimeZoneId { get; set; }
        public string Pin { get; set; }
        public string ServerName { get; set; }
        public string IsLockedOut { get; set; }
        public string LockedFrom { get; set; }
        public string ClientVersion { get; set; }
        public string IpAddress { get; set; }
        public string IuthenticationMessage { get; set; }
        public string IsTokenValid { get; set; }
    }
}