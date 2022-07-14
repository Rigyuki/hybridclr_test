using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CSharp
{

    [StructLayout( LayoutKind.Sequential, Pack = 1)]
    struct StructWithoutClass
    {
        byte a;
        long b;
    }

    //[StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct StructWithClass
    {
        byte a;
        object b;
    }

    internal class TC_StructLayout : GeneralTestCaseBase
    {
        public void s1(StructWithoutClass a)
        {

        }
        public void s2(StructWithClass a)
        {

        }
    }
}
