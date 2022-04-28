namespace TechniServIT.ELDAX.Mobile.WebApi.Service.Models
{
    public class TariffInfo
    {
        public string TariffName { get; set; }

        public long MaxCountAdesDocs { get; set; }

        public long MaxSizeAdesDocs { get; set; }

        public long ActualCountAdesDocs { get; set; }

        public long ActualSizeAdesDoc { get; set; }
    }
}