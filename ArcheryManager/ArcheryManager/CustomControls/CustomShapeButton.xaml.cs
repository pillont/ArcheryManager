using System;
using Xamarin.Forms;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    public partial class CustomShapeButton : ContentView
    {
        public static readonly BindableProperty BorderWidthProperty =
                      BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(CustomShapeButton), 1d);

        public double BorderWidth
        {
            get { return (double)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
                      BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CustomShapeButton), Color.Black);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty ShapeTypeProperty =
                         BindableProperty.Create(nameof(ShapeType), typeof(ShapeType), typeof(CustomShapeButton), ShapeType.Oval);

        public ShapeType ShapeType
        {
            get { return (ShapeType)GetValue(ShapeTypeProperty); }
            set { SetValue(ShapeTypeProperty, value); }
        }

        public static readonly BindableProperty ColorProperty =
                      BindableProperty.Create(nameof(Color), typeof(Color), typeof(CustomShapeButton), Color.LightGray);

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
                      BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomShapeButton), string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty FontAttributesProperty =
                      BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(CustomShapeButton), FontAttributes.None);

        private readonly TapGestureRecognizer recognizer;

        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { SetValue(FontAttributesProperty, value); }
        }

        public event EventHandler Tapped
        {
            add
            {
                recognizer.Tapped += value;
            }
            remove
            {
                recognizer.Tapped -= value;
            }
        }

        public CustomShapeButton()
        {
            this.BindingContext = this;
            InitializeComponent();

            recognizer = new TapGestureRecognizer();
            GestureRecognizers.Add(recognizer);
        }
    }
}
