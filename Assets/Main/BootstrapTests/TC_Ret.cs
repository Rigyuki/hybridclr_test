using AOTDefs;
using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace BootstrapTests
{
    public class TC_Ret : BoostrapTestCaseBase
    {

        [UnitTest]
        public void Ret_bool()
        {
            Assert.Equal(true, Call<bool>("Ret_bool_true"));
        }

        [UnitTest]
        public void Ret_byte()
        {
            Assert.Equal(1, Call<byte>("Ret_byte_1"));
        }

        [UnitTest]
        public void Ret_sbyte_minus1()
        {
            Assert.Equal(-1, Call<sbyte>("Ret_sbyte_minus1"));
        }

        [UnitTest]
        public void Ret_ushort()
        {
            Assert.Equal(0x1122, Call<ushort>("Ret_ushort"));
        }

        [UnitTest]
        public void Ret_short()
        {
            Assert.Equal(-0x1122, Call<short>("Ret_short"));
        }

        [UnitTest]
        public void Ret_uint()
        {
            Assert.Equal(0x11223344, Call<uint>("Ret_uint"));
        }

        [UnitTest]
        public void Ret_int()
        {
            Assert.Equal(-0x11223344, Call<int>("Ret_int"));
        }

        [UnitTest]
        public void Ret_ulong()
        {
            Assert.Equal(0x1122334455667788, Call<ulong>("Ret_ulong"));
        }

        [UnitTest]
        public void Ret_long()
        {
            Assert.Equal(-0x1122334455667788, Call<long>("Ret_long"));
        }

        [UnitTest]
        public void Ret_float()
        {
            Assert.Equal(1234f, Call<float>("Ret_float"));
        }

        [UnitTest]
        public void Ret_double()
        {
            Assert.Equal(1234567890.0, Call<double>("Ret_double"));
        }

        [UnitTest]
        public void Ret_null()
        {
            Assert.Null(Call<object>("Ret_null"));
        }



        [UnitTest]
        public void Ret_enum_byte()
        {
            Assert.Equal(AOT_Enum_byte.A, Call<AOT_Enum_byte>("Ret_enum_byte"));
        }

        [UnitTest]
        public void Ret_enum_sbyte_minus1()
        {
            Assert.Equal(AOT_Enum_sbyte.A, Call<AOT_Enum_sbyte>("Ret_enum_sbyte"));
        }

        [UnitTest]
        public void Ret_enum_ushort()
        {
            Assert.Equal(AOT_Enum_ushort.A, Call<AOT_Enum_ushort>("Ret_enum_ushort"));
        }

        [UnitTest]
        public void Ret_enum_short()
        {
            Assert.Equal(AOT_Enum_short.A, Call<AOT_Enum_short>("Ret_enum_short"));
        }

        [UnitTest]
        public void Ret_enum_uint()
        {
            Assert.Equal(AOT_Enum_uint.A, Call<AOT_Enum_uint>("Ret_enum_uint"));
        }

        [UnitTest]
        public void Ret_enum_int()
        {
            Assert.Equal(AOT_Enum_int.A, Call<AOT_Enum_int>("Ret_enum_int"));
        }

        [UnitTest]
        public void Ret_enum_ulong()
        {
            Assert.Equal(AOT_Enum_ulong.A, Call<AOT_Enum_ulong>("Ret_ulong"));
        }

        [UnitTest]
        public void Ret_enum_long()
        {
            Assert.Equal(AOT_Enum_long.A, Call<AOT_Enum_long>("Ret_long"));
        }

        [UnitTest]
        public void Ret_ValueTypeSize1()
        {
            EqualValue(new ValueTypeSize1 { x1 = 1 }, Call<ValueTypeSize1>("Ret_ValueTypeSize1"));
        }

        [UnitTest]
        public void Ret_ValueTypeSize2()
        {
            EqualValue(new ValueTypeSize2 { x1 = 1, x2 = 2 }, Call<ValueTypeSize2>("Ret_ValueTypeSize2"));
        }

        [UnitTest]
        public void Ret_ValueTypeSize3()
        {
            EqualValue(new ValueTypeSize3 { x1 = 1, x2 = 2, x3 = 3 }, Call<ValueTypeSize3>("Ret_ValueTypeSize3"));
        }

        [UnitTest]
        public void Ret_ValueTypeSize4()
        {
            EqualValue(new ValueTypeSize4 { x1 = 1 }, Call<ValueTypeSize4>("Ret_ValueTypeSize4"));
        }

        [UnitTest]
        public void Ret_ValueTypeSize5()
        {
            EqualValue(new ValueTypeSize5 { x1 = 1, x2 = 2, x3 = 3, x4 = 4, x5 = 5 }, Call<ValueTypeSize5>("Ret_ValueTypeSize5"));
        }

        [UnitTest]
        public void Ret_ValueTypeSize8()
        {
            EqualValue(new ValueTypeSize8 { x1 = 1 }, Call<ValueTypeSize8>("Ret_ValueTypeSize8"));
        }

        [UnitTest]
        public void Ret_ValueTypeSize9()
        {
            EqualValue(new ValueTypeSize9 { x1 = 1, x2 = 2, x3 = 3, x4 = 4, x5 = 5, x6 = 6, x7 = 7, x8 = 8, x9 = 9 }, Call<ValueTypeSize9>("Ret_ValueTypeSize9"));
        }

        [UnitTest]
        public void Ret_ValueTypeSize16()
        {
            EqualValue(new ValueTypeSize16 { x1 = 1, x2 = 2 }, Call<ValueTypeSize16>("Ret_ValueTypeSize16"));
        }

        [UnitTest]
        public void Ret_ValueTypeSize20()
        {
            EqualValue(new ValueTypeSize20 { x1 = 1, x2 = 2, x3 = 3, x4 = 4, x5 = 5 }, Call<ValueTypeSize20>("Ret_ValueTypeSize20"));
        }

        [UnitTest]
        public void Ret_NotHFA()
        {
            EqualValue(new NotHFA { x = 1, y = 2, z = 3 }, Call<NotHFA>("Ret_NotHFA"));
        }

        [UnitTest]
        public void Ret_EmbedHFA()
        {
            EqualValue(new EmbedHFA { x = new Vector2(1, 2), y = 3 }, Call<EmbedHFA>("Ret_EmbedHFA"));
        }

        [UnitTest]
        public void Ret_EmbedHFA2()
        {
            EqualValue(new EmbedHFA2 { x = new Vector2(1, 2), y = new Vector2(3, 4) }, Call<EmbedHFA2>("Ret_EmbedHFA2"));
        }

        [UnitTest]
        public void Ret_Vector2f()
        {
            EqualValue(new Vector2f { x = 1f, y = 2f }, Call<Vector2f>("Ret_Vector2f"));
        }

        [UnitTest]
        public void Ret_Vector3f()
        {
            EqualValue(new Vector3f { x = 1f, y = 2f, z = 3f }, Call<Vector3f>("Ret_Vector3f"));
        }

        [UnitTest]
        public void Ret_Vector4f()
        {
            EqualValue(new Vector4f { x = 1f, y = 2f, z = 3f, w = 4f }, Call<Vector4f>("Ret_Vector4f"));
        }

        [UnitTest]
        public void Ret_Vector2d()
        {
            EqualValue(new Vector2d { x = 1, y = 2 }, Call<Vector2d>("Ret_Vector2d"));
        }

        [UnitTest]
        public void Ret_Vector3d()
        {
            EqualValue(new Vector3d { x = 1, y = 2, z = 3 }, Call<Vector3d>("Ret_Vector3d"));
        }

        [UnitTest]
        public void Ret_Vector4d()
        {
            EqualValue(new Vector4d { x = 1, y = 2, z = 3, w = 4 }, Call<Vector4d>("Ret_Vector4d"));
        }
    }
}
