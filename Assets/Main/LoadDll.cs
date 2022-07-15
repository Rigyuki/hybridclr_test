using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class LoadDll : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DownLoadDlls(this.StartRunner));
    }

    private static Dictionary<string, byte[]> s_dllBytes = new Dictionary<string, byte[]>();

    public static byte[] GetDllBytes(string dllName)
    {
        return s_dllBytes[dllName];
    }

    IEnumerator DownLoadDlls(Action onDownloadComplete)
    {
        var dlls = new string[]
        {
            "Tests.dll",
            "BootstrapTests.dll",
            "mscorlib.dll",
            "System.dll",
            "System.Core.dll", // 如果使用了Linq，需要这个
        };
        foreach (var dll in dlls)
        {
            string dllPath = $"{Application.streamingAssetsPath}/{dll}";
            Debug.Log($"start download dll:{dll}");
            UnityWebRequest www = UnityWebRequest.Get(dllPath);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Or retrieve results as binary data
                byte[] dllBytes = www.downloadHandler.data;
                Debug.Log($"dll:{dll}  size:{dllBytes.Length}");
                s_dllBytes[dll] = dllBytes;
            }
        }

        onDownloadComplete();
    }

    private void StartRunner()
    {
        TestRunner.PreLoadTests();
        TestRunner.InitTestContext();
        TestRunner.Run();
    }
}
