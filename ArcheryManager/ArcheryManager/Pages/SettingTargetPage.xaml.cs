using ArcheryManager.Utils;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingTargetPage : ContentPage
    {
        public new TargetSetting BindingContext
        {
            get
            {
                if (base.BindingContext is TargetSetting)
                {
                    return base.BindingContext as TargetSetting;
                }
                else
                {
                    throw new InvalidCastException("binding target of " + nameof(SettingTargetPage) + " must be Target setting");
                }
            }
            set
            {
                base.BindingContext = value;
            }
        }

        public SettingTargetPage()
        {
            InitializeComponent();
        }
    }
}
