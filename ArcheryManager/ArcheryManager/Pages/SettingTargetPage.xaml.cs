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

        /// <summary>
        /// limit min of Arrow count to const
        /// </summary>
        private void ArrowCount_Unfocused(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
            int val = Convert.ToInt32(entry.Text);
            if (val < TargetSetting.MinArrowCount)
            {
                if (BindingContext != null)
                {
                    BindingContext.ArrowsCount = TargetSetting.MinArrowCount;
                }
            }
        }
    }
}
