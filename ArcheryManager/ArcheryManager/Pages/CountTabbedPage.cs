using ArcheryManager.Helpers;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;
using System;
using Xamarin.Forms;

namespace ArcheryManager.Pages
{
    public class CountTabbedPage : TabbedPageWithGeneralEvent
    {
        /// <summary>
        /// initial index to the target page in the children
        /// So index of the tab
        /// </summary>
        private readonly int TargetIndex;

        public CountTabbedPage(Page counter)
        {
            try
            {
                //NOTE : swipe must be removed on a target
                //MISTAKE : have conflict with target gesture to create arrows
                AndroidTabbedPageHelper.RemoveSwipe(this);

                InsertTabPages(counter);
                TargetIndex = Children.IndexOf(counter);

                App.NavigationPage.Popped += NavigationPage_Popped;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// insert counter page in args
        /// insert new timer page
        /// insert new remarks page
        /// </summary>
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
                CurrentPage = Children[TargetIndex];
            }
        }
    }
}
