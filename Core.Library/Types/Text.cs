namespace Core.Library.Types {
    public class Text : TypeBase<Text, string>
    {
        public Text(string value) :base(value) {
        }
        public static implicit operator Text(string value) => new Text(value);
        public static implicit operator Text(char value) => new Text(value.ToString());
        public static implicit operator Text(Letter value) => new Text(value.Value.ToString());
        public static implicit operator string(Text i) => i.Value;

        public override Text _Decr() => throw new Exception("Invalid oprtation");
        public override Text _Incr() => throw new Exception("Invalid oprtation");

        public override bool Equals(object? obj) {
            if (obj == null) return false;
            return Value == ((Text)obj).Value;
        }
        public override int GetHashCode() => base.GetHashCode();
    }
}