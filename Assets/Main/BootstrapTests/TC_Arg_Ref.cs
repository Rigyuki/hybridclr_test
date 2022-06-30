using AOTDefs;
using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;
using UnityEngine;

namespace BootstrapTests
{

    /// <summary>
    /// 测试 AOT -> interpreter 传参，ref 参数
    /// </summary>
    public class TC_Arg_Ref : BoostrapTestCaseBase
    {

        [UnitTest]
        public void Arg_bool()
        {
            bool v = true;
            Assert.Equal(1, CallRef2<bool, int>("Arg_bool", ref v));
        }

        [UnitTest]
        public void Arg_byte()
        {
            byte v = 1;
            Assert.Equal(1, CallRef2<byte, int>("Arg_byte", ref v));
        }

        [UnitTest]
        public void Arg_sbyte()
        {
            sbyte v = -1;
            Assert.Equal(-1, CallRef2<sbyte, int>("Arg_sbyte", ref v));
        }

        [UnitTest]
        public void Arg_ushort()
        {
            ushort v = 1;
            Assert.Equal(1, CallRef2<ushort, int>("Arg_ushort", ref v));
        }

        [UnitTest]
        public void Arg_short()
        {
            short v = -1;
            Assert.Equal(-1, CallRef2<short, int>("Arg_short", ref v));
        }

        [UnitTest]
        public void Arg_char()
        {
            char v = (char)1;
            Assert.Equal(1, CallRef2<char, int>("Arg_char", ref v));
        }

        [UnitTest]
        public void Arg_uint()
        {
            uint v = 1;
            Assert.Equal(1, CallRef("Arg_uint", ref v));
        }

        [UnitTest]
        public void Arg_int()
        {
            int v = -1;
            Assert.Equal(-1, CallRef("Arg_int", ref v));
        }

        [UnitTest]
        public void Arg_ulong()
        {
            ulong v = 1;
            Assert.Equal(1ul, CallRef("Arg_ulong", ref v));
        }

        [UnitTest]
        public void Arg_long()
        {
            long v = -1;
            Assert.Equal(-1L, CallRef("Arg_long", ref v));
        }

        [UnitTest]
        public void Arg_float()
        {
            float v = 1f;
            Assert.Equal(1f, CallRef("Arg_float", ref v));
        }

        [UnitTest]
        public void Arg_double()
        {
            double v = 1.0;
            Assert.Equal(1.0, CallRef("Arg_double", ref v));
        }

        [UnitTest]
        public void Arg_null()
        {
            object v = new object();
            Assert.Equal(v, CallRef("Arg_object", ref v));
        }

        [UnitTest]
        public void Arg_enum_byte()
        {
            var v = AOT_Enum_byte.A;
            Assert.Equal((int)AOT_Enum_byte.A, CallRef2<AOT_Enum_byte, int>("Arg_enum_byte", ref v));
        }

        [UnitTest]
        public void Arg_enum_sbyte()
        {
            var v = AOT_Enum_sbyte.A;
            Assert.Equal((int)AOT_Enum_sbyte.A, CallRef2<AOT_Enum_sbyte, int>("Arg_enum_sbyte", ref v));
        }

        [UnitTest]
        public void Arg_enum_short()
        {
            var v = AOT_Enum_short.A;
            Assert.Equal((int)AOT_Enum_short.A, CallRef2<AOT_Enum_short, int>("Arg_enum_short", ref v));
        }

        [UnitTest]
        public void Arg_enum_ushort()
        {
            var v = AOT_Enum_ushort.A;
            Assert.Equal((int)AOT_Enum_ushort.A, CallRef2<AOT_Enum_ushort, int>("Arg_enum_ushort", ref v));
        }

        [UnitTest]
        public void Arg_enum_int()
        {
            var v = AOT_Enum_int.A;
            Assert.Equal((int)AOT_Enum_int.A, CallRef2<AOT_Enum_int, int>("Arg_enum_int", ref v));
        }

        [UnitTest]
        public void Arg_enum_uint()
        {
            var v = AOT_Enum_uint.A;
            Assert.Equal((uint)AOT_Enum_uint.A, CallRef2<AOT_Enum_uint, uint>("Arg_enum_uint", ref v));
        }

        [UnitTest]
        public void Arg_enum_long()
        {
            var v = AOT_Enum_long.A;
            Assert.Equal((long)AOT_Enum_long.A, CallRef2<AOT_Enum_long, long>("Arg_enum_long", ref v));
        }

        [UnitTest]
        public void Arg_enum_ulong()
        {
            var v = AOT_Enum_ulong.A;
            Assert.Equal((ulong)AOT_Enum_ulong.A, CallRef2<AOT_Enum_ulong, ulong>("Arg_enum_ulong", ref v));
        }


