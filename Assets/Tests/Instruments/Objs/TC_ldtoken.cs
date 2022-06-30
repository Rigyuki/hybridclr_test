using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Tests.Instruments.Objs
{
    internal class TC_ldtoken : GeneralTestCaseBase
    {

        [UnitTest]
        public void type_1()
        {
            Type t = typeof(string);
            Assert.Equal("String", t.Name);
        }


        [UnitTest]
        public void type_2()
        {
            Type t = typeof(IEnumerable<>);
            Assert.Equal("IEnumerable`1", t.Name);
        }


        [UnitTest]
        public void type_3()
        {
            Type t = typeof(IEnumerable<int>);
            Assert.Equal("IEnumerable`1", t.Name);
        }
    }
}
