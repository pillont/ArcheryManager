using System.Threading.Tasks;
using ArcheryManager.Pages.PagesTemplates;
using Xamarin.Forms;

namespace ArcheryManager.Interactions.Behaviors
{
    public class BackMessageBehavior : CustomBehavior<ContentPageWithGeneralEvent>
    {
        private readonly AlertArg AlertArg;
        private readonly NavigationPage NavigationReference;

        /// <summary>
        /// behavior to display alert when the navigation page pop the associated page
        /// </summary>
        public BackMessageBehavior(NavigationPage navigationP, AlertArg alertArg)
        {
            NavigationReference = navigationP;
            AlertArg = alertArg;
        }

        protected override void OnAttachedTo(ContentPageWithGeneralEvent bindable)
        {
            base.OnAttachedTo(bindable);
            NavigationReference.Popped += NavigationPage_Popped;
        }

        private async void NavigationPage_Popped(object sender, NavigationEventArgs e)
        {
            if (e.Page == AssociatedObject)
            {
                bool answer = await DisplayAlert();
                if (!answer)
                {
                    await NavigationReference.PushAsync(e.Page);
                }
                else
                {
                    NavigationReference.Popped -= NavigationPage_Popped;
                }
            }
        }

        private async Task<bool> DisplayAlert()
        {
            return await NavigationReference.DisplayAlert(AlertArg.Title,
                                                            AlertArg.Message,
                                                            AlertArg.Accept,
                                                            AlertArg.Cancel);
        }
    }

    /// <summary>
    /// <seealso cref="Page.DisplayAlert(string, string, string, string)"/>
    /// </summary>
    public class AlertArg
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Accept { get; set; }
        public string Cancel { get; set; }
    }
}
