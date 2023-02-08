using Business;
using Commons;
using DevExpress.XtraSplashScreen;
using Entity;
using Entity.Dto;
using Entity.Enums;
using Entity.Enums.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmInventoryOrder : FrmBaseForm
    {
        private int pageSize = 30;      //每页记录数
        private int recordCount = 0;    //总记录数
        private int pageCount = 0;      //总页数
        private int currentPage = 0;    //当前页

        public FrmInventoryOrder()
        {
            InitializeComponent();

            var towerItems = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(TowerEnum));
            cmbArea.DataSource = towerItems;
            cmbArea.DisplayMember = "Description";
            cmbArea.ValueMember = "Value";

            BindEmptyShelfSide();

            var types = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(InventoryOrderTypeEnum));
            cbType.DataSource = types;
            cbType.DisplayMember = "Description";
            cbType.ValueMember = "Value";
            cbType.Enabled = false;

            dataGridViewSelect.ScrollBars = ScrollBars.Both;
            dataGridViewSelect.Dock = DockStyle.Fill;
            dataGridViewSelect.AutoGenerateColumns = false;
            dataGridViewSelect.DataSource = PagedBarcodes;
            dataGridViewSelect.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色
        }

        private List<AvailableBarcode> Barcodes = new List<AvailableBarcode>();

        private BindingList<AvailableBarcode> PagedBarcodes = new BindingList<AvailableBarcode>();

        private void BindEmptyShelfSide()
        {
            var emptyItems = new List<string>() { "全部" };
            cbShelfSide.DataSource = emptyItems;
            cbShelfSide.SelectedIndex = -1;
        }

        private readonly object lockQueryObj = new object();

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockQueryObj)
                {
                    int inventoryType = Convert.ToInt32(this.cbType.SelectedValue);
                    if (inventoryType < 0)
                    {
                        "请选择盘点模式".ShowTips();
                        return;
                    }
                    if (inventoryType == (int)InventoryOrderTypeEnum.Percent && nupPercent.Value == 0)
                    {
                        "请填写抽盘比例".ShowTips();
                        return;
                    }

                    Barcodes = GetBarcodesByCondition().ToList();

                    currentPage = 1;
                    recordCount = Barcodes.Count;
                    pageCount = (recordCount / pageSize);
                    if (recordCount % pageSize > 0)
                    {
                        pageCount += 1;
                    }
                    LoadPagedWorkOrder();
                }
            }
            catch (Exception ex)
            {
                _ = ex.GetDeepException().ShowError();
            }
        }

        private IEnumerable<AvailableBarcode> GetBarcodesByCondition()
        {
            MaterialQueryCondition condition = new MaterialQueryCondition
            {
                //库区
                TowerNo = Convert.ToInt32(cmbArea.SelectedValue),
                PartNumber = tbMaterialNo.Text.Trim()
            };

            //巷道、货架
            switch (condition.TowerNo)
            {
                case 0:
                case 3:
                    break;
                case 1:
                    condition.ABSide = this.cbShelfSide.Text;
                    break;
                case 2:
                    if (!string.IsNullOrWhiteSpace(this.cbShelfSide.Text))
                    {
                        condition.MachineId = $"SWHY0{this.cbShelfSide.Text}";
                    }
                    break;
                case 4:
                    condition.MachineId = this.cbShelfSide.Text;
                    break;
            }

            var allBarcodes = InventoryBll.GetAvailableBarcodesForInventory(condition);

            int orderType = TypeParse.StrToInt(cbType.SelectedValue, -1);
            if (orderType != (int)InventoryOrderTypeEnum.Percent)
            {
                return allBarcodes;
            }
            return BuildRandomBarcodes(allBarcodes);
        }

        private IEnumerable<AvailableBarcode> BuildRandomBarcodes(IEnumerable<AvailableBarcode> originBarcodes)
        {
            var result = new List<AvailableBarcode>();
            if (originBarcodes == null || !originBarcodes.Any())
            {
                return result;
            }
            int percent = (int)nupPercent.Value;
            int barcodesCount = originBarcodes.Count();
            int pickCount = (percent * barcodesCount / 100) + 1;
            Random rnd = new Random();
            List<int> indexList = new List<int>();
            for (int i = 0; i < pickCount; i++)
            {
                int index = rnd.Next(barcodesCount);
                if (indexList.Contains(index))
                {
                    i--;
                    continue;
                }
                result.Add(originBarcodes.ElementAt(i));
            }
            return result;
        }

        private void LoadPagedWorkOrder()
        {
            if (pageCount == 0)
            {
                PagedBarcodes.Clear();
                tpscurrentPage.Text = "0";//当前页
                tpspageCount.Text = "0";//总页数
                tpsrecordCount.Text = "0";//总记录数
                return;
            }
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord = pageSize * (currentPage - 1) + 1;
            int endRecord = pageSize * currentPage;

            if (currentPage >= pageCount) endRecord = recordCount;
            PagedBarcodes.Clear();
            for (int i = beginRecord - 1; i < endRecord; i++)
            {
                PagedBarcodes.Add(Barcodes[i]);
            }
            tpscurrentPage.Text = currentPage.ToString();//当前页
            tpspageCount.Text = pageCount.ToString();//总页数
            tpsrecordCount.Text = recordCount.ToString();//总记录数
        }

        private readonly object lockBuildObj = new object();

        private void BtnBuildTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockBuildObj)
                {
                    int inventoryType = Convert.ToInt32(this.cbType.SelectedValue);
                    if (inventoryType < 0)
                    {
                        "请选择盘点模式".ShowTips();
                        return;
                    }
                    if (inventoryType == (int)InventoryOrderTypeEnum.Percent && nupPercent.Value == 0)
                    {
                        "请填写抽盘比例".ShowTips();
                        return;
                    }
                    if (Barcodes == null || Barcodes.Count == 0)
                    {
                        "当前条件下未计算出需要盘点的物料".ShowTips();
                        return;
                    }

                    string subArea = cbShelfSide.Text;
                    if (subArea == "全部")
                    {
                        subArea = string.Empty;
                    }
                    int towerNo = Convert.ToInt32(cmbArea.SelectedValue);
                    if (string.IsNullOrWhiteSpace(subArea) && (towerNo == (int)TowerEnum.LightShelf || towerNo == (int)TowerEnum.ReformShelf))
                    {
                        "料架和货架盘点时，暂时只支持单个架子盘点，请选择一个货架或者料架号".ShowTips();
                        return;
                    }

                    int asrsArea = (int)TowerEnum.ASRS;
                    if (towerNo != (int)TowerEnum.SortingArea)
                    {
                        var orders = InventoryBll.GetAvailableInventoryOrders();
                        var validateOrders = orders.Where(p => p.InventoryArea == asrsArea || (p.InventoryArea == towerNo && p.SubArea == subArea));
                        if (validateOrders.Any())
                        {
                            var inventoryNos = validateOrders.Select(p => p.InventoryNo).Distinct();
                            string notifyString = string.Join(",", inventoryNos.ToArray());
                            $"当前要盘点的库区 {EnumHelper.GetDescription(typeof(TowerEnum), towerNo)}-{subArea} 已存在盘点单 {notifyString}，将其完成后才可以创建新的盘点".ShowTips();
                            return;
                        }

                        var validateBarcodes = DeliveryBll.GetInventoryValidateBarcode();
                        var validatedBarcodes = validateBarcodes.Where(p => p.DeliveryAreaId == asrsArea || p.DeliveryAreaId == towerNo);
                        if (validatedBarcodes.Any())
                        {
                            var deliveryIds = validatedBarcodes.Select(p => p.DeliveryId).Distinct();
                            var deliveryOrders = DeliveryBll.GetInventoryValidateOrders(deliveryIds);
                            var deliveryNos = deliveryOrders.Select(p => p.DeliveryNo);
                            var notifyString = string.Join(",", deliveryNos.ToArray());
                            $"当前要盘点的库区 {EnumHelper.GetDescription(typeof(TowerEnum), towerNo)}-{subArea} 已存在出库单 {notifyString}，将其完成后才可以创建新的盘点".ShowTips();
                            return;
                        }

                        var transferOrders = TransferBll.GetInventoryValidateOrders();
                        var validateTransferOrders = transferOrders.Where(p => p.SourceAreaId == asrsArea || p.SourceAreaId == towerNo);
                        if (validateTransferOrders.Any())
                        {
                            var transferNos = validateTransferOrders.Select(p => p.TransferNo).Distinct();
                            var notifyString = string.Join(",", transferNos);
                            $"当前要盘点的库区 {EnumHelper.GetDescription(typeof(TowerEnum), towerNo)}-{subArea} 已存在移库单 {notifyString}，将其完成后才可以创建新的盘点".ShowTips();
                            return;
                        }
                    }

                    int rowCount = 0;
                    var barcodes = Barcodes.GroupBy(p => p.LockTowerNo);
                    List<string> orderNos = new List<string>();
                    foreach (var item in barcodes)
                    {
                        string orderNo = $"PD{DateTime.Now:yyyyMMddHHmmss}{rowCount}";

                        orderNos.Add(orderNo);
                        rowCount += InventoryBll.BuildInventoryOrder(orderNo, item.ToList(), AppInfo.LoginUserInfo.account, inventoryType, (int)nupPercent.Value, item.Key, subArea);
                    }

                    if (rowCount > 0)
                    {
                        $"创建盘点单成功:{string.Join(",", orderNos.ToArray())}".ShowTips();
                        Barcodes.Clear();
                        PagedBarcodes.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                _ = ex.GetDeepException().ShowError();
            }
        }

        private void CmbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int tower = TypeParse.StrToInt(cmbArea.SelectedValue, -1);
            switch (tower)
            {
                case 1:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "巷道：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.AbSide;
                    cbType.Enabled = true;
                    btnSyncLightShelf.Visible = false;
                    break;
                case 2:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "料架：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.LightShelf;
                    SetTypeComboxToDefault();

                    btnSyncLightShelf.Visible = true;
                    break;
                case 3:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "栈板：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.PalletAreas;
                    SetTypeComboxToDefault();
                    btnSyncLightShelf.Visible = false;
                    break;
                case 4:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "货架：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.TransformationShelf;
                    SetTypeComboxToDefault();
                    btnSyncLightShelf.Visible = false;
                    break;
                default:
                    lblShelfSide.Visible = false;
                    cbShelfSide.Visible = false;
                    cbShelfSide.SelectedIndex = -1;
                    SetTypeComboxToDefault();
                    btnSyncLightShelf.Visible = false;
                    break;
            }
        }

        private void SetTypeComboxToDefault()
        {
            cbType.SelectedValue = (int)InventoryOrderTypeEnum.Numeric;
            cbType.Enabled = false;
        }

        private void CbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int orderType = TypeParse.StrToInt(cbType.SelectedValue, -1);

            bool visibility = orderType == (int)InventoryOrderTypeEnum.Percent;
            lblPercent.Visible = visibility;
            nupPercent.Visible = visibility;

        }

        private void BtnFrist_ButtonClick(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadPagedWorkOrder();
        }

        private void BtnPre_ButtonClick(object sender, EventArgs e)
        {
            currentPage -= 1;
            LoadPagedWorkOrder();
        }

        private void BtnNext_ButtonClick(object sender, EventArgs e)
        {
            currentPage += 1;
            LoadPagedWorkOrder();
        }

        private void BtnLast_ButtonClick(object sender, EventArgs e)
        {
            currentPage = pageCount;
            LoadPagedWorkOrder();
        }

        private void BtnSyncLightShelf_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockBuildObj)
                {
                    CallMesWmsApiBll.SyncLightShelf();

                    "同步成功，请检查数据和日志".ShowTips();
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
    }
}
