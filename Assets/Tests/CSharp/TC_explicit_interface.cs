using SharpUnit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CSharp
{
    interface IExplicit
    {
        int Show();
    }

    class ExplicitMethod : IExplicit
    {
        public virtual int Show()
        {
            return 1;
        }

        int IExplicit.Show() => Show();
    }

    internal class TC_explicit_interface : GeneralTestCaseBase
    {
        [UnitTest]
        public void same_name()
        {
            IExplicit o = new ExplicitMethod();
            Assert.Equal(1, o.Show());
        }
    }
}
