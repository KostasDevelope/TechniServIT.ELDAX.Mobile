using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace TechniServIT.ELDAX.Mobile.ViewModels
{
    public class MasterDetailPageEldaxViewModel : ViewModelBase
    {
        public MasterDetailPageEldaxViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
            NavigateCommand = new DelegateCommand<string>(NavigateCommandExecuted);
        }

        public DelegateCommand<string> NavigateCommand { get; }

        private async void NavigateCommandExecuted(string view)
        {
            var result = await _navigationService.NavigateAsync($"NavigationPage/{view}");
            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }
    }
}
