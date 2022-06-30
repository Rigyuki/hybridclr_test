using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Instruments.Arrays
{
    internal class TC_ldelema : GeneralTestCaseBase
    {

        [UnitTest]
        public void ld_1()
        {
            var arr = new int[] { -1, 1 };
            ref int x = ref arr[0];
            Assert.Equal(-1, x);
            ref int y = ref arr[1];
            Assert.Equal(1, y);
        }

        [UnitTest]
        public void OutOfRange_lower()
        {
            var arr = new int[] { -1, 1 };
            Assert.ExpectException<IndexOutOfRangeException>();
            ref int s = ref arr[-1];
            Assert.Fail();
        }

        [UnitTest]
        public void OutOfRange_upper()
        {
            var arr = new int[] { -1, 1 };
            Assert.ExpectException<IndexOutOfRangeException>();
            ref int s = ref arr[2];
            Assert.Fail();
        }

        [UnitTest]
        public void NullRef()
        {
            int[] arr = null;
            Assert.ExpectException<NullReferenceException>();
            ref int s = ref arr[0];
            Assert.Fail();
        }
    }
}
