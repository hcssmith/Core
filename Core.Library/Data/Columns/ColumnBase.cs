using Core.Library.Types;

namespace Core.Library.Data.Columns
{
    public interface IColumnBase
    {
        public void SetColumnName(string name);
        public string GetColumnName();
    }
    public abstract class ColumnBase<TCol, TBase, TPrimative> : IColumnBase
        where TBase : TypeBase<TBase, TPrimative>
        where TPrimative : notnull
        where TCol : ColumnBase<TCol, TBase, TPrimative>, new()
    {
        protected TBase _value;
        public string? ColumnName;
        public Bool IsPrimaryKey;

        public TBase Value
        {
            get => _value;
            set => _value = value;
        }

        public ColumnBase()
        {
            IsPrimaryKey = false;
            if (typeof(TCol) == typeof(IntegerColumn))
            {
                _value = (dynamic) new Integer(default(int));
            } else if (typeof(TCol) == typeof(TextColumn))
            {
                _value = (dynamic) new Text("");
            } else {
                _value = (dynamic) new Integer(default(int));
            }
        }

        public ColumnBase(TBase b)
        {
            IsPrimaryKey = false;
            _value = b;
        }

        void IColumnBase.SetColumnName(string name)
        {
            ColumnName = name;
        }

        string IColumnBase.GetColumnName()
        {
            return ColumnName is null ? "" : ColumnName;
        }
    }
}