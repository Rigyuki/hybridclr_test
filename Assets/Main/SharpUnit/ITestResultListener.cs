using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharpUnit
{
    public interface ITestResultListener
    {
        void TestPass(TestCase testCase, MethodInfo method);

        void TestFailed(TestCase testCase, MethodInfo method, Exception error);
    }
}
