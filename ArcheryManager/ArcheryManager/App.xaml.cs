using ArcheryManager.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            MainPage = new TargetPage();
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
