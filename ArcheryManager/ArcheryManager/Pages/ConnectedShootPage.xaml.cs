using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArcheryManager.Pages.PagesTemplates;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectedShootPage : ContentPageWithGeneralEvent
    {
        //public ToolbarItem ConnectButton => InternalConnectButton;
        //public ListView RegisteredList => InternalRegisteredList;

        public ConnectedShootPage()
        {
            InitializeComponent();
        }
    }
}
