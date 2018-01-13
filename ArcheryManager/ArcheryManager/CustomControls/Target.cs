using ArcheryManager.Entities;
using ArcheryManager.Factories;
using ArcheryManager.Helpers;
using ArcheryManager.Interactions.Behaviors;
using ArcheryManager.Interfaces;
using ArcheryManager.Settings.ArrowSettings;
using ArcheryManager.Utils;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using XFShapeView;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.CustomControls
{
    public class Target : ContentView, IMovableTarget
    {
        #region constants

        /// <summary>
        /// width of the arrow in the target
        /// </summary>
        public const int ArrowWidth = 7;

        /// <summary>
        /// ratio to define the width of the zone
        /// </summary>
        public const double ColorWidthRatio = 1.02;

        /// <summary>
        /// width of the target strings
        /// </summary>
        public const int StringWidth = 1;

        public static readonly BindableProperty TargetSizeProperty =
                              BindableProperty.Create(nameof(TargetSize), typeof(double), typeof(Target), DefaultTargetSize);

        /// <summary>
        /// width of the arrow in the zoomed target
        /// </summary>
        private const double ArrowWidthZommed = ArrowWidth * MovableTargetBehavior.TargetScale;

        /// <summary>
        /// size of the target
        /// </summary>
        private const double DefaultTargetSize = 320;

        /// <summary>
        /// color of the arrows in the target
        /// </summary>
        private readonly Color ArrowColor = Color.Green;

        /// <summary>
        /// color of the point to set arrow
        /// </summary>
        private readonly Color ArrowSetterColor = Color.Fuchsia;

        private readonly Color PreviousArrowsColor = Color.DarkGray;

        #endregion constants

        /// <summary>
        /// point to set arrow during manipulation
        /// </summary>
        public ShapeView ArrowSetter { get; private set; }

        public new TargetViewModel BindingContext
        {
            get
            {
                return base.BindingContext as TargetViewModel;
            }
        }

        public ArrowFactory Factory { get; private set; }

        /// <summary>
        /// gris container of the target
        /// </summary>
        public Grid TargetGrid { get; private set; }

        public virtual double TargetSize
        {
            get { return (double)GetValue(TargetSizeProperty); }
            set
            {
                SetValue(TargetSizeProperty, value);
                PreviousArrowGrid.TargetSize = TargetSize;
                ArrowGrid.TargetSize = TargetSize;
            }
        }

        #region target layout

        public readonly AverageCanvas AverageCanvas;
        internal readonly ArrowsGrid ArrowGrid;

        internal readonly ArrowsGrid PreviousArrowGrid;

        #endregion target layout

        public Target()
        {
            /*
             * target layout
             */
            PreviousArrowGrid = new ArrowsGrid()
            {
                AutomationId = "lastArrowInTargetGrid",
                ArrowWidth = ArrowWidth,
                ArrowColor = PreviousArrowsColor
            };
            AverageCanvas = new AverageCanvas()
            {
                AutomationId = "averageCanvas",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            ArrowGrid = new ArrowsGrid()
            {
                AutomationId = "arrowInTargetGrid",
                ArrowWidth = ArrowWidth,
                ArrowColor = CommonConstant.DefaultArrowColor
            };

            CreateContent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                Factory = new ArrowFactory(this, BindingContext.ArrowSetting);
                DrawTargetVisual();

                var binding = new Binding(nameof(TargetViewModel.ShowAllArrows));
                PreviousArrowGrid.SetBinding(IsVisibleProperty, binding);

                binding = new Binding(nameof(TargetViewModel.AverageIsVisible));
                AverageCanvas.SetBinding(IsVisibleProperty, binding);

                ArrowGrid.SetBinding(ArrowsGrid.ItemsProperty, new Binding() { Source = BindingContext, Path = nameof(BindingContext.CurrentArrows) });
                PreviousArrowGrid.SetBinding(ArrowsGrid.ItemsProperty, new Binding() { Source = BindingContext, Path = nameof(BindingContext.PreviousArrows) });
            }
        }

        #region visual of the target

        /// <summary>
        /// function to generate TargetGrid
        /// init and add all shapes in the grid
        /// </summary>
        public void DrawTargetVisual()
        {
            TargetGrid.Children.Clear();

            for (int i = 1; i < Factory.Setting.ZoneCount; i++)
            {
                double rate = (Factory.Setting.ZoneCount - i * ColorWidthRatio) / Factory.Setting.ZoneCount;

                var shape = new ShapeView
                {
                    HeightRequest = TargetSize * rate, //TODO
                    WidthRequest = TargetSize * rate, //TODO
                    ShapeType = ShapeType.Circle,
                    BorderColor = BindingContext.ArrowSetting.BorderColorZone(i),
                    Color = BindingContext.ArrowSetting.ColorofTargetZone(i),
                    BorderWidth = StringWidth,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    AutomationId = "zone" + i,
                };

                TargetGrid.Children.Add(shape);
            }

            var center = new ShapeView
            {
                HeightRequest = 2,
                WidthRequest = 2,
                ShapeType = ShapeType.Circle,
                BorderColor = Color.Black,
                Color = Color.Black,
                BorderWidth = 1,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                AutomationId = "center",
            };

            TargetGrid.Children.Add(center);//TODO layout builder
            TargetGrid.Children.Add(AverageCanvas); //TODO layout builder
            TargetGrid.Children.Add(PreviousArrowGrid);//TODO layout builder
            TargetGrid.Children.Add(ArrowGrid);//TODO layout builder
        }

        /// <summary>
        /// create the target content
        /// </summary>
        private void CreateContent()
        {
            TargetGrid = new Grid();

            CreateVisualArrowSetter();

            Grid globalGrid = new Grid();
            globalGrid.Children.Add(TargetGrid);
            globalGrid.Children.Add(ArrowSetter);

            Content = globalGrid;
        }

        /// <summary>
        /// generate ArrowSetter
        /// </summary>
        private void CreateVisualArrowSetter()
        {
            ArrowSetter = new ShapeView()
            {
                HeightRequest = ArrowWidthZommed,
                WidthRequest = ArrowWidth * MovableTargetBehavior.TargetScale,
                ShapeType = ShapeType.Circle,
                BorderColor = Color.Black,
                Color = ArrowSetterColor,
                BorderWidth = 1,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                IsVisible = false,
            };
        }

        #endregion visual of the target
    }

    public class TargetViewModel : ViewModel
    {
        public readonly IArrowSetting ArrowSetting;
        private readonly ScoreCounter Counter;
        private readonly CountedShoot Shoot;

        public bool AverageIsVisible
        {
            get
            {
                return Shoot.AverageIsVisible;
            }
        }

        public ObservableCollection<Arrow> PreviousArrows => new ObservableCollection<Arrow>(Counter.PreviousArrow);

        public bool ShowAllArrows
        {
            get
            {
                return Shoot.ShowAllArrows;
            }
        }

        // NOTE : set observable collections to keep the type of ItemGrid.Items
        public ObservableCollection<Arrow> CurrentArrows => Counter.CurrentArrows != null
                                                                    ? new ObservableCollection<Arrow>(Counter.CurrentArrows)
                                                                                                : new ObservableCollection<Arrow>();

        public TargetViewModel(CounterManager manager)
        {
            Shoot = manager.CurrentShoot;
            var arrowSetting = ArrowSettingFactory.Create(Shoot.TargetStyle);
            ArrowSetting = arrowSetting;

            Counter = manager.Counter;
            Counter.PropertyChanged += Counter_PropertyChanged;
            Shoot.PropertyChanged += Shoot_PropertyChanged;
            Shoot_PropertyChanged(this, new PropertyChangedEventArgs(nameof(CountedShoot.ShowAllArrows)));
        }

        private void Counter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Counter.PreviousArrow))
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(PreviousArrows)));
            }
            else if (e.PropertyName == nameof(Counter.CurrentArrows))
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentArrows)));
            }
        }

        /// <summary>
        /// show previous arrow if value of ShowAllArrows change
        /// show average if value of AverageIsVisible change
        /// </summary>
        private void Shoot_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CountedShoot.ShowAllArrows))
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(TargetViewModel.ShowAllArrows)));
            }

            if (e.PropertyName == nameof(CountedShoot.AverageIsVisible))
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(TargetViewModel.AverageIsVisible)));
            }
        }
    }
}
