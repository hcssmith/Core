using Core.Library.Data;
using Core.Library.Data.Columns;
using Core.Library.Types;

namespace Core.Library.Engine
{
    public class BusinessProcess
    {
        protected DataSource _ds;
        protected Integer Counter;
        private ColumnCollection? _queryBase;
        protected ColumnCollection? From { get => _queryBase; set => _queryBase = value; }

        protected List<object> Relations;
        protected List<object> Where;
        private List<ColumnCollection> rows;

        private delegate void OnStartEvent();
        private delegate void OnEnterRowEvent();
        private delegate void OnLeaveRowEvent();
        private delegate void OnEndEvent();

        OnStartEvent? OnStartActions;
        OnEnterRowEvent? OnEnterRowActions;
        OnLeaveRowEvent? OnLeaveRowActions;
        OnEndEvent? OnEndActions;


        public BusinessProcess()
        {
            DataSource? ds = (DataSource?)ObjectCollection.SharedObjects.GetObject("DefaultDataSource");
            if (ds is null)
            {
                throw new Exception("No Default Data Source specified");
            }
            _ds = ds;
            rows = new();
            Counter = 0;
        }

        protected void Execute()
        {
            //Start actions
            OnStartActions += Start;
            OnStartActions += OnStart;
            //begin row
            OnEnterRowActions += EnterRow;
            OnEnterRowActions += OnEnterRow;
            // end row
            OnLeaveRowActions += OnLeaveRow;
            OnLeaveRowActions += LeaveRow;
            // end actions
            OnEndActions += End;
            OnEndActions += OnEnd;

            foreach(Delegate onStartEvent in OnStartActions.GetInvocationList())
            {
                onStartEvent.DynamicInvoke();
            }

            foreach(ColumnCollection row in rows)
            {
                foreach (KeyValuePair<Text, object> col in row.Columns)
                {
                    if (From is null) throw new Exception("No From set");
                    if (From.Columns[col.Key] is TextColumn){
                        ((TextColumn)From.Columns[col.Key]).Value = ((TextColumn)col.Value).Value;
                    } else if (From.Columns[col.Key] is IntegerColumn)
                    {
                        ((IntegerColumn)From.Columns[col.Key]).Value = ((IntegerColumn)col.Value).Value;
                    }
                }
                foreach(Delegate onRowEnterEvent in OnEnterRowActions.GetInvocationList())
                {
                    Counter++;
                    onRowEnterEvent.DynamicInvoke();
                }
                foreach(Delegate onRowLeaveEvent in OnLeaveRowActions.GetInvocationList())
                {
                    onRowLeaveEvent.DynamicInvoke();
                }
            }

            foreach(Delegate onEndEvent in OnEndActions.GetInvocationList())
            {
                onEndEvent.DynamicInvoke();
            }



        }

        private void Start()
        {
            if (From is not null)
            {
                rows = _ds.GetAllRows(From);
            }
        }

        private void EnterRow()
        {
            //pass
        }

        private void LeaveRow()
        {
            if (From is not null)
            {
                _ds.SaveRow(From);
            }
            //Save row to datasource
            Console.WriteLine("Save / create / delete current row");
        }

        private void End()
        {
            // dispose of any instance variables
            Console.WriteLine("Final actions.");
        }

        public virtual void OnLeaveRow() {}
        public virtual void OnEnterRow() {}
        public virtual void OnStart() {}
        public virtual void OnEnd() {}

    }
}