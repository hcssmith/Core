namespace Core.Library.Types {
    public class Location : Text {
        public Location(Text t) :base(t) {}

        public static implicit operator Location(string value) => new Location(value);
        public Bool Exists()
        {
            return true;
        }
        public Bool IsDir() => true;
        public Bool IsFile() => true;
        public void Create(Text contents) {}
        public List<Text> Contents() => new List<Text>();

    }
}