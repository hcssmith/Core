using Core.Library.Types;

namespace Core.Library.Data.Columns
{
    public interface IColumnBase
    {
        public void SetColumnName(string name);
        public Text GetColumnName();
        public Bool IsPrimaryKey(); 
        public Bool Altered();
        public Text GetValue(); 
    }
    public abstract class ColumnBase<TCol, TBase, TPrimative> : IColumnBase
        where TBase : TypeBase<TBase, TPrimative>
        where TPrimative : notnull
        where TCol : ColumnBase<TCol, TBase, TPrimative>, new()
    {
        protected TBase _value;
        protected TBase _previousValue;
        public string? ColumnName;
        private Bool _pk;
        public Bool PrimaryKey { get => _pk; set => _pk = value; } 
        public TBase Value
        {
            get => _value;
            set => _value = value;
        }

        public TBase PreviousValue
        {
            get => _previousValue;
        }

        public ColumnBase()
        {
            _pk = false;
            if (typeof(TCol) == typeof(IntegerColumn))
            {
                _value = (dynamic) new Integer(default(int));
            } else if (typeof(TCol) == typeof(TextColumn))
            {
                _value = (dynamic) new Text("");
            } else {
                _value = (dynamic) new Integer(default(int));
            }
            _previousValue = _value;
        }

        public ColumnBase(TBase b)
        {
            _pk = false;
            _value = b;
            _previousValue = _value;

        }

        void IColumnBase.SetColumnName(string name) => ColumnName = name;
        Text IColumnBase.GetColumnName() => ColumnName is null ? "" : ColumnName;
        Bool IColumnBase.IsPrimaryKey() => _pk;
        Bool IColumnBase.Altered() => _value != _previousValue;
        Text IColumnBase.GetValue() => (dynamic) _value;
    }
}