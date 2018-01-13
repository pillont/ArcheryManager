using ArcheryManager.Helpers;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.Pages
{
    public class CountTabbedPage : TabbedPageWithGeneralEvent
    {
        public readonly ContentPageWithGeneralEvent Counter;

        /// <summary>
        /// initial index to the target page in the children
        /// So index of the tab
        /// </summary>
        private readonly int TargetIndex;

        private RemarksPage Remark;
        private TimerPage Timer;

        public CountTabbedPage(ContentPageWithGeneralEvent counter)
        {
            Counter = counter;

            //NOTE : swipe must be removed on a target
            //MISTAKE : have conflict with target gesture to create arrows
            AndroidTabbedPageHelper.RemoveSwipe(this);

            InsertTabPages();
            TargetIndex = Children.IndexOf(Counter);

            MessagingCenterHelper.Instance.PoppingPageEvent += NavigationPage_Popped;
        }

        /// <summary>
        /// insert counter page in args
        /// insert new timer page
        /// insert new remarks page
        /// </summary>
        private void InsertTabPages()
        {
            Timer = new TimerPage() { Title = AppResources.Timer };
            Remark = ViewFactory.CreatePage<RemarksPageViewModel, RemarksPage>() as RemarksPage;
            Counter.Title = AppResources.Shoot;

            this.Children.Add(Counter);
            this.Children.Add(Timer);
            this.Children.Add(Remark);
        }

        /// <summary>
        /// curren tab is counter if the page is popped
        /// NOTE : when return to this page by the back message, the counter is visible
        /// </summary>
        private void NavigationPage_Popped(object sender, Page page)
        {
            if (page == this)
            {
                CurrentPage = Children[TargetIndex];
            }
        }
    }
}
