using Business;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Entity.DataContext;
using Entity.Dto.Balance;
using Entity.Dto.Delivery;
using Entity.Enums;
using Mapster;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TirionWinfromFrame.Commons;

namespace TirionWinfromFrame.iWmsForm
{
    public partial class FrmClearOrders : XtraForm
    {
        public FrmClearOrders()
        {
            InitializeComponent();
            this.gridBarcodes.DataSource = WorkOrders;

            this.Load += FrmClearOrders_Load;
            this.FormClosing += FrmClearOrders_FormClosing;
        }

        private void FrmClearOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        private BindingList<DeliveryOrderDto> WorkOrders = new BindingList<DeliveryOrderDto>();

        private void FrmClearOrders_Load(object sender, EventArgs e)
        {
            deEndTime.EditValue = DateTime.Today.AddDays(-30);

            RefreshOrders();
        }

        private void RefreshOrders()
        {
            DateTime endTime = deEndTime.EditValue == null ? DateTime.Today.AddDays(-2) : deEndTime.DateTime.Date;

            WorkOrders.Clear();

            var orders = DeliveryBll.GetClearableOrders(endTime, tbOrder.Text.Trim());

            foreach (var item in orders)
            {
                WorkOrders.Add(item);
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
            RefreshOrders();
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            try
            {
                lock (lockButtonObj)
                {
                    var selectedRowIndex = gvBarcodes.GetSelectedRows();
                    if (selectedRowIndex.Length <= 0)
                    {
                        "选择要清理的出库单".ShowTips();
                        return;
                    }
                    foreach (int index in selectedRowIndex)
                    {
                        DeliveryOrderDto row = WorkOrders.ElementAt(index);

                        ClearCertainOrder(row);
                    }

                    SplashScreenManager.CloseForm(false);

                    "清理成功".ShowTips();
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);

                ex.GetDeepException().ShowError();
            }
            finally
            {
                RefreshOrders();
            }
        }

        private void ClearCertainOrder(DeliveryOrderDto row)
        {
            try
            {
                var order = DeliveryBll.GetDeliveryOrderByNo(row.DeliveryNo);
                if (order.OrderStatus >= (int)DeliveryOrderStatusEnum.Reviewed)
                {
                    return;
                }

                var barcodes = DeliveryBll.GetDeliveryBarcodes(order.BusinessId);

                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (Wms_DeliveryBarcode item in barcodes)
                {
                    try
                    {
                        ClearCertainBarcode(item);
                        dict.Add(item.Barcode, "为什么会走到这");
                    }
                    catch (OppoCoreException ex)
                    {
                        dict.Add(item.Barcode, ex.Message);

                        //Task.Run(() =>
                        //{
                        CallMesWmsApiBll.SaveLogs(item.Barcode, "关闭过期工单", $"{AppInfo.LoginUserInfo.username}({AppInfo.LoginUserInfo.account})", ex.Message);
                        //});
                    }
                    catch (Exception ex)
                    {
                        dict.Add(item.Barcode, ex.Message);

                        //Task.Run(() =>
                        //{
                        CallMesWmsApiBll.SaveLogs(item.Barcode, "关闭过期工单", $"{AppInfo.LoginUserInfo.username}({AppInfo.LoginUserInfo.account})", ex.GetDeepException());
                        //}/*);*/
                    }

                    DeliveryBll.ClearDeliveryBarcode(item, AppInfo.LoginUserInfo.account);
                };

                DeliveryBll.ClearDeliveryOrder(order, AppInfo.LoginUserInfo.account);

                //Task.Run(() =>
                //{
                CallMesWmsApiBll.SaveLogs(row.DeliveryNo, "关闭过期工单", $"{AppInfo.LoginUserInfo.username}({AppInfo.LoginUserInfo.account})", JsonConvert.SerializeObject(dict));
                //});
            }
            catch (Exception ex)
            {
                //Task.Run(() =>
                //{
                CallMesWmsApiBll.SaveLogs(row.DeliveryNo, "关闭过期工单", $"{AppInfo.LoginUserInfo.username}({AppInfo.LoginUserInfo.account})", $"关闭失败:{ex.GetDeepException()}");
                //});
            }
        }

        private void ClearCertainBarcode(Wms_DeliveryBarcode barcode)
        {
            var dtBarcodes = GeneralBusiness.GetBarcode(barcode.Barcode);
            if (dtBarcodes == null || dtBarcodes.Rows.Count == 0)
            {
                throw new OppoCoreException("不存在这个upn");
            }
            var barcodeRow = dtBarcodes.Rows[0];
            string statusString = Convert.ToString(barcodeRow["Status"]);
            if (statusString != "3")
            {
                var material = CallMesWmsApiBll.CallMaterialFromMes(barcode.Barcode);
                if (material != null && material.StoreId != "361")
                {
                    GeneralBusiness.DeliveryBarcode(barcode.Barcode);
                    throw new OppoCoreException("站位不是361置为出库");
                }
                else
                {
                    GeneralBusiness.ReleaseBarcode(barcode.Barcode);
                    throw new OppoCoreException("站位为361释放UPN");
                }
            }
            throw new OppoCoreException("已经是出库状态");
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            try
            {
                lock (lockButtonObj)
                {
                    foreach (DeliveryOrderDto row in WorkOrders)
                    {
                        ClearCertainOrder(row);
                    }

                    SplashScreenManager.CloseForm(false);
                    "清理成功".ShowTips();
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                ex.GetDeepException().ShowError();
            }
            finally
            {
                RefreshOrders();
            }
        }
    }
}
