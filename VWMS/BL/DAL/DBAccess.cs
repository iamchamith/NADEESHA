using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
 
namespace BL.DAL
{
    internal class DBAccess
    {
        static string connS = @"Data Source=DELL\SQLEXPRESS;Initial Catalog=NADEESHA;Integrated Security=True;Pooling=False";
        static SqlConnection Conn = new SqlConnection(connS);
        static SqlConnection GetConnection() {

            if (Conn.State == ConnectionState.Closed)
            {
                Conn = new SqlConnection(connS);
                Conn.Open();
            }
            return Conn;
        }

        public static bool Update(DataObject obj)
        {

            using (var cmd = new SqlCommand(obj.Sql, GetConnection()))
            {
                try
                {
                    foreach (var item in obj.KeyValue)
                    {
                        cmd.Parameters.AddWithValue(item.Key,item.Value);
                    }
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
             
        }

        public static DataSet Select(DataObject obj)
        {
    
            using (var cmd = new SqlCommand(obj.Sql, GetConnection()))
            {
                try
                {
                    foreach (var item in obj.KeyValue)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

    }

    public class DataObject {

        public string Sql { get; set; }
        public Dictionary<string, string> KeyValue { get; set; }
    }

  
}
