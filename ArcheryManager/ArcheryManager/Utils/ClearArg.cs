using System;
using System.Collections.Generic;

namespace ArcheryManager.Utils
{
    public class ClearArg<T>
    {
        public event EventHandler<IEnumerable<T>> Cleared;

        public Type PageType { get; set; }

        public void OnCleared(object sender, List<T> list)
        {
            Cleared?.Invoke(sender, list);
        }
    }
}
