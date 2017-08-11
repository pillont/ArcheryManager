using Xamarin.Forms;

namespace ArcheryManager.Models
{
    public class Remark : BindableObject
    {
        public static readonly BindableProperty TextProperty =
                      BindableProperty.Create(nameof(Text), typeof(string), typeof(Remark), string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty ArrowIndexProperty =
                      BindableProperty.Create(nameof(FlightIndex), typeof(int?), typeof(Remark), null);

        /// <summary>
        /// null value => general remark
        /// not null => flight remark
        /// </summary>
        public int? FlightIndex
        {
            get { return (int?)GetValue(ArrowIndexProperty); }
            set { SetValue(ArrowIndexProperty, value); }
        }
    }
}
