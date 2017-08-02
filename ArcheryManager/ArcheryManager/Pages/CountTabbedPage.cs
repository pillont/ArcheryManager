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
    public class CountTabbedPage : TabbedPage
    {
        public CountTabbedPage(Page counter)
        {
            try
            {
                counter.Title = AppResources.Shoot;
                this.Children.Add(counter);
                this.Children.Add(new TimerPage() { Title = AppResources.Timer });
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
