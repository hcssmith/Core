using Core.Library.Types;

namespace Core.Library.Engine {
    public class ObjectCollection
    {
        private readonly Dictionary<Text, object> _objectStore = new Dictionary<Text, object>();

        private static ObjectCollection _sharedObjects = new ObjectCollection();

        public static ObjectCollection SharedObjects {
            get => _sharedObjects;
        }

        public object? GetObject(Text objref)
        {
            if (_objectStore.ContainsKey(objref))
            {
                return _objectStore[objref];
            }
            return null;
        }

        public void AddToStore(Text objref, object o) => _objectStore.Add(objref, o);
    }
}