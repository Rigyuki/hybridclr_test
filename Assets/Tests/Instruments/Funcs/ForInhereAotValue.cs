namespace Tests.Instruments.Funcs
{
    public struct ForInhereAotValue : IFoo
    {
        public int a;

        public int b;

        public ForInhereAotValue(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public void Inc()
        {
            a += 1;
        }

        public int Show()
        {
            return a;
        }

        public override string ToString()
        {
            return a.ToString();
        }

        public int Calc()
        {
            return a;
        }

        public static int Default()
        {
            return 10;
        }

        public object CallGeneric<T>(T x)
        {
            return $"{x}-{a}";
        }

        public static object CallStaticGeneric<T>(T x)
        {
            return x;
        }
    }

}
