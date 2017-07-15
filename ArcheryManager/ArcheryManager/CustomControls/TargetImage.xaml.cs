using Xamarin.Forms;

namespace ArcheryManager.CustomControls
{
    public partial class TargetImage : ContentView
    {
        public enum TargetStyle
        {
            EnglishTarget,
            FieldTarget,
            IndoorRecurveTarget,
            IndoorCompoundTarget,
        }

        public TargetStyle StyleTarget { get; set; }
        private const bool DefaultIsSelected = false;

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

        public static readonly BindableProperty IsSelectedProperty =
                      BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(TargetImage), DefaultIsSelected);

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public TargetImage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
