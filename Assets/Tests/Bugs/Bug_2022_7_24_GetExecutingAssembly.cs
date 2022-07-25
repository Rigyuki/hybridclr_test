using AOTDefs;
using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tests.Bugs
{

    internal class Bug_2022_7_24_GetExecutingAssembly : GeneralTestCaseBase
    {
        /*
        [UnitTest]
        public void test()
        {
            var ass = System.Reflection.Assembly.GetExecutingAssembly();
            Assert.Equal("Tests", ass.GetName().Name);
        }
        */
    }
}
