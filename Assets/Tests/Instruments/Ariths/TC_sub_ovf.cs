//using System;
//using SharpUnit;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//namespace Tests.Instruments.Ariths
//{
//    class TC_Sub_ovf : HuatuoTestCaseBase
//    {
//        [UnitTest]
//        public static void sub_ovf_un_ulong()
//        {
//            checked
//            {
//                ulong a = 0xFFFFFFFFFFL;
//                ulong b = 0xFFFFFFFFFCL;
//                Assert.Equal(3L, a - b);
//            }
//        }

//        [UnitTest]
//        public static void sub_ovf_un_ulong_OverflowException()
//        {
//            checked
//            {
//                ulong a = 0xFFFFFFFFFL;
//                ulong b = 0xFFFFFFFFFFL;
//                Assert.ExpectException(new OverflowException());
//                ulong c = a - b;
//            }
//        }

//        [UnitTest]
//        public static void sub_ovf_un_uint()
//        {
//            checked
//            {
//                uint a = 5;
//                uint b = 2;
//                Assert.Equal(3, a - b);
//            }
//        }

//        [UnitTest]
//        public static void sub_ovf_un_uint_OverflowException()
//        {
//            checked
//            {
//                uint a = 300;
//                uint b = 200;
//                Assert.ExpectException(new OverflowException());
//                uint c = b - a;
//            }
//        }

//        [UnitTest]
//        public static void sub_ovf_int()
//        {
//            checked
//            {
//                int a = 5;
//                int b = 2;
//                Assert.Equal(3, a - b);
//            }
//        }

//        [UnitTest]
//        public static void sub_ovf_int_OverflowException()
//        {
//            checked
//            {
//                int a = 0x7FFFFFFF;
//                int b = -200;
//                Assert.ExpectException(new OverflowException());
//                int c = b - a;
//            }
//        }

//        [UnitTest]
//        public static void sub_ovf_long()
//        {
//            checked
//            {
//                long a = 0xFFFFFFFFF;
//                long b = 0xFFFFFFFFC;
//                Assert.Equal(3, a - b);
//            }
//        }

//        [UnitTest]
//        public static void sub_ovf_long_OverflowException()
//        {
//            checked
//            {
//                long a = 0x7FFFFFFFFFFFFFFF;
//                long b = -200;
//                Assert.ExpectException(new OverflowException());
//                long c = b - a;
//            }
//        }
//    }
//}
