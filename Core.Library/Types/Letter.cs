namespace Core.Library.Types {
    public class Letter : TypeBase<Letter, char>
    {
        public Letter(char value) :base(value) {
        }
        public static implicit operator Letter(char value) => new Letter(value);
        public static implicit operator Letter(string value) =>textToLetter(value);
        public static implicit operator Letter(Text value) =>textToLetter(value);
        public static implicit operator char(Letter i) => i.Value;
        public static implicit operator string(Letter i) => i.Value.ToString();

        private static Letter textToLetter(Text t) {
            if (t.Value.Length > 0)
            {
                return new Letter(t.Value[0]);
            } else {
                return new Letter('\0');
            }
        }

        public override Letter _Decr() => throw new Exception("Invalid oprtation");
        public override Letter _Incr() => throw new Exception("Invalid oprtation");

        public override bool Equals(object? obj) {
            if (obj == null) return false;
            return Value == ((Letter)obj).Value;
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}