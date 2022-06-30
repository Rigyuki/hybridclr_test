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
    /// 测试 AOT -> interpreter 传参，普通参数
    /// </summary>
    public class TC_Arg : BoostrapTestCaseBase
    {

        [UnitTest]
        public void Arg_bool()
        {
            Assert.Equal(1, Call2<bool, int>("Arg_bool", true));
        }

        [UnitTest]
        public void Arg_byte()
        {
            Assert.Equal(1, Call2<byte, int>("Arg_byte", 1));
        }

        [UnitTest]
        public void Arg_sbyte()
        {
            Assert.Equal(-1, Call2<sbyte, int>("Arg_sbyte", -1));
        }

        [UnitTest]
        public void Arg_ushort()
        {
            Assert.Equal(1, Call2<ushort, int>("Arg_ushort", 1));
        }

        [UnitTest]
        public void Arg_short()
        {
            Assert.Equal(-1, Call2<short, int>("Arg_short", -1));
        }

        [UnitTest]
        public void Arg_char()
        {
            Assert.Equal(1, Call2<char, int>("Arg_char", (char)1));
        }

        [UnitTest]
        public void Arg_uint()
        {
            Assert.Equal(1, Call("Arg_uint", (uint)1));
        }

        [UnitTest]
        public void Arg_int()
        {
            Assert.Equal(-1, Call("Arg_int", (int)-1));
        }

        [UnitTest]
        public void Arg_ulong()
        {
            Assert.Equal(1ul, Call("Arg_ulong", (ulong)1));
        }

        [UnitTest]
        public void Arg_long()
        {
            Assert.Equal(-1L, Call("Arg_long", (long)-1));
        }

        [UnitTest]
        public void Arg_float()
        {
            Assert.Equal(1f, Call("Arg_float", 1f));
        }

        [UnitTest]
        public void Arg_double()
        {
            Assert.Equal(1.0, Call("Arg_double", 1.0));
        }

        [UnitTest]
        public void Arg_null()
        {
            Assert.Equal(null, Call<object>("Arg_null", null));
        }

        [UnitTest]
        public void Arg_enum_byte()
        {
            Assert.Equal((int)AOT_Enum_byte.A, Call2<AOT_Enum_byte, int>("Arg_byte", AOT_Enum_byte.A));
        }

        [UnitTest]
        public void Arg_enum_sbyte()
        {
            Assert.Equal((int)AOT_Enum_sbyte.A, Call2<AOT_Enum_sbyte, int>("Arg_sbyte", AOT_Enum_sbyte.A));
        }

        [UnitTest]
        public void Arg_enum_short()
        {
            Assert.Equal((int)AOT_Enum_short.A, Call2<AOT_Enum_short, int>("Arg_short", AOT_Enum_short.A));
        }

        [UnitTest]
        public void Arg_enum_ushort()
        {
            Assert.Equal((int)AOT_Enum_ushort.A, Call2<AOT_Enum_ushort, int>("Arg_ushort", AOT_Enum_ushort.A));
        }

        [UnitTest]
        public void Arg_enum_int()
        {
            Assert.Equal((int)AOT_Enum_int.A, Call2<AOT_Enum_int, int>("Arg_int", AOT_Enum_int.A));
        }

        [UnitTest]
        public void Arg_enum_uint()
        {
            Assert.Equal((uint)AOT_Enum_uint.A, Call2<AOT_Enum_uint, uint>("Arg_uint", AOT_Enum_uint.A));
        }

        [UnitTest]
        public void Arg_enum_long()
        {
            Assert.Equal((long)AOT_Enum_long.A, Call2<AOT_Enum_long, long>("Arg_long", AOT_Enum_long.A));
        }

        [UnitTest]
        public void Arg_enum_ulong()
        {
            Assert.Equal((ulong)AOT_Enum_ulong.A, Call2<AOT_Enum_ulong, ulong>("Arg_ulong", AOT_Enum_ulong.A));
        }


        // normal struct
        [UnitTest]
        public void Arg_ValueTypeSize1()
        {
            ValueTypeSize1 v = default;
            v.x1 = 1;

            EqualValue(v, Call("Arg_ValueTypeSize1", v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize2()
        {
            ValueTypeSize2 v = default;
            v.x1 = 1;
            v.x2 = 2;

            EqualValue(v, Call("Arg_ValueTypeSize2", v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize3()
        {
            ValueTypeSize3 v = default;
            v.x1 = 1;
            v.x2 = 2;
            v.x3 = 3;

            EqualValue(v, Call("Arg_ValueTypeSize3", v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize4()
        {
            ValueTypeSize4 v = default;
            v.x1 = 1;

            EqualValue(v, Call("Arg_ValueTypeSize4", v));
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

            EqualValue(v, Call("Arg_ValueTypeSize5", v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize8()
        {
            ValueTypeSize8 v = default;
            v.x1 = 1;

            EqualValue(v, Call("Arg_ValueTypeSize8", v));
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

            EqualValue(v, Call("Arg_ValueTypeSize9", v));
        }

        [UnitTest]
        public void Arg_ValueTypeSize16()
        {
            ValueTypeSize16 v = default;
            v.x1 = 1;
            v.x2 = 2;

            EqualValue(v, Call("Arg_ValueTypeSize16", v));
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

            EqualValue(v, Call("Arg_ValueTypeSize20", v));
        }

        [UnitTest]
        public void Arg_NotHFA()
        {
            NotHFA x = default;
            x.x = 1f;
            x.y = 2f;
            x.z = 3;

            EqualValue(x, Call("Arg_NotHFA", x));
        }

        [UnitTest]
        public void Arg_EmbedHFA()
        {
            EmbedHFA x = default;
            x.x.x = 1f;
            x.x.y = 2f;
            x.y = 3f;

            EqualValue(x, Call("Arg_EmbedHFA", x));
        }

        [UnitTest]
        public void Arg_EmbedHFA2()
        {
            EmbedHFA2 x = default;
            x.x.x = 1f;
            x.x.y = 2f;
            x.y.x = 3f;
            x.y.y = 4f;

            EqualValue(x, Call("Arg_EmbedHFA2", x));
        }

        // HFA

        [UnitTest]
        public void Arg_Vector2f()
        {
            Vector2f v = default;
            v.x = 1f;
            v.y = 2f;

            EqualValue(v, Call("Arg_Vector2f", v));
        }

        [UnitTest]
        public void Arg_Vector3f()
        {
            Vector3f v = default;
            v.x = 1f;
            v.y = 2f;
            v.z = 3f;

            EqualValue(v, Call("Arg_Vector3f", v));
        }


        [UnitTest]
        public void Arg_Vector4f()
        {
            Vector4f v = default;
            v.x = 1f;
            v.y = 2f;
            v.z = 3f;
            v.w = 4f;

            EqualValue(v, Call("Arg_Vector4f", v));
        }


        [UnitTest]
        public void Arg_Vector2d()
        {
            Vector2d v = default;
            v.x = 1.0;
            v.y = 2.0;

            EqualValue(v, Call("Arg_Vector2d", v));
        }


        [UnitTest]
        public void Arg_Vector3d()
        {
            Vector3d v = default;
            v.x = 1.0;
            v.y = 2.0;
            v.z = 3.0;

            EqualValue(v, Call("Arg_Vector3d", v));
        }


        [UnitTest]
        public void Arg_Vector4d()
        {
            Vector4d v = default;
            v.x = 1.0;
            v.y = 2.0;
            v.z = 3.0;
            v.w = 4.0;

            EqualValue(v, Call("Arg_Vector4d", v));
        }
    }
}