        // normal struct
        [UnitTest]
        public void Arg_ValueTypeSize1()
        {
            ValueTypeSize1 v = default;
            v.x1 = 1;

            EqualValue(v, CallRef("Arg_ValueTypeSize1", ref v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize2()
        {
            ValueTypeSize2 v = default;
            v.x1 = 1;
            v.x2 = 2;

            EqualValue(v, CallRef("Arg_ValueTypeSize2", ref v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize3()
        {
            ValueTypeSize3 v = default;
            v.x1 = 1;
            v.x2 = 2;
            v.x3 = 3;

            EqualValue(v, CallRef("Arg_ValueTypeSize3", ref v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize4()
        {
            ValueTypeSize4 v = default;
            v.x1 = 1;

            EqualValue(v, CallRef("Arg_ValueTypeSize4", ref v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize5()
        {
            ValueTypeSize5 v = default;
            v.x1 = 1;
            v.x2 = 2;
            v.x3 = 3;
            v.x4 = 4;
            v.x5 = 5;

            EqualValue(v, CallRef("Arg_ValueTypeSize5", ref v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize8()
        {
            ValueTypeSize8 v = default;
            v.x1 = 1;

            EqualValue(v, CallRef("Arg_ValueTypeSize8", ref v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize9()
        {
            ValueTypeSize9 v = default;
            v.x1 = 1;
            v.x2 = 2;
            v.x3 = 3;
            v.x4 = 4;
            v.x5 = 5;
            v.x6 = 6;
            v.x7 = 7;
            v.x8 = 8;
            v.x9 = 9;

            EqualValue(v, CallRef("Arg_ValueTypeSize9", ref v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize16()
        {
            ValueTypeSize16 v = default;
            v.x1 = 1;
            v.x2 = 2;

            EqualValue(v, CallRef("Arg_ValueTypeSize16", ref v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize20()
        {
            ValueTypeSize20 v = default;
            v.x1 = 1;
            v.x2 = 2;
            v.x3 = 3;
            v.x4 = 4;
            v.x5 = 5;

            EqualValue(v, CallRef("Arg_ValueTypeSize20", ref v));
        }

        [UnitTest]
        public void Arg_NotHFA()
        {
            NotHFA x = default;
            x.x = 1f;
            x.y = 2f;
            x.z = 3;

            EqualValue(x, CallRef("Arg_NotHFA", ref x));
        }

        [UnitTest]
        public void Arg_EmbedHFA()
        {
            EmbedHFA x = default;
            x.x.x = 1f;
            x.x.y = 2f;
            x.y = 3f;

            EqualValue(x, CallRef("Arg_EmbedHFA", ref x));
        }

        [UnitTest]
        public void Arg_EmbedHFA2()
        {
            EmbedHFA2 x = default;
            x.x.x = 1f;
            x.x.y = 2f;
            x.y.x = 3f;
            x.y.y = 4f;

            EqualValue(x, CallRef("Arg_EmbedHFA2", ref x));
        }

        // HFA

        [UnitTest]
        public void Arg_Vector2f()
        {
            Vector2f v = default;
            v.x = 1f;
            v.y = 2f;

            EqualValue(v, CallRef("Arg_Vector2f", ref v));
        }

        [UnitTest]
        public void Arg_Vector3f()
        {
            Vector3f v = default;
            v.x = 1f;
            v.y = 2f;
            v.z = 3f;

            EqualValue(v, CallRef("Arg_Vector3f", ref v));
        }


        [UnitTest]
        public void Arg_Vector4f()
        {
            Vector4f v = default;
            v.x = 1f;
            v.y = 2f;
            v.z = 3f;
            v.w = 4f;

            EqualValue(v, CallRef("Arg_Vector4f", ref v));
        }


        [UnitTest]
        public void Arg_Vector2d()
        {
            Vector2d v = default;
            v.x = 1.0;
            v.y = 2.0;

            EqualValue(v, CallRef("Arg_Vector2d", ref v));
        }


        [UnitTest]
        public void Arg_Vector3d()
        {
            Vector3d v = default;
            v.x = 1.0;
            v.y = 2.0;
            v.z = 3.0;

            EqualValue(v, CallRef("Arg_Vector3d", ref v));
        }


        [UnitTest]
        public void Arg_Vector4d()
        {
            Vector4d v = default;
            v.x = 1.0;
            v.y = 2.0;
            v.z = 3.0;
            v.w = 4.0;

            EqualValue(v, CallRef("Arg_Vector4d", ref v));
        }
    }
}
