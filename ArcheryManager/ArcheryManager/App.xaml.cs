using ArcheryManager.Pages;
using ArcheryManager.Settings;
using Xamarin.Forms;

namespace ArcheryManager
{
    public partial class App : Application
    {
        private static NavigationPage _navigationPage;

        public static NavigationPage NavigationPage
        {
            get
            {
                if (_navigationPage == null)
                {
                    //#if TEST
                    _navigationPage = new NavigationPage(new BackDoorPage());
                    //#else
                    //                    navigationPage = new NavigationPage(new GeneralMenu());
                    //#endif
                }
                return _navigationPage;
            }
        }

        public App()
        {
            try
            {
                InitializeComponent();

                DependencyService.Register<GeneralCounterSetting>();

                MainPage = NavigationPage;
            }
            catch (System.Exception e)
            {
                throw;
            }
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
