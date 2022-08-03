using System;
using SharpUnit;
using UnityEngine;

namespace Tests.Instruments.Converts
{
    class TC_conv_ovf_u4 : GeneralTestCaseBase
    {
        [UnitTest]
        public void int_1()
        {
            int x = 1;
            checked
            {
                uint y = (uint)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void uint_1()
        {
            uint x = 1;
            checked
            {
                uint y = (uint)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void long_1()
        {
            long x = 1;
            checked
            {
                uint y = (uint)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void long_overflow_up()
        {
            long x = 0x1_00000002;
            Assert.ExpectException<OverflowException>();
            checked
            {
                uint y = (uint)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void ulong_1()
        {
            ulong x = 1;
            checked
            {
                uint y = (uint)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void ulong_overflow_up()
        {
            ulong x = 0x100000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                uint y = (uint)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public unsafe void nuint_1()
        {
            uint* x = (uint*)1;
            checked
            {
                uint y = (uint)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public unsafe void nuint_overflow_up()
        {
            uint* x = (uint*)0x100000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                uint y = (uint)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public unsafe void nuint_overflow_down()
        {
            uint* x = (uint*)-0x100000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                uint y = (uint)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public unsafe void unint_1()
        {
            uint* x = (uint*)1;
            checked
            {
                uint y = (uint)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public unsafe void unint_overflow_up()
        {
            uint* x = (uint*)0x100000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                uint y = (uint)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void float_1()
        {
            float x = 1;
            checked
            {
                uint y = (uint)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void float_overflow_up()
        {
            float x = 0x1_10000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                uint y = (uint)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void float_overflow_down()
        {
            float x = -1;
            Assert.ExpectException<OverflowException>();
            checked
            {
                uint y = (uint)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void double_1()
        {
            double x = 1;
            checked
            {
                uint y = (uint)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void double_overflow_up()
        {
            double x = 0x100000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                uint y = (uint)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void double_overflow_down()
        {
            double x = -1;
            Assert.ExpectException<OverflowException>();
            checked
            {
                uint y = (uint)x;
                Assert.Fail();
            }
        }
    }
}
