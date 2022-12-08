using Business;
using Commons;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Entity;
using Entity.DataContext;
using Entity.Dto;
using Entity.Enums;
using Entity.Enums.Transfer;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmWareHouseDetail : XtraForm
    {
        public FrmWareHouseDetail()
        {
            InitializeComponent();
            this.ControlBox = false;

            gridWMS.ScrollBars = ScrollBars.Both;
            gridWMS.AutoGenerateColumns = false;
            gridWMS.DataSource = WorkOrderDetails;
            gridWMS.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色

            gridIWMS.ScrollBars = ScrollBars.Both;
            gridIWMS.AutoGenerateColumns = false;
            gridIWMS.DataSource = WorkOrderBarcodes;
            gridIWMS.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色
        }

        public FrmWareHouseDetail(InstockOrderDto order)
            : this()
        {
            CurrentOrder = order;
        }

        public InstockOrderDto CurrentOrder { get; set; }

        private BindingList<InstockDetailDto> WorkOrderDetails = new BindingList<InstockDetailDto>();

        private BindingList<InstockBarcodeDto> WorkOrderBarcodes = new BindingList<InstockBarcodeDto>();

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWareHouseDetail_Load(object sender, EventArgs e)
        {
            BindDefaultTower();
            CompareMaterialQty();
        }

        /// <summary>
        /// 定时刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            CompareMaterialQty();
        }

        private void BindDefaultTower()
        {
            var areas = WareHouseBLL.GetBoundAreas();
            if (areas == null || areas.Count == 0)
            {
                return;
            }

            foreach (var item in areas)
            {
                switch (item.AreaId)
                {
                    case (int)TowerEnum.SortingArea:
                        //ResetCheckBoxStatus(item, cbSorting);
                        break;
                    case (int)TowerEnum.ASRS:
                        ResetCheckBoxStatus(item, cbAsrs);
                        break;
                    case (int)TowerEnum.LightShelf:
                        //ResetCheckBoxStatus(item, cbLightShelf);
                        break;
                    case (int)TowerEnum.ReformShelf:
                        //ResetCheckBoxStatus(item, cbReform);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ResetCheckBoxStatus(InstockAreaDto instockArea, CheckBox cb)
        {
            if (instockArea.InstockId != CurrentOrder.BusinessId)
            {
                cb.ForeColor = Color.Green;
                cb.Text = $"{cbSorting.Text}({instockArea.InstockNo})";
                cb.Enabled = false;
            }
            isPostBack = true;
            cb.Enabled = true;
        }


        public void CompareMaterialQty()
        {
            var materials = WareHouseBLL.GetInstockDetails(CurrentOrder.BusinessId);
            var barcodes = WareHouseBLL.GetInstockBarcodes(CurrentOrder.BusinessId);

            Dictionary<string, InstockDetailDto> dict = new Dictionary<string, InstockDetailDto>();
            foreach (var item in materials)
            {
                var detail = WorkOrderDetails.FirstOrDefault(p => p.BusinessId == item.BusinessId);
                if (detail == null)
                {
                    detail = item.Adapt<InstockDetailDto>();
                    WorkOrderDetails.Add(detail);
                }
                if (!dict.ContainsKey(detail.BusinessId))
                {
                    dict.Add(detail.BusinessId, detail);
                }
            }

            foreach (DataRow item in barcodes.Rows)
            {
                var barcode = new InstockBarcodeDto()
                {
                    OrderNo = CurrentOrder.InstockNo,
                    MaterialNo = Convert.ToString(item["MaterialNo"]),
                    Upn = Convert.ToString(item["Upn"]),
                    Location = Convert.ToString(item["Location"]),
                    TowerNo = TypeParse.StrToInt(Convert.ToString(item["TowerNo"]), -1),
                    CreateTime = TypeParse.StrToDateTime(Convert.ToString(item["CreateTime"]), new DateTime(1900, 1, 1)),
                    InnerQty = TypeParse.StrToInt(Convert.ToString(item["InnerQty"]), 0),
                    Operator = Convert.ToString(item["Operator"]),
                    InstockDetailId = Convert.ToString(item["InstockDetailId"])
                };
                if (!dict.ContainsKey(barcode.InstockDetailId))
                {
                    continue;
                }
                var detail = dict[barcode.InstockDetailId];
                if (detail.Barcodes.Any(p => p.Upn == barcode.Upn))
                {
                    continue;
                }
                detail.Barcodes.Add(barcode);
            }
            CurrentOrder.Details = WorkOrderDetails.ToList();

            RefreshBarcodes();
        }

        /// <summary>
        /// 设置行样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridWMS_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.gridWMS.Columns[e.ColumnIndex].Name == "State")
            {
                if (Convert.ToString(e.Value) == "超收")
                {
                    e.CellStyle.BackColor = Color.Orange;
                }
                else if (Convert.ToString(e.Value) == "短收")
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else if (Convert.ToString(e.Value) == "正常")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    e.CellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            bool isShowWarn = WorkOrderDetails.Any(p => p.ReceiveStatusDisplay.Equals("未入库") || p.ReceiveStatusDisplay.Equals("短收"));
            if (isShowWarn)
            {
                "当前单据存在短收项，不可完成".ShowTips();
                return;
            }

            //bool isOk;
            //if (isShowWarn)
            //{
            //    FrmWareHouseWarn frmWareHouseWarn = new FrmWareHouseWarn() { OrderNo = lblOrderNo.Text };
            //    isOk = frmWareHouseWarn.ShowDialog() == DialogResult.OK;
            //}
            //else
            //{
            //    isOk = "确定完成入库？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;
            //}

            //if (isOk)
            //{
            WareHouseBLL.FinishInstockOrder(CurrentOrder.BusinessId, (int)InstockOrderStatusEnum.Finished, CurrentOrder.InstockType, AppInfo.LoginUserInfo.account);
            WareHouseBLL.UnlockTowerByOrder(CurrentOrder.BusinessId, AppInfo.LoginUserInfo.account);
            //移库时，需要对比reelId,更新锁定的工单号
            DialogResult = DialogResult.OK;
            //}
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            WareHouseBLL.UnlockTowerByOrder(CurrentOrder.BusinessId, AppInfo.LoginUserInfo.account);
            DialogResult = DialogResult.Cancel;
        }

        private void btnForceFinish_Click(object sender, EventArgs e)
        {
            FrmWareHouseWarn frmWareHouseWarn = new FrmWareHouseWarn() { OrderNo = lblOrderNo.Text };
            if (frmWareHouseWarn.ShowDialog() == DialogResult.OK)
            {
                WareHouseBLL.FinishInstockOrder(CurrentOrder.BusinessId, (int)InstockOrderStatusEnum.Finished, CurrentOrder.InstockType, AppInfo.LoginUserInfo.account);
                WareHouseBLL.UnlockTowerByOrder(CurrentOrder.BusinessId, AppInfo.LoginUserInfo.account);
                DialogResult = DialogResult.OK;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
            base.OnClosed(e);
        }

        private bool isPostBack = false;

        private void cbReform_CheckedChanged(object sender, EventArgs e)
        {
            if (isPostBack)
            {
                isPostBack = false;
                return;
            }
            CheckBox cb = sender as CheckBox;
            try
            {
                var towers = EnumHelper.GetEnumItems(typeof(TowerEnum));
                var current = towers.FirstOrDefault(p => cb.Text.Contains(p.Description));
                // 锁定库区
                if (cb.Checked)
                {
                    if (current.Value == (int)TowerEnum.ASRS)
                    {
                        ValidateDeliveryOrderLimit(current.Value);
                        ValidateTransferOrderLimit(current.Value);
                    }

                    bool result = WareHouseBLL.LockTower(CurrentOrder.BusinessId, current.Value, AppInfo.LoginUserInfo.account);

                    // false为锁定
                    if (!result)
                    {
                        $"{current.Description}已被锁定".ShowTips();
                        isPostBack = true;
                        cb.Checked = false;
                    }
                }
                // 解锁库区
                else
                {
                    WareHouseBLL.UnLockTower(CurrentOrder.BusinessId, current.Value, AppInfo.LoginUserInfo.account);
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
                isPostBack = true;
                cb.Checked = !cb.Checked;
            }
        }

        private void ValidateDeliveryOrderLimit(int tower)
        {
            var records = BaseDeliveryBll.GetExecutingRecords();
            if (records == null || records.Count == 0)
            {
                return;
            }
            var recordGroup = records.Where(p => p.LightArea == tower).ToList();
            if (recordGroup.Count > 0)
            {
                string area = EnumHelper.GetDescription(typeof(TowerEnum), tower);
                List<string> orderNos = recordGroup.Select(p => p.OrderNo).Distinct().ToList();
                throw new OppoCoreException($"当前有出库单据({string.Join(",", orderNos)})在库区{area}中执行，请等待");
            }
        }

        private void ValidateTransferOrderLimit(int tower)
        {
            var transferOrders = new TransferBll().GetExecutingOrders();
            if (transferOrders == null || transferOrders.Count == 0)
            {
                return;
            }
            var transferOrder = transferOrders.FirstOrDefault(p => p.SourceAreaId == tower || p.TargetAreaId == tower);
            if (transferOrder != null)
            {
                string area = EnumHelper.GetDescription(typeof(TowerEnum), tower);
                string transferType = EnumHelper.GetDescription(typeof(TransferTypeEnum), transferOrder.TransferType);
                throw new OppoCoreException($"当前有{transferType}单据({transferOrder.TransferNo})在库区{area}中执行，请等待");
            }
        }

        private void gridWMS_SelectionChanged(object sender, EventArgs e)
        {
            RefreshBarcodes();
        }

        private void RefreshBarcodes()
        {
            try
            {
                if (gridWMS.SelectedCells.Count == 0)
                {
                    return;
                }
                var row = gridWMS.SelectedCells[0].OwningRow;
                var orderMaterial = row.DataBoundItem as InstockDetailDto;

                WorkOrderBarcodes.Clear();
                foreach (InstockBarcodeDto item in orderMaterial.Barcodes)
                {
                    WorkOrderBarcodes.Add(item);
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private readonly object lockButtonObj = new object();

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockButtonObj)
                {
                    CompareMaterialQty();
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
