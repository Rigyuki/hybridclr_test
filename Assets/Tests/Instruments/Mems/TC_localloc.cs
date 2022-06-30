using System;
using SharpUnit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Instruments.Mems
{
    internal class TC_localloc: GeneralTestCaseBase
    {
        [UnitTest]
        public unsafe static void alloc_0()
        {
            int* b = stackalloc int[0];
            Assert.Equal(null, b);
        }

        [UnitTest]
        public unsafe static void alloc_1()
        {
            int* b = stackalloc int[3];
            Assert.Equal(0, b[0]);
            Assert.Equal(0, b[1]);
            Assert.Equal(0, b[2]);
            b[0] = 1;
            b[1] = 2;
            b[2] = 3;
            Assert.Equal(1, b[0]);
        }
    }
}
