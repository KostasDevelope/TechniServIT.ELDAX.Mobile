using Prism.Mvvm;
using Telerik.XamarinForms.Common.DataAnnotations;
using TechniServIT.ELDAX.Mobile.Resources;
using TechniServIT.ELDAX.Mobile.Attributes;

namespace TechniServIT.ELDAX.Mobile.Models
{
    public class LoginModel : BindableBase
    {
        private string _userName;

        [DisplayOptions(HeaderResourceKey = "UserName", PlaceholderTextResourceKey = "AddUserName", Position = 0)]
        [DataSourceKey("UserName")]
        [NonEmptyValidatorCustom(typeof(LoginPageResource), "UserNameRequired", null)]
        [StringLengthValidator(2, 10, "Your name should be longer than 2 symbols.", "ok")]
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private string _password;

        [DisplayOptions(HeaderResourceKey = "Password", PlaceholderTextResourceKey = "AddPassword", Position = 1)]
        [DataSourceKey("Password")]
        [NonEmptyValidatorCustom(typeof(LoginPageResource), "UserNameRequired", null)]
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _email;

        [DisplayOptions(HeaderResourceKey = "Email", PlaceholderTextResourceKey = "AddEmail", Position = 2)]
        [DataSourceKey("Email")]
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private int _age = 27;

        [DisplayOptions(HeaderResourceKey = "Age", PlaceholderTextResourceKey = "AddAge", Position = 3)]
        [DataSourceKey("Age")]
        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        private double _weight = 60.5;

        [DisplayOptions(HeaderResourceKey = "Weight", PlaceholderTextResourceKey = "AddWeight", Position = 4)]
        [DataSourceKey("Weight")]
        public double Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }

        private int _height = 163;

        [DisplayOptions(HeaderResourceKey = "Height", PlaceholderTextResourceKey = "AddHeight", Position = 5)]
        [DataSourceKey("Height")]
        [ReadOnly]
        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }
    }
}