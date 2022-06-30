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
    internal class TC_ldobj : GeneralTestCaseBase
    {

        [UnitTest]
        public unsafe void valuetypesize1_1()
        {
            ValueTypeSize1 x = new ValueTypeSize1 { x1 = 1};
            ValueTypeSize1* px = &x;
            ValueTypeSize1 y = *px;
            
            Assert.Equal(1, y.x1);
        }

        [UnitTest]
        public unsafe void valuetypesize2_1()
        {
            ValueTypeSize2 x = new ValueTypeSize2 { x1 = 1 };
            ValueTypeSize2* px = &x;
            ValueTypeSize2 y = *px;

            Assert.Equal(1, y.x1);
        }

        [UnitTest]
        public unsafe void valuetypesize3_1()
        {
            var x = new ValueTypeSize3 { x1 = 1 };
            ValueTypeSize3* px = &x;
            ValueTypeSize3 y = *px;

            Assert.Equal(1, y.x1);
        }

        [UnitTest]
        public unsafe void valuetypesize4_1()
        {
            var x = new ValueTypeSize4 { x1 = 1 };
            ValueTypeSize4* px = &x;
            ValueTypeSize4 y = *px;

            Assert.Equal(1, y.x1);
        }

        [UnitTest]
        public unsafe void valuetypesize5_1()
        {
            var x = new ValueTypeSize5 { x1 = 1 };
            ValueTypeSize5* px = &x;
            ValueTypeSize5 y = *px;

            Assert.Equal(1, y.x1);
        }

        [UnitTest]
        public unsafe void valuetypesize8_1()
        {
            var x = new ValueTypeSize8 { x1 = 1 };
            ValueTypeSize8* px = &x;
            ValueTypeSize8 y = *px;

            Assert.Equal(1, y.x1);
        }

        [UnitTest]
        public unsafe void valuetypesize9_1()
        {
            var x = new ValueTypeSize9 { x1 = 1 };
            ValueTypeSize9* px = &x;
            ValueTypeSize9 y = *px;

            Assert.Equal(1, y.x1);
        }

        [UnitTest]
        public unsafe void valuetypesize16_1()
        {
            var x = new ValueTypeSize16 { x1 = 1 };
            ValueTypeSize16* px = &x;
            ValueTypeSize16 y = *px;

            Assert.Equal(1, y.x1);
        }
    }
}
