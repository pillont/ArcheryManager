using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ArcheryManager.Utils
{
    public class ListViewGroup<T> : ObservableCollection<T>
    {
        public String Name { get; set; }
        public String ShortName { get; set; }

        public ListViewGroup(IEnumerable<T> collection)
            : base(collection)
        {
        }
    }
}
