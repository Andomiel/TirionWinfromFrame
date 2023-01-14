using Business;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Entity.DataContext;
using Entity.Dto.Balance;
using Entity.Enums;
using Mapster;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TirionWinfromFrame.Commons;

namespace TirionWinfromFrame.iWmsForm.Report
{
    public partial class FrmBalanceDetail : XtraForm
    {
        private readonly BalanceOrderDto order;

        public FrmBalanceDetail(BalanceOrderDto balanceOrder)
        {
            InitializeComponent();
            this.gridBarcodes.DataSource = WorkOrderBarcodes;

            order = balanceOrder;

            this.Text = order.BalanceNo;

            this.Load += FrmBalanceDetail_Load;
            this.FormClosing += FrmBalanceDetail_FormClosing;
        }

        private void FrmBalanceDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Tick -= RefreshTimer_Tick;
                refreshTimer.Dispose();
            }
        }

        private Timer refreshTimer;

        private BindingList<BalanceBarcodeDto> WorkOrderBarcodes = new BindingList<BalanceBarcodeDto>();

        private void FrmBalanceDetail_Load(object sender, EventArgs e)
        {
            RefreshBarcodes();

            if (order.OrderStatus > (int)BalanceOrderStatusEnum.Executing)
            {
                this.tbBarcode.Text = string.Empty;
                this.tbBarcode.Enabled = false;
                this.btnConfirm.Enabled = false;
            }
            else
            {
                if (refreshTimer != null)
                {
                    refreshTimer.Stop();
                    refreshTimer.Tick -= RefreshTimer_Tick;
                    refreshTimer.Dispose();
                }
                refreshTimer = new Timer
                {
                    Interval = 30 * 1000
                };
                refreshTimer.Tick += RefreshTimer_Tick;
                refreshTimer.Start();
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshBarcodes();
        }

        private void RefreshBarcodes()
        {
            var barcodes = BalanceBusiness.GetBalanceBarcodes(order.BusinessId);

            foreach (Wms_BalanceBarcode item in barcodes)
            {
                var barcode = WorkOrderBarcodes.FirstOrDefault(p => p.BusinessId == item.BusinessId);
                if (barcode == null)
                {
                    WorkOrderBarcodes.Add(item.Adapt<BalanceBarcodeDto>());
                }
                else if (item.OrderStatus >= barcode.OrderStatus)
                {
                    item.Adapt(barcode);
                }
                else
                {
                    //do nothing;
                }
            }
        }

        private void GvBarcodes_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            IndicatorObjectInfoArgs info = e.Info;
            if (info == null || !info.IsRowIndicator || e.RowHandle < 0)
                return;
            info.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private readonly object lockButtonObj = new object();

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            try
            {
                lock (lockButtonObj)
                {
                    if (e != null)
                    {
                        ValidateBarcode();
                    }

                    string upn = tbBarcode.Text.Trim().Split('*')[0];
                    var barcode = WorkOrderBarcodes.FirstOrDefault(p => p.Barcode == upn);
                    if (barcode == null)
                    {
                        var newBarcode = GeneralBusiness.GetInventoryBarcode(upn);
                        if (newBarcode == null || newBarcode.Rows.Count == 0)
                        {
                            throw new Exception($"找不到当前扫描出来的{upn}对应的库存信息");
                        }
                        DataRow dr = newBarcode.Rows[0];
                        //TODO:如果这个时候，此料已经被算料到移库单或者发料单了呢
                        string materialNo = Convert.ToString(dr["Part_Number"]);
                        int quantity = TypeParse.StrToInt(Convert.ToString(dr["Qty"]), 0);
                        string location = $"{Convert.ToString(dr["ABSide"])}{Convert.ToString(dr["LockMachineID"])}-{Convert.ToString(dr["LockLocation"])}";
                        int tower = TypeParse.StrToInt(Convert.ToString(dr[""]), 0);

                        barcode = new BalanceBarcodeDto()
                        {
                            Barcode = upn,
                            AreaId = tower,
                            BalanceId = order.BusinessId,
                            BusinessId = Guid.NewGuid().ToString("D"),
                            BalanceLocation = location,
                            Quantity = quantity,
                            OrderStatus = (int)BalanceBarcodeStatusEnum.Finished
                        };

                        BalanceBusiness.InsertBarcode(barcode, AppInfo.LoginUserInfo.username);

                        WorkOrderBarcodes.Add(barcode);
                    }
                    else
                    {
                        if (barcode.OrderStatus == (int)BalanceBarcodeStatusEnum.Finished)
                        {
                            $"当前物料{upn}已经扫描，无须再次扫描".ShowTips();
                            return;
                        }
                        barcode.OrderStatus = (int)BalanceBarcodeStatusEnum.Finished;

                        BalanceBusiness.UpdateBarcodeStatus(barcode, AppInfo.LoginUserInfo.account);
                    }

                    tbBarcode.Text = string.Empty;
                    tbBarcode.Focus();
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

        private void ValidateBarcode()
        {
            if (!tbBarcode.Text.Contains("*"))
            {
                "请扫二维码".ShowTips();
                tbBarcode.Text = string.Empty;
                return;
            }
            if (!tbBarcode.Text.EndsWith("*"))
            {
                "二维码结尾不是*号，请确认二维码完整性".ShowTips();
                return;
            }
            tbBarcode.Text = BarcodeFormatter.FormatBarcode(tbBarcode.Text.Trim());
        }

        private void GvBarcodes_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {    //右键弹出菜单
                if (e.Button != MouseButtons.Right)
                {
                    return;
                }
                //容许用户添加行时，最后一行为未实际添加的行，所以不需考虑弹出菜单
                if (e.RowHandle < 0)
                {
                    return;
                }
                //只有upn上允许弹窗
                if (e.Column.AbsoluteIndex != 0)
                {
                    return;
                }
                //创建快捷菜单
                ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

                //删除当前行
                ToolStripMenuItem tsmiRemoveCurrentRow = new ToolStripMenuItem("删除");
                tsmiRemoveCurrentRow.Click += (obj, arg) =>
                {
                    var row = WorkOrderBarcodes.ElementAt(e.RowHandle);

                    row.OrderStatus = (int)BalanceBarcodeStatusEnum.Cancelled;

                    BalanceBusiness.UpdateBarcodeStatus(row, AppInfo.LoginUserInfo.account);

                    WorkOrderBarcodes.Remove(row);
                };
                contextMenuStrip.Items.Add(tsmiRemoveCurrentRow);

                contextMenuStrip.Show(MousePosition.X, MousePosition.Y);
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }
    }
}
