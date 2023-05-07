
using Core.Library.Data.Columns;
using Core.Library.Data;
using Core.Library.Types;
using System.Xml;


namespace Core.Library.Data
{
    public enum DataSourceType
    {
        Xml,
    }
    public class DataSource 
    {
        private Location dataLocation;
        private IRowsProvider ds;

        public DataSource(Text connectionString, DataSourceType? typeOfDataSource = null)
        {
            dataLocation = connectionString.Value;
            switch (typeOfDataSource)
            {
                case DataSourceType.Xml:
                    ds = new XMLDataSource(dataLocation);
                    break;
                default:
                    ds = new XMLDataSource(dataLocation);
                    break;
            }
        }

        public List<T> GetAllRows<T>(T model) where T : ColumnCollection => ds.GetAllRows(model);
        public void SaveRow<T>(T model) where T : ColumnCollection => ds.SaveRow(model);

        internal interface IRowsProvider
        {
            List<T> GetAllRows<T>(T model) where T : ColumnCollection;
            void SaveRow<T>(T model) where T : ColumnCollection;
        }

        internal class XMLDataSource : IRowsProvider
        {
            private Location fileLocation;
            public XMLDataSource(Location xmlFileLocation)
            {
                fileLocation = xmlFileLocation;
            }
            void IRowsProvider.SaveRow<T>(T model)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileLocation);
                //TODO: Fix xpath based on model primary key
                XmlNode? node = doc.SelectSingleNode("//" + model.TableName+"/"+model.RowLabel+"[]");
                if (node is null)
                {
                    // create new node.
                    doc.Save(fileLocation);
                    return;
                }
                if (node.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (XmlElement)node;
                    foreach(KeyValuePair<Text, object> v in ((ColumnCollection)model).Columns)
                    {
                        e.SetAttribute(v.Key, ((IColumnBase)v.Value).GetValue());
                    }
                }
                doc.Save(fileLocation);

            }

            List<T> IRowsProvider.GetAllRows<T>(T model)
            {
                List<T> l = new List<T>();
                XmlDocument doc = new XmlDocument();
                doc.Load(fileLocation);
                XmlNodeList? rows = doc.SelectNodes("//"+ model.TableName + "/" + model.RowLabel);
                if (rows is null) return new List<T>();
                foreach(XmlNode row in rows)
                {
                    T? newRow = (T?)Activator.CreateInstance(model.GetType());
                    if (newRow is null) throw new Exception("Could not create new instance of model");
                    if (row.NodeType != XmlNodeType.Element) break;
                    XmlElement e = (XmlElement)row;
                    foreach( KeyValuePair<Text, object> col in newRow.Columns)
                    {
                        string? s = e.GetAttribute(col.Key);
                        if (s is null) break;
                        if (col.Value is IntegerColumn i)
                        {
                            i.Value = s;
                        } else if (col.Value is TextColumn t)
                        {
                            t.Value = s;
                        }
                    }
                    l.Add(newRow);
                }
                return l;
            }
        }
    }
}