using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace HybridCLR
{
    internal class CopyDllHelper
    {
        public static void CopyHotfixAndAOTDll2BuildStreamingAssetsDir(BuildTarget target, string outputPath)
        {
            var buildDir = BuildConfig.GetHotFixDllsOutputDirByTarget(target);
            var buildStreamingAssetsDir = $"{outputPath}";
            Directory.CreateDirectory(buildStreamingAssetsDir);

            // copy hotfix dll
            foreach (var dllName in BuildConfig.AllHotUpdateDllNames)
            {
                string hotfixDll = $"{buildDir}/{dllName}";
                string targetDll = $"{buildStreamingAssetsDir}/{dllName}";
                File.Copy(hotfixDll, targetDll, true);
                UnityEngine.Debug.Log($"copy hotfix dll. {hotfixDll} => {targetDll}");
            }

            // copy aot dll
            var aotStripDllDir = BuildConfig.GetAssembliesPostIl2CppStripDir(target);
            foreach (var aotDll in BuildConfig.AOTMetaDlls)
            {
                string targetDll = $"{buildStreamingAssetsDir}/{Path.GetFileName(aotDll)}";
                string aotDllFullPath = $"{aotStripDllDir}/{aotDll}";
                File.Copy(aotDllFullPath, targetDll, true);
                UnityEngine.Debug.Log($"copy aot dll. {aotDllFullPath} => {targetDll}");
            }
        }

        [MenuItem("HybridCLR/Compile_Copy_Win64")]
        static void CompileAndCopyDll2BuildDir64()
        {
            CompileDllHelper.CompileDllWin64();
            CopyDll2BuildDir64();
        }

        //[UnityEditor.Callbacks.DidReloadScripts]
        [MenuItem("HybridCLR/CopyDll/Assets_StreamingAssets")]
        private static void OnScriptsReloaded()
        {
            CopyHotfixAndAOTDll2BuildStreamingAssetsDir(EditorUserBuildSettings.activeBuildTarget, Application.streamingAssetsPath);
        }

        [MenuItem("HybridCLR/CopyDll/Build_Win64")]
        static void CopyDll2BuildDir64()
        {
            BuildTarget target = BuildTarget.StandaloneWindows64;
            string outputPath = $"{Directory.GetParent(Application.dataPath)}/Build-Win64/build/bin/hybridclr_test_Data/StreamingAssets";
            CopyHotfixAndAOTDll2BuildStreamingAssetsDir(target, outputPath);
        }

        [MenuItem("HybridCLR/CopyDll/Build_AndroidV7")]
        static void CopyDll_AndroidV7()
        {
            BuildTarget target = BuildTarget.Android;
            string outputPath = $"{BuildConfig.ProjectDir}/Build-AndroidV7/unityLibrary/src/main/assets/";
            CopyHotfixAndAOTDll2BuildStreamingAssetsDir(target, outputPath);
        }

        [MenuItem("HybridCLR/CopyDll/Build_AndroidV8")]
        static void CopyDll_AndroidV8()
        {
            BuildTarget target = BuildTarget.Android;
            string outputPath = $"{BuildConfig.ProjectDir}/Build-AndroidV8/unityLibrary/src/main/assets/";
            CopyHotfixAndAOTDll2BuildStreamingAssetsDir(target, outputPath);
        }

        [MenuItem("HybridCLR/CopyDll/Release_Win64")]
        static void CopyDll2BuildDir2()
        {
            BuildTarget target = BuildTarget.StandaloneWindows64;
            string outputPath = $"{Directory.GetParent(Application.dataPath)}/Release-Win64/hybridclr_test_Data/StreamingAssets";
            CopyHotfixAndAOTDll2BuildStreamingAssetsDir(target, outputPath);
        }
    }
}
