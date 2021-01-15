using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuyenTap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Loald();
        }

        private void Loald()
        {
            BUS.BUS.GetALL(dataGridView1);
            
        }
        string file = "";
        public void reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            file = "";
            pictureBox1.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BUS.BUS.GetALL(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(DialogResult.OK == open.ShowDialog())
            {
                int j = 0;
                open.Filter = "Insert image(*)|*";
                string FileNguon = open.FileName;
                file = Path.GetFileName(open.FileName);
                string FileCopy = Path.Combine(@"ANH\" + file);
                try
                {
                    File.Copy(FileNguon, FileCopy, true);
                }
                catch { }
                pictureBox1.Image = Image.FromFile(FileCopy);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    file = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    pictureBox1.Image = Image.FromFile(@"ANH\" + file);

                }
            }
            catch  { }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = string.Format("insert into Vat_Lieu values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')" +
                " ", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, file, textBox7.Text);
           if (BUS.BUS.XuLy(sql)==false)
            {
                MessageBox.Show("Trung Khoa");
            }
            else
            {
                MessageBox.Show("Them Thanh cong");
                Loald();
                reset();
            }  
       }

        private void button2_Click(object sender, EventArgs e)
        {

            string sql = string.Format("update Vat_Lieu set TenVL='{1}',DVT='{2}'," +
                " GiaNhap='{3}', GiaBan='{4}',SoLuong='{5}',ANH='{6}',ghiChu='{7}' where MaVL='{0}' " +
                " ", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, file, textBox7.Text);
            if (BUS.BUS.XuLy(sql) == false)
            {
                MessageBox.Show("Loi ");
            }
            else
            {
                MessageBox.Show("Sua Thanh cong");
                Loald();
                reset();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string sql = string.Format("delete Vat_Lieu  " +
                " where MaVL='{0}' " +
                " ", textBox1.Text);
            if (BUS.BUS.XuLy(sql) == false)
            {
                MessageBox.Show("Loi ");
            }
            else
            {
                MessageBox.Show("Xoa Thanh cong");
                Loald();
                reset();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
            Loald();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BUS.BUS.XuatEcell(dataGridView1);
        }
    }
}
