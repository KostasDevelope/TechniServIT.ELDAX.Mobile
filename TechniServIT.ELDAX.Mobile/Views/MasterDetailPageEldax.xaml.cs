using Prism.Navigation;
using Xamarin.Forms;

namespace TechniServIT.ELDAX.Mobile.Views
{
    public partial class MasterDetailPageEldax : IMasterDetailPageOptions
    {
        public static readonly BindableProperty IsPresentedAfterNavigationProperty =
           BindableProperty.Create(nameof(IsPresentedAfterNavigation), typeof(bool), typeof(MasterDetailPageEldax), false);

        public MasterDetailPageEldax()
        {
            InitializeComponent();
        }
        public bool IsPresentedAfterNavigation
        {
            get => (bool)GetValue(IsPresentedAfterNavigationProperty);
            set => SetValue(IsPresentedAfterNavigationProperty, value);
        }
    }
}