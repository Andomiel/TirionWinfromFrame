using Business;
using Commons;
using Entity.Dto;
using Entity.Enums;
using Entity.Enums.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

                    Barcodes = GetBarcodesByCondition();

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

        private List<AvailableBarcode> GetBarcodesByCondition()
        {
            MaterialQueryCondition condition = new MaterialQueryCondition
            {
                //库区
                TowerNo = Convert.ToInt32(cmbArea.SelectedValue)
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

        private List<AvailableBarcode> BuildRandomBarcodes(List<AvailableBarcode> originBarcodes)
        {
            var result = new List<AvailableBarcode>();
            if (originBarcodes == null || originBarcodes.Count == 0)
            {
                return result;
            }
            int percent = (int)nupPercent.Value;
            int pickCount = (percent * originBarcodes.Count / 100) + 1;
            Random rnd = new Random();
            List<int> indexList = new List<int>();
            for (int i = 0; i < pickCount; i++)
            {
                int index = rnd.Next(originBarcodes.Count);
                if (indexList.Contains(index))
                {
                    i--;
                    continue;
                }
                result.Add(originBarcodes[index]);
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
                    cbShelfSide.DataSource = BuildComboxHelper.BuildAbSide();
                    cbType.Enabled = true;
                    break;
                case 2:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "货架：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.BuildLightShelf();
                    SetTypeComboxToDefault();
                    break;
                case 3:
                    lblShelfSide.Visible = false;
                    cbShelfSide.Visible = false;
                    cbShelfSide.SelectedIndex = -1;
                    SetTypeComboxToDefault();
                    break;
                case 4:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "货架：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.BuildTransformationShelf();
                    SetTypeComboxToDefault();
                    break;
                default:
                    lblShelfSide.Visible = false;
                    cbShelfSide.Visible = false;
                    cbShelfSide.SelectedIndex = -1;
                    SetTypeComboxToDefault();
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
    }
}
