using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class TargetByTypeInherited : TargetByType
    {
        public override void PublicVirtualMethodNotDecorated()
        {
            TestRecords.RecordBody("PublicOverridedVirtualMethodNotDecorated");
        }
        public void PublicNewMethodNotDecorated()
        {
            TestRecords.RecordBody("PublicNewMethodNotDecorated");
        }
    }
}
