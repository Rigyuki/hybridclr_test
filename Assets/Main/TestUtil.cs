using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



delegate T RefFunc<T>(ref T a);
delegate T OutFunc<T>(out T a);
delegate T InFunc<T>(in T a);

delegate T RefFunc<A, T>(ref A a);
delegate T OutFunc<A, T>(out A a);
delegate T InFunc<A, T>(in A a);


public static class TestUtil
{
    public static Assembly GetAssembly(string name)
    {
        return AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == name);
    }

    public static T Call<T>(Type type, string methodName)
    {
        MethodInfo method = type.GetMethod(methodName);

        var func = (Func<T>)Delegate.CreateDelegate(typeof(Func<T>), method);
        return func();
    }

    public static T Call<T>(Type type, string methodName, T a)
    {
        MethodInfo method = type.GetMethod(methodName);

        var func = (Func<T, T>)Delegate.CreateDelegate(typeof(Func<T, T>), method);
        return func(a);
    }

    public static T Call2<A, T>(Type type, string methodName, A a)
    {
        MethodInfo method = type.GetMethod(methodName);

        var func = (Func<A, T>)Delegate.CreateDelegate(typeof(Func<A, T>), method);
        return func(a);
    }

    public static T CallRef<T>(Type type, string methodName, ref T a)
    {
        MethodInfo method = type.GetMethod(methodName);

        var func = (RefFunc<T>)Delegate.CreateDelegate(typeof(RefFunc<T>), method);
        return func(ref a);
    }

    public static T CallRef2<A, T>(Type type, string methodName, ref A a)
    {
        MethodInfo method = type.GetMethod(methodName);

        var func = (RefFunc<A, T>)Delegate.CreateDelegate(typeof(RefFunc<A, T>), method);
        return func(ref a);
    }


    public static T CallOut<T>(Type type, string methodName, out T a)
    {
        MethodInfo method = type.GetMethod(methodName);

        var func = (OutFunc<T>)Delegate.CreateDelegate(typeof(OutFunc<T>), method);
        return func(out a);
    }

    public static T CallOut2<A, T>(Type type, string methodName, out A a)
    {
        MethodInfo method = type.GetMethod(methodName);

        var func = (OutFunc<A, T>)Delegate.CreateDelegate(typeof(OutFunc<A, T>), method);
        return func(out a);
    }


    public static T CallIn<T>(Type type, string methodName, in T a)
    {
        MethodInfo method = type.GetMethod(methodName);

        var func = (InFunc<T>)Delegate.CreateDelegate(typeof(InFunc<T>), method);
        return func(in a);
    }

    public static T CallIn2<A, T>(Type type, string methodName, in A a)
    {
        MethodInfo method = type.GetMethod(methodName);

        var func = (InFunc<A, T>)Delegate.CreateDelegate(typeof(InFunc<A, T>), method);
        return func(in a);
    }
}
