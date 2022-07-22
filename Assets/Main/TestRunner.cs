using HybridCLR;
using SharpUnit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;


public class TestRunner
{
    public static void PreLoadTests()
    {
        foreach (var ass in AppDomain.CurrentDomain.GetAssemblies())
        {
            ass.GetCustomAttributes();
        }
    }

    public static void Run()
    {
        var suite = new TestSuite();
        PrepareBootstrapTests(suite);
        PrepareGeneralTests(suite);

        var result = new TestResult(new CLRTestResultListener());
        suite.Run(result);

        TestReporter.GenerateStatisticReport();
        TestReporter.Close();
    }


    public static Assembly LoadAssembly(string assName)
    {
#if UNITY_EDITOR
        return TestUtil.GetAssembly(assName);
#else
        byte[] dllBytes = LoadDll.GetDllBytes(assName + ".dll");
        return System.Reflection.Assembly.Load(dllBytes);
#endif
    }

    public static void InitTestContext()
    {
        TestReporter.Init();
#if !UNITY_EDITOR
        LoadAOTAssemblyMetadatas();
#endif
        TestContext.Ins.BootstrapTestAssembly = LoadAssembly("BootstrapTests");
        TestContext.Ins.TestAssembly = LoadAssembly("Tests");
    }

    private static unsafe void LoadAOTAssemblyMetadatas()
    {
        var aotDlls = new string[]
        {
            "mscorlib.dll",
            "System.dll",
            "System.Core.dll",
            "Main.dll",
        };
        foreach(string dll in aotDlls)
        {
            byte[] dllBytes = LoadDll.GetDllBytes(dll);
            fixed (byte* ptr = dllBytes)
            {
                int err = RuntimeApi.LoadMetadataForAOTAssembly((IntPtr)ptr, dllBytes.Length);
                Debug.LogFormat("LoadMetadataForAOTAssembly:{0}. ret:{1}", dll, err);
            }
        }
    }

    private static void PrepareBootstrapTests(TestSuite suite)
    {
        Assembly testAss = typeof(TestRunner).Assembly;

        var testCaseType = typeof(TestCase);
        foreach (var type in testAss.GetTypes())
        {
            if (!type.IsAbstract && testCaseType.IsAssignableFrom(type))
            {
                suite.AddAll((TestCase)Activator.CreateInstance(type));
            }
        }
    }

    private static void PrepareGeneralTests(TestSuite suite)
    {
        var testCaseType = typeof(TestCase);
        foreach (var type in TestContext.Ins.TestAssembly.GetTypes())
        {
            if (!type.IsAbstract && testCaseType.IsAssignableFrom(type))
            {
                suite.AddAll((TestCase)Activator.CreateInstance(type));
            }
        }
    }
}
