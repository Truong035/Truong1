using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;
using System.Drawing;


namespace BUS
{
   public static class BUS
    {
        public static void GetALL(DataGridView dataGridView1)
        {
            dataGridView1.DataSource = DAL.DAL.GetAll("Select * from Vat_Lieu");


        }


        public static bool  XuLy(string sql)
        {
            //if (DAL.DAL.TruyXuat(sql))
            //{
            //   // MessageBox.Show("Thanh cong ");
                
            //}
            //else
            //{
            //    MessageBox.Show("Da Co Loi Xay Ra ");
            //    return false;
            //}
            return DAL.DAL.TruyXuat(sql);
         
        }

        public static void XuatEcell(DataGridView dataGridView1)
        {
            Microsoft.Office.Interop.Excel._Application application = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet= workbook.ActiveSheet;
            worksheet.Cells.ColumnWidth = 15;

            worksheet.Cells[3, 3] = "Danh Sach Vat Lieu";
            worksheet.Cells[3,3].Font.Size = 14;
            worksheet.Cells[3,3].Font.Bold = true;

            worksheet.Cells[5, 1] = "STT";
            worksheet.Cells[5, 1].Font.Size = 13;
            worksheet.Cells[5,  1].Font.Bold = true;
            worksheet.Cells[5,  1].Interior.Color = ColorTranslator.ToOle(Color.Yellow);
            worksheet.Cells[5,  1].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            worksheet.Cells[5,  1].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            worksheet.Cells[5, 1].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            worksheet.Cells[5, 1].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            int row = 1;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {

           

                worksheet.Cells[5, i+2] = dataGridView1.Columns[i].Name;
                worksheet.Cells[5, i+2].Font.Size = 13;
                worksheet.Cells[5 , i + 2].Font.Bold = true;
                worksheet.Cells[5,i+2].Interior.Color = ColorTranslator.ToOle(Color.Yellow);
                worksheet.Cells[5, i + 2].Borders[XlBordersIndex.xlEdgeLeft].LineStyle =XlLineStyle.xlContinuous;
                worksheet.Cells[5, i + 2].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Cells[5, i + 2].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Cells[5, i + 2].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
               
            }

            for (int j = 0; j <dataGridView1.Rows.Count-1; j++)
            {
                
                worksheet.Cells[5+j+1, 1] = j + 1;
                worksheet.Cells[5+j+1, 1].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Cells[5+j+1, 1].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Cells[5+j+1, 1].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                worksheet.Cells[5+j+1, 1].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[5+j+1, i + 1+1] = dataGridView1.Rows[j].Cells[i].Value.ToString();
                    worksheet.Cells[5 +j+1,i + 1+1].Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    worksheet.Cells[5 + j + 1, i + 1+1].Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    worksheet.Cells[5 + j + 1, i + 1+1].Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    worksheet.Cells[5 + j + 1, i + 1+1].Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                }

            }
            application.Visible = true;
          

        }
    }
}
