using AOTDefs;
using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Tests.Instruments.Objs
{
    internal class TC_sizeof : GeneralTestCaseBase
    {

        [UnitTest]
        public unsafe void size_1()
        {
            Assert.Equal(1, sizeof(ValueTypeSize1));
        }


        [UnitTest]
        public unsafe void size_2()
        {
            Assert.Equal(2, sizeof(ValueTypeSize2));
        }

        [UnitTest]
        public unsafe void size_3()
        {
            Assert.Equal(3, sizeof(ValueTypeSize3));
        }

        [UnitTest]
        public unsafe void size_4()
        {
            Assert.Equal(4, sizeof(ValueTypeSize4));
        }

        [UnitTest]
        public unsafe void size_5()
        {
            Assert.Equal(5, sizeof(ValueTypeSize5));
        }

        [UnitTest]
        public unsafe void size_8()
        {
            Assert.Equal(8, sizeof(ValueTypeSize8));
        }

        [UnitTest]
        public unsafe void size_9()
        {
            Assert.Equal(9, sizeof(ValueTypeSize9));
        }

        [UnitTest]
        public unsafe void size_16()
        {
            Assert.Equal(16, sizeof(ValueTypeSize16));
        }
    }
}
