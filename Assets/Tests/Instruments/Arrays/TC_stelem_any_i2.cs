﻿using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Instruments.Arrays
{
    internal class TC_stelem_any_i2 : GeneralTestCaseBase
    {
        public static T GetEle<T>(T[] arr, int index)
        {
            return arr[index];
        }


        public static void SetEle<T>(T[] arr, int index, T value)
        {
            arr[index] = value;
        }

        [UnitTest]
        public void st_1()
        {
            var arr = new short[3] {1, 1, 1};
            SetEle<short>(arr, 1, -1);

            var x = GetEle(arr, 0);
            Assert.Equal(1, x);
            var y = GetEle(arr, 1);
            Assert.Equal(-1, y);
            var z = GetEle(arr, 2);
            Assert.Equal(1, z);
        }

        [UnitTest]
        public void OutOfRange_lower()
        {
            var arr = new short[2];
            Assert.ExpectException<IndexOutOfRangeException>();
            SetEle<short>(arr, -1, 1);
            Assert.Fail();
        }

        [UnitTest]
        public void OutOfRange_upper()
        {
            var arr = new short[2];
            Assert.ExpectException<IndexOutOfRangeException>();
            SetEle<short>(arr, 2, 1);
            Assert.Fail();
        }

        [UnitTest]
        public void NullRef()
        {
            short[] arr = null;
            Assert.ExpectException<NullReferenceException>();
            SetEle<short>(arr, 0, 1);
            Assert.Fail();
        }
    }
}
