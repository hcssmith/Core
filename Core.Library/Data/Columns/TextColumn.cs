using Core.Library.Types;

namespace Core.Library.Data.Columns
{
    public class TextColumn : ColumnBase<TextColumn, Text, string>
    {
        public TextColumn(Text t) : base(t) {}
        public TextColumn() : base() {}
    }
}