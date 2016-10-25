using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class TargetByType
    {
        public virtual void PublicVirtualMethodNotDecorated()
        {
            TestRecords.RecordBody("PublicVirtualMethodNotDecorated");
        }

        protected virtual void ProtectedVirtualMethodNotDecorated()
        {
            TestRecords.RecordBody("ProtectedVirtualMethodNotDecorated");
        }

    }

}
