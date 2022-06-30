﻿using System;
using SharpUnit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Instruments.Mems
{
    internal class TC_ldloca: GeneralTestCaseBase
    {
        [UnitTest]
        public static void loc_s()
        {
            int a = 8;
            ref var r = ref a;
            Assert.Equal(8, r);
        }

        [UnitTest]
        public static void loc_255()
        {
            int a000, a001, a002, a003, a004, a005, a006, a007, a008, a009;
            int a010, a011, a012, a013, a014, a015, a016, a017, a018, a019;
            int a020, a021, a022, a023, a024, a025, a026, a027, a028, a029;
            int a030, a031, a032, a033, a034, a035, a036, a037, a038, a039;
            int a040, a041, a042, a043, a044, a045, a046, a047, a048, a049;
            int a050, a051, a052, a053, a054, a055, a056, a057, a058, a059;
            int a060, a061, a062, a063, a064, a065, a066, a067, a068, a069;
            int a070, a071, a072, a073, a074, a075, a076, a077, a078, a079;
            int a080, a081, a082, a083, a084, a085, a086, a087, a088, a089;
            int a090, a091, a092, a093, a094, a095, a096, a097, a098, a099;
            int a100, a101, a102, a103, a104, a105, a106, a107, a108, a109;
            int a110, a111, a112, a113, a114, a115, a116, a117, a118, a119;
            int a120, a121, a122, a123, a124, a125, a126, a127, a128, a129;
            int a130, a131, a132, a133, a134, a135, a136, a137, a138, a139;
            int a140, a141, a142, a143, a144, a145, a146, a147, a148, a149;
            int a150, a151, a152, a153, a154, a155, a156, a157, a158, a159;
            int a160, a161, a162, a163, a164, a165, a166, a167, a168, a169;
            int a170, a171, a172, a173, a174, a175, a176, a177, a178, a179;
            int a180, a181, a182, a183, a184, a185, a186, a187, a188, a189;
            int a190, a191, a192, a193, a194, a195, a196, a197, a198, a199;
            int a200, a201, a202, a203, a204, a205, a206, a207, a208, a209;
            int a210, a211, a212, a213, a214, a215, a216, a217, a218, a219;
            int a220, a221, a222, a223, a224, a225, a226, a227, a228, a229;
            int a230, a231, a232, a233, a234, a235, a236, a237, a238, a239;
            int a240, a241, a242, a243, a244, a245, a246, a247, a248, a249;
            int a250, a251, a252, a253, a254;
            int a255 = 255;
            ref var r = ref a255;
            Assert.Equal(255, r);
        }
    }
}
