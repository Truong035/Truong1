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
        static SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-M08G8QT\SQLEXPRESS;Initial Catalog=Onthi;Integrated Security=True");
        public static DataTable GetAll(string v)
        {
            DataTable data = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(v, connection);
            dataAdapter.Fill(data);
            return data;
        }

        public static bool TruyXuat(string sql)
        {
            try
            {
                connection.Open();
                SqlCommand sql1 = new SqlCommand(sql, connection);
                sql1.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(""+e.Message);
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }
    }
}
