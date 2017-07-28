using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ArcheryManager.UnitTest
{
    public class MockableBindableObject : BindableObject
    {
        public new virtual object BindingContext
        {
            get
            {
                return base.BindingContext;
            }
            set
            {
                base.BindingContext = value;
            }
        }
    }
}
