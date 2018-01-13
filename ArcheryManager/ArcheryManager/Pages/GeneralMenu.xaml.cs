using ArcheryManager.Controllers;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeneralMenu : ContentPage
    {
        public GeneralMenu()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
    }

    public class GeneralMenuViewModel : ViewModel
    {
        private readonly PageOpenerController Controller;

        public ICommand CounterTapped => new Command(Controller.OpenCounterSelector);
        public ICommand SavesCommand => new Command(Controller.OpenSaveCounterList);
        public ICommand TimerTapped => new Command(Controller.OpenTimerPage);

        public GeneralMenuViewModel(PageOpenerController controller)
        {
            Controller = controller;
        }
    }
}
