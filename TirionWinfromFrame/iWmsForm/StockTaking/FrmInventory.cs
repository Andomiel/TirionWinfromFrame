using Entity.Facade;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmInventory : FrmBaseForm
    {
        public FrmInventory()
        {
            InitializeComponent();

            gridInventory.ScrollBars = ScrollBars.Both;
            gridInventory.Dock = DockStyle.Fill;
            gridInventory.AutoGenerateColumns = false;
            gridInventory.DataSource = CompareResults;
        }

        private BindingList<WMSInventory> CompareResults = new BindingList<WMSInventory>();

        /// <summary>
        /// FormLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInventory_Load(object sender, EventArgs e)
        {
            //gridInventory.DataSource = LoadInventory(txtPartNumber.Text);
        }

        /// <summary>
        /// 加载库存
        /// </summary>
        private void LoadInventory(string sku = "")
        {

            string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/Material/GetWMSInventory";
            if (!string.IsNullOrWhiteSpace(sku))
            {
                url = $"{url}?sku={sku}";
            }

            var response = WebClientHelper.Get<List<WMSInventory>>(url);
            CompareResults.Clear();
            if (response == null || response.Count <= 0)
            {
                response = new List<WMSInventory>();
            }
            foreach (var item in response)
            {
                item.Difference = $"{int.Parse(item.QTY) - int.Parse(item.IWMS_QTY)}";
                CompareResults.Add(item);
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInventory(txtPartNumber.Text);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            //Creating DataTable.
            DataTable dt = new DataTable();

            //Adding the Columns.
            foreach (DataGridViewColumn column in gridInventory.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows.
            foreach (DataGridViewRow row in gridInventory.Rows)
            {
                dt.Rows.Add();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            string fileName = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.DefaultExt = "xls";
            fileDialog.Filter = "Excel文件|*.xls";
            fileDialog.FileName = fileName;
            fileDialog.ShowDialog();
            fileName = fileDialog.FileName;

            using (var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet();
                List<string> columns = new List<string>();
                IRow row = excelSheet.CreateRow(0);
                int columnIndex = 0;

                foreach (DataColumn column in dt.Columns)
                {
                    columns.Add(column.ColumnName);
                    row.CreateCell(columnIndex).SetCellValue(column.ColumnName);
                    columnIndex++;
                }

                int rowIndex = 1;
                foreach (DataRow dsrow in dt.Rows)
                {
                    row = excelSheet.CreateRow(rowIndex);
                    int cellIndex = 0;
                    foreach (string col in columns)
                    {
                        row.CreateCell(cellIndex).SetCellValue(dsrow[col].ToString());
                        cellIndex++;
                    }

                    rowIndex++;
                }
                workbook.Write(fs);
            }
        }
    }
}
