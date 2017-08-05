using ArcheryManager.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ArcheryManager.Settings
{
    public class RemarksSaved : BindableObject
    {
        public static readonly BindableProperty GeneralRemarksProperty =
                              BindableProperty.Create(nameof(GeneralRemarks), typeof(ObservableCollection<Remark>), typeof(RemarksSaved), null);

        public ObservableCollection<Remark> GeneralRemarks
        {
            get { return (ObservableCollection<Remark>)GetValue(GeneralRemarksProperty); }
            set { SetValue(GeneralRemarksProperty, value); }
        }

        public static readonly BindableProperty FlightRemarkProperty =
                      BindableProperty.Create(nameof(FlightRemark), typeof(ObservableCollection<Remark>), typeof(RemarksSaved), null);

        public ObservableCollection<Remark> FlightRemark
        {
            get { return (ObservableCollection<Remark>)GetValue(FlightRemarkProperty); }
            set { SetValue(FlightRemarkProperty, value); }
        }

        public RemarksSaved()
        {
            FlightRemark = new ObservableCollection<Remark>();
            GeneralRemarks = new ObservableCollection<Remark>();
        }
    }
}
