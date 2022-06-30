using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

public abstract class BoostrapTestCaseBase : TestCase
{


    private Type _klass;


    public override void SetUp()
    {
        _klass = TestContext.Ins.BootstrapTestAssembly.GetType(this.GetType().FullName);
    }

    public T Call<T>(string methodName)
    {
        return TestUtil.Call<T>(_klass, methodName);
    }


    public T Call2<A, T>(string methodName, A arg)
    {
        return TestUtil.Call2<A, T>(_klass, methodName, arg);
    }

    public T Call<T>(string methodName, T arg)
    {
        return TestUtil.Call<T>(_klass, methodName, arg);
    }

    public T CallRef<T>(string methodName, ref T arg)
    {
        return TestUtil.CallRef<T>(_klass, methodName, ref arg);
    }

    public T CallRef2<A, T>(string methodName, ref A arg)
    {
        return TestUtil.CallRef2<A, T>(_klass, methodName, ref arg);
    }

    public unsafe void EqualValue<T>(T expect, T value) where T : struct
    {
        void* p1 = UnsafeUtility.AddressOf(ref expect);
        void* p2 = UnsafeUtility.AddressOf(ref value);
        int size = UnsafeUtility.SizeOf<T>();
        Assert.Equal(0, UnsafeUtility.MemCmp(p1, p2, size));
    }
}
