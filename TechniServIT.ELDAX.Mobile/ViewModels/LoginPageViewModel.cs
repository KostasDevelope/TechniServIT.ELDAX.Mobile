using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechniServIT.ELDAX.Mobile.Eldax.Common.Services;
using TechniServIT.ELDAX.Mobile.Models;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Services;

namespace TechniServIT.ELDAX.Mobile.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly Dictionary<string, bool> properties = new Dictionary<string, bool>();
        private readonly IAccountService _accountService;

        public LoginPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService,
            IAccountService accountService) : base(navigationService, dialogService)
        {
            LoginModel = new LoginModel();
            LoginCommand = new DelegateCommand(async () => await Login());
            _accountService = accountService;
        }

        public bool IsValid
        {
            get => properties.Values.All(s => s);
        }

        private LoginModel _loginModel;

        public LoginModel LoginModel
        {
            get => _loginModel;
            set => SetProperty(ref _loginModel, value);
        }

        public void UpdatePropertyState(string name, bool isValid)
        {
            if (!properties.ContainsKey(name))

                properties.Add(name, isValid);
            else
                properties[name] = isValid;

            RaisePropertyChanged(nameof(IsValid));
        }

        public DelegateCommand LoginCommand { get; private set; }

        private async Task Login()
        {
            if (!IsValid) return;

            var result = await Executor(async () =>
            {
                return await _accountService.AuthenticateEx(_loginModel.UserName, _loginModel.Password);
            });

            if (result.Success && !string.IsNullOrEmpty(result.Model?.Token))
            {
                ApplicationPropertiesService.SetPropertyJson(CommonConstants.AuthenticationContext, result);
                await _navigationService.NavigateAsync($"{CommonConstants.MasterDetailPageEldax}/{CommonConstants.NavigationPage}/{CommonConstants.DashboardPage}");
            }
        }
    }
}