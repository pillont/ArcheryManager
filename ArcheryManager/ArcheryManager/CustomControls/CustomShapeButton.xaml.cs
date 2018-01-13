using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFShapeView;

namespace ArcheryManager.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomShapeButton : ContentView
    {
        public event EventHandler Tapped
        {
            add
            {
                Recognizer.Tapped += value;
            }
            remove
            {
                Recognizer.Tapped -= value;
            }
        }

        public static readonly BindableProperty BorderColorProperty =
                      BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CustomShapeButton), Color.Black);

        public static readonly BindableProperty BorderWidthProperty =
                                      BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(CustomShapeButton), 1d);

        public static readonly BindableProperty ColorProperty =
                      BindableProperty.Create(nameof(Color), typeof(Color), typeof(CustomShapeButton), Color.LightGray);

        public static readonly BindableProperty CommandParameterProperty =
                      BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(CustomShapeButton), null);

        public static readonly BindableProperty CommandProperty =
                      BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CustomShapeButton), null);

        public static readonly BindableProperty FontAttributesProperty =
                      BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(CustomShapeButton), FontAttributes.None);

        public static readonly BindableProperty ShapeTypeProperty =
                         BindableProperty.Create(nameof(ShapeType), typeof(ShapeType), typeof(CustomShapeButton), ShapeType.Oval);

        public static readonly BindableProperty TextProperty =
                      BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomShapeButton), string.Empty);

        private readonly TapGestureRecognizer Recognizer;

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public double BorderWidth
        {
            get { return (double)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { SetValue(FontAttributesProperty, value); }
        }

        public ShapeType ShapeType
        {
            get { return (ShapeType)GetValue(ShapeTypeProperty); }
            set { SetValue(ShapeTypeProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public CustomShapeButton()
        {
            PropertyChanged += CustomShapeButton_PropertyChanged;
            InitializeComponent();
            generalGrid.BindingContext = this;

            #region create tap recognizer

            Recognizer = new TapGestureRecognizer();
            //get default values
            Command = Recognizer.Command;
            CommandParameter = Recognizer.CommandParameter;
            GestureRecognizers.Add(Recognizer);

            #endregion create tap recognizer
        }

        private void CustomShapeButton_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Command):
                    Recognizer.Command = Command;
                    break;

                case nameof(CommandParameter):
                    Recognizer.CommandParameter = CommandParameter;
                    break;
            }
        }
    }
}
