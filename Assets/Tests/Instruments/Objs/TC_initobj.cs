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
    internal class TC_initobj : GeneralTestCaseBase
    {
        // 不好构造

        [UnitTest]
        public unsafe void valuetypesize1_1()
        {
            long a = -1;
            ValueTypeSize1 x = default;
            long b = -1;
            
            Assert.Equal(0, x.x1);
            Assert.Equal(-1, a);
            Assert.Equal(-1, b);
        }

        [UnitTest]
        public unsafe void valuetypesize2_1()
        {
            long a = -1;
            ValueTypeSize2 x = default;
            long b = -1;

            Assert.Equal(0, x.x1);
            Assert.Equal(-1, a);
            Assert.Equal(-1, b);
        }

        [UnitTest]
        public unsafe void valuetypesize3_1()
        {
            long a = -1;
            ValueTypeSize3 x = default;
            long b = -1;

            Assert.Equal(0, x.x1);
            Assert.Equal(-1, a);
            Assert.Equal(-1, b);
        }

        [UnitTest]
        public unsafe void valuetypesize4_1()
        {
            long a = -1;
            ValueTypeSize4 x = default;
            long b = -1;

            Assert.Equal(0, x.x1);
            Assert.Equal(-1, a);
            Assert.Equal(-1, b);
        }

        [UnitTest]
        public unsafe void valuetypesize5_1()
        {
            long a = -1;
            ValueTypeSize5 x = default;
            long b = -1;

            Assert.Equal(0, x.x1);
            Assert.Equal(-1, a);
            Assert.Equal(-1, b);
        }

        [UnitTest]
        public unsafe void valuetypesize8_1()
        {
            long a = -1;
            ValueTypeSize8 x = default;
            long b = -1;

            Assert.Equal(0, x.x1);
            Assert.Equal(-1, a);
            Assert.Equal(-1, b);
        }

        [UnitTest]
        public unsafe void valuetypesize9_1()
        {
            long a = -1;
            ValueTypeSize9 x = default;
            long b = -1;

            Assert.Equal(0, x.x1);
            Assert.Equal(-1, a);
            Assert.Equal(-1, b);
        }

        [UnitTest]
        public unsafe void valuetypesize16_1()
        {
            long a = -1;
            ValueTypeSize16 x = default;
            long b = -1;

            Assert.Equal(0, x.x1);
            Assert.Equal(-1, a);
            Assert.Equal(-1, b);
        }
    }
}
