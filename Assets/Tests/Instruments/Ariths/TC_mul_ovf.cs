//using System;
//using SharpUnit;

//namespace Tests.Instruments.Ariths
//{
//    class TC_Mul_ovf : HuatuoTestCaseBase
//    {
//        [UnitTest]
//        public static void mul_ovf_int()
//        {
//            checked
//            {
//                int a = 2;
//                int b = 3;
//                Assert.Equal(6, a * b);
//            }
//        }

//        [UnitTest]
//        public static void mul_ovf_long()
//        {
//            checked
//            {
//                long a = 2;
//                long b = 3;
//                Assert.Equal(6, a * b);
//            }
//        }

//        [UnitTest]
//        public static void mul_ovf_float()
//        {
//            checked
//            {
//                float a = 2;
//                float b = 3;
//                Assert.Equal(6f, a * b);
//            }
//        }

//        [UnitTest]
//        public static void mul_ovf_double()
//        {
//            checked
//            {
//                double a = 2;
//                double b = 3;
//                Assert.Equal(6d, a * b);
//            }
//        }

//        [UnitTest]
//        public static void mul_ovf_int_OverflowException()
//        {
//            checked
//            {
//                int a = 2147483647;
//                int b = 2147483647;
//                Assert.ExpectException(new OverflowException());
//                int c = a * b;
//            }
//        }

//        [UnitTest]
//        public static void mul_ovf_long_OverflowException()
//        {
//            checked
//            {
//                long a = 9223372036854775807;
//                long b = 9223372036854775807;
//                Assert.ExpectException(new OverflowException());
//                long c = a * b;
//            }
//        }

//        [UnitTest]
//        public static void mul_ovf_un_uint()
//        {
//            checked
//            {
//                uint a = 2;
//                uint b = 3;
//                Assert.Equal(6, a * b);
//            }
//        }

//        [UnitTest]
//        public static void mul_ovf_un_ulong()
//        {
//            checked
//            {
//                ulong a = 2;
//                ulong b = 3;
//                Assert.Equal(6, a * b);
//            }
//        }

//        [UnitTest]
//        public void mul_ovf_un_uint_OverflowException()
//        {
//            checked
//            {
//                uint a = 4294967295;
//                uint b = 4294967295;
//                Assert.ExpectException(new OverflowException());
//                uint c = a * b;
//                Assert.Fail();
//            }
//        }

//        [UnitTest]
//        public void mul_ovf_un_ulong_OverflowException()
//        {
//            checked
//            {
//                ulong a = 18446744073709551615;
//                ulong b = 18446744073709551615;
//                Assert.ExpectException(new OverflowException());
//                ulong c = a * b;
//                Assert.Fail();
//            }
//        }
//    }
//}