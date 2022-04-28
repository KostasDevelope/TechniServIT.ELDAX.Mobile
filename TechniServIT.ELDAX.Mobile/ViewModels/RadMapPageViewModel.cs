using Prism.Navigation;
using Prism.Services;
using Telerik.XamarinForms.Map;

namespace TechniServIT.ELDAX.Mobile.ViewModels
{
    public class RadMapPageViewModel : ViewModelBase
    {
        public RadMapPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            var assembly = this.GetType().Assembly;
            _sourceMap = MapSource.FromResource("TechniServIT.ELDAX.Mobile.Maps.Ukraine.BMU-Rivers-SHP.shp", assembly);
            _dataSourceMap = MapSource.FromResource("TechniServIT.ELDAX.Mobile.Maps.Ukraine.BMU-Rivers-SHP.dbf", assembly);
        }

        private MapSource _sourceMap;

        public MapSource SourceMap
        {
            get => _sourceMap;
            set => SetProperty(ref _sourceMap, value); 
        }

        private MapSource _dataSourceMap;

        public MapSource DataSourceMap
        {
            get => _dataSourceMap;
            set => SetProperty(ref _dataSourceMap, value); 
        }
    }
}