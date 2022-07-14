using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace HybridCLR
{
    public class BuildPlayerHelper
    {
        public static void CopyDlls(string outputDir)
        {
            Directory.CreateDirectory(outputDir);

        }

        [MenuItem("HybridCLR/Build/Win64")]
        public static void Build_Win64()
        {
            BuildTarget target = BuildTarget.StandaloneWindows64;
            // Get filename.
            string outputPath = $"{BuildConfig.ProjectDir}/Release-Win64";

            var buildOptions = BuildOptions.None;

            string location = $"{outputPath}/HybridCLRTest.exe";

            Debug.Log("====> Build App");
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions()
            {
                scenes = new string[] { "Assets/Scenes/main.unity" },
                locationPathName = location,
                options = buildOptions,
                target = BuildTarget.StandaloneWindows64,
                targetGroup = BuildTargetGroup.Standalone,
            };

            var report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            if (report.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
            {
                Debug.LogError("���ʧ��");
                return;
            }

            Debug.Log("====> Build AssetBundle");
            Debug.Log("====> ���� AssetBundle");
            CopyDlls($"{outputPath}/HybridCLRTrial_Data/StreamingAssets");

#if UNITY_EDITOR
            Application.OpenURL($"file:///{outputPath}");
#endif
        }

        //[MenuItem("HybridCLR/Build/Andriod64")]
        public static void Build_Android64()
        {
            BuildTarget target = BuildTarget.Android;
            // Get filename.
            string outputPath = $"{BuildConfig.ProjectDir}/Release-Android";

            var buildOptions = BuildOptions.None;

            string location = outputPath + "/HybridCLRTrial.apk";
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions()
            {
                scenes = new string[] { "Assets/Scenes/main.unity" },
                locationPathName = location,
                options = buildOptions,
                target = target,
                targetGroup = BuildTargetGroup.Android,
            };

            Debug.Log("====> ��1�� Build App(Ϊ�����ɲ���AOTԪ����dll)");
            BuildPipeline.BuildPlayer(buildPlayerOptions);
            Debug.Log("====> Build AssetBundle");

            // FIX ME! need copy dlls 
            //CopyDlls($"{outputPath}/HybridCLRTrial_Data/StreamingAssets");

            Debug.Log("====> ��2�δ��");
            BuildPipeline.BuildPlayer(buildPlayerOptions);
#if UNITY_EDITOR
            Application.OpenURL($"file:///{outputPath}");
#endif
        }
    }
}
