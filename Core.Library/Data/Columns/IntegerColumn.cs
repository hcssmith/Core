using  Core.Library.Types;

namespace Core.Library.Data.Columns
{
    public class IntegerColumn : ColumnBase<IntegerColumn, Integer, int>
    {
        public IntegerColumn(Integer i) : base(i) {}
        public IntegerColumn() : base() {}
    }
}