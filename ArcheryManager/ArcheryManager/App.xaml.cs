﻿using ArcheryManager.Pages;
using Xamarin.Forms;

namespace ArcheryManager
{
    public partial class App : Application
    {
        private static NavigationPage navigationPage;

        public static NavigationPage NavigationPage
        {
            get
            {
                if (navigationPage == null)
                {
                    //#if TEST
                    navigationPage = new NavigationPage(new BackDoorPage());
                    //#else
                    //                    navigationPage = new NavigationPage(new GeneralMenu());
                    //#endif
                }
                return navigationPage;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = NavigationPage;
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
