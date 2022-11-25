using Business;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Entity.DataContext;
using Entity.Dto;
using Entity.Enums;
using Entity.Enums.Inventory;
using Mapster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TirionWinfromFrame.Commons;

namespace TirionWinfromFrame.iWmsForm.StockTaking
{
    public partial class FrmInventoryDetail : XtraForm
    {
        private readonly InventoryOrderDto order;

        public FrmInventoryDetail(InventoryOrderDto inventoryOrder)
        {
            InitializeComponent();
            this.gridBarcodes.DataSource = WorkOrderBarcodes;

            order = inventoryOrder;

            this.Text = order.InventoryNo;
            this.gcGeneral.Text = $"{order.InventoryNo}-{order.InventoryAreaDisplay}-{order.SubArea}";

            this.Load += FrmInventoryDetail_Load;
            this.Disposed += FrmInventoryDetail_Disposed;
        }

        private void FrmInventoryDetail_Disposed(object sender, EventArgs e)
        {
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Tick -= RefreshTimer_Tick;
                refreshTimer.Dispose();
            }
        }

        private Timer refreshTimer;

        private BindingList<InventoryBarcodeDto> WorkOrderBarcodes = new BindingList<InventoryBarcodeDto>();

        private void FrmInventoryDetail_Load(object sender, EventArgs e)
        {
            RefreshBarcodes();

            if (order.OrderStatus >= (int)InventoryOrderStatusEnum.Executing)
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
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshBarcodes();
        }

        private void RefreshBarcodes()
        {
            var barcodes = InventoryBll.GetInventoryBarcodes(order.BusinessId);

            WorkOrderBarcodes.Clear();
            foreach (Wms_InventoryBarcode item in barcodes)
            {
                WorkOrderBarcodes.Add(item.Adapt<InventoryBarcodeDto>());
            }
        }

        private void GvBarcodes_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Name != "colResult")
            {
                return;
            }
            string cellValue = Convert.ToString(e.CellValue);
            if (cellValue == "多料" || cellValue == "盘盈")
            {
                e.Appearance.BackColor = Color.CornflowerBlue;
            }
            else if (cellValue == "缺料" || cellValue == "盘亏")
            {
                e.Appearance.BackColor = Color.OrangeRed;
            }
            else if (cellValue == "正常")
            {
                e.Appearance.BackColor = Color.LimeGreen;
            }
            else
            {
                //do nothing
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
                            throw new Exception($"找不到当前盘点扫描出来的{upn}对应的库存信息");
                        }
                        DataRow dr = newBarcode.Rows[0];
                        //TODO:如果这个时候，此料已经被算料到移库单或者发料单了呢
                        string materialNo = Convert.ToString(dr["Part_Number"]);
                        int quantity = TypeParse.StrToInt(Convert.ToString(dr["Qty"]), 0);
                        string location = $"{Convert.ToString(dr["ABSide"])}{Convert.ToString(dr["LockMachineID"])}-{Convert.ToString(dr["LockLocation"])}";

                        InventoryBll.MaterialInstockTakingNew(order.BusinessId, materialNo, upn, quantity, location, AppInfo.LoginUserInfo.account);

                        barcode = new InventoryBarcodeDto()
                        {
                            Barcode = upn,
                            CreateTime = DateTime.Now,
                            CreateUser = AppInfo.LoginUserInfo.account,
                            InventoryOrderId = order.BusinessId,
                            LastUpdateTime = DateTime.Now,
                            LastUpdateUser = AppInfo.LoginUserInfo.account,
                            MaterialNo = materialNo,
                            OrderStatus = (int)InventoryBarcodeStatusEnum.Executed,
                            OriginLocation = location,
                            OriginQuantity = 0,
                            RealQuantity = quantity,
                        };
                        WorkOrderBarcodes.Add(barcode);
                    }
                    else
                    {
                        if (barcode.OrderStatus == (int)InventoryBarcodeStatusEnum.Executed || barcode.OrderStatus == (int)InventoryBarcodeStatusEnum.Confirmed)
                        {
                            $"当前物料{upn}已经被盘点，无须再次扫描".ShowTips();
                            return;
                        }
                        InventoryBll.MaterialInstockTakingSuccess(barcode.Barcode, barcode.OriginLocation, AppInfo.LoginUserInfo.account);

                        barcode.OrderStatus = (int)InventoryBarcodeStatusEnum.Executed;
                        barcode.RealQuantity = barcode.OriginQuantity;
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
    }
}
