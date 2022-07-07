using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Huatuo
{
    public class BuildPlayer
    {
        public static void GenMethodBridges()
        {
            EditorHelper.MethodBridge_X86();
            EditorHelper.MethodBridge_Arm64();
        }

        public static void CopyHotfixAndAOTDll2BuildStreamingAssetsDir(BuildTarget target, string outputPath)
        {
            var buildDir = EditorHelper.GetDllBuildOutputDirByTarget(target);
            var buildStreamingAssetsDir = $"{outputPath}";
            Directory.CreateDirectory(buildStreamingAssetsDir);

            // copy hotfix dll
            foreach (var dllName in BuildProcessor_2020_1_OR_NEWER.s_allHotUpdateDllNames)
            {
                string hotfixDll = $"{buildDir}/{dllName}";
                string targetDll = $"{buildStreamingAssetsDir}/{dllName}";
                File.Copy(hotfixDll, targetDll, true);
                UnityEngine.Debug.Log($"copy hotfix dll. {hotfixDll} => {targetDll}");
            }

            // copy aot dll
            var aotStripDllDir = EditorHelper.GetAssembliesPostIl2CppStripDir(target);
            foreach (var aotDll in EditorHelper.s_additionAotDlls)
            {
                string targetDll = $"{buildStreamingAssetsDir}/{Path.GetFileName(aotDll)}";
                string aotDllFullPath = $"{aotStripDllDir}/{aotDll}";
                File.Copy(aotDllFullPath, targetDll, true);
                UnityEngine.Debug.Log($"copy aot dll. {aotDllFullPath} => {targetDll}");
            }
        }


        //[UnityEditor.Callbacks.DidReloadScripts]
        [MenuItem("Huatuo/CopyDll/Assets_StreamingAssets")]
        private static void OnScriptsReloaded()
        {
            BuildPlayer.CopyHotfixAndAOTDll2BuildStreamingAssetsDir(EditorUserBuildSettings.activeBuildTarget, Application.streamingAssetsPath);
        }

        [MenuItem("Huatuo/CopyDll/Build_Win64")]
        static void CopyDll2BuildDir()
        {
            BuildTarget target = BuildTarget.StandaloneWindows64;
            string outputPath = $"{Directory.GetParent(Application.dataPath)}/Build-Win64/build/bin/HuatuoTest_Data/StreamingAssets";
            CopyHotfixAndAOTDll2BuildStreamingAssetsDir(target, outputPath);
        }

        [MenuItem("Huatuo/CopyDll/Release_Win64")]
        static void CopyDll2BuildDir2()
        {
            BuildTarget target = BuildTarget.StandaloneWindows64;
            string outputPath = $"{Directory.GetParent(Application.dataPath)}/Release-Win64/HuatuoTest_Data/StreamingAssets";
            CopyHotfixAndAOTDll2BuildStreamingAssetsDir(target, outputPath);
        }

        [MenuItem("Huatuo/Build/Win64")]
        public static void Build_Win64()
        {
            BuildTarget target = BuildTarget.StandaloneWindows64;
            EditorHelper.CompileDllWin64();
            // GenMethodBridges();
            // Get filename.
            string outputPath = $"{Directory.GetParent(Application.dataPath)}/Release-Win64";

            var buildOptions = BuildOptions.None;

            string location = outputPath + "/HuatuoTest.exe";
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions()
            {
                scenes = new string[] { "Assets/Scenes/main.unity" },
                locationPathName = location,
                options = buildOptions,
                target = BuildTarget.StandaloneWindows64,
                targetGroup = BuildTargetGroup.Standalone,
            };

            BuildPipeline.BuildPlayer(buildPlayerOptions);

            CopyHotfixAndAOTDll2BuildStreamingAssetsDir(target, outputPath);
#if UNITY_STANDALONE_WIN
        Application.OpenURL($"file:///{outputPath}");
#endif
        }

        [MenuItem("Huatuo/Build/Andriod64")]
        public static void Build_Android64()
        {
            GenMethodBridges();
            // Get filename.
            string path = $"{Application.dataPath}/../Release-Android64";

            var buildOptions = BuildOptions.None;

            string location = path + "/HuatuoTest.apk";
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions()
            {
                scenes = new string[] { "Assets/Scenes/main.unity" },
                locationPathName = location,
                options = buildOptions,
                target = BuildTarget.Android,
                targetGroup = BuildTargetGroup.Android,
            };

            BuildPipeline.BuildPlayer(buildPlayerOptions);
        }
    }
}
