using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TirionWinfromFrame.Commons
{
    public class NpoiHelper
    {
        private static IWorkbook workbook = null;
        private static FileStream fs = null;

        /// <summary>
        /// 将EXCEL中的数据导入到DataTable中
        /// </summary>
        /// <param name="fileName">excel文件路径</param>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <returns>返回的DataTable</returns>
        public static DataTable ExcelToDataTable(string fileName, string sheetName, int dataStartRowNum)
        {
            string test = string.Empty;

            ISheet sheet = null;
            DataTable data = new DataTable();
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0 || fileName.IndexOf(".XLSX") > 0)
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else if (fileName.IndexOf(".xls") > 0 || fileName.IndexOf(".XLS") > 0)
                {
                    workbook = new HSSFWorkbook(fs);
                }

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow startRow = sheet.GetRow(dataStartRowNum);
                    int cellCount = startRow.LastCellNum; //总列数
                    for (int i = 0; i <= cellCount; i++)
                    {
                        ICell cell = startRow.GetCell(i);
                        if (cell != null)
                        {
                            string cellValue = cell.StringCellValue;
                            if (cellValue != null)
                            {
                                DataColumn column = new DataColumn(cellValue);
                                data.Columns.Add(column);
                            }
                        }
                    }

                    int rowCount = sheet.LastRowNum;
                    for (int i = dataStartRowNum + 1; i <= rowCount; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (string.IsNullOrWhiteSpace(row?.GetCell(0)?.ToString())) continue;
                        DataRow dataRow = data.NewRow();
                        for (int j = 0; j <= cellCount; j++)
                        {
                            test = j.ToString();
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message + test);
                return null;
            }
        }

        public static DataTable ExcelToDataTable(string fileName, string sheetName, int dataStartRowNum, int firstColumn = 0, int headStartRowNum = -1, int headRowCount = 0)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0 || fileName.IndexOf(".XLSX") > 0)
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else if (fileName.IndexOf(".xls") > 0 || fileName.IndexOf(".XLS") > 0)
                {
                    workbook = new HSSFWorkbook(fs);
                }

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                List<string> headDataValue = new List<string>();
                if (sheet != null)
                {
                    if (headStartRowNum != -1)
                    {
                        for (int i = 0; i < headRowCount; i++)
                        {
                            IRow row = sheet.GetRow(headStartRowNum + i);
                            ICell cellHead = row.GetCell(firstColumn);
                            if (cellHead != null)
                            {
                                string cellValue = cellHead.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }

                            }
                            ICell cellData = row.GetCell(firstColumn + 1);
                            if (cellData != null)
                            {
                                string cellValue = cellData.ToString();
                                headDataValue.Add(cellValue == null ? string.Empty : cellValue);
                            }
                        }
                    }

                    IRow startRow = sheet.GetRow(dataStartRowNum);
                    int cellCount = startRow.LastCellNum - firstColumn; //总列数
                    for (int i = 1; i <= cellCount; i++)
                    {
                        ICell cell = startRow.GetCell(i);
                        if (cell != null)
                        {
                            string cellValue = cell.StringCellValue;
                            if (cellValue != null)
                            {
                                DataColumn column = new DataColumn(cellValue);
                                data.Columns.Add(column);
                            }
                        }
                    }

                    int rowCount = sheet.LastRowNum;
                    for (int x = dataStartRowNum + 1; x <= rowCount; x++)
                    {
                        IRow row = sheet.GetRow(x);
                        if (string.IsNullOrWhiteSpace(row?.GetCell(firstColumn)?.ToString())) break;
                        DataRow dataRow = data.NewRow();
                        for (int y = 0; y < headDataValue.Count; y++)
                        {
                            dataRow[y] = headDataValue[y];
                        }
                        for (int z = 1; z <= cellCount; z++)
                        {
                            if (row.GetCell(z) != null)
                                dataRow[z + headDataValue.Count - firstColumn] = row.GetCell(z).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 由List导出Excel
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="filePath">导出路径</param>
        /// <param name="data">在导出的List</param>
        /// <param name="headerNameDic">表头和属性对应关系</param>
        /// <param name="sheetName">sheet名称</param>
        /// <returns></returns>
        public static string ExportToExcel<T>(string filePath, List<T> data, List<HeadColumn> headColumnList, string sheetName = "result") where T : class
        {
            if (data.Count <= 0) return null;

            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            if (string.IsNullOrEmpty(filePath)) return null;

            bool isCompatible = filePath.EndsWith(".xls", StringComparison.OrdinalIgnoreCase);
            if (isCompatible)
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                workbook = new XSSFWorkbook();
            }

            ICellStyle headCellStyle = workbook.CreateCellStyle();
            headCellStyle.FillPattern = FillPattern.SolidForeground;
            headCellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
            headCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            headCellStyle.VerticalAlignment = VerticalAlignment.Center;
            headCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            headCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            headCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            headCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            IFont font = workbook.CreateFont();
            font.IsBold = true;
            headCellStyle.SetFont(font);

            ICellStyle normalCellStyle = workbook.CreateCellStyle();
            normalCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            normalCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            normalCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            normalCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;



            ISheet sheet = workbook.CreateSheet(sheetName);
            IRow headerRow = sheet.CreateRow(0);

            for (int i = 0; i < headColumnList.Count; i++)
            {
                ICell cell = headerRow.CreateCell(i);
                cell.SetCellValue(headColumnList[i].ColumnDes);
                cell.CellStyle = headCellStyle;
                sheet.SetColumnWidth(i, headColumnList[i].ColumnWeight);
            }

            Type t = typeof(T);
            int rowIndex = 1;
            foreach (T item in data)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                for (int n = 0; n < headColumnList.Count; n++)
                {
                    object pValue = t.GetProperty(headColumnList[n].ColumnKey.Trim()).GetValue(item, null);
                    ICell cell = dataRow.CreateCell(n);
                    cell.SetCellValue((pValue ?? "").ToString());
                    cell.CellStyle = normalCellStyle;
                }
                rowIndex++;
            }

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Dispose();

            sheet = null;
            headerRow = null;
            workbook = null;

            return filePath;
        }

        /// <summary>
        /// 由List导出Excel--单列行合并
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="filePath">导出路径</param>
        /// <param name="data">在导出的List</param>
        /// <param name="headerNameDic">表头和属性对应关系</param>
        /// <param name="mergeColumnNames">需要合并的列名</param>
        /// <param name="focusColumnNames">合并需要参考其值的列名</param>
        /// <param name="sheetName">sheet名称</param>
        /// <returns></returns>
        public static string ExportToExcel<T>(string filePath, List<T> data, Dictionary<string, string> headerNameDic, List<string> mergeColumnNames, List<string> focusColumnNames = null, string sheetName = "result") where T : class
        {
            if (data.Count <= 0) return null;

            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            if (string.IsNullOrEmpty(filePath)) return null;

            IList<KeyValuePair<string, string>> headerNameList = new List<KeyValuePair<string, string>>();
            foreach (KeyValuePair<string, string> keyValuePair in headerNameDic)
            {
                headerNameList.Add(keyValuePair);
            }

            bool isCompatible = filePath.EndsWith(".xls", StringComparison.OrdinalIgnoreCase);
            if (isCompatible)
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                workbook = new XSSFWorkbook();
            }

            ICellStyle cellStyle = workbook.CreateCellStyle();
            cellStyle.FillPattern = FillPattern.SolidForeground;
            cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
            ISheet sheet = workbook.CreateSheet(sheetName);
            IRow headerRow = sheet.CreateRow(0);

            for (int i = 0; i < headerNameList.Count; i++)
            {
                ICell cell = headerRow.CreateCell(i);
                cell.SetCellValue(headerNameList[i].Value);
                cell.CellStyle = cellStyle;
            }

            Dictionary<string, MergeCellTemp> mergeDic = mergeColumnNames.ToDictionary(k => k, v => new MergeCellTemp());
            List<CellRangeAddress> cellRangeAddresses = new List<CellRangeAddress>();
            Type t = typeof(T);
            int rowIndex = 1;
            string focusValue = string.Empty;
            foreach (T item in data)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                string focusTemp = string.Empty;
                foreach (var focus in focusColumnNames)
                {
                    object fValue = t.GetProperty(focus).GetValue(item, null);
                    focusTemp = $"{focusTemp}-{(fValue ?? "")}";
                }
                bool isSame = focusValue == focusTemp;
                focusValue = focusTemp;
                for (int n = 0; n < headerNameList.Count; n++)
                {
                    object pValue = t.GetProperty(headerNameList[n].Key).GetValue(item, null);
                    string value = (pValue ?? "").ToString();
                    if (mergeDic.ContainsKey(headerNameList[n].Key))
                    {
                        var temp = mergeDic[headerNameList[n].Key];
                        if (string.IsNullOrWhiteSpace(temp.Value))
                        {
                            mergeDic[headerNameList[n].Key] = new MergeCellTemp(value, rowIndex);
                        }
                        else
                        {
                            if (temp.Value.Equals(value) && isSame)
                            { }
                            else
                            {
                                temp.EndRow = rowIndex - 1;
                                if (temp.StartRow != temp.EndRow)
                                {
                                    cellRangeAddresses.Add(new CellRangeAddress(temp.StartRow, temp.EndRow, n, n));
                                }
                                mergeDic[headerNameList[n].Key] = new MergeCellTemp(value, rowIndex);
                            }
                        }
                    }
                    else
                    {
                        mergeDic[headerNameList[n].Key] = new MergeCellTemp(value, rowIndex);
                    }
                    dataRow.CreateCell(n).SetCellValue((pValue ?? "").ToString());
                }
                rowIndex++;
            }

            foreach (var cellRangeAddress in cellRangeAddresses)
            {
                sheet.AddMergedRegion(cellRangeAddress);
            }
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Dispose();

            sheet = null;
            headerRow = null;
            workbook = null;

            return filePath;
        }

        /// <summary>
        /// 由DataGridView导出
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="sheetName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ExportToExcel(string filePath, DataGridView grid, string sheetName = "result")
        {
            if (grid.Rows.Count <= 0) return null;

            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            if (string.IsNullOrEmpty(filePath)) return null;

            bool isCompatible = filePath.EndsWith(".xls", StringComparison.OrdinalIgnoreCase);
            if (isCompatible)
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                workbook = new XSSFWorkbook();
            }

            ICellStyle cellStyle = workbook.CreateCellStyle();
            cellStyle.FillPattern = FillPattern.SolidForeground;
            cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
            ISheet sheet = workbook.CreateSheet(sheetName);
            IRow headerRow = sheet.CreateRow(0);

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                ICell cell = headerRow.CreateCell(i);
                cell.SetCellValue(grid.Columns[i].Name);
                cell.CellStyle = cellStyle;
            }

            int rowIndex = 1;
            foreach (DataGridViewRow row in grid.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                for (int n = 0; n < grid.Columns.Count; n++)
                {
                    dataRow.CreateCell(n).SetCellValue((row.Cells[n].Value ?? "").ToString());
                }
                rowIndex++;
            }

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Dispose();

            sheet = null;
            headerRow = null;
            workbook = null;

            return filePath;
        }

        public static string ExportToExcel(string filePath, List<string> data, string head, string sheetName = "result")
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            if (string.IsNullOrEmpty(filePath)) return null;

            bool isCompatible = filePath.EndsWith(".xls", StringComparison.OrdinalIgnoreCase);
            if (isCompatible)
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                workbook = new XSSFWorkbook();
            }

            ICellStyle headCellStyle = workbook.CreateCellStyle();
            headCellStyle.FillPattern = FillPattern.SolidForeground;
            headCellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
            headCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            headCellStyle.VerticalAlignment = VerticalAlignment.Center;
            headCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            headCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            headCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            headCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            IFont font = workbook.CreateFont();
            font.IsBold = true;
            headCellStyle.SetFont(font);

            ICellStyle normalCellStyle = workbook.CreateCellStyle();
            normalCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            normalCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            normalCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            normalCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;

            ISheet sheet = workbook.CreateSheet(sheetName);
            IRow headerRow = sheet.CreateRow(0);

            ICell headCell = headerRow.CreateCell(0);
            headCell.SetCellValue(head);
            headCell.CellStyle = headCellStyle;
            sheet.SetColumnWidth(0, 7168);

            int rowIndex = 1;
            foreach (string item in data)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                ICell cell = dataRow.CreateCell(0);
                cell.SetCellValue((item).ToString());
                cell.CellStyle = normalCellStyle;
                rowIndex++;
            }

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fs);
            fs.Dispose();

            sheet = null;
            headerRow = null;
            workbook = null;

            return filePath;
        }
    }

    public class MergeCellTemp
    {
        public MergeCellTemp() { }
        public MergeCellTemp(string value, int startRow)
        {
            Value = value;
            StartRow = startRow;
        }
        public string Value { get; set; } = string.Empty;
        //合并开始行
        public int StartRow { get; set; } = -1;
        //合并结束行
        public int EndRow { get; set; } = -1;
    }

    public class HeadColumn
    {
        public HeadColumn(string key, string des, int weight)
        {
            ColumnKey = key;
            ColumnDes = des;
            ColumnWeight = weight;
        }

        public string ColumnKey { get; set; }

        public string ColumnDes { get; set; }

        public int ColumnWeight { get; set; }
    }
}
