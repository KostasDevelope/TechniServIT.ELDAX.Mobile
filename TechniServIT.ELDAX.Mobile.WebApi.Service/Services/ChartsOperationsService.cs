using apiClient = TechniServIT.ELDAX.Mobile.WebApi.Service.ApiClient;

namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Services
{
    public interface IChartsOperationsService
    {
    }

    public class ChartsOperationsService : BaseService, IChartsOperationsService
    {
        private const string urlApi = "api/chartsoperations/";
        public ChartsOperationsService(apiClient.ApiClient apiClient) : base(apiClient)
        {
        }
    }
}