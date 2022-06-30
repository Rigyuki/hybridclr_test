using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

        [MenuItem("Huatuo/Build/Win64")]
        public static void Build_Win64()
        {
            GenMethodBridges();
            // Get filename.
            string path = $"{Application.dataPath}/../Release-Win64";

            var buildOptions = BuildOptions.None;

            string location = path + "/Test.exe";
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions()
            {
                scenes = new string[] { "Assets/Scenes/main.unity" },
                locationPathName = location,
                options = buildOptions,
                target = BuildTarget.StandaloneWindows64,
                targetGroup = BuildTargetGroup.Standalone,
            };

            BuildPipeline.BuildPlayer(buildPlayerOptions);
        }

        [MenuItem("Huatuo/Build/Andriod64")]
        public static void Build_Android64()
        {
            GenMethodBridges();
            // Get filename.
            string path = $"{Application.dataPath}/../Release-Android64";

            var buildOptions = BuildOptions.None;

            string location = path + "/Test.apk";
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
