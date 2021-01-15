using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dal
{
   public static class DAL
    {
      static  string sql = @"Data Source=DESKTOP-M08G8QT\SQLEXPRESS;Initial Catalog=ExCell;Integrated Security=True";
      private static SqlConnection connection = new SqlConnection(sql);

        public static DataTable GetAll(string sql)
        {
            DataTable data = new DataTable();
       
            try
            {
                SqlDataAdapter sqlData = new SqlDataAdapter(sql, connection);
                sqlData.Fill(data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            
            return data;

        }

    }
}
