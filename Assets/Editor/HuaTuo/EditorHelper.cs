using Huatuo.Generators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Player;
using UnityEditor.Build.Reporting;
using UnityEditor.Il2Cpp;
using UnityEngine;
using FileMode = System.IO.FileMode;

namespace Huatuo
{
    /// <summary>
    /// 这里仅仅是一个流程展示
    /// 简单说明如果你想将huatuo的dll做成自动化的简单实现
    /// </summary>
    public class EditorHelper : IIl2CppProcessor
    {


        //[UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded()
        {
            var target = EditorUserBuildSettings.activeBuildTarget;
            var buildDir = GetDllBuildOutputDirByTarget(target);
            CompileDll(buildDir, target);
            foreach(var dllName in new string[] {"Tests.dll", "BootstrapTests.dll"})
            {
                string hotfixDll = $"{buildDir}/{dllName}";
                string target1 = $"{Application.streamingAssetsPath}/{dllName}";
                File.Copy(hotfixDll, target1, true);

                //foreach (var verTarget in new string[] { "Build-Win64" })
                //{
                //    string verStreamingAssetsPath = $"{Application.dataPath}/../{verTarget}/build/bin/HuatuoTest_Data/StreamingAssets";
                //    if (!Directory.Exists(verStreamingAssetsPath))
                //    {
                //        continue;
                //    }
                //    string target2 = $"{verStreamingAssetsPath}/{dllName}";
                //    File.Copy(hotfixDll, target2, true);
                //}
                UnityEngine.Debug.Log("compile succ");
            }
        }


        public int callbackOrder => 1;

        public static string GetAssembliesPostIl2CppStripDir(BuildTarget target) => $"{Path.GetDirectoryName(Application.dataPath)}/HuatuoData/AssembliesPostIl2CppStrip/{target}";

        public static HashSet<string> s_additionAotDlls = new HashSet<string>
        {
            "mscorlib.dll",
            "System.dll",
            "System.Core.dll",
        };

        public void OnBeforeConvertRun(BuildReport report, Il2CppBuildPipelineData data)
        {
            var projDir = Path.GetDirectoryName(Application.dataPath);
            var dstPath = GetAssembliesPostIl2CppStripDir(data.target);

            Directory.CreateDirectory(dstPath);

            string srcStripDllPath = projDir + "/" + (data.target == BuildTarget.Android ? "Temp/StagingArea/assets/bin/Data/Managed" : "Temp/StagingArea/Data/Managed/");

            foreach (var fileFullPath in Directory.GetFiles(srcStripDllPath, "*.dll"))
            {
                var file = Path.GetFileName(fileFullPath);
                if (!s_additionAotDlls.Contains(file))
                {
                    continue;
                }
                string target1 = $"{Application.streamingAssetsPath}/{file}";
                Debug.Log($"copy strip dll {fileFullPath} ==> {target1}");
                File.Copy(fileFullPath, target1, true);

                //foreach (var verTarget in new string[] { "Build-Win64" })
                //{
                //    string verStreamingAssetsPath = $"{Application.dataPath}/../{verTarget}/build/bin/HuatuoTest_Data/StreamingAssets";
                //    if (!Directory.Exists(verStreamingAssetsPath))
                //    {
                //        continue;
                //    }
                //    string target2 = $"{verStreamingAssetsPath}/{file}";
                //    Debug.Log($"copy strip dll {fileFullPath} ==> {target2}");
                //    File.Copy(fileFullPath, target2, true);
                //}

            }
        }

        private static void CreateDirIfNotExists(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
        }

        public static string ToReleateAssetPath(string s)
        {
            return s.Substring(s.IndexOf("Assets/"));
        }

        private static void CompileDll(string buildDir, BuildTarget target)
        {
            var group = BuildPipeline.GetBuildTargetGroup(target);

            ScriptCompilationSettings scriptCompilationSettings = new ScriptCompilationSettings();
            scriptCompilationSettings.group = group;
            scriptCompilationSettings.target = target;
            scriptCompilationSettings.options = ScriptCompilationOptions.DevelopmentBuild;
            CreateDirIfNotExists(buildDir);
            PlayerBuildInterface.CompilePlayerScripts(scriptCompilationSettings, buildDir);
            //foreach (var ass in scriptCompilationResult.assemblies)
            //{
            //    Debug.LogFormat("compile assemblies:{0}", ass);
            //}
        }

