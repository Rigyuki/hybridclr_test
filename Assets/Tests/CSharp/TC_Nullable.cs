using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CSharp
{
    internal class TC_Nullable : GeneralTestCaseBase
    {
        [UnitTest]
        public void int_1()
        {
            var a = (int?)1;
            Assert.True(a == 1);
        }


        [UnitTest]
        public void char_1()
        {
            var a = (char?)'.';
            Assert.True(a == '.');
        }
    }
}
