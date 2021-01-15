using BUL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExCell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            Bus.GetAll(dataGridView1);
            Bus.GetAll(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BUL.Bus.xuatExcell(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select HangHoa.MaSP, HangHoa.TenSP, ChatLieu.TenChatLieu," +
               "HangHoa.DonGiaNhap " +
             ", HangHoa.DonGiaBan ," +
             " HangHoa.Soluong " +
             " from  ChatLieu ,HangHoa " +
             " where HangHoa.MaChatLieu=ChatLieu.MaChatLieu and ( HangHoa.DonGiaBan>='{0}' and HangHoa.DonGiaBan<='{1}' or " +
             " HangHoa.MaSP like N'{2}'  or HangHoa.TenSP like N'{3}' or  ChatLieu.TenChatLieu like N'{4}' " +
             "  " +
             ") "
             , textBox3.Text,textBox4.Text,textBox1.Text,textBox2.Text,comboBox1.Text);
            Bus.TruyVan(dataGridView1, sql);  
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }
    }
}
