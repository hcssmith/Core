namespace Core.Library.Types {
    public class Fraction : TypeBase<Fraction, double>
    {
        public Fraction(double value) :base(value) {
            SetIncrAmount(1.0);
        }
        public Fraction() : base() {}

        static Fraction() {DefaultValue = 0.0;}
        public static implicit operator Fraction(double value) => new Fraction(value);

        public static implicit operator Fraction(Text value) => textToFraction(value);
        public static implicit operator Fraction(Letter value) => textToFraction(value);
        public static implicit operator Fraction(string value) => textToFraction(value);
        public static implicit operator Fraction(char value) => textToFraction(value);
        public static implicit operator double(Fraction i) => i.Value;
        private static Fraction textToFraction(Text t) => Convert.ToDouble(t.Value);

        public override Fraction _Decr() => new Fraction(Value-incrAmount);
        public override Fraction _Incr() => new Fraction(Value+incrAmount);

        public override bool Equals(object? obj) {
            if (obj == null) return false;
            return Value == ((Fraction)obj).Value;
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}
