using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CSharp
{
#if UNITY_2021_1_OR_NEWER
    public interface IShow
    {
        int Show(int a)
        {
            return a + 1;
        }
    }

    public class MyShow : IShow
    {

    }

    internal class TC_InterfaceDefaultMethod : GeneralTestCaseBase
    {
        [UnitTest]
        public void test()
        {
            IShow a = new MyShow();
            Assert.Equal(11, a.Show(10));
        }
    }
#endif
}
