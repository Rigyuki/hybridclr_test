using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

public abstract class GeneralTestCaseBase : TestCase
{

    public unsafe void EqualValue<T>(T expect, T value) where T : struct
    {
        void* p1 = UnsafeUtility.AddressOf(ref expect);
        void* p2 = UnsafeUtility.AddressOf(ref value);
        int size = UnsafeUtility.SizeOf<T>();
        Assert.Equal(0, UnsafeUtility.MemCmp(p1, p2, size));
    }
}
