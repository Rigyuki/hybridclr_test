using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CSharp
{

    class ConstString
    {
        public const string Str = "abc";
    }

    internal class TC_Reflection : GeneralTestCaseBase
    {
        [UnitTest]
        public void const_string()
        {
            var strField = typeof(ConstString).GetField("Str");
            string s = (string)strField.GetValue(null);
            Assert.Equal("abc", s);
        }
    }
}
