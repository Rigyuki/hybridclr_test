using AOTDefs;
using SharpUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CSharp.CustomeAttrites
{

    public class FT_EnumAttribute :  Attribute
    {
        public FT_EnumAttribute(AOT_Enum_int x)
        {
            X = x;
        }

        public AOT_Enum_int X { get; }
    }

    internal class TC_CustomAttribute : GeneralTestCaseBase
    {

        [UnitTest]
        [FT_Enum(AOT_Enum_int.A)]
        public void InterpreterEnumAttriteField()
        {
            var method = GetType().GetMethod(nameof(InterpreterEnumAttriteField));
            var attrs = method.GetCustomAttributes(typeof(FT_EnumAttribute), false);
            Assert.NotNull(attrs);
            Assert.Equal(1, attrs.Length);
            FT_EnumAttribute attr = (FT_EnumAttribute)attrs[0];
            Assert.Equal(AOT_Enum_int.A, attr.X);
        }

        [UnitTest]
        [AOTDefs.EnumField(AOT_Enum_int.A)]
        public void AOTEnumAttriteField()
        {
            var method = GetType().GetMethod(nameof(AOTEnumAttriteField));
            var attrs = method.GetCustomAttributes(typeof(AOTDefs.EnumFieldAttribute), false);
            Assert.NotNull(attrs);
            Assert.Equal(1, attrs.Length);
            var attr = (AOTDefs.EnumFieldAttribute)attrs[0];
            Assert.Equal(AOT_Enum_int.A, attr.X);
        }
    }
}
