//using SharpUnit;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Tests.Instruments.Ariths
//{
//    internal class TC_Add_ovf : HuatuoTestCaseBase
//    {
//        [UnitTest]
//        public static void add_ovf_uint_3()
//        {
//            checked
//            {
//                uint a = 1;
//                uint b = 2;
//                Assert.Equal(3, a + b);
//            }
//        }
//        [UnitTest]
//        public static void add_ovf_uint_5()
//        {
//            checked
//            {
//                uint a = 0xFFFFFFFE;
//                uint b = 20;
//                Assert.ExpectException(new OverflowException());
//                uint c = a + b;
//            }
//        }
//        [UnitTest]
//        public static void add_ovf_uint_OverflowException()
//        {
//            checked
//            {
//                uint a = 0xFFFFFFFF;
//                uint b = 2;
//                Assert.ExpectException(new OverflowException());
//                uint c = a + b;
//            }
//        }

//        [UnitTest]
//        public static void add_ovf_ulong_3()
//        {
//            checked
//            {
//                ulong a = 1;
//                ulong b = 2;
//                Assert.Equal(3, a + b);
//            }
//        }
//        [UnitTest]
//        public static void add_ovf_ulong_0xFFFFFFFFFFL()
//        {
//            checked
//            {
//                ulong a = 0xFFFFFFFFFFFFFFFF;
//                ulong b = 2;
//                Assert.ExpectException(new OverflowException());
//                ulong c = a + b;
//            }
//        }
//        [UnitTest]
//        public static void add_ovf_ulong_OverflowException()
//        {
//            checked
//            {
//                ulong a = 0xFFFFFFFFFFFFFFFF;
//                ulong b = 2;
//                Assert.ExpectException(new OverflowException());
//                ulong c = a + b;
//            }
//        }
//    }
//}