        public static string DllBuildOutputDir => Path.GetFullPath($"{Application.dataPath}/../Temp/Huatuo/build");


        public static string GetDllBuildOutputDirByTarget(BuildTarget target)
        {
            return $"{DllBuildOutputDir}/{target}";
        }

        [MenuItem("Huatuo/CompileDll/ActiveBuildTarget")]
        public static void CompileDllActiveBuildTarget()
        {
            var target = EditorUserBuildSettings.activeBuildTarget;
            CompileDll(GetDllBuildOutputDirByTarget(target), target);
        }

        [MenuItem("Huatuo/CompileDll/Win64")]
        public static void CompileDllWin64()
        {
            var target = BuildTarget.StandaloneWindows64;
            CompileDll(GetDllBuildOutputDirByTarget(target), target);
        }

        [MenuItem("Huatuo/CompileDll/Linux64")]
        public static void CompileDllLinux()
        {
            var target = BuildTarget.StandaloneLinux64;
            CompileDll(GetDllBuildOutputDirByTarget(target), target);
        }

        [MenuItem("Huatuo/CompileDll/OSX")]
        public static void CompileDllOSX()
        {
            var target = BuildTarget.StandaloneOSX;
            CompileDll(GetDllBuildOutputDirByTarget(target), target);
        }

        [MenuItem("Huatuo/CompileDll/Android")]
        public static void CompileDllAndroid()
        {
            var target = BuildTarget.Android;
            CompileDll(GetDllBuildOutputDirByTarget(target), target);
        }

        [MenuItem("Huatuo/CompileDll/IOS")]
        public static void CompileDllIOS()
        {
            //var target = EditorUserBuildSettings.activeBuildTarget;
            var target = BuildTarget.iOS;
            CompileDll(GetDllBuildOutputDirByTarget(target), target);
        }

        private static void CleanIl2CppBuildCache()
        {
            string il2cppBuildCachePath = $"{Application.dataPath}/../Library/Il2cppBuildCache";
            if (!Directory.Exists(il2cppBuildCachePath))
            {
                return;
            }
            Debug.Log($"clean il2cpp build cache:{il2cppBuildCachePath}");
            Directory.Delete(il2cppBuildCachePath, true);
        }


        [MenuItem("Huatuo/Generate/MethodBridge_X64")]
        public static void MethodBridge_X86()
        {
            //var target = EditorUserBuildSettings.activeBuildTarget;
            string outputFile = $"{Application.dataPath}/../HuatuoData/LocalIl2CppData/il2cpp/libil2cpp/huatuo/interpreter/MethodBridge_x64.cpp";
            var g = new MethodBridgeGenerator(new MethodBridgeGeneratorOptions()
            {
                CallConvention = CallConventionType.X64,
                Assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(s => !s.GetName().Name.Contains("Editor")).ToList(),
                OutputFile = outputFile,
            });

            g.PrepareMethods();
            g.Generate();
            Debug.LogFormat("== output:{0} ==", outputFile);
            CleanIl2CppBuildCache();
        }

        [MenuItem("Huatuo/Generate/MethodBridge_Arm64")]
        public static void MethodBridge_Arm64()
        {
            string outputFile = $"{Application.dataPath}/../HuatuoData/LocalIl2CppData/il2cpp/libil2cpp/huatuo/interpreter/MethodBridge_arm64.cpp";
            var g = new MethodBridgeGenerator(new MethodBridgeGeneratorOptions()
            {
                CallConvention = CallConventionType.Arm64,
                Assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(s => !s.GetName().Name.Contains("Editor")).ToList(),
                OutputFile = outputFile,
            });

            g.PrepareMethods();
            g.Generate();
            Debug.LogFormat("== output:{0} ==", outputFile);
            CleanIl2CppBuildCache();
        }

