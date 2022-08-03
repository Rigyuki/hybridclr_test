﻿using System;
using SharpUnit;
using UnityEngine;

namespace Tests.Instruments.Converts
{
    class TC_conv_ovf_u8 : GeneralTestCaseBase
    {
        [UnitTest]
        public void float_1()
        {
            float x = 1;
            checked
            {
                ulong y = (ulong)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void float_overflow_up()
        {
            float x = 3.40282e+020f;
            Assert.ExpectException<OverflowException>();
            checked
            {
                ulong y = (ulong)x;
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
                ulong y = (ulong)x;
                Assert.Fail();
            }
        }

        [UnitTest]
        public void double_1()
        {
            double x = 1;
            checked
            {
                ulong y = (ulong)x;
                Assert.Equal(1, y);
            }
        }

        [UnitTest]
        public void double_overflow_up()
        {
            double x = 3.40282e+020f;
            Assert.ExpectException<OverflowException>();
            checked
            {
                ulong y = (ulong)x;
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
                ulong y = (ulong)x;
                Assert.Fail();
            }
        }
    }
}
