using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum TestcaseStatus
{
    Ok,
    Failed,
    NotRun,
}

public class TestcaseResult
{
    public string Family { get; set; }

    public string Name { get; set; }

    public TestcaseStatus Status { get; set; }

    public string Msg { get; set; }
}

public class TestReporter
{
    private static FileStream _logFileStream;
    private static StreamWriter _baseLogger;

    private static string LogDir => Application.persistentDataPath + "/testlogs";

    private static string LogFileName => $"{LogDir}/test.log";

    private static readonly List<TestcaseResult> s_results = new List<TestcaseResult>();

    public static void Init()
    {
        string logDir = LogDir;
        Directory.CreateDirectory(logDir);

        var logFileName = LogFileName;
        if(File.Exists(logFileName))
        {
            File.Move(logFileName, $"{logDir}/test-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}.log");
        }
        _logFileStream = File.OpenWrite(logFileName);
        _baseLogger = new StreamWriter(_logFileStream);
    }

    public static void Close()
    {
        _baseLogger.Flush();
        _baseLogger.Close();
#if UNITY_STANDALONE_WIN && !UNITY_EDITOR
        Application.OpenURL($"file:///{LogFileName}");
#endif
    }


    //public static void ReportCppTestCase(string testcaseFamily, string testCaseName, TestcaseStatus succ, string msg)
    //{
    //    _baseLogger.WriteLine("[{0}] {1}::{2}. {3}", succ, testcaseFamily, testCaseName, msg);
    //    s_results.Add(new TestcaseResult { Family = testcaseFamily, Name = testCaseName, Status = succ, Msg = msg });
    //    _baseLogger.Flush();
    //    _ = _logFileStream.FlushAsync();
    //}

    public static void ReportCLRTestCase(string testcaseFamily, string testCaseName, TestcaseStatus succ, string msg)
    {
        if (succ == TestcaseStatus.Ok)
        {
            // Debug.LogFormat("[{0}] {1}::{2}. {3}", succ, testcaseFamily, testCaseName, msg);
        }
        else
        {
            //Debug.LogErrorFormat("[{0}] {1}::{2}. {3}", succ, testcaseFamily, testCaseName, msg);
        }
        _baseLogger.WriteLine("[{0}] {1}::{2}. {3}", succ, testcaseFamily, testCaseName, msg);
        s_results.Add(new TestcaseResult { Family = testcaseFamily, Name = testCaseName, Status = succ, Msg = msg });
        _baseLogger.Flush();
        _ = _logFileStream.FlushAsync();
    }

    public static void GenerateStatisticReport()
    {
        int totalTestCase = s_results.Count;
        int totalSucc = 0;
        int totalFail = 0;
        int totalNotRun = 0;

        var fails = new List<TestcaseResult>();
        foreach (var testcase in s_results)
        {
            switch(testcase.Status)
            {
                case TestcaseStatus.Ok: ++totalSucc; break;
                case TestcaseStatus.Failed:
                    {
                        ++totalFail;
                        fails.Add(testcase);
                        break;
                    }
                case TestcaseStatus.NotRun: ++totalNotRun; break;
            }
        }

        _baseLogger.WriteLine();
        _baseLogger.WriteLine("#### fail cases ####");
        foreach (var testcase in fails)
        {
            Debug.LogErrorFormat("[{0}] {1}::{2}. {3}", testcase.Status, testcase.Family, testcase.Name, testcase.Msg);
            _baseLogger.WriteLine("[{0}] {1}::{2}. {3}", testcase.Status, testcase.Family, testcase.Name, testcase.Msg);
        }
        _baseLogger.WriteLine();
        _baseLogger.WriteLine();
        _baseLogger.WriteLine("========================");
        _baseLogger.WriteLine("total:{0}", totalTestCase);
        _baseLogger.WriteLine("succ:{0}", totalSucc);
        _baseLogger.WriteLine("fail:{0}", totalFail);
        _baseLogger.WriteLine("========================");
        Debug.LogFormat("total:{0} succ:{1} fail:{2}", totalTestCase, totalSucc, totalFail);
    }
}
