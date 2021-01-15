using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
 public static   class BUS
    {

         public static void  GetALL(DataGridView data)
        {
           data.DataSource= DAL.DAL.GetALL(" EXEC GETALL");
        }
        public static void XUlY(string SQL)
        {
            DAL.DAL.truyvan(SQL);

        }
        public static void XuatEcel( DataGridView data)
        {
            _Application application = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = application.Workbooks.Add(Type.Missing);
            Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Cells.Font.Size = 12;
            worksheet.Cells.Font.Bold = true;
            worksheet.Cells.ColumnWidth = 15;
            worksheet.Cells[2, 3] = "Danh Sach Cong Viec";
            int hang = 5;
            for (int i = 0; i < data.Columns.Count; i++)
            {
                worksheet.Cells[hang, i + 1] = data.Columns[i].Name;
            }

            for (int i = 0; i < data.Rows.Count-1; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    worksheet.Cells[hang+i+1, i + 1] = data.Rows[i].Cells[j].Value.ToString();
                }
            }
            application.Visible = true;

        }

    }
}
