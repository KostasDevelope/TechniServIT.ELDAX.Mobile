using Newtonsoft.Json;
using System;
using Xamarin.Forms;

namespace TechniServIT.ELDAX.Mobile.Eldax.Common.Services
{
    public static class ApplicationPropertiesService
    {
        public static T GetProperty<T>(string key)
        {
            var result = Application.Current.Properties.ContainsKey(key) && Application.Current.Properties[key] != null
              ? (T)Convert.ChangeType(Application.Current.Properties[key], typeof(T))
              : default(T);

            return result;
        }

        public static T GetPropertyJson<T>(string key)
        {
            var result = Application.Current.Properties.ContainsKey(key) && Application.Current.Properties[key] != null
              ? JsonConvert.DeserializeObject<T>(Application.Current.Properties[key] as string)
              : default(T);

            return result;
        }

        public static bool IsValue(string key)
        {
            return Application.Current.Properties.ContainsKey(key) && Application.Current.Properties[key] != null;
        }

        public static void SetProperty<T>(string key, T value)
        {
            Application.Current.Properties[key] = value;
        }

        public static void SetPropertyJson<T>(string key, T value)
        {
            Application.Current.Properties[key] = JsonConvert.SerializeObject(value);
        }

        public static bool DeleteProperty(string key)
        {
            return Application.Current.Properties.ContainsKey(key) ?
                   Application.Current.Properties.Remove(key) : false;
        }
    }
}