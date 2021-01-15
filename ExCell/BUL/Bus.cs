using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUL
{
    public static class Bus
    {

        public static void GetAll(DataGridView data)
        {
            string sql = string.Format("select HangHoa.MaSP, HangHoa.TenSP, ChatLieu.TenChatLieu," +
                "HangHoa.DonGiaNhap " +
 ", HangHoa.DonGiaBan , HangHoa.Soluong from  ChatLieu ,HangHoa where HangHoa.MaChatLieu=ChatLieu.MaChatLieu ");
            data.DataSource = Dal.DAL.GetAll(sql);


        }

        public static void GetAll(ComboBox comboBox1)
        {
            string sql = "select * from ChatLieu";
            comboBox1.DataSource = Dal.DAL.GetAll(sql);
            comboBox1.DisplayMember = "TenChatLieu";
            comboBox1.ValueMember = "MaChatLieu";

        }
        public static void xuatExcell(DataGridView data)
        {

            _Application application = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = application.Workbooks.Add(Type.Missing);
            Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Cells[3, 3] = "Danh Sach Hang Hoa";
            int hang = 5;
            worksheet.Cells.ColumnWidth = 20;
            worksheet.Cells.Font.Size = 12;
           
           worksheet.Cells[5,1].Interior.Color= ColorTranslator.ToOle(System.Drawing.Color.Red);
            for (int i = 0; i < data.Columns.Count; i++)
            {
                worksheet.Cells[5, i + 1] = data.Columns[i].Name;
                worksheet.Cells[5,i+1].Font.Bold = true;
                worksheet.Cells[5, i + 1].Font.Size = 15;
                worksheet.Cells[hang,i+1].Interior.Color = ColorTranslator.ToOle(Color.Yellow);
                worksheet.Cells[hang,i+1].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Cells[hang, i + 1].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Cells[hang, i + 1].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Cells[hang, i + 1].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            }
            worksheet.Cells.Font.Bold = false;
            for (int i = 0; i < data.Rows.Count - 1; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    worksheet.Cells[hang + i + 1, j + 1] = data.Rows[i].Cells[j].Value.ToString();
                    worksheet.Cells[hang + i + 1, j + 1].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    worksheet.Cells[hang + i + 1, j + 1].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    worksheet.Cells[hang + i + 1, j + 1].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    worksheet.Cells[hang + i + 1, j + 1].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                }

            }
            application.Visible = true;
            
        }

        public static void TruyVan(DataGridView  data  ,string sql)
        {
            
            data.DataSource = Dal.DAL.GetAll(sql);

        }
    }
}
