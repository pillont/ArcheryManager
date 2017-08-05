using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;
using ArcheryManager.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArcheryManager.Pages
{
    public class CountTabbedPage : TabbedPageWithGeneralEvent
    {
        public CountTabbedPage(Page counter)
        {
            try
            {
                var timer = new TimerPage() { Title = AppResources.Timer };
                counter.Title = AppResources.Shoot;
                this.Children.Add(counter);
                this.Children.Add(timer);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CurrentPage = Children[0];
        }
    }
}
