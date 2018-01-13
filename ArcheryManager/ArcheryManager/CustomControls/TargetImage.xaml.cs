using ArcheryManager.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TargetImage : ContentView
    {
        public enum TargetStyle
        {
            EnglishTarget,
            FieldTarget,
            IndoorRecurveTarget,
            IndoorCompoundTarget,
        }

        public static readonly BindableProperty ColorProperty =
                      BindableProperty.Create(nameof(Color), typeof(Color), typeof(TargetImage), Color.Transparent);

        public static readonly BindableProperty SourceProperty =
                      BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(TargetImage), null);

        public static readonly BindableProperty TextProperty =
                      BindableProperty.Create(nameof(Text), typeof(string), typeof(TargetImage), string.Empty);

        private const bool DefaultIsSelected = false;

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public TargetStyle StyleTarget { get; set; }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public TargetImage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
