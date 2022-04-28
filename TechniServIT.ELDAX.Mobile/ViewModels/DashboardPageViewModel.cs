using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TechniServIT.ELDAX.Mobile.Commands;
using TechniServIT.ELDAX.Mobile.Eldax.Common.Services;
using TechniServIT.ELDAX.Mobile.Models;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Models;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Services;

namespace TechniServIT.ELDAX.Mobile.ViewModels
{
    public class DashboardPageViewModel : ViewModelBase
    {
        private readonly IApplicationCommands _applicationCommands;
        private readonly IAccountService _accountService;

        public DashboardPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService,
            IApplicationCommands applicationCommands,
            IAccountService accountService
            ) : base(navigationService, dialogService)
        {
            _applicationCommands = applicationCommands;
            _accountService = accountService;

            var DateTimeNow = ApplicationPropertiesService.GetProperty<DateTime>(key: "DateTimeNow");

            Title = $"Main Page {DateTimeNow}";

            ShowCommand = new DelegateCommand(async () => await AuthenticateExAsync());

            _applicationCommands.ShowPopup.RegisterCommand(ShowCommand);
            this.Data = GetCategoricalData();
        }

        private async Task AuthenticateExAsync()
        {
            try
            {

                var result = await _accountService.AuthenticateEx("sa", "123");

                await _dialogService.DisplayAlertAsync("Alert"
                        , string.IsNullOrEmpty(result.Model?.Token) ? "No Login" : $"Token: {result.Model?.Token}"
                        , "OK");
                
            }
            catch (Exception ex)
            {
                await _dialogService.DisplayAlertAsync("Alert"
                        , ex.Message
                        , "OK");
            }
        }

        public DelegateCommand ShowCommand { get; private set; }

        public ObservableCollection<CategoricalData> Data { get; set; }

        private static ObservableCollection<CategoricalData> GetCategoricalData()
        {
            var data = new ObservableCollection<CategoricalData>
            {
                new Models.CategoricalData { Category = "A", Value = 101 },
                new CategoricalData { Category = "B", Value = 45 },
                new CategoricalData { Category = "C", Value = 77 },
                new CategoricalData { Category = "D", Value = 15 },
                new CategoricalData { Category = "E", Value = 56 },
            };
            return data;
        }
    }
}