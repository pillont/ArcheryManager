using ArcheryManager.Helpers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Mvvm;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogPage : ContentPage
    {
        public LogPage()
        {
            InitializeComponent();
        }
    }

    public class LogPageViewModel : ViewModel
    {
        private const string MessageFileNotExisting = "Log file not existing";
        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                NotifyPropertyChanged(nameof(Text));
            }
        }

        public LogPageViewModel()
        {
            try
            {
                Text = LoggerHelper.ReadLog();
            }
            catch (FileNotFoundException e)
            {
                Text = MessageFileNotExisting;
            }
        }
    }
}
