using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufacturingExecutionSystem.MES.Client.Model;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.Windows.Forms;
using System.IO;
using NPOI.XSSF.Streaming;
using System.Web;
using NPOI.POIFS.FileSystem;
using NPOI.HSSF.UserModel;

namespace ManufacturingExecutionSystem.MES.Client.Utility.Utils
{
    class ExcelHelper
    {
        public void ExportDataToExcel(ProductOrder ProductOrderInfo, DataGridView dataGridView)
        {
            // 创建一个工作表
            IWorkbook workbook = new XSSFWorkbook();
            ICellStyle cellStyle = workbook.CreateCellStyle();
            IFont font = workbook.CreateFont();
            font.FontName = "宋体";
            cellStyle.SetFont(font);

            // 创建一页sheet
            ISheet sheet1 = workbook.CreateSheet("sheet1");

            int RowIndex; // 行索引
            int ColumIndex; // 列索引

            

            // 创建第一行
            IRow row = sheet1.CreateRow(0);
            row.CreateCell(0).SetCellValue("合同编号");
            row.CreateCell(1).SetCellValue(ProductOrderInfo.OrderNo);
            row.CreateCell(2).SetCellValue("订单日期：" + ProductOrderInfo.BuyDate);

            row = sheet1.CreateRow(1);

            for (ColumIndex = 0; ColumIndex < dataGridView.ColumnCount; ColumIndex++)
            {
                // 第1行 第ColumIndex列
                row.CreateCell(ColumIndex).SetCellValue(dataGridView.Columns[ColumIndex].HeaderText);
                row.GetCell(ColumIndex).CellStyle = cellStyle;
            }

            for (RowIndex = 0; RowIndex < dataGridView.RowCount-1; RowIndex++)
            {
                // 从第二行开始插入数据
                row = sheet1.CreateRow(RowIndex + 2);
                for (ColumIndex = 0; ColumIndex < dataGridView.ColumnCount; ColumIndex++)
                {
                    row.CreateCell(ColumIndex).SetCellValue(dataGridView.Rows[RowIndex].Cells[ColumIndex].Value.ToString());
                    row.GetCell(ColumIndex).CellStyle = cellStyle;
                }
            }

            // 设置首行筛选
            sheet1.SetAutoFilter(new CellRangeAddress(1, 1, 0, dataGridView.ColumnCount - 1));

            // 获取项目exe路径
            string excelFilePath = AppDomain.CurrentDomain.BaseDirectory;
            string excelFileName = (DateTime.Now.Year).ToString() 
                                    + '-' + (DateTime.Now.Month).ToString() 
                                    + '-' + (DateTime.Now.Day).ToString() 
                                    + ProductOrderInfo.CompanyFullName;
            excelFilePath += "ExcelFile\\";

            if (!Directory.Exists(excelFilePath))
            {
                Directory.CreateDirectory(excelFilePath);
            }

            excelFilePath += excelFileName;


            while (File.Exists(excelFilePath + ".xlsx"))
            {
                excelFilePath += "I";
            }

            FileStream sw = File.Create(excelFilePath + ".xlsx");

            // 写入
            workbook.Write(sw);
            sw.Close();
        }
    }
}
