using Core.Library.Types;
using Core.Library.Data.Columns;
using Core.Library.Data;

namespace Core.UsageExample.Models
{
    public class Orders : ColumnCollection
    {
        public readonly IntegerColumn AccountId = new IntegerColumn();
        public readonly IntegerColumn Id = new IntegerColumn() { PrimaryKey = true };
        public readonly TextColumn Description = new TextColumn();

        public Orders()
        {
            TableName = "Orders";
            RowLabel = "Order";
            Add(nameof(AccountId), AccountId);
            Add(nameof(Id), Id);
            Add(nameof(Description), Description);
        }


    }
}