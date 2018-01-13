using ArcheryManager.Entities;
using ArcheryManager.Helpers;
using ArcheryManager.Pages;
using ArcheryManager.Resources;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemarkEditor : ContentView
    {
        public event EventHandler Completed
        {
            add { editor.Completed += value; }
            remove { editor.Completed -= value; }
        }

        public static readonly BindableProperty AreGeneralRemarksProperty =
                      BindableProperty.Create(nameof(AreGeneralRemarks), typeof(bool), typeof(RemarkEditor), false);

        public static readonly BindableProperty CurrentTextProperty =
                      BindableProperty.Create(nameof(CurrentText), typeof(string), typeof(RemarkEditor), string.Empty);

        public static readonly BindableProperty PreviousProperty =
                      BindableProperty.Create(nameof(Previous), typeof(ObservableCollection<Remark>), typeof(RemarkEditor), null);

        public static readonly BindableProperty TitleProperty =
                      BindableProperty.Create(nameof(Title), typeof(string), typeof(RemarkEditor), string.Empty);

        private readonly string EmptyMessage;

        public bool AreGeneralRemarks
        {
            get { return (bool)GetValue(AreGeneralRemarksProperty); }
            set { SetValue(AreGeneralRemarksProperty, value); }
        }

        public string CurrentText
        {
            get { return (string)GetValue(CurrentTextProperty); }
            set
            {
                SetValue(CurrentTextProperty, value);
                OnPropertyChanged(nameof(HaveText));
            }
        }

        public bool HaveText
        {
            get
            {
                return !string.IsNullOrWhiteSpace(CurrentText) && CurrentText != EmptyMessage;
            }
        }

        public ObservableCollection<Remark> Previous
        {
            get { return (ObservableCollection<Remark>)GetValue(PreviousProperty); }
            set { SetValue(PreviousProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public RemarkEditor()
        {
            EmptyMessage = AppResources.EnterRemarksHere;
            InitializeComponent();
            generalLayer.BindingContext = this;
            Previous = new ObservableCollection<Remark>();
            Editor_Unfocused(editor, null);
        }

        private void editor_Completed(object sender, EventArgs e)
        {
            this.Unfocus();
        }

        private void Editor_Focused(object sender, FocusEventArgs e)
        {
            var editor = sender as Editor;
            if (CurrentText == EmptyMessage)
            {
                CurrentText = string.Empty;
                editor.TextColor = Color.Black;
            }
        }

        private void Editor_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentText))
            {
                var editor = sender as Editor;

                CurrentText = EmptyMessage;
                editor.TextColor = Color.Gray;
            }
        }

        private async void Previous_Click(object sender, EventArgs e)
        {
            var page = new ListRemarks(Previous, AreGeneralRemarks) { Title = Title };
            MessagingCenterHelper.PushInNavigationPage(this, page);
        }

        private void Valid_Click(object sender, EventArgs e)
        {
            var remark = new Remark() { Text = CurrentText };
            Previous.Add(remark);

            CurrentText = string.Empty;

            Editor_Unfocused(editor, null);
        }
    }
}
