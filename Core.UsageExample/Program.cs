using Core.Library.Types;
using Core.Library.Types.Complex;
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
            Range<int> r = Range<int>.New(6);
            r.Filter((x)=>{
                if(x==2 || x==3) return true;
                return false;
                });
            r.Apply((x) => x * 2);
            foreach(var v in r)
            {
                Console.WriteLine(v);
            }
            Integer i = DefaultTypeBuilder.CreateDefault<Integer>();
            Console.WriteLine(i);
        }
    }

    public class ExampleProcess : BusinessProcess
    {
        private readonly Account Account = new Account();
        private readonly Orders Order = new Orders();

        public ExampleProcess() : base() {}
        
        public void Run()
        {
            InitializeDataView();
            Execute();
        }

        public void InitializeDataView()
        {
            From = Account;

            //Relations.Add(Order);
        }

        public override void OnStart()
        {
            Console.WriteLine("This Works....");
        }

        public override void OnLeaveRow()
        {
            Console.WriteLine(Account.AccountName.Value);
            Result<Text, Bool> t = TestFunc();
            if(t.Successfull)
            {
              Console.WriteLine(t.Value);
            }
            if (Account.Id.Value == 3)
            {
                Account.AccountName.Value = "James";
            } 
            
        }

        private Result<Text, Bool> TestFunc()
        {
          Result<Text, Bool> res = new("Some Value");
          return res;
        }

    }
}
