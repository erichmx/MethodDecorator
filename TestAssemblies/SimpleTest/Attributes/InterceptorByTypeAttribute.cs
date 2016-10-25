using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MethodDecoratorInterfaces;

namespace SimpleTest.Attributes
{
    namespace SimpleTest
    {
        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
        public class InterceptorByTypeAttribute : MethodDecoratorByTypeAttribute
        {
            public void Init(object instance, MethodBase method, object[] args)
            {
                if (null == method) throw new ArgumentNullException("method");
                TestRecords.RecordInit(instance, method.DeclaringType.FullName + "." + method.Name, args.Length);
            }
            public void OnEntry()
            {
                TestRecords.RecordOnEntry();
            }

            public void OnExit()
            {
                TestRecords.RecordOnExit();
            }

            public void OnException(Exception exception)
            {
                TestRecords.RecordOnException(exception.GetType(), exception.Message);
            }

            public void OnTaskContinuation(Task t)
            {
                TestRecords.RecordOnContinuation();
            }
        }
    }
}