        [MenuItem("Huatuo/Generate/MethodBridge_Armv7")]
        public static void MethodBridge_Armv7()
        {
            string outputFile = $"{Application.dataPath}/../HuatuoData/LocalIl2CppData/il2cpp/libil2cpp/huatuo/interpreter/MethodBridge_armv7.cpp";
            var g = new MethodBridgeGenerator(new MethodBridgeGeneratorOptions()
            {
                CallConvention = CallConventionType.Armv7,
                Assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(s => !s.GetName().Name.Contains("Editor")).ToList(),
                OutputFile = outputFile,
            });

            g.PrepareMethods();
            g.Generate();
            Debug.LogFormat("== output:{0} ==", outputFile);
            CleanIl2CppBuildCache();
        }

        //public class A
        //{
        //    public static int s = 0;

        //    static A()
        //    {
        //        s = 1;
        //    }

        //    public A()
        //    {

        //    }

        //    int X { get; set; }


        //}



        //struct NotHFA
        //{
        //    public float x;
        //    public float y;
        //    public int z;
        //}

        //struct EmbedHFA
        //{
        //    public static float z;
        //    public Vector2 x;
        //    public float y;
        //}

        //struct EmbedHFA2
        //{
        //    public Vector2 x;
        //    public Vector2 y;
        //}

        //struct EmbedHFA3
        //{
        //    public double x;
        //    public double y;
        //    public double z;
        //}

        //[MenuItem("Test/Test")]
        //public static void TestMethodCheck()
        //{
        //    var paArm64 = new PlatformAdaptor_Arm64();

        //    {
        //        var type = typeof(Vector2);
        //        var size = PlatformAdaptor_Arm64.ComputeSizeOf(type);
        //        Debug.Assert(size == 8);
        //        bool ishfa = PlatformAdaptor_Arm64.ComputHFATypeInfo(type, size, out var typeInfo);
        //        Debug.Assert(ishfa);
        //        var ti = PlatformAdaptor_Arm64.CreateValueType(type, false);
        //        Debug.Assert(ti.PorType == ParamOrReturnType.ARM64_HFA_FLOAT_2);
        //    }
        //    {
        //        var type = typeof(NotHFA);
        //        var size = PlatformAdaptor_Arm64.ComputeSizeOf(type);
        //        Debug.Assert(size == 12);
        //        bool ishfa = PlatformAdaptor_Arm64.ComputHFATypeInfo(type, size, out var typeInfo);
        //        Debug.Assert(!ishfa);
        //    }
        //    {
        //        var type = typeof(EmbedHFA);
        //        var size = PlatformAdaptor_Arm64.ComputeSizeOf(type);
        //        Debug.Assert(size == 12);
        //        bool ishfa = PlatformAdaptor_Arm64.ComputHFATypeInfo(type, size, out var typeInfo);
        //        Debug.Assert(ishfa);
        //        var ti = PlatformAdaptor_Arm64.CreateValueType(type, false);
        //        Debug.Assert(ti.PorType == ParamOrReturnType.ARM64_HFA_FLOAT_3);
        //    }
        //    {
        //        var type = typeof(EmbedHFA2);
        //        var size = PlatformAdaptor_Arm64.ComputeSizeOf(type);
        //        Debug.Assert(size == 16);
        //        bool ishfa = PlatformAdaptor_Arm64.ComputHFATypeInfo(type, size, out var typeInfo);
        //        Debug.Assert(ishfa);
        //        var ti = PlatformAdaptor_Arm64.CreateValueType(type, false);
        //        Debug.Assert(ti.PorType == ParamOrReturnType.ARM64_HFA_FLOAT_4);
        //    }
        //    {
        //        var type = typeof(EmbedHFA3);
        //        var size = PlatformAdaptor_Arm64.ComputeSizeOf(type);
        //        Debug.Assert(size == 24);
        //        bool ishfa = PlatformAdaptor_Arm64.ComputHFATypeInfo(type, size, out var typeInfo);
        //        Debug.Assert(ishfa);
        //        var ti = PlatformAdaptor_Arm64.CreateValueType(type, false);
        //        Debug.Assert(ti.PorType == ParamOrReturnType.ARM64_HFA_DOUBLE_3);
        //    }
        //    Debug.Log("test succ");
        //}
    }
}