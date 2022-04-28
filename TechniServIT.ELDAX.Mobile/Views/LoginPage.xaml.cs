using System;
using TechniServIT.ELDAX.Mobile.Models;
using TechniServIT.ELDAX.Mobile.Resources;
using TechniServIT.ELDAX.Mobile.ViewModels;
using Telerik.XamarinForms.Input;
using Telerik.XamarinForms.Input.DataForm;
using Xamarin.Forms;

namespace TechniServIT.ELDAX.Mobile.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            DataFormLocalizationManager.Manager = LoginPageResource.ResourceManager;
            InitializeComponent();

            dataForm.RegisterEditor(nameof(LoginModel.UserName), EditorType.TextEditor);
            dataForm.RegisterEditor(nameof(LoginModel.Password), EditorType.TextEditor);
            dataForm.RegisterEditor(nameof(LoginModel.Email), EditorType.TextEditor);
            dataForm.RegisterEditor(nameof(LoginModel.Age), EditorType.IntegerEditor);
            dataForm.RegisterEditor(nameof(LoginModel.Weight), EditorType.DecimalEditor);
            dataForm.RegisterEditor(nameof(LoginModel.Height), EditorType.IntegerEditor);
        }
        private void Form_NativeControlLoaded(object sender, EventArgs e)
        {
            (sender as RadDataForm)?.ValidateAll();
        }
        private void ValidationCompleted(object sender, PropertyValidationCompletedEventArgs e)
        {
            (this.BindingContext as LoginPageViewModel)?.UpdatePropertyState(e.PropertyName, e.IsValid);
        }
    }
}