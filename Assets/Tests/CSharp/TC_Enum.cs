using System;
using SharpUnit;

namespace Tests.CSharp
{
    internal enum MyColor
    {
        red,
        green,
        blue = 8,
        yellow,
    }
    internal class TC_Enum : GeneralTestCaseBase
    {
        enum Color
        {
            red,
            green,
            blue = 8,
            yellow,
        }

        [UnitTest]
        public void GetRed_0()
        {
            Assert.Equal(0, (int)Color.red);
        }

        [UnitTest]
        public void GetGreen_1()
        {
            Assert.Equal(1, (int)Color.green);
        }

        [UnitTest]
        public void GetRedAdd_2()
        {
            Assert.Equal(2, (int)(Color.red + 2));
        }

        [UnitTest]
        public void GetGreenAdd_3()
        {
            Assert.Equal(3, (int)(Color.green + 2));
        }

        [UnitTest]
        public void GetBlue_8()
        {
            Assert.Equal(8, (int)Color.blue);
        }

        [UnitTest]
        public void GetYellor_9()
        {
            Assert.Equal(9, (int)Color.yellow);
        }
    }
}
