using System;
using ASPNETExcelByNPOI.ServiceReference1;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPNETExcelByNPOI.Common;
using NPOI.SS.UserModel;
using System.IO;
using System.Text;
using NPOI.HSSF.UserModel;

namespace ASPNETExcelByNPOI
{
    public partial class ExcelImportExport : System.Web.UI.Page
    {
        private ServiceClient client = new ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            repeaterCustomer.DataSource = client.GetCustomer("");
            repeaterCustomer.DataBind();
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            /*将文件另存到一个文件夹后使用其完整路径调用ExcelImport方法*/
            if (excelUpload.HasFile == true)
            {
                string savePath = @"c:\temp\uploads\";//另存的路径
                string fileName = excelUpload.FileName;//获取选择文件名
                string extension = System.IO.Path.GetExtension(fileName);//获取选择文件扩展名

                if (extension == ".xls")
                {
                    System.IO.Directory.CreateDirectory(savePath);
                    savePath += fileName;
                    excelUpload.SaveAs(savePath);

                    ExcelImport(savePath);
                }
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExcelExport();
        }

        private void ExcelImport(string fullName)
        {
            using (FileStream fs = File.OpenRead(fullName))
            {
                HSSFWorkbook workBook = new HSSFWorkbook(fs);

                ISheet sheet = workBook.GetSheetAt(0);
                
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    IRow dataRow = sheet.GetRow(i);

                    string customerName = dataRow.GetCell(1).ToString().Trim();
                    string customerAddress = dataRow.GetCell(2).ToString().Trim();

                    client.SetCustomer(customerName, customerAddress);
                }

            }
        }

        private void ExcelExport()
        {
            string sheet1Title = "Sheet1";

            NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();

            NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet(sheet1Title);

            NPOI.SS.UserModel.IRow headerRow4Sheet1 = sheet1.CreateRow(0);

            ExcelCellStyle cellStyle = new ExcelCellStyle(book);

            ICell cell;//初始化ICell准备设值

            #region 设定Sheet1的头行

            cell = headerRow4Sheet1.CreateCell(0); cell.CellStyle = cellStyle.style; cell.SetCellValue("客户ID");
            cell = headerRow4Sheet1.CreateCell(1); cell.CellStyle = cellStyle.style; cell.SetCellValue("客户名");
            cell = headerRow4Sheet1.CreateCell(2); cell.CellStyle = cellStyle.style; cell.SetCellValue("客户地址");

            #endregion

            /*0行已经设为表头行，内容从第1行开始设值*/
            int sheet1RowID = 1;

            Customer[] listCustomer = client.GetCustomer("");

            foreach (Customer customer in listCustomer)
            {
                IRow r = sheet1.CreateRow(sheet1RowID);

                cell = r.CreateCell(0); cell.SetCellValue(customer.customerID); cell.CellStyle = cellStyle.style;
                cell = r.CreateCell(1); cell.SetCellValue(customer.customerName); cell.CellStyle = cellStyle.style;
                cell = r.CreateCell(2); cell.SetCellValue(customer.customerAddress); cell.CellStyle = cellStyle.style;

                sheet1RowID += 1;//每做一个循环就到下一行设置
            }

            /*以下是做自适应宽度*/
            ChangeStyle(book, sheet1);

            /*最后作输出流导出文件*/
            MemoryStream ms = new MemoryStream();
            book.Write(ms);
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", HttpUtility.UrlEncode("客户列表信息", System.Text.Encoding.UTF8)));
            Response.BinaryWrite(ms.ToArray());
            Response.End();
            book = null;
            ms.Close();
            ms.Dispose();
        }

        protected void ChangeStyle(IWorkbook hssfworkbook, ISheet sheet)
        {
            for (int columnNum = 0; columnNum <= sheet.GetRow(0).LastCellNum + 12; columnNum++) //columnNum为列的数量
            {
                int columnWidth = sheet.GetColumnWidth(columnNum) / 256; //获取当前列宽度
                for (int rowNum = 0; rowNum <= sheet.LastRowNum; rowNum++) //在这一列上循环行
                {
                    IRow currentRow = sheet.GetRow(rowNum);
                    if (currentRow != null)
                    {
                        ICell currentCell = currentRow.GetCell(columnNum);
                        if (currentCell != null)
                        {
                            int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                            //单元格的宽度
                            if (columnWidth < length + 1)
                            {
                                columnWidth = length + 1;
                            }
                            //若当前单元格内容宽度大于列宽，则调整列宽为当前单元格宽度，后面的+1是我人为的操作
                        }
                    }
                }
                if (columnWidth > 255)
                {
                    columnWidth = 255;//由于最大宽度是255，所以这里需要判断下，否则会报错
                }
                sheet.SetColumnWidth(columnNum, columnWidth * 256);//设置最终宽度
            }
        }
    }
}