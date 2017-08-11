using ArcheryManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcheryManager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListRemarks : ContentPage
    {
        public ListRemarks(IEnumerable<Remark> list, bool areGeneralRemarks)
        {
            try
            {
                InitializeComponent();

                BindingContext = new ListRemarksViewModel(list, !areGeneralRemarks);
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        internal class ListRemarksViewModel : BindableObject
        {
            public static readonly BindableProperty IsEmptyListProperty =
                          BindableProperty.Create(nameof(IsEmptyList), typeof(bool), typeof(ListRemarksViewModel), true);

            public bool IsEmptyList
            {
                get { return (bool)GetValue(IsEmptyListProperty); }
                set { SetValue(IsEmptyListProperty, value); }
            }

            public static readonly BindableProperty ItemsProperty =
                          BindableProperty.Create(nameof(Items), typeof(ObservableCollection<Remark>), typeof(ListRemarksViewModel), null);

            public ObservableCollection<Remark> Items
            {
                get { return (ObservableCollection<Remark>)GetValue(ItemsProperty); }
                set
                {
                    if (Items != null)
                    {
                        Items.CollectionChanged -= Items_CollectionChanged;
                    }

                    SetValue(ItemsProperty, value);
                    Items.CollectionChanged += Items_CollectionChanged;

                    Items_CollectionChanged(Items, null);
                }
            }

            private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                IsEmptyList = Items.Count == 0;
            }

            public static readonly BindableProperty AreNotGeneralRemarksProperty =
                          BindableProperty.Create(nameof(AreNotGeneralRemarks), typeof(bool), typeof(ListRemarksViewModel), true);

            public bool AreNotGeneralRemarks
            {
                get { return (bool)GetValue(AreNotGeneralRemarksProperty); }
                set { SetValue(AreNotGeneralRemarksProperty, value); }
            }

            public ListRemarksViewModel(IEnumerable<Remark> list, bool areNotGeneralRemarks)
            {
                Items = new ObservableCollection<Remark>(list);
                AreNotGeneralRemarks = areNotGeneralRemarks;
            }
        }
    }
}
