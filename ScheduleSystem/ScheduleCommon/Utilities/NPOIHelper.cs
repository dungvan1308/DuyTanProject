using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Data;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Model;
using NPOI.SS.UserModel;

namespace ScheduleCommon.Utilities
{
    public class NPOIHelper
    {   
        public static DataTable xlsxToDT(string fileName, bool header)
        {
            DataTable dt = new DataTable();
            XSSFWorkbook xssfworkbook = new XSSFWorkbook();
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            try
            {                
                using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    ISheet sheet;
                    if (Path.GetExtension(fileName).ToLower() == ".xls")
                    {
                        hssfworkbook = new HSSFWorkbook(file);
                        sheet = hssfworkbook.GetSheetAt(0);
                    }
                    else if (Path.GetExtension(fileName).ToLower() == ".xlsx")
                    {
                        xssfworkbook = new XSSFWorkbook(file);
                        sheet = xssfworkbook.GetSheetAt(0);
                    }
                    else
                        return dt;                    
                    IRow headerRow = sheet.GetRow(0);
                    IEnumerator rows = sheet.GetRowEnumerator();
                    int colCount = headerRow.LastCellNum;
                    int rowCount = sheet.LastRowNum;
                    for (int c = 0; c < colCount; c++)
                    {
                        dt.Columns.Add(headerRow.GetCell(c).ToString());
                    }
                    bool skipReadingHeaderRow = rows.MoveNext();
                    while (rows.MoveNext())
                    {
                        IRow row = (XSSFRow)rows.Current;
                        DataRow dr = dt.NewRow();
                        int count = header ? 0 : 1;
                        for (int i = 0; i < colCount; i++)
                        {
                            ICell cell = row.GetCell(i);
                            if (cell != null)
                            {
                                dr[i] = cell.ToString();
                            }
                        }
                        dt.Rows.Add(dr);
                    }
                    sheet = null;
                }
            }
            catch(Exception ex)
            {
                
            }
            hssfworkbook = null;            
            return dt;
        }        
        public static void ExportDataTableToExcel(DataTable sourceTable, string fileName)
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            MemoryStream memoryStream = new MemoryStream();
            XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet("Export");
            XSSFRow headerRow = (XSSFRow)sheet.CreateRow(0);
            // handling header.
            foreach (DataColumn column in sourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            // handling value.
            int rowIndex = 1;
            foreach (DataRow row in sourceTable.Rows)
            {
                XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in sourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                rowIndex++;
            }
            workbook.Write(memoryStream);
            memoryStream.Flush();
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = memoryStream.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
            catch (Exception ex)
            {

            }
            
        }                
        
    }
}
