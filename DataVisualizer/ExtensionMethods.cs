using System.Data;
using System.Data.OleDb;
using System.IO;

namespace DataVisualizer
{
    class ExtensionMethods
    {
        public static DataSet ConvertCSVtoDataTable(string filePath)
        {
            using (OleDbConnection conn = new OleDbConnection
                       ("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " +
                         Path.GetDirectoryName(filePath) +
                         "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\""))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter
                   ("SELECT * FROM " + Path.GetFileName(filePath), conn);

                DataSet ds = new DataSet("Temp");
                adapter.Fill(ds);
                return ds;
            }
        }
    }
}
