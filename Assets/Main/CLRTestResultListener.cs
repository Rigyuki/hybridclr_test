using SharpUnit;
using System;
using System.Reflection;


public class CLRTestResultListener : ITestResultListener
{
    public void TestFailed(TestCase testCase, MethodInfo method, Exception error)
    {
        TestReporter.ReportCLRTestCase(testCase.GetType().FullName, method.Name, TestcaseStatus.Failed, error.Message);
    }

    public void TestPass(TestCase testCase, MethodInfo method)
    {
        TestReporter.ReportCLRTestCase(testCase.GetType().FullName, method.Name, TestcaseStatus.Ok, "ok");
    }
}
