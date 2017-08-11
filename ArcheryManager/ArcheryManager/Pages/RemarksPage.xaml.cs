using ArcheryManager.Models;
using ArcheryManager.Settings;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemarksPage : ContentPage
    {
        private static readonly IGeneralCounterSetting GeneralCounterSetting = DependencyService.Get<IGeneralCounterSetting>();

        public ObservableCollection<Remark> FlightRemarkSaved => GeneralCounterSetting.RemarksSaved.FlightRemark;
        public ObservableCollection<Remark> GeneralRemarkSaved => GeneralCounterSetting.RemarksSaved.GeneralRemarks;

        public RemarksPage()
        {
            try
            {
                InitializeComponent();
                FlightRemarksEditor.Previous = FlightRemarkSaved;
                GeneralRemarksEditor.Previous = GeneralRemarkSaved;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
