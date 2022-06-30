using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOTDefs
{
    public enum AOT_Enum_byte : byte
    {
        A = 1,
    }
    public enum AOT_Enum_sbyte : sbyte
    {
        A = -1,
        B = 1,
    }

    public enum AOT_Enum_short : short
    {
        A = -1,
        B = 1,
    }

    public enum AOT_Enum_ushort : ushort
    {
        A = 1,
    }

    public enum AOT_Enum_int : int
    {
        A = -1,
        B = 1,
    }

    public enum AOT_Enum_uint : uint
    {
        A = 1,
    }

    public enum AOT_Enum_long : long
    {
        A = -0x1122334455667788,
        B = 0x1122334455667788,
    }


    public enum AOT_Enum_ulong : ulong
    {
        A = 0x1122334455667788,
    }
}
