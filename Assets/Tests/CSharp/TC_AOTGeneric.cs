using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CSharp.AOTGenerics
{
    struct A
    {
        public int x;
        public float y;
        public string z;
    }

    internal class TC_AOTGeneric : GeneralTestCaseBase
    {
        [UnitTest]
        public void test_1()
        {
            var arr = new List<A>();
            arr.Add(new A { x = 1, y = 2f, z = "abc" });
            var e = arr[0];
            Assert.Equal(1, e.x);
            Assert.Equal(2f, e.y);
            Assert.Equal("abc", e.z);
        }

        [UnitTest]
        public void test_2()
        {
            var a = new List<A>() { new A { x = 1, y = 2f, z = "abc" } };
            var b = new List<A>() { new A { x = 2, y = 4f, z = "aaa" } };
            a.AddRange(b);
            Assert.Equal(2, a.Count);
            var e = a[1];
            Assert.Equal(2, e.x);
            Assert.Equal(4f, e.y);
            Assert.Equal("aaa", e.z);
        }

        [UnitTest]
        public void test_3()
        {
            var a = new List<A>() { new A { x = 1, y = 2f, z = "abc" } };
            var b = new A[] { new A { x = 2, y = 4f, z = "aaa" } };
            a.AddRange(b);
            Assert.Equal(2, a.Count);
            var e = a[1];
            Assert.Equal(2, e.x);
            Assert.Equal(4f, e.y);
            Assert.Equal("aaa", e.z);
        }
    }
}
