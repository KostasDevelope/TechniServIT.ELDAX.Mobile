using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using TechniServIT.ELDAX.Mobile.Eldax.Common.Services;
using TechniServIT.ELDAX.Mobile.WebApi.Service.Models;

namespace TechniServIT.ELDAX.Mobile.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected readonly INavigationService _navigationService;
        protected readonly IPageDialogService _dialogService;

        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ViewModelBase(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        protected async Task<WebApiResultT<T>> Executor<T>(Func<AuthenticationContext, Task<WebApiResultT<T>>> func)
        {
            var navigationLoginPage = $"NavigationPage/{CommonConstants.LoginPage}";
            var authenticationContext = ApplicationPropertiesService.GetPropertyJson<AuthenticationContext>(CommonConstants.AuthenticationContext);
           
            if(authenticationContext == null || !string.IsNullOrWhiteSpace(authenticationContext.Token))
                await _navigationService.NavigateAsync(navigationLoginPage);

            var result = await func.Invoke(authenticationContext); 
            switch(result.Status)
            {
                case 500:
                    await _dialogService.DisplayAlertAsync("Error", result.Message, "OK");
                    break;
                case 401:
                    await _navigationService.NavigateAsync(navigationLoginPage);
                    break;
                default:
                    if (!result.Success)
                    {
                        await _dialogService.DisplayAlertAsync("Error", result.Message, "OK");
                    }
                    break; 

            }
            return result;
        }

        protected async Task<WebApiResultT<T>> Executor<T>(Func<Task<WebApiResultT<T>>> func)
        {
            var result = await func.Invoke();
            switch (result.Status)
            {
                case 500:
                    await _dialogService.DisplayAlertAsync("Error", result.Message, "OK");
                    break;
                default:
                    if (!result.Success)
                    {
                        await _dialogService.DisplayAlertAsync("Error", result.Message, "OK");
                    }
                 break;
            }
            return result;
        }


        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }
    }
}