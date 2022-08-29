using Business;
using DevExpress.XtraSplashScreen;
using Entity.Facade;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
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

            var materials = WareHouseBLL.CensusMaterials();
            foreach (var item in response)
            {
                var material = materials.FirstOrDefault(p => p.MaterialNo == item.SKU);
                int iwmsCount = 0;
                if (material != null)
                {
                    iwmsCount = material.TotalCount;
                    materials.Remove(material);
                }
                item.IWMS_QTY = iwmsCount.ToString();
                item.Difference = $"{TypeParse.StrToInt(item.QTY, 0) - iwmsCount}";
                CompareResults.Add(item);
            }
            foreach (var item in materials)
            {
                CompareResults.Add(new WMSInventory()
                {
                    Difference = (-item.TotalCount).ToString(),
                    SKU = item.MaterialNo
                });
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                LoadInventory(txtPartNumber.Text);
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
            SplashScreenManager.CloseForm();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                ExportToExcel();
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
            SplashScreenManager.CloseForm();
        }

        public void ExportToExcel()
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx",
                FilterIndex = 0,
                OverwritePrompt = true,
                RestoreDirectory = true,
                CreatePrompt = true,
                Title = "Export Excel File To"
            };
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            List<HeadColumn> headColumns = new List<HeadColumn>
            {
                new HeadColumn("WAREHOUSE_ID","仓库号", 2200),
                new HeadColumn("LOT02","库存组织", 2200),
                new HeadColumn("LOT03","状态", 2200),
                new HeadColumn("SKU","物料代码", 2200),
                new HeadColumn("MATERIAL_NAME","物料名称", 4000),
                new HeadColumn("QTY","Wms数量", 2200),
                new HeadColumn("IWMS_QTY","iWms", 2200),
                new HeadColumn("Difference","差异", 2200)
            };
            string fileFullName = NpoiHelper.ExportToExcel(dialog.FileName, CompareResults.ToList(), headColumns);
            if (!string.IsNullOrWhiteSpace(fileFullName))
            {
                System.Diagnostics.Process.Start("explorer", "/select," + fileFullName);
            }
        }

    }
}
