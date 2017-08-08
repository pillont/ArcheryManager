using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace ArcheryManager.Pages
{
    public class CountTabbedPage : TabbedPageWithGeneralEvent
    {
        public CountTabbedPage(Page counter)
        {
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);

            try
            {
                InsertTabPages(counter);
            }
            catch (Exception e)
            {
                throw;
            }

            App.NavigationPage.Popped += NavigationPage_Popped;
        }

        private void InsertTabPages(Page counter)
        {
            var timer = new TimerPage() { Title = AppResources.Timer };
            var remark = new RemarksPage();
            counter.Title = AppResources.Shoot;
            this.Children.Add(counter);
            this.Children.Add(timer);
            this.Children.Add(remark);
        }

        /// <summary>
        /// curren tab is counter if the page is popped
        /// NOTE : when return to this page by the back message, the counter is visible
        /// </summary>
        private void NavigationPage_Popped(object sender, NavigationEventArgs e)
        {
            if (e.Page == this)
            {
                CurrentPage = Children[0];
            }
        }
    }
}
