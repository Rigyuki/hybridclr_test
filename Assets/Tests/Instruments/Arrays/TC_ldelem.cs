using AOTDefs;
using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Tests.Instruments.Arrays
{
    internal class TC_ldelem : GeneralTestCaseBase
    {

        [UnitTest]
        public void ld_1()
        {
            var arr = new ValueTypeSize4[] { new ValueTypeSize4 { x1 = 1 }, new ValueTypeSize4 { x1 = 2 } };

            var x = arr[0];
            Assert.Equal(1, x.x1);
            var y = arr[1];
            Assert.Equal(2, y.x1);

            var x2 = ArrayVerifyUtil.Get(arr, 0);
            Assert.Equal(1, x2.x1);
            var y2 = ArrayVerifyUtil.Get(arr, 1);
            Assert.Equal(2, y2.x1);
        }

        [UnitTest]
        public void OutOfRange_lower()
        {
            var arr = new ValueTypeSize4[] { new ValueTypeSize4 { x1 = 1 }, new ValueTypeSize4 { x1 = 2 } };
            Assert.ExpectException<IndexOutOfRangeException>();
            var s = arr[-1];
            Assert.Fail();
        }

        [UnitTest]
        public void OutOfRange_upper()
        {
            var arr = new ValueTypeSize4[] { new ValueTypeSize4 { x1 = 1 }, new ValueTypeSize4 { x1 = 2 } };
            Assert.ExpectException<IndexOutOfRangeException>();
            var s = arr[2];
            Assert.Fail();
        }

        [UnitTest]
        public void NullRef()
        {
            ValueTypeSize4[] arr = null;
            Assert.ExpectException<NullReferenceException>();
            var s = arr[0];
            Assert.Fail();
        }
    }
}
