using ArcheryManager.Pages;
using ArcheryManager.Settings;
using Xamarin.Forms;

namespace ArcheryManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

#if TEST
            MainPage = new BackDoorPage();

#else
            MainPage = new TargetPage(IndoorCompoundArrowSetting.Instance);
#endif
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
