using ArcheryManager.iOS;
using ArcheryManager.Settings;
using UIKit;
using Xamarin.Forms;

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
