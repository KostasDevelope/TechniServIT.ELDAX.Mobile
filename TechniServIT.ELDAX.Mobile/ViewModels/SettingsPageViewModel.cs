using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace TechniServIT.ELDAX.Mobile.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            _barcodevalue = "https://www.telerik.com/xamarin-ui";
        }
        private string _barcodevalue;
        public string BarcodeValue 
        {
            get => _barcodevalue;
            set => SetProperty(ref _barcodevalue, value);
        }
    }
}