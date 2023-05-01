using Core.Library.Types;
using Core.Library.Engine;
using Core.Library.Data;
using Core.UsageExample.Models;

namespace Core.UsageExample // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSource ds = new DataSource("store.xml");
            ObjectCollection.SharedObjects.AddToStore("DefaultDataSource", ds);
            ExampleProcess ep = new ExampleProcess();
            ep.Run();     
        }
    }

    public class ExampleProcess : BusinessProcess
    {
        private readonly Account Account = new Account();

        public ExampleProcess() : base() {}
        
        public void Run()
        {
            InitializeDataView();
            Execute();
        }

        public void InitializeDataView()
        {
            From = Account;
        }

        public override void OnStart()
        {
            Console.WriteLine("This Works....");
        }

        public override void OnLeaveRow()
        {
            Console.WriteLine(Account.AccountName.Value);
        }

    }
}