using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace ArcheryManager.Entities
{
    public class BaseEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime CreationDate { get; set; }

        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }

        public DateTime LastChangeDate { get; set; }

        public BaseEntity()
        {
            PropertyChanged += BaseEntity_PropertyChanged;
            CreationDate = DateTime.Now;
            UpdateModificationDate();
        }

        public void OnPropertyChange(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        protected void UpdateModificationDate()
        {
            LastChangeDate = DateTime.Now;
        }

        private void BaseEntity_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName != nameof(LastChangeDate))
                UpdateModificationDate();
        }
    }
}
