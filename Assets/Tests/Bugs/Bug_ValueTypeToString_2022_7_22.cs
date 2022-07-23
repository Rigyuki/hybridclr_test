using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Bugs
{

    internal class Bug_ValueTypeToString_2022_7_22 : GeneralTestCaseBase
    {
        [UnitTest]
        public void tostring()
        {
            var p = new KeyValuePair<ulong, int>(1, 2);
            var s = p.ToString();
            Assert.Equal("[1, 2]", s);
        }
    }
}
