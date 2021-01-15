using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
     public static class DAL
    {
        static string sql = @"Data Source=DESKTOP-M08G8QT\SQLEXPRESS;Initial Catalog=Bai1;Integrated Security=True";
        private static SqlConnection connection = new SqlConnection(sql);

        public static DataTable GetALL(string sql)
        {
            DataTable data = new DataTable();
            SqlDataAdapter sqlData = new SqlDataAdapter(sql,connection);
            sqlData.Fill(data);
            return data;
        }
        public static bool truyvan(string sql)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                return true;

            }catch(Exception e)
            {
                MessageBox.Show("Da xay ra loi" + e.Message)
                    ;
                return false;
                 
            }

            return true;
        }
       


    }
}
