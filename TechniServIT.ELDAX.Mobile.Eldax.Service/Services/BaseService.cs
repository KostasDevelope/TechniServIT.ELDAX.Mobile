using ELDAXService;

namespace TechniServIT.ELDAX.Mobile.Eldax.Service.Services
{
    public class BaseService
    {
        protected readonly ELDAXServiceClient _client;

        public BaseService(ELDAXServiceClient client)
        {
            _client = client;
        }
    }
}