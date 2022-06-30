using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class TestContext
{
    public static TestContext Ins { get; } = new TestContext();

    public Assembly TestAssembly { get; set; }

    public Assembly BootstrapTestAssembly { get; set; }

}
