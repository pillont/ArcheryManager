using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        public ResultPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Disable selection during listview tap
        /// REF : https://developer.xamarin.com/guides/xamarin-forms/user-interface/listview/interactivity/#selectiontaps
        /// </summary>
        private void ListView_ItemTappedDisabled(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
