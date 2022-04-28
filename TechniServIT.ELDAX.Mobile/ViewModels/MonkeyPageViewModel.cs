using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TechniServIT.ELDAX.Mobile.ViewModels
{
    public class MonkeyPageViewModel : ViewModelBase
    {
        public MonkeyPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService, dialogService)
        {
        }
    }
}
