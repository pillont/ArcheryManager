using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ArcheryManager.CustomControls
{
    public partial class TargetImage : ContentView
    {
        public static readonly BindableProperty TextProperty =
                      BindableProperty.Create(nameof(Text), typeof(string), typeof(TargetImage), string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty SourceProperty =
                      BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(TargetImage), null);

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public TargetImage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
