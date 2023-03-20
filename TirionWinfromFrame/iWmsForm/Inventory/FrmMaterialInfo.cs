using Business;
using DevExpress.XtraSplashScreen;
using Entity;
using Entity.Dto;
using Entity.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmMaterialInfo : FrmBaseForm
    {
        public int pageSize = 100;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        private BindingList<InventoryEntity> Barcodes = new BindingList<InventoryEntity>();

        public FrmMaterialInfo()
        {
            InitializeComponent();
            var towerMaps = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(TowerEnum));
            towerMaps.Add(new EnumItem() { Value = 5, Description = "烘烤区" });
            cmbArea.DataSource = towerMaps;
            cmbArea.DisplayMember = "Description";
            cmbArea.ValueMember = "Value";

            cbMateType.DataSource = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(ReelTypeEnum));
            cbMateType.DisplayMember = "Description";
            cbMateType.ValueMember = "Name";

            //dtpCycleStart.Format = DateTimePickerFormat.Custom;
            //dtpCycleStart.CustomFormat = " ";
            //dtpCycleEnd.Format = DateTimePickerFormat.Custom;
            //dtpCycleEnd.CustomFormat = " ";
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = " ";
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = " ";

            dataGridViewX1.ScrollBars = ScrollBars.Both;
            dataGridViewX1.Dock = DockStyle.Fill;
            dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewX1.DataSource = Barcodes;
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            var thisDateTimePicker = sender as DateTimePicker;
            thisDateTimePicker.Format = DateTimePickerFormat.Long;
            thisDateTimePicker.CustomFormat = null;
        }

        private string orderBy = " SaveTime DESC ";

        private readonly object lockOperateObj = new object();

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockOperateObj)
                {
                    orderBy = " SaveTime DESC ";
                    currentPage = 1;
                    GetOrders();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void GetOrders()
        {
            MaterialQueryCondition condition = BuildConditions();
            Barcodes.Clear();
            int startRow = (currentPage - 1) * pageSize;
            var inventory = InOutStockStorageData.GetSmt_zd_MaterialInfo(condition, startRow, startRow + pageSize, orderBy);
            foreach (var item in inventory)
            {
                Barcodes.Add(item);
            }
            recordCount = 0;
            if (inventory != null && inventory.Any())
            {
                recordCount = inventory.First().TotalCount;
            }
            pageCount = (recordCount / pageSize);
            if (recordCount % pageSize > 0)
            {
                pageCount += 1;
            }
            LoadPagedWorkOrder();
        }

        private MaterialQueryCondition BuildConditions()
        {
            MaterialQueryCondition condition = new MaterialQueryCondition
            {
                //周期
                //haveCycleQuery = dtpCycleStart.Format != DateTimePickerFormat.Custom
                //                    && dtpCycleEnd.Format != DateTimePickerFormat.Custom,
                //CycleStart = Convert.ToDateTime(dtpCycleStart.Value.ToString("yyyy-MM-dd")),
                //CycleEnd = Convert.ToDateTime(dtpCycleEnd.Value.ToString("yyyy-MM-dd")),
                //料盘类型
                MateType = (this.cbMateType.SelectedItem as EnumItem).Name,
                //MSD
                MSD = this.cbMSD.Text,
                //流水号
                SerialNoStart = this.txtSerialNoStart.Text,
                SerialNoEnd = this.txtSerialNoEnd.Text,
                //超期
                ExceedStart = TypeParse.StrToInt(this.txtExceedStart.Text, 0),
                ExceedEnd = TypeParse.StrToInt(this.txtExceedEnd.Text, 0),
                //入库时间
                haveSaveTimeQuery = dtpStart.Format != DateTimePickerFormat.Custom
                                       && dtpEnd.Format != DateTimePickerFormat.Custom,
                SaveTimeStart = Convert.ToDateTime(dtpStart.Value.ToString("yyyy-MM-dd")),
                SaveTimeEnd = Convert.ToDateTime(dtpEnd.Value.ToString("yyyy-MM-dd")).AddDays(1),

                //库区
                TowerNo = Convert.ToInt32(cmbArea.SelectedValue)
            };

            //巷道、货架
            switch (condition.TowerNo)
            {
                case (int)TowerEnum.PalletArea:
                case (int)TowerEnum.SortingArea:
                default:
                    break;
                case (int)TowerEnum.ASRS:
                    condition.ABSide = this.cbShelfSide.Text;
                    break;
                case (int)TowerEnum.LightShelf:
                    condition.MachineId = string.IsNullOrWhiteSpace(cbShelfSide.Text) ? string.Empty : $"SWHY0{this.cbShelfSide.Text}";
                    break;
                case (int)TowerEnum.ReformShelf:
                    condition.MachineId = this.cbShelfSide.Text;
                    break;
            }
            //状态
            condition.HoldState = this.BoxStatus.Text;
            //供货厂家
            condition.Supplier = this.TextSupply.Text;
            condition.UPN = this.txtReelid.Text.ToString().Trim();
            //料号
            condition.PartNumber = this.txtPn.Text.ToString();

            return condition;
        }

        private void LoadPagedWorkOrder()
        {
            if (pageCount == 0)
            {
                tpscurrentPage.Text = "0";//当前页
                tpspageCount.Text = "0";//总页数
                tpsrecordCount.Text = "0";//总记录数
                return;
            }
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            tpscurrentPage.Text = currentPage.ToString();//当前页
            tpspageCount.Text = pageCount.ToString();//总页数
            tpsrecordCount.Text = recordCount.ToString();//总记录数
        }


        private void BtnFrist_ButtonClick(object sender, EventArgs e)
        {
            currentPage = 1;
            GetOrders();
        }

        private void BtnPre_ButtonClick(object sender, EventArgs e)
        {
            currentPage -= 1;
            GetOrders();
        }

        private void BtnNext_ButtonClick(object sender, EventArgs e)
        {
            currentPage += 1;
            GetOrders();
        }

        private void BtnLast_ButtonClick(object sender, EventArgs e)
        {
            currentPage = pageCount;
            GetOrders();
        }

        private void FrmInStockDatailInfo_Load(object sender, EventArgs e)
        {
            dataGridViewX1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色
            dataGridViewX1.AutoGenerateColumns = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtReelid.Text = "";
            txtPn.Text = "";
            txtExceedStart.Text = "";
            txtExceedEnd.Text = "";
            txtSerialNoStart.Text = "";
            txtSerialNoEnd.Text = "";
            TextSupply.Text = "";
            lblShelfSide.Visible = false;
            cbMateType.SelectedIndex = 0;
            cmbArea.SelectedValue = -1;
            cbShelfSide.SelectedIndex = -1;
            cbShelfSide.Visible = false;
            cbMSD.SelectedIndex = -1;
            BoxStatus.SelectedIndex = -1;
            //DateTimePickerReset(dtpCycleStart);
            //DateTimePickerReset(dtpCycleEnd);
            DateTimePickerReset(dtpStart);
            DateTimePickerReset(dtpEnd);
            Barcodes.Clear();
        }

        private void DateTimePickerReset(DateTimePicker dtpicker)
        {
            dtpicker.Format = DateTimePickerFormat.Custom;
            dtpicker.CustomFormat = " ";
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                MaterialQueryCondition condition = BuildConditions();
                var inventory = InOutStockStorageData.GetMaterialInfoExport(condition);
                ExportToExcel(inventory);
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
            SplashScreenManager.CloseForm();
        }

        public void ExportToExcel(IEnumerable<InventoryEntity> data)
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
                new HeadColumn("UPN","UPN", 7168),
                new HeadColumn("PartNumber","物料代码", 4000),
                new HeadColumn("Supplier","供货厂家", 3000),
                new HeadColumn("DateCode","生产日期", 3000),
                new HeadColumn("SerialNo","流水号", 2000),
                new HeadColumn("Qty","数量", 2200),
                new HeadColumn("Lot","批次", 2200),
                new HeadColumn("MinPacking","最小包装", 2200),
                new HeadColumn("MSD","MSD", 1000),
                new HeadColumn("TowerDes","库区", 3000),
                new HeadColumn("ABSide","巷道货架", 3000),
                new HeadColumn("Location","库位", 2200),
                new HeadColumn("ReelTypeDes","料盘类型", 1500),
                new HeadColumn("StatusDisplay","库存状态", 3000),
                new HeadColumn("HoldState","冻烘状态", 3000),
                new HeadColumn("SaveTime","入库时间", 7168),
                new HeadColumn("HoldNo","冻结单号", 4000),
            };
            string fileFullName = NpoiHelper.ExportToExcel(dialog.FileName, data, headColumns);
            if (!string.IsNullOrWhiteSpace(fileFullName))
            {
                System.Diagnostics.Process.Start("explorer", "/select," + fileFullName);
            }
        }

        private void CmbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int towerNo = Convert.ToInt32(cmbArea.SelectedValue);
            switch (towerNo)
            {
                case 1:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "巷道：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.AbSide;
                    break;
                case 2:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "货架：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.LightShelf;
                    break;
                case 3:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "栈板：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.PalletAreas;
                    break;
                case 4:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "货架：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.TransformationShelf;
                    break;
                default:
                    lblShelfSide.Visible = false;
                    cbShelfSide.Visible = false;
                    cbShelfSide.SelectedIndex = -1;
                    break;
            }
        }

        private void txtExceed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private object lockSyncObj = new object();

        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockSyncObj)
                {
                    DataTable dtBarcode = InOutStockStorageData.GetAllMaterial();
                    foreach (DataRow row in dtBarcode.Rows)
                    {
                        string barcode = Convert.ToString(row["ReelID"]);
                        string qrCode = Convert.ToString(row["QRCode"]);
                        if (!string.IsNullOrWhiteSpace(qrCode))
                        {
                            continue;
                        }

                        var info = CallMesWmsApiBll.CallMaterialInfoByUPN(qrCode);

                        if (info == null || string.IsNullOrWhiteSpace(info.StoreId) || info.StoreId == "361")
                        {
                            continue;
                        }

                        GeneralBusiness.DeliveryBarcode(barcode);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridViewX1.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridViewX1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void DataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (e.ColumnIndex == 1)
            {
                sb.Append(" Part_Number ");
            }
            else
            {
                sb.Append(" SaveTime ");
            }
            if (e.Clicks % 2 == 0)
            {
                sb.Append(" ASC ");
            }
            else
            {
                sb.Append(" DESC ");
            }

            orderBy = sb.ToString();
            GetOrders();
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1)
                {
                    return;
                }
                if (dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    return;
                }
                if (e.ColumnIndex == 0)
                {
                    var row = dataGridViewX1.SelectedCells[0].OwningRow;
                    var barcode = row.DataBoundItem as InventoryEntity;
                    System.Diagnostics.Process.Start($"http://172.16.255.19/iwms-79-8086/?logKey={barcode.UPN}");
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }
    }
}

