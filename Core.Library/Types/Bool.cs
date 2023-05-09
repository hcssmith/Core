namespace Core.Library.Types
{
    public class Bool : TypeBase<Bool, bool>
    {
        public Bool(bool b) :base(b) {}
        public Bool() :base() {}

        static Bool() {DefaultValue = false;}
        public static implicit operator Bool(bool value) => new Bool(value);
        public static implicit operator Bool(Text value) => textToBool(value);
        public static implicit operator Bool(string value) => textToBool(value);
        public static implicit operator Bool(char value) => textToBool(value);
        
        private static Bool textToBool(Text t)
        {
            if (t.In("True", "TRUE", "t", "T"))
            {
                return new Bool(true);
            }
            return new Bool(false);
        }
        public static implicit operator bool(Bool i) => i.Value;
        public override Bool _Decr() => throw new Exception("Invalid oprtation");
        public override Bool _Incr() => throw new Exception("Invalid oprtation");
    }
}
