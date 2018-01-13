using ArcheryManager.Controllers;
using ArcheryManager.Resources;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;
using static ArcheryManager.CustomControls.TargetImage;
using System;
using ArcheryManager.Utils;
using ArcheryManager.Entities;
using ArcheryManager.Helpers;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BackDoorPage : ContentPage
    {
        public BackDoorPage()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
    }

    public class BackDoorPageViewModel : ViewModel
    {
        private readonly PageOpenerController Controller;
        public ICommand AddCounterClicked => new Command(AddCounter);
        public ICommand ButtonCounterClicked => new Command(Controller.OpenEnglishButtonsCounterPage);
        public ICommand ConnectedShootCommand => new Command(Controller.ConnectedShoot);
        public ICommand CounterSelectorClicked => new Command(Controller.OpenCounterSelector);
        public ISQLiteConnectionManager DBSaver { get; }
        public ICommand GeneralMenuClicked => new Command(Controller.OpenGeneralMenuPage);
        public ICommand LogClicked => new Command(Controller.OpenLogPage);
        public ICommand RemarksClicked => new Command(Controller.OpenRemarksPage);
        public ICommand SavesClicked => new Command(Controller.OpenSaveCounterList);
        public ICommand TargetClick => new Command<Button>(OpenTarget);
        public ICommand TimerClick => new Command(Controller.OpenTimerPage);

        public BackDoorPageViewModel(PageOpenerController controller, ISQLiteConnectionManager dBSaver)
        {
            DBSaver = dBSaver;
            Controller = controller;
        }

        public void OpenTarget(Button btn)
        {
            TargetStyle style;
            if (btn.Text == AppResources.EnglishTarget)
            {
                style = TargetStyle.EnglishTarget;
            }
            else if (btn.Text == AppResources.FieldTarget)
            {
                style = TargetStyle.FieldTarget;
            }
            else if (btn.Text == AppResources.IndoorCompoundTarget)
            {
                style = TargetStyle.IndoorCompoundTarget;
            }
            else // indoorRecurveTargetButton
            {
                style = TargetStyle.IndoorRecurveTarget;
            }

            Controller.OpenTarget(style);
        }

        private void AddCounter()
        {
            Random random = new Random();

            var date = new DateTime(2017, 05, 5);
            for (int day = 0; day < 7; day++)
            {
                int max = Enum.GetNames(typeof(TargetStyle)).Length;
                for (int count = 0; count < max; count++)
                {
                    var counter = new CountedShoot()
                    {
                        CreationDate = date,
                        TargetStyle = (TargetStyle)count,
                        IsFinished = random.Next(0, 2) == 0,
                    };

                    DBSaver.InsertOrReplaceWithChildrenRecursivelyAsync(counter);

                    var man = new ScoreCounter(counter, DBSaver, null);
                    man.NewFlight();
                    for (int arrow = 0; arrow < 10; arrow++)
                    {
                        man.AddArrowIfPossible(new Arrow() { Index = 5 });
                    }
                }
                date = date.AddDays(1);
            }

            MessagingCenterHelper.SendToast(this, "shoot adding", "shoot was added", "OK");
        }
    }
}
