using AOTDefs;
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
    /// TC 是 TestClass的缩写
    /// </summary>
    public static class TC_Arg
    {

        public static int Arg_bool(bool x)
        {
            return x ? 1 : 0;
        }

        public static int Arg_byte(byte x)
        {
            return x;
        }

        public static int Arg_sbyte(sbyte x)
        {
            return x;
        }

        public static int Arg_ushort(ushort x)
        {
            return x;
        }

        public static int Arg_short(short x)
        {
            return x;
        }

        public static int Arg_char(char x)
        {
            return x;
        }

        public static uint Arg_uint(uint x)
        {
            return x;
        }

        public static int Arg_int(int x)
        {
            return x;
        }

        public static ulong Arg_ulong(ulong x)
        {
            return x;
        }

        public static long Arg_long(long x)
        {
            return x;
        }

        public static float Arg_float(float x)
        {
            return x;
        }

        public static double Arg_double(double x)
        {
            return x;
        }

        public static object Arg_null(object x)
        {
            return x;
        }

        public static int Arg_enum_byte(AOT_Enum_byte x)
        {
            return (int)x;
        }

        public static int Arg_enum_sbyte(AOT_Enum_sbyte x)
        {
            return (int)x;
        }

        public static int Arg_enum_short(AOT_Enum_short x)
        {
            return (int)x;
        }

        public static int Arg_enum_ushort(AOT_Enum_ushort x)
        {
            return (int)x;
        }

        public static int Arg_enum_int(AOT_Enum_int x)
        {
            return (int)x;
        }

        public static uint Arg_enum_uint(AOT_Enum_uint x)
        {
            return (uint)x;
        }

        public static long Arg_enum_long(AOT_Enum_long x)
        {
            return (long)x;
        }

        public static ulong Arg_enum_ulong(AOT_Enum_ulong x)
        {
            return (ulong)x;
        }

        // normal struct
        public static ValueTypeSize1 Arg_ValueTypeSize1(ValueTypeSize1 x)
        {
            return x;
        }

        public static ValueTypeSize2 Arg_ValueTypeSize2(ValueTypeSize2 x)
        {
            return x;
        }

        public static ValueTypeSize3 Arg_ValueTypeSize3(ValueTypeSize3 x)
        {
            return x;
        }

        public static ValueTypeSize4 Arg_ValueTypeSize4(ValueTypeSize4 x)
        {
            return x;
        }

        public static ValueTypeSize5 Arg_ValueTypeSize5(ValueTypeSize5 x)
        {
            return x;
        }

        public static ValueTypeSize8 Arg_ValueTypeSize8(ValueTypeSize8 x)
        {
            return x;
        }

        public static ValueTypeSize9 Arg_ValueTypeSize9(ValueTypeSize9 x)
        {
            return x;
        }

        public static ValueTypeSize16 Arg_ValueTypeSize16(ValueTypeSize16 x)
        {
            return x;
        }

        public static ValueTypeSize20 Arg_ValueTypeSize20(ValueTypeSize20 x)
        {
            return x;
        }

        public static NotHFA Arg_NotHFA(NotHFA x)
        {
            return x;
        }

        public static EmbedHFA Arg_EmbedHFA(EmbedHFA x)
        {
            return x;
        }

        public static EmbedHFA2 Arg_EmbedHFA2(EmbedHFA2 x)
        {
            return x;
        }

        // HFA

        public static Vector2f Arg_Vector2f(Vector2f x)
        {
            return x;
        }

        public static Vector3f Arg_Vector3f(Vector3f x)
        {
            return x;
        }

        public static Vector4f Arg_Vector4f(Vector4f x)
        {
            return x;
        }

        public static Vector2d Arg_Vector2d(Vector2d x)
        {
            return x;
        }

        public static Vector3d Arg_Vector3d(Vector3d x)
        {
            return x;
        }

        public static Vector4d Arg_Vector4d(Vector4d x)
        {
            return x;
        }

    }
}
