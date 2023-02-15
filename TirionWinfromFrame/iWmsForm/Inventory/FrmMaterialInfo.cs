using Business;
using DevExpress.XtraSplashScreen;
using Entity;
using Entity.Dto;
using Entity.Enums;
using Entity.Facade;
using MES;
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

            int lightShelf = (int)TowerEnum.LightShelf;
            towerMaps.RemoveAll(p => p.Value > -1 && p.Value < lightShelf);
            //towerMaps.Add(new EnumItem() { Value = 5, Description = "烘烤区" });
            cmbArea.DataSource = towerMaps;
            cmbArea.DisplayMember = "Description";
            cmbArea.ValueMember = "Value";

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
                MateType = string.Empty,//(this.cbMateType.SelectedItem as EnumItem).Name,
                //MSD
                MSD = string.Empty,// this.cbMSD.Text,
                //流水号
                SerialNoStart = string.Empty,// this.txtSerialNoStart.Text,
                SerialNoEnd = string.Empty,// this.txtSerialNoEnd.Text,
                //超期
                ExceedStart = 0,// TypeParse.StrToInt(this.txtExceedStart.Text, 0),
                ExceedEnd = 0,//TypeParse.StrToInt(this.txtExceedEnd.Text, 0),
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
                //case (int)TowerEnum.SortingArea:
                default:
                    break;
                //case (int)TowerEnum.ASRS:
                //    condition.ABSide = this.cbShelfSide.Text;
                //    break;
                case (int)TowerEnum.LightShelf:
                    condition.MachineId = string.IsNullOrWhiteSpace(cbShelfSide.Text) ? string.Empty : $"SWHY0{this.cbShelfSide.Text}";
                    break;
                case (int)TowerEnum.ReformShelf:
                case (int)TowerEnum.Nearby:
                    condition.MachineId = this.cbShelfSide.Text;
                    break;
            }
            //状态
            condition.HoldState = this.BoxStatus.Text;
            //供货厂家
            condition.Supplier = string.Empty;// this.TextSupply.Text;
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

            SetHighPrivilege();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtReelid.Text = "";
            txtPn.Text = "";
            lblShelfSide.Visible = false;
            cmbArea.SelectedValue = -1;
            cbShelfSide.SelectedIndex = -1;
            cbShelfSide.Visible = false;
            BoxStatus.SelectedIndex = -1;
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
                new HeadColumn("UPN","ReelId", 7168),
                new HeadColumn("Supplier","工单号", 3000),
                new HeadColumn("PartNumber","物料料号", 4000),
                new HeadColumn("Supplier","IC料号", 3000),
                new HeadColumn("Qty","数量", 2200),
                new HeadColumn("Lot","原物料料号", 3000),
                new HeadColumn("MinPacking","供应商色块", 2200),
                new HeadColumn("MSD","批次", 1000),
                new HeadColumn("TowerDes","库区", 3000),
                new HeadColumn("ABSide","货架", 3000),
                new HeadColumn("Location","库位", 2200),
                new HeadColumn("StatusDisplay","库存状态", 3000),
                new HeadColumn("SaveTime","入库时间", 7168)
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
                    lblShelfSide.Text = "烧录料架：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.LightShelf;
                    break;
                case 3:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "线边料架：";
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

        private void LightSingleBarcode(string positionNo)
        {
            StringBuilder sb = new StringBuilder("请求发料亮灯");
            try
            {
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/midea/api/lightshelf/light";
                sb.AppendLine($"地址:{url}");
                LightShelfLocationRequest request = new LightShelfLocationRequest
                {
                    ShelfPosition = positionNo
                };
                string requestJson = JsonConvert.SerializeObject(request);
                sb.AppendLine($"请求参数:{requestJson}");
                string strResponse = WebClientHelper.Post(JsonConvert.SerializeObject(request), url, null);
                sb.AppendLine($"返回:{strResponse}");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"异常:{ex.Message}");
            }
            FileLog.Log(sb.ToString());
        }

        private readonly object lockSyncObj = new object();

        private void btnSync_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockSyncObj)
                {
                    if (dataGridViewX1.SelectedCells.Count == 0)
                    {
                        "请选择需要点亮的物料".ShowTips();
                        return;
                    }
                    List<string> positions = new List<string>();
                    foreach (DataGridViewCell item in dataGridViewX1.SelectedCells)
                    {
                        var row = item.OwningRow;
                        var barcodeEntity = row.DataBoundItem as InventoryEntity;
                        if (barcodeEntity == null || positions.Contains(barcodeEntity.Location))
                        {
                            continue;
                        }
                        positions.Add(barcodeEntity.Location);
                        LightSingleBarcode(barcodeEntity.Location);
                    }
                    "发料亮灯成功！".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
            finally
            {
                SplashScreenManager.CloseForm();
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

        private void BtnTrancate_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockOperateObj)
                {
                    var diagResult = "本操作将清空所有库存数据，确认是否继续?".ShowYesNoAndWarning();
                    if (diagResult != DialogResult.Yes)
                    {
                        return;
                    }

                    InOutStockStorageData.TruncateAllInventory();

                    "所有数据已清空".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        private void SetHighPrivilege()
        {
            using (var db = new MESDB())
            {
                var roles = db.Database.SqlQuery<int>($@"SELECT distinct roleId 
                FROM[dbo].[sysUserRole] c 
                where c.userId = {AppInfo.LoginUserInfo.id}").ToListAsync().Result;

                if (roles == null || roles.Count == 0)
                {
                    btnTrancate.Visible = false;
                }
                else if (roles.Contains(1) || roles.Contains(7))
                {
                    btnTrancate.Visible = true;
                }
                else
                {
                    btnTrancate.Visible = false;
                }
            }
        }
    }
}

