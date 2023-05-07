using Core.Library.Types;

namespace Core.Library.Data.Columns
{
    public class ColumnCollection
    {
        private Dictionary<Text, object> _columns;
        public Dictionary<Text, object> Columns
        {
            get => _columns;
        }
        private Text tableName = new Text("");
        private Text rowLabel = new Text("");
        public Text TableName {
            get {
                if (tableName == "") return "undefinedTable";
                return tableName;
            }
            set => tableName = value;
            }
        public Text RowLabel {
            get {
                if (rowLabel == "") return "undefinedRow";
                return rowLabel;
            }
            set => rowLabel = value;
            }

        public ColumnCollection()
        {
            _columns = new();
        }

        protected void Add(Text colmunName, object col) {
            if (col is IColumnBase i)
            {
                i.SetColumnName(colmunName);
                _columns.Add(colmunName, i);
            } else {
                _columns.Add(colmunName, col);
            }
        }

        protected void Add(object col)
        {
            if (col is IColumnBase i)
            {
                _columns.Add(i.GetColumnName(), col);
            }
        }

        public Text GetPrimaryKeyColumnName()
        {
            foreach(KeyValuePair<Text, object> kvp in _columns)
            {
                if (kvp.Value is IColumnBase cb)
                {
                    if (cb.IsPrimaryKey()) return kvp.Key;
                }
            }
            return "";
        }
    }
}