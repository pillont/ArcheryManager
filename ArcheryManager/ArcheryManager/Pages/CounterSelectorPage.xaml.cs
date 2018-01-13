using ArcheryManager.Controllers;
using ArcheryManager.CustomControls;
using ArcheryManager.Entities;
using ArcheryManager.Factories;
using ArcheryManager.Helpers;
using ArcheryManager.Pages.PagesTemplates;
using ArcheryManager.Resources;
using ArcheryManager.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;
using static ArcheryManager.CustomControls.TargetImage;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterSelectorPage : ContentPageWithGeneralEvent
    {
        public new CounterSelectorPageViewModel BindingContext
        {
            get
            {
                return base.BindingContext as CounterSelectorPageViewModel;
            }
        }

        public CounterSelectorPage()
        {
            InitializeComponent();
            PagePushed += OnPushed;
        }

        public void SelectTarget(TargetImage image)
        {
            image.Color = Color.Aquamarine;
            BindingContext.TargetStyle = image.StyleTarget;

            var others = imageGrid.Children.Where(i => i != image);
            foreach (TargetImage i in others)
            {
                i.Color = Color.Transparent;
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            //TODO : use mvvm for manage imageGrid items
            foreach (var image in imageGrid.Children)
            {
                var tap = new TapGestureRecognizer();
                tap.Tapped += Image_Tapped;
                image.GestureRecognizers.Add(tap);
            }

            var first = imageGrid.Children.First() as TargetImage;
            SelectTarget(first);
        }

        protected void OnPushed(object sender, EventArgs arg)
        {
            var validButton = new ToolbarItem()
            {
                Text = AppResources.Valid,
                Command = new Command(() => BindingContext.Valid()),
            };

            var argEvent = new ToolbarItemsArg()
            {
                PageType = typeof(CounterSelectorPage),
                ToolbarItem = validButton
            };
            MessagingCenterHelper.AddToolbarItem(this, argEvent);
        }

        private void Image_Tapped(object sender, EventArgs e)
        {
            SelectTarget(sender as TargetImage);
        }
    }

    public class CounterSelectorPageViewModel : ViewModel
    {
        private readonly CounterManager CounterManager;
        private readonly TargetStarterController TargetStarterController;

        public bool HaveTarget
        {
            get { return Shoot.HaveTarget; }
            set { Shoot.HaveTarget = value; }
        }

        public bool IsWaiting { get; private set; }

        public LimitArrowNumberSelectorViewModel LimitArrowNumberSelectorViewModel
        {
            get
            {
                return new LimitArrowNumberSelectorViewModel(Shoot);
            }
        }

        public CountedShoot Shoot => CounterManager.CurrentShoot;

        internal TargetStyle TargetStyle
        {
            set
            {
                CounterManager.CurrentShoot.TargetStyle = value;
            }
        }

        public CounterSelectorPageViewModel(CounterManager counterManager, TargetStarterController starter)
        {
            TargetStarterController = starter;
            IsWaiting = false;
            CounterManager = counterManager;
            CounterManager.CurrentShoot = new CountedShoot();
        }

        public void Valid()
        {
            TargetStarterController.StartPage();
        }
    }
}
