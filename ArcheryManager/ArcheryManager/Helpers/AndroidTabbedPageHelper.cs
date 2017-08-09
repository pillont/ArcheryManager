using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

//NOTE : keep remove xamarin.form to not have conflict

namespace ArcheryManager.Helpers
{
    public class AndroidTabbedPageHelper
    {
        /// <summary>
        /// remove swipe on android tabbed page
        /// </summary>
        /// <param name="countTabbedPage"></param>
        public static void RemoveSwipe(Xamarin.Forms.TabbedPage countTabbedPage)
        {
            countTabbedPage.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }
    }
}
