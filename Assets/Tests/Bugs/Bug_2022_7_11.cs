using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Bugs
{
    public class BindableProperty<T> where T : IEquatable<T>
    {
        private T mValue;

        //当值改变时调用
        private Action<T> mOnValueChanged = v => { };


        public BindableProperty(T value)
        {
            mValue = value;
        }

        /// <summary>
        /// 值
        /// </summary>
        public T Value
        {
            get => mValue;
            set
            {
                if (!mValue.Equals(value))
                {
                    mValue = value;
                    mOnValueChanged?.Invoke(value);
                }
            }
        }

        public T Value2
        {
            get => mValue;
            set
            {
                if (!mValue.Equals(value))
                {
                    mValue = value;
                }
            }
        }

        public T Value3
        {
            get => mValue;
            set
            {
                    mValue = value;
            }
        }

        public T Value4
        {
            get => mValue;
            set
            {
                if (!mValue.Equals(value))
                {

                }
            }
        }

        public T Value5
        {
            get => mValue;
            set
            {
                mOnValueChanged?.Invoke(value);
            }
        }
    }

    internal class Bug_2022_7_11 : GeneralTestCaseBase
    {

        private static BindableProperty<string> s_prop = new BindableProperty<string>("");

        [UnitTest]
        public void test1()
        {
            s_prop.Value = "a";
        }

        [UnitTest]
        public void test2()
        {
            s_prop.Value2 = "a";
        }

        [UnitTest]
        public void test3()
        {
            s_prop.Value3 = "a";
        }

        [UnitTest]
        public void test4()
        {
            s_prop.Value4 = "a";
        }

        [UnitTest]
        public void test5()
        {
            s_prop.Value5 = "a";
        }

        [UnitTest]
        public void test6()
        {
            Action<string> mOnValueChanged = v => { };
            var s = "a";
            mOnValueChanged?.Invoke(s);
        }

        [UnitTest]
        public void test7()
        {
            Action<string> mOnValueChanged = v => { };
            Assert.NotNull(mOnValueChanged);
        }

        [UnitTest]
        public void test8()
        {
            int a = 5;
            Func<int, int> mOnValueChanged = v => v + a ;
            Assert.NotNull(mOnValueChanged);
        }
    }
}
