using System;
using System.Globalization;
using System.Resources;
using TechniServIT.ELDAX.Mobile.Resources;
using Xamarin.Forms.Xaml;

//https://mindofai.github.io/Implementing-Localization-with-Xamarin.Forms/
//, ResourceType=typeof(MasterDetailPageEldaxResource) 
// Title="{local:Translate Key=MasterPage}"
namespace TechniServIT.ELDAX.Mobile.Extensions
{
    public class TranslateExtension : IMarkupExtension
    {
        private Type ResourceType = typeof(MasterDetailPageEldaxResource);

        public string Key { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(Key) || ResourceType == null) return null;

            var resourceManager = new ResourceManager(ResourceType.FullName, ResourceType.Assembly);

            return resourceManager.GetString(Key, CultureInfo.CurrentCulture);
        }
    }
}
