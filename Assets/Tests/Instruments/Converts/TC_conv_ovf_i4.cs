﻿using System;
using SharpUnit;

namespace Tests.Instruments.Converts
{
    class TC_conv_ovf_i4 : GeneralTestCaseBase
    {
        [UnitTest]
        public void uint_1()
        {
            uint x = 1;
            checked
            {
                int y = (int)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public unsafe void uint_overflow_up()
        {
            uint* x = (uint*)0x80000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                int y = (int)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void long_1()
        {
            long x = 1;
            checked
            {
                int y = (int)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void long_overflow_up()
        {
            long x = 0x1_000000002;
            Assert.ExpectException<OverflowException>();
            checked
            {
                int y = (int)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void long_overflow_down()
        {
            long x = -0x1_00000002;
            Assert.ExpectException<OverflowException>();
            checked
            {
                int y = (int)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void ulong_1()
        {
            ulong x = 1;
            checked
            {
                int y = (int)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void ulong_overflow_up()
        {
            ulong x = 0x80000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                int y = (int)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public unsafe void nint_1()
        {
            int* x = (int*)1;
            checked
            {
                int y = (int)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public unsafe void nint_overflow_up()
        {
            int* x = (int*)0x80000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                int y = (int)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public unsafe void nint_overflow_down()
        {
            int* x = (int*)-0x80000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                int y = (int)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public unsafe void unint_1()
        {
            uint* x = (uint*)1;
            checked
            {
                int y = (int)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public unsafe void unint_overflow_up()
        {
            uint* x = (uint*)0x80000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                int y = (int)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void float_1()
        {
            float x = 1;
            checked
            {
                int y = (int)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void float_overflow_up()
        {
            float x = 0x8001_0000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                int y = (int)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void float_overflow_down()
        {
            float x = -0x8001_0000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                int y = (int)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void double_1()
        {
            double x = 1;
            checked
            {
                int y = (int)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void double_overflow_up()
        {
            double x = 0x80000000;
            Assert.ExpectException<OverflowException>();
            checked
            {
                int y = (int)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void double_overflow_down()
        {
            double x = -0x80000001;
            Assert.ExpectException<OverflowException>();
            checked
            {
                int y = (int)x;
                Assert.Fail();
            }
        }
    }
}
