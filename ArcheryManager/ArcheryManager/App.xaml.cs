using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Pages;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Services;
using ArcheryManager.Utils;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace ArcheryManager
{
    public partial class App : Application
    {
        public const string DBName =
#if TEST
            "ArcheryManagerDB_Test.db3";

#elif RELEASE
            "ArcheryManagerDB_Release_v1.db3";

#elif DEBUG
            "ArcheryManagerDB_Debug_v1.db3";

#endif
        private readonly MessagingCenterHelper MessagingCenterHelper = MessagingCenterHelper.Instance;

        private static NavigationPage _navigationPage;

        private NavigationPage NavigationPage
        {
            get
            {
                if (_navigationPage == null)
                {
#if RELEASE
                    var page = ViewFactory.CreatePage<GeneralMenuViewModel, GeneralMenu>() as Page;
#else
                    var page = ViewFactory.CreatePage<BackDoorPageViewModel, BackDoorPage>() as Page;
#endif
                    _navigationPage = new NavigationPageWithInterface(page);

                    var behavior = new ToolBarItemsBehavior<NavigationPageWithInterface>();
                    _navigationPage.Behaviors.Add(behavior);
                }
                return _navigationPage;
            }
        }

        public App()
        {
            RegisterHelper.InitRegister();

            InitializeComponent();

            MainPage = NavigationPage;

            InitNavigationMessagingCenter();
        }

        private void InitNavigationMessagingCenter()
        {
            MessagingCenterHelper.BackPageEvent += Instance_BackPageEvent;
            MessagingCenterHelper.PushedPageEvent += Instance_PushingPageEvent;
            MessagingCenterHelper.SendToastEvent += Instance_SendToastEvent;
            MessagingCenterHelper.RemovedPageInNavigationEvent += Instance_RemovedPageInNavigation;
            MessagingCenterHelper.PopToRootPageEvent += Instance_PopToRootPage;

            NavigationPage.Popped += NavigationPage_Popped;
        }

        private void Instance_PopToRootPage(object sender, Page page)
        {
            NavigationPage.Navigation.PopToRootAsync();
        }

        private void Instance_RemovedPageInNavigation(object sender, Page page)
        {
            NavigationPage.Navigation.RemovePage(page);
        }

        private async void Instance_SendToastEvent(object sender, Interactions.Behaviors.AlertArg e)
        {
            CheckValueOrThrow(e);

            if (e.Accept == null)
            {
                await NavigationPage.DisplayAlert(e.Title, e.Message, e.Cancel);
            }
            else
            {
                bool r = await NavigationPage.DisplayAlert(e.Title, e.Message, e.Accept, e.Cancel);
                e.ResultChanged(r);
            }
        }

        private static void CheckValueOrThrow(AlertArg e)
        {
            if (e.Title == null
            || e.Message == null
            || e.Cancel == null)
            {
                throw new ArgumentNullException("title, message and cancel info in the alert arg must be set");
            }
        }

        private void Instance_PushingPageEvent(object sender, Page page)
        {
            Device.BeginInvokeOnMainThread(() =>
                NavigationPage.PushAsync(page).ContinueWith(async t =>
                {
                    try
                    {
                        await t;

                        //after push page raise event
                        if (page is IViewWithGeneralEvent p)
                        {
                            Device.BeginInvokeOnMainThread(() =>
                                                   p.OnPagePushed(sender, null));
                        }
                    }
                    catch (Exception e)
                    {
                        Device.BeginInvokeOnMainThread(() => throw e);
                    }
                }));
        }

        private void NavigationPage_Popped(object sender, NavigationEventArgs e)
        {
            MessagingCenterHelper.PoppedInNavigationPage(this, e.Page);
        }

        private void Instance_BackPageEvent(object sender, EventArgs e)
        {
            NavigationPage.SendBackButtonPressed();
        }

        private static async Task InitSqliteTablesAsync()
        {
            var service = DependencyService.Get<ISqliteService>();
            var saver = service.GetAsyncConnection();
            await CreateTables(saver);

#if TEST
            //TO REMOVE ALL VALUES
            await saver.DropTableAsync<Remark>();
            await saver.DropTableAsync<Arrow>();
            await saver.DropTableAsync<Flight>();
            await saver.DropTableAsync<CountedShoot>();
            await CreateTables(saver);

#endif
        }

        private static async Task CreateTables(SQLiteConnectionManager saver)
        {
            //TO CREATE TABLES
            await saver.CreateTableAsync<Remark>();
            await saver.CreateTableAsync<Arrow>();
            await saver.CreateTableAsync<Flight>();
            await saver.CreateTableAsync<CountedShoot>();
        }

        protected override void OnStart()
        {
            //NOTE : Task.Run and Wait to be sure the database are creating before start application
            var t = Task.Run(() => InitSqliteTablesAsync());
            t.Wait();
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
