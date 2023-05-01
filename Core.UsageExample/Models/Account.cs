using Core.Library.Types;
using Core.Library.Data.Columns;
using Core.Library.Data;

namespace Core.UsageExample.Models
{
    public class Account : ColumnCollection
    {
        public readonly TextColumn AccountName = new TextColumn();
        public readonly IntegerColumn Id = new IntegerColumn() { IsPrimaryKey = true };
        public readonly IntegerColumn OrderCount = new IntegerColumn();

        public Account()
        {
            TableName = "Accounts";
            RowLabel = "Account";
            Add(nameof(AccountName), AccountName);
            Add(nameof(Id), Id);
            Add(nameof(OrderCount), OrderCount);
        }


    }
}