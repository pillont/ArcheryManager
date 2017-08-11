using Xamarin.Forms;
using UIKit;
using ArcheryManager.iOS;
using ArcheryManager.Settings;

[assembly: Dependency(typeof(IOSKeyboardHelper))]

namespace ArcheryManager.iOS
{
    public class IOSKeyboardHelper : IKeyboardHelper
    {
        public void HideKeyboard()
        {
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
        }
    }
}
