using SharpUnit;


namespace Tests.Instruments.Branches
{
    internal class TC_Ble_un
    {
        [UnitTest]
        public static void ble_un_s_uint()
        {
            uint a = 32U;
            uint aa = 31U;
            if (a > aa)
            {
                Assert.True(true);
            }
            Assert.Fail();
        }

        [UnitTest]
        public static void ble_un_s_ulong()
        {
            ulong a = 32U;
            ulong aa = 31U;
            if (a > aa)
            {
                Assert.True(true);
            }
            Assert.Fail();
        }

        [UnitTest]
        public static void ble_un_int()
        {
            uint a = 32U;
            uint aa = 31U;
            if (a > aa)
            {
                Assert.Fail();
                var b = 245;
                var c = 231;
                var d = 897;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                Assert.True(true);
            }
            else
            {
                Assert.Fail();
            }
        }

        [UnitTest]
        public static void ble_un_long()
        {
            ulong a = 32U;
            ulong aa = 31U;
            if (a > aa)
            {
                Assert.Fail();
                var b = 245;
                var c = 231;
                var d = 897;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                c = b + c; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1; b = b + 1;
                b = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c; d = b + c;
                Assert.True(true);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
