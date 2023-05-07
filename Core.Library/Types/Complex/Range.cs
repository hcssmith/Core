using System.Collections;
using Core.Library.Types;

namespace Core.Library.Types.Complex
{
    public class Range<T> : IEnumerable
        where T: notnull, IComparable
    {
        private List<T> _items;

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) GetEnumerator();

        public RangeEnum<T> GetEnumerator() => new RangeEnum<T>(_items); 

        public Range (T count)
        {
            _items = new List<T>();
            T? start = default(T);
            if (start is null) start = (T)Activator.CreateInstance<T>();
            for(T curr = start; (dynamic) curr < count; curr = (dynamic) curr + 1)
            {
                _items.Add(curr);
            }
        }
        ///
        /// Inclusive Range Range(1, 5) -> 1, 2, 3, 4, 5
        public Range(T start, T end)
        {
            _items = new List<T>();
            for(T curr = start; (dynamic) curr <= end; curr = (dynamic) curr + 1)
            {
                _items.Add(curr);
            }
        }

        public static Range<T> New(T start, T end) => new Range<T>(start, end);
        public static Range<T> New(T count) => new Range<T>(count);

        public void Filter(Func<T, bool> filter_func)
        {
            int position = 0;
            while(position < _items.Count)
            {
                if(filter_func(_items[position])) _items.RemoveAt(position);
                position++;
            }
        }

        public List<object> Apply(Func<T, object> func)
        {
            List<object> return_list = new List<object>();
            foreach(var v in _items)
            {
                return_list.Add(func(v));
            }
            return return_list;
        }

        public void Apply(Action<T> func)
        {
            int position = 0;
            while(position < _items.Count)
            {
                func(_items[position]);
                position++;
            }
        }

        public void Apply(Func<T, T> func)
        {
            int position = 0;
            while(position < _items.Count)
            {
                _items[position] = func(_items[position]);
                position++;
            }
        }

        public T this[int index]
        {
            get => _items[index];
        }




        public class RangeEnum<T1> : IEnumerator
            where T1: notnull, IComparable
        {
            List<T1> _items;
            int position;

            public RangeEnum(List<T1> items)
            {
                position = -1;
                _items = items;
            }
            object IEnumerator.Current {get => Current;}

            public T1 Current
            {
                get
                    {
                        try
                        {
                            return _items[position];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            throw new InvalidOperationException();
                        }
                    }
            }
       

            public bool MoveNext()
            {
                position++;
                return (position < _items.Count );
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}