﻿using System;
using SharpUnit;

namespace Tests.Instruments.Converts
{
    class TC_conv_ovf_i8 : GeneralTestCaseBase
    {
        [UnitTest]
        public void ulong_1()
        {
            ulong x = 1;
            checked
            {
                long y = (long)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void ulong_overflow_up()
        {
            ulong x = ~0UL;
            Assert.ExpectException<OverflowException>();
            checked
            {
                long y = (long)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public unsafe void nint_1()
        {
            int* x = (int*)1;
            checked
            {
                long y = (long)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void float_1()
        {
            float x = 1;
            checked
            {
                long y = (long)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void float_2()
        {
            float x = -1;
            checked
            {
                long y = (long)x;
                Assert.Equal(-1, y);
            }
        }

        [UnitTest]
        public void float_overflow_up()
        {
            float x = ~0UL;
            Assert.ExpectException<OverflowException>();
            checked
            {
                long y = (long)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void float_overflow_down()
        {
            float x = ~0UL;
            Assert.ExpectException<OverflowException>();
            checked
            {
                long y = (long)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void double_1()
        {
            double x = 1;
            checked
            {
                long y = (long)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void double_2()
        {
            double x = -1;
            checked
            {
                long y = (long)x;
                Assert.Equal(-1, y);
            }
        }

        [UnitTest]
        public void double_overflow_up()
        {
            double x = ~0UL;
            Assert.ExpectException<OverflowException>();
            checked
            {
                long y = (long)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void double_overflow_down()
        {
            double x = ~0UL;
            Assert.ExpectException<OverflowException>();
            checked
            {
                long y = (long)x;
                Assert.Fail();
            }
        }
    }
}
