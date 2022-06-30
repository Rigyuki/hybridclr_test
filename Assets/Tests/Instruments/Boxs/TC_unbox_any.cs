using AOTDefs;
using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Tests.Instruments.Boxs
{
    internal class TC_unbox_any : GeneralTestCaseBase
    {

        [UnitTest]
        public void int_1()
        {
            var o = (object)1;
            int b = (int)o;
            Assert.Equal(1, b);
        }

        [UnitTest]
        public void int_2()
        {
            var o = (object)1;
            Assert.ExpectException<InvalidCastException>();
            long b = (long)o;
        }

        [UnitTest]
        public void null_1()
        {
            Assert.ExpectException<NullReferenceException>();
            object o = null;
            int b = (int)o;
            Assert.Fail();
        }

        [UnitTest]
        public void null_2()
        {
            object o = null;
            int? x = (int?)o;
            Assert.False(x.HasValue);
        }

        [UnitTest]
        public void int_3()
        {
            object o = 1;
            int? x = (int?)o;
            Assert.True(x.HasValue);
            Assert.Equal(1, x.Value);
        }

        [UnitTest]
        public void int_4()
        {
            object o = 1;
            Assert.ExpectException<InvalidCastException>();
            long? x = (long?)o;
            Assert.Fail();
        }

        [UnitTest]
        public void enum_sbyte_1()
        {
            AOT_Enum_sbyte x = AOT_Enum_sbyte.A;
            var o = (object)x;
            var y = (AOT_Enum_sbyte)o;
            Assert.Equal(x, y);
        }

        [UnitTest]
        public void enum_sbyte_2()
        {
            AOT_Enum_sbyte x = AOT_Enum_sbyte.A;
            var o = (object)x;
            sbyte y = (sbyte)o;
            Assert.Equal(-1, y);
        }

        [UnitTest]
        public void valuetype_1()
        {
            var x = new ValueTypeSize1() { x1 = 1};
            var o = (object)x;
            var y = (ValueTypeSize1)o;
            Assert.Equal(1, y.x1);
        }
    }
}
