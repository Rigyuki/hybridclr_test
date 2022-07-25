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

    public class FT_BoxedValueAttribute : Attribute
    {
        public object[] Args { get; }

        public FT_BoxedValueAttribute(params object[] args)
        {
            Args = args;
        }
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
        [FT_BoxedValue(AOT_Enum_int.A)]
        public void fixedarg_boxed_enum()
        {
            var method = GetType().GetMethod(nameof(fixedarg_boxed_enum));
            var attrs = method.GetCustomAttributes(typeof(FT_BoxedValueAttribute), false);
            Assert.NotNull(attrs);
            Assert.Equal(1, attrs.Length);
            var attr = (FT_BoxedValueAttribute)attrs[0];
            Assert.Equal(AOT_Enum_int.A, (AOT_Enum_int)attr.Args[0]);
        }

        [UnitTest]
        [FT_BoxedValue(11L)]
        public void fixedarg_boxed_long()
        {
            var method = GetType().GetMethod(nameof(fixedarg_boxed_long));
            var attrs = method.GetCustomAttributes(typeof(FT_BoxedValueAttribute), false);
            Assert.NotNull(attrs);
            Assert.Equal(1, attrs.Length);
            var attr = (FT_BoxedValueAttribute)attrs[0];
            Assert.Equal(11L, (long)attr.Args[0]);
        }

        [UnitTest]
        [FT_BoxedValue(typeof(Vector2d))]
        public void fixedarg_type()
        {
            var method = GetType().GetMethod(nameof(fixedarg_type));
            var attrs = method.GetCustomAttributes(typeof(FT_BoxedValueAttribute), false);
            Assert.NotNull(attrs);
            Assert.Equal(1, attrs.Length);
            var attr = (FT_BoxedValueAttribute)attrs[0];
            Assert.Equal(typeof(Vector2d), (Type)attr.Args[0]);
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
