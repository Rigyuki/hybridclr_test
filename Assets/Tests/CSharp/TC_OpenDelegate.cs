using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CSharp.Delegates
{
    struct A
    {
        public int x;
        public float y;
        public string z;

        public int Show(int b)
        {
            return this.x + b;
        }
    }

    delegate int DelShow(ref A a, int b);

    class B
    {
        public int x;
        public float y;
        public string z;

        public int Show(int b)
        {
            return this.x + b;
        }

        public static int Run(B s, int b)
        {
            return s.x + b;
        }
    }

    internal class TC_OpenDelegate : GeneralTestCaseBase
    {
        [UnitTest]
        public void class_open_instance()
        {
            var b = new B() { x = 1, y = 2f, z = "abc" };
            var m = typeof(B).GetMethod("Show");
            var del = (Func<B, int, int>)Delegate.CreateDelegate(typeof(Func<B, int, int>), null, m);
            Assert.Equal(5, del(b, 4));
        }

        [UnitTest]
        public void class_open_static()
        {
            var b = new B() { x = 1, y = 2f, z = "abc" };
            var m = typeof(B).GetMethod("Run");
            var del = (Func<int, int>)Delegate.CreateDelegate(typeof(Func<int, int>), b, m);
            Assert.Equal(5, del(4));
        }

        [UnitTest]
        public void struct_open_instance()
        {
            var b = new A() { x = 1, y = 2f, z = "abc" };
            var m = typeof(A).GetMethod("Show");
            var del = (DelShow)Delegate.CreateDelegate(typeof(DelShow), null, m);
            Assert.Equal(5, del(ref b, 4));
        }
    }
}
