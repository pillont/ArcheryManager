using ArcheryManager.Models;
using ArcheryManager.Pages;
using ArcheryManager.Settings;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ArcheryManager.CustomControls
{
    public partial class RemarkEditor : ContentView
    {
        private const int BaseFlightIndex = 1;

        private static readonly IGeneralCounterSetting GeneralCounterSetting = DependencyService.Get<IGeneralCounterSetting>();

        public bool HaveText
        {
            get
            {
                return !string.IsNullOrWhiteSpace(CurrentText);
            }
        }

        public static readonly BindableProperty AreGeneralRemarksProperty =
                      BindableProperty.Create(nameof(AreGeneralRemarks), typeof(bool), typeof(RemarkEditor), false);

        public bool AreGeneralRemarks
        {
            get { return (bool)GetValue(AreGeneralRemarksProperty); }
            set { SetValue(AreGeneralRemarksProperty, value); }
        }

        public static readonly BindableProperty CurrentTextProperty =
                      BindableProperty.Create(nameof(CurrentText), typeof(string), typeof(RemarkEditor), string.Empty);

        public string CurrentText
        {
            get { return (string)GetValue(CurrentTextProperty); }
            set
            {
                SetValue(CurrentTextProperty, value);
                OnPropertyChanged(nameof(HaveText));
            }
        }

        public static readonly BindableProperty TitleProperty =
                      BindableProperty.Create(nameof(Title), typeof(string), typeof(RemarkEditor), string.Empty);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty PreviousProperty =
                      BindableProperty.Create(nameof(Previous), typeof(ObservableCollection<Remark>), typeof(RemarkEditor), null);

        public ObservableCollection<Remark> Previous
        {
            get { return (ObservableCollection<Remark>)GetValue(PreviousProperty); }
            set { SetValue(PreviousProperty, value); }
        }

        public RemarkEditor()
        {
            InitializeComponent();
            BindingContext = this;
            Previous = new ObservableCollection<Remark>();
        }

        private void Valid_Click(object sender, EventArgs e)
        {
            var remark = new Remark() { Text = CurrentText };
            if (!AreGeneralRemarks)
            {
                remark.FlightIndex = GeneralCounterSetting.ScoreResult.FlightsSaved.Count + BaseFlightIndex;
            }
            Previous.Add(remark);

            CurrentText = string.Empty;
        }

        private async void Previous_Click(object sender, EventArgs e)
        {
            try
            {
                var page = new ListRemarks(Previous, AreGeneralRemarks) { Title = Title };
                await App.NavigationPage.PushAsync(page);
            }
            catch (Exception ee)
            {
                throw;
            }
        }
    }
}
