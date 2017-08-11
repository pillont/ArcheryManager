using Android.App;
using Android.Content;
using Android.Views.InputMethods;
using ArcheryManager.Droid.Services;
using ArcheryManager.Settings;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidKeyboardHelper))]

namespace ArcheryManager.Droid.Services
{
    public class DroidKeyboardHelper : IKeyboardHelper
    {
        public void HideKeyboard()
        {
            var inputMethodManager = Xamarin.Forms.Forms.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            if (inputMethodManager != null && Xamarin.Forms.Forms.Context is Activity)
            {
                var activity = Xamarin.Forms.Forms.Context as Activity;
                var token = activity.CurrentFocus == null ? null : activity.CurrentFocus.WindowToken;
                inputMethodManager.HideSoftInputFromWindow(token, 0);
            }
        }
    }
}
