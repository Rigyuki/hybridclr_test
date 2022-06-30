using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class LoadDll : MonoBehaviour
{
    void Start()
    {
        BetterStreamingAssets.Initialize();

        TestRunner.InitTestContext();
        TestRunner.Run();
    }
}
