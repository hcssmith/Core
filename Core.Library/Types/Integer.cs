namespace Core.Library.Types {
    public class Integer : TypeBase<Integer, int>
    {
        public Integer(int value) :base(value) {
            SetIncrAmount(1);
        }
        public Integer() : base() {}
        static Integer() {DefaultValue = 0;}
        public static implicit operator Integer(int value) => new Integer(value);
        public static implicit operator Integer(Text value) => texttoInteger(value);
        public static implicit operator Integer(Letter value) => texttoInteger(value);
        public static implicit operator Integer(string value) => texttoInteger(value);
        public static implicit operator Integer(char value) => texttoInteger(value);
        public static implicit operator int(Integer i) => i.Value;
        public static implicit operator Text(Integer i) => i.Value.ToString();

        private static Integer texttoInteger(Text t) => Convert.ToInt32(t);

        public override Integer _Decr() => new Integer(Value-incrAmount);
        public override Integer _Incr() => new Integer(Value+incrAmount);

        public override bool Equals(object? obj) {
            if (obj == null) return false;
            return Value == ((Integer)obj).Value;
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
