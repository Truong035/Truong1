using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
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
            BUS.BUS.GetALL(dataGridView1);
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length>0 && textBox3.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                string sql = string.Format("insert into Congviec values ('{0}' , '{1}' ,'{2}')", textBox1.Text,
                    textBox2.Text, textBox3.Text);
                BUS.BUS.XUlY(sql);
                LoadData();

            }
            else
            {
                MessageBox.Show("Vui Long nhap day du thong tin ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = string.Format("delete congviec where MaCV = '{0}' ", textBox1.Text
                   );
            BUS.BUS.XUlY(sql);
            LoadData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox3.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                string sql = string.Format("update Congviec set TenCV= '{1}' , Luong='{2}' where MaCV = '{0} '", textBox1.Text,
                    textBox2.Text, textBox3.Text);
                BUS.BUS.XUlY(sql);
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui Long nhap day du thong tin ");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int check = -1;
        string ma ="";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            check = e.RowIndex;
            if (check > -1)
            {
                ma = dataGridView1.Rows[check].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[check].Cells[0].Value.ToString(); 
                textBox2.Text = dataGridView1.Rows[check].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[check].Cells[2].Value.ToString();
                button2.Enabled = true;
                button3.Enabled = true;
                button1.Enabled = false;

            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = true;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BUS.BUS.XuatEcel(dataGridView1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(ma))
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
    }
}
