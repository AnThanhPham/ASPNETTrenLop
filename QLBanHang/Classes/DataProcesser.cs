using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QLBanHang.Classes
{
    internal class DataProcesser
    {
        string strConnect = "Data Source=DESKTOP-671LI2L\\SQLEXPRESS;Initial Catalog=QLBanHang;User ID=sa;Password=123456";
        SqlConnection sqlConncect = null;
        
        //Open a connection to Server
        void OpenConnection()
        {
            sqlConncect = new SqlConnection(strConnect);
            if(sqlConncect.State != ConnectionState.Open)
                sqlConncect.Open();
        }
        
        //Close a Connection
        void CloseConnection()
        {
            if(sqlConncect.State != ConnectionState.Closed)
            {
                sqlConncect.Close();
                sqlConncect.Dispose();
            }    
        }
        //read Data from a Select statement and return a DataTable
        public DataTable ReadData(string sqlSelect)
        {
            DataTable dt = new DataTable();
            OpenConnection();
            SqlDataAdapter dataAdapter=new SqlDataAdapter(sqlSelect,sqlConncect);
            dataAdapter.Fill(dt);
            CloseConnection();
            dataAdapter.Dispose();
            return dt;
        }
        
        //Change Data 
        public void ChangeData(string sql)
        {
            OpenConnection();
            SqlCommand sqlcmm = new SqlCommand();
            sqlcmm.Connection = sqlConncect;
            sqlcmm.CommandText = sql;
            sqlcmm.ExecuteNonQuery();
            CloseConnection();
            sqlcmm.Dispose();
        }

    }
}
