namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Models
{
    public class WebApiResult
    {
        public int? Status { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }

    public class WebApiResultT<T> : WebApiResult
    {
        public T Model { get; set; }
    }
}