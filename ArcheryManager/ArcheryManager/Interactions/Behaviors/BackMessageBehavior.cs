using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;

namespace ArcheryManager.Interactions.Behaviors
{
    public class BackMessageBehavior : CustomBehavior<ContentPageWithGeneralEvent>
    {
        protected override void OnAttachedTo(ContentPageWithGeneralEvent bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.BackButtonPressed += Bindable_BackButtonPressed;
        }

        private void Bindable_BackButtonPressed(object sender, BackButtonPressedArg e)
        {
            var answer = App.NavigationPage.DisplayAlert(AppResources.Question, AppResources.SureQuitCount, AppResources.Yes, AppResources.No).Result;
            e.ValidPress = answer;
        }
    }
}
