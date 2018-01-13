using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Resources
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public static string GetTextResource(string key)
        {
            string text = AppResources.ResourceManager.GetString(key);
            if (text == null)
            {
                text = ErrorResources.ResourceManager.GetString(key);
            }
            return text;
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return null;
            }

            string text = AppResources.ResourceManager.GetString(Text, CultureInfo.CurrentCulture);
            if (text == null)
            {
                text = ErrorResources.ResourceManager.GetString(Text, CultureInfo.CurrentCulture);
            }
            return text;
        }
    }
}
