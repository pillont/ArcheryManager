using ArcheryManager.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterSelectorPage : ContentPage
    {
        private Setting setting;

        public CounterSelectorPage()
        {
            InitializeComponent();
            setting = new Setting();
            this.BindingContext = setting;
        }

        /// <summary>
        /// limit min of Arrow count to const
        /// </summary>
        private void ArrowCount_Unfocused(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
            int val = Convert.ToInt32(entry.Text);
            if (val < Setting.MinArrowCount)
            {
                if (BindingContext != null)
                {
                    setting.ArrowsCount = Setting.MinArrowCount;
                }
            }
        }
    }

    public class Setting : BindableObject
    {
        public const int MinArrowCount = 3;
        public const int DefaultArrowCount = 6;
        private const bool DefaultWantTarget = true;

        public static readonly BindableProperty ArrowsCountProperty =
                      BindableProperty.Create(nameof(ArrowsCount), typeof(int), typeof(Setting), DefaultArrowCount);

        public int ArrowsCount
        {
            get { return (int)GetValue(ArrowsCountProperty); }
            set { SetValue(ArrowsCountProperty, value); }
        }

        public static readonly BindableProperty HaveMaxArrowsCountProperty =
                     BindableProperty.Create(nameof(HaveMaxArrowsCount), typeof(bool), typeof(Setting), false);

        public bool HaveMaxArrowsCount
        {
            get { return (bool)GetValue(HaveMaxArrowsCountProperty); }
            set { SetValue(HaveMaxArrowsCountProperty, value); }
        }

        public static readonly BindableProperty WantTargetProperty =
                      BindableProperty.Create(nameof(WantTarget), typeof(bool), typeof(Setting), DefaultWantTarget);

        public bool WantTarget
        {
            get { return (bool)GetValue(WantTargetProperty); }
            set { SetValue(WantTargetProperty, value); }
        }
    }
}
