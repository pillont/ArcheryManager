using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Resources
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return null;
            }

            return AppResources.ResourceManager.GetString(Text, CultureInfo.CurrentCulture);
        }

        public static string GetTextResource(string key)
        {
            return AppResources.ResourceManager.GetString(key);
        }
    }
}
