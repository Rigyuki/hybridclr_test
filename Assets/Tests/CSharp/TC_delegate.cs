using SharpUnit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tests.Csharp.Delegates
{
    class A
    {
        public virtual int GetX()
        {
            return 0;
        }
    }

    class B : A
    {
        public override int GetX()
        {
            return 1;
        }

        public Func<int> CreateBaseGetX()
        {
            return base.GetX;
        }
    }

    public class TC_delegate : GeneralTestCaseBase
    {
        /// <summary>
        /// delegate调用所保存的函数时，不应该调用函数相应的虚函数版本
        /// </summary>
        [UnitTest]
        public void NotVirtualDelegateInvoke()
        {
            var b = new B();
            var d = b.CreateBaseGetX();
            var x = d();
            Assert.Equal(0, x);
        }
    }
}

