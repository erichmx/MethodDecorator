using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class TargetByGenericTypeInherited : TargetByGenericType<String>
    {
        public override void PublicVirtualMethodNotDecorated()
        {
            TestRecords.RecordBody("PublicOverridedVirtualMethodNotDecorated");
        }
        public String PublicNewMethodNotDecorated()
        {
            TestRecords.RecordBody("PublicNewMethodNotDecorated");
            return "returns PublicNewMethodNotDecorated";
        }
    }
}
