using Business;
using Entity;
using Entity.DataContext;
using Entity.Dto;
using Entity.Enums;
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
    public partial class FrmInstocks : FrmBaseForm
    {
        public FrmInstocks()
        {
            InitializeComponent();
            InitCombox(cbOrderType, typeof(InOrderTypeEnum));
            InitCombox(cbOrderStatus, typeof(InstockOrderStatusEnum));

            dgvOrders.ScrollBars = ScrollBars.Both;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = PagedWorkOrders;
            dgvOrders.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色

            dgvMaterials.ScrollBars = ScrollBars.Both;
            dgvMaterials.Dock = DockStyle.Fill;
            dgvMaterials.AutoGenerateColumns = false;
            dgvMaterials.DataSource = WorkOrderDetails;
            dgvMaterials.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色

            dgvBarcodes.ScrollBars = ScrollBars.Both;
            dgvBarcodes.Dock = DockStyle.Fill;
            dgvBarcodes.AutoGenerateColumns = false;
            dgvBarcodes.DataSource = WorkOrderBarcodes;
            dgvBarcodes.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色

            dtOrderDate.Value = DateTime.Now.AddDays(-2);
            dtFinishDate.Value = DateTime.Now.AddDays(1);
        }

        private void Dtp_MouseUp(object sender, MouseEventArgs e)
        {
            var thisDateTimePicker = sender as DateTimePicker;
            thisDateTimePicker.CustomFormat = "yyyy-MM-dd";
        }

        private void InitCombox(ComboBox cb, Type enumType)
        {
            List<EnumItem> enumItems = new List<EnumItem>
            {
                new EnumItem
                {
                    Name = string.Empty,
                    Value = -1,
                    Description = "全部"
                }
            };

            enumItems.AddRange(EnumHelper.GetEnumItems(enumType));

            cb.DataSource = enumItems;
            cb.DisplayMember = "Description";
            cb.ValueMember = "Value";
            cb.SelectedIndex = 0;
        }

        private List<InstockOrderDto> WorkOrders = new List<InstockOrderDto>();

        private BindingList<InstockOrderDto> PagedWorkOrders = new BindingList<InstockOrderDto>();

        private BindingList<InstockDetailDto> WorkOrderDetails = new BindingList<InstockDetailDto>();

        private BindingList<InstockBarcodeDto> WorkOrderBarcodes = new BindingList<InstockBarcodeDto>();

        private Dictionary<string, BindingList<InstockBarcodeDto>> OrderBarcodes = new Dictionary<string, BindingList<InstockBarcodeDto>>();

        private object lockQueryObj = new object();

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockQueryObj)
                {
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
            // 获取入库单列表
            var warehouses = WareHouseBLL.GetInstockOrders(tbOrderNo.Text.Trim(), tbUpn.Text.Trim(), tbMaterialNo.Text.Trim(),
                Convert.ToInt32(cbOrderType.SelectedValue),
                Convert.ToInt32(cbOrderStatus.SelectedValue), tbUser.Text.Trim(), dtOrderDate.Value, dtFinishDate.Value);

            WorkOrders = warehouses.Adapt<List<InstockOrderDto>>();
            //.Select(s => new InstockOrder(s.First()))
            //.OrderByDescending(p => p.ADD_TIME)
            //.ToList();

            currentPage = 1;
            recordCount = WorkOrders.Count;
            pageCount = (recordCount / pageSize);
            if (recordCount % pageSize > 0)
            {
                pageCount += 1;
            }
            LoadPagedOrders();
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedCells.Count == 0)
                {
                    return;
                }
                var row = dgvOrders.SelectedCells[0].OwningRow;
                var order = row.DataBoundItem as InstockOrderDto;

                var details = WareHouseBLL.GetInstockDetails(order.BusinessId);
                var barcodes = WareHouseBLL.GetInstockBarcodes(order.BusinessId);

                WorkOrderDetails.Clear();
                WorkOrderBarcodes.Clear();
                OrderBarcodes.Clear();
                foreach (DataRow item in barcodes.Rows)
                {
                    var barcode = new InstockBarcodeDto()
                    {
                        OrderNo = order.InstockNo,
                        MaterialNo = Convert.ToString(item["MaterialNo"]),
                        Upn = Convert.ToString(item["Upn"]),
                        Location = Convert.ToString(item["Location"]),
                        TowerNo = TypeParse.StrToInt(Convert.ToString(item["TowerNo"]), -1),
                        CreateTime = TypeParse.StrToDateTime(Convert.ToString(item["CreateTime"]), new DateTime(1900, 1, 1)),
                        InnerQty = TypeParse.StrToInt(Convert.ToString(item["InnerQty"]), 0),
                        Operator = Convert.ToString(item["Operator"]),
                        InstockDetailId = Convert.ToString(item["InstockDetailId"])
                    };
                    if (OrderBarcodes.ContainsKey(barcode.InstockDetailId))
                    {
                        OrderBarcodes[barcode.InstockDetailId].Add(barcode);
                    }
                    else
                    {
                        OrderBarcodes.Add(barcode.InstockDetailId, new BindingList<InstockBarcodeDto>() { barcode });
                    }
                }
                foreach (Wms_InstockDetail item in details)
                {
                    if (WorkOrderDetails.Any(p => p.BusinessId == item.BusinessId))
                    {
                        continue;
                    }
                    var detail = item.Adapt<InstockDetailDto>();
                    if (OrderBarcodes.ContainsKey(detail.BusinessId))
                    {
                        detail.Barcodes = OrderBarcodes[detail.BusinessId];
                        detail.ActualCount = detail.Barcodes.Sum(p => p.InnerQty);
                    }
                    WorkOrderDetails.Add(detail);
                }
                order.Details = WorkOrderDetails.ToList();
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 || e.ColumnIndex == -1)
                {
                    return;
                }
                if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                {
                    return;
                }
                string action = dgvOrders.Columns[e.ColumnIndex].Name;//操作类型
                if (action == "colOperate")
                {
                    var row = dgvOrders.SelectedCells[0].OwningRow;
                    var order = row.DataBoundItem as InstockOrderDto;
                    if (string.IsNullOrWhiteSpace(order.OperationText))
                    {
                        return;
                    }

                    FrmWareHouseDetail formDetail = new FrmWareHouseDetail(order) { Width = 1200, Height = 800 };

                    formDetail.lblOrderNo.Text = order.InstockNo;
                    var types = EnumHelper.GetEnumItems(typeof(InOrderTypeEnum));
                    var currentType = types.FirstOrDefault(p => p.Value == order.InstockType);
                    formDetail.lblType.Text = currentType?.Name;
                    formDetail.lblTypeName.Text = order.OrderTypeDisplay;

                    if (formDetail.ShowDialog() == DialogResult.OK)
                    {
                        var details = WareHouseBLL.GetInstockDetails(order.BusinessId).ToList();
                        WorkOrderDetails.Clear();
                        foreach (Wms_InstockDetail item in details)
                        {
                            WorkOrderDetails.Add(item.Adapt<InstockDetailDto>());
                        }
                        dgvOrders.UpdateCellValue(e.ColumnIndex - 3, e.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void dgvOrders_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                    e.RowBounds.Location.Y,
                    dgvOrders.RowHeadersWidth - 4,
                    e.RowBounds.Height);

                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                    dgvOrders.RowHeadersDefaultCellStyle.Font,
                    rectangle,
                    dgvOrders.RowHeadersDefaultCellStyle.ForeColor,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);


                var row = dgvOrders.Rows[e.RowIndex];
                var order = row.DataBoundItem as InstockOrderDto;
                if (order.OrderStatus == (int)InstockOrderStatusEnum.Finished)
                {
                    row.Cells["colOrderStatus"].Style.BackColor = Color.LightGreen;
                }
                else if (order.OrderStatus == (int)InstockOrderStatusEnum.Closed)
                {
                    row.Cells["colOrderStatus"].Style.BackColor = Color.Silver;
                }
                else
                {
                    row.Cells["colOrderStatus"].Style.BackColor = Color.Yellow;
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private object lockExportObj = new object();

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockExportObj)
                {
                    var workOrders = PagedWorkOrders.Where(p => p.IsSelected).ToList();
                    if (workOrders.Count == 0)
                    {
                        "请选择要导出明细的入库单".ShowTips();
                        return;
                    }
                    Dictionary<string, List<InstockBarcode>> data = new Dictionary<string, List<InstockBarcode>>();
                    foreach (var order in workOrders)
                    {
                        var barcodes = WareHouseBLL.GetInstockBarcodes(order.BusinessId);

                        List<InstockBarcode> dataItem = new List<InstockBarcode>();
                        foreach (DataRow item in barcodes.Rows)
                        {
                            dataItem.Add(new InstockBarcode()
                            {
                                OrderNo = order.InstockNo,
                                OrderTime = order.CreateTime,
                                OrderTypeDes = order.OrderTypeDisplay,
                                OrderStatus = order.OrderStatusDisplay,
                                MaterialNo = Convert.ToString(item["MaterialNo"]),
                                Barcode = Convert.ToString(item["Upn"]),
                                InnerCount = TypeParse.StrToInt(Convert.ToString(item["InnerQty"]), 0),
                                DeliveryOperator = order.LastUpdateUser,
                            });
                        }

                        data.Add(order.InstockNo, dataItem);
                    }

                    List<HeadColumn> headColumns = new List<HeadColumn>
                        {
                            new HeadColumn("OrderNo","入库单号", 4200),
                            new HeadColumn("OrderTime","下达时间", 4000),
                            new HeadColumn("OrderTypeDes","单据类型", 3000),
                            //new HeadColumn("FinishedTime","完成时间", 4000),
                            new HeadColumn("OrderStatus","单据状态", 3000),
                            //new HeadColumn("DestinationNo","目的地", 2200),
                            new HeadColumn("MaterialNo","物料代码", 2200),
                            //new HeadColumn("MaterialName","物料名称", 4000),
                            //new HeadColumn("DeliveryCount","需求数量", 2200),
                            //new HeadColumn("InventoryStatus","库存状态", 3000),
                            new HeadColumn("Barcode","UPN", 7168),
                            new HeadColumn("InnerCount","盘内数量", 2200),
                            new HeadColumn("DeliveryOperator","操作人", 3000),
                        };

                    ExportToExcel(data, headColumns);
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        public void ExportToExcel<T>(Dictionary<string, List<T>> data, List<HeadColumn> headColumns) where T : class
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            dialog.FilterIndex = 0;
            dialog.OverwritePrompt = true;
            dialog.InitialDirectory = "D:\\";
            if (data.Count == 1)
            {
                dialog.FileName = $"入库单{data.First().Key}-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
            }
            else
            {
                dialog.FileName = $"入库单-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}";
            }
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileFullName = NpoiHelper.ExportToExcel(dialog.FileName, data, headColumns);
            if (!string.IsNullOrWhiteSpace(fileFullName))
            {
                System.Diagnostics.Process.Start("explorer", "/select," + fileFullName);
            }
        }

        private void FrmInstocks_Load(object sender, EventArgs e)
        {
            GetOrders();
        }

        private void dgvOrders_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.C)
            {
                Clipboard.SetDataObject(this.dgvOrders.CurrentCell.Value.ToString());
            }
        }

        private void dgvDetails_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.C)
            {
                //Clipboard.SetDataObject(this.dgvDetails.CurrentCell.Value.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbOrderNo.Clear();
            tbUpn.Clear();
            tbMaterialNo.Clear();
            tbUser.Clear();
            dtOrderDate.CustomFormat = " ";
            dtOrderDate.Value = DateTime.Today;
            dtFinishDate.CustomFormat = " ";
            dtFinishDate.Value = DateTime.Today;
            cbOrderType.SelectedIndex = 0;
            cbOrderStatus.SelectedIndex = 0;
            GetOrders();
        }

        private void btnNoSource_Click(object sender, EventArgs e)
        {
            FrmInStockNotice dialog = new FrmInStockNotice();
            dialog.ShowDialog();
        }

        private void dgvMaterials_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvMaterials.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvMaterials.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvMaterials.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dgvMaterials_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMaterials.SelectedRows.Count == 0)
                {
                    return;
                }
                var row = dgvMaterials.SelectedRows[0];
                var orderMaterial = row.DataBoundItem as InstockDetailDto;

                //List<InstockBarcodeDto> barcodes = OrderBarcodes.Where(p => p.OrderNo == selectedOrder.InstockNo
                //                                                && p.MaterialNo == orderMaterial.MaterialNo).ToList();

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

        private void dgvBarcodes_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvBarcodes.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvBarcodes.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvBarcodes.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        public int pageSize = 10;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页

        private void LoadPagedOrders()
        {
            if (pageCount == 0)
            {
                PagedWorkOrders.Clear();
                WorkOrderDetails.Clear();
                WorkOrderBarcodes.Clear();
                tpscurrentPage.Text = "0";//当前页
                tpspageCount.Text = "0";//总页数
                tpsrecordCount.Text = "0";//总记录数
                return;
            }

            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord = pageSize * (currentPage - 1) + 1;
            int endRecord = pageSize * currentPage;

            if (currentPage == pageCount) endRecord = recordCount;
            PagedWorkOrders.Clear();
            for (int i = beginRecord - 1; i < endRecord; i++)
            {
                PagedWorkOrders.Add(WorkOrders[i]);
            }
            WorkOrderDetails.Clear();
            WorkOrderBarcodes.Clear();

            tpscurrentPage.Text = currentPage.ToString();//当前页
            tpspageCount.Text = pageCount.ToString();//总页数
            tpsrecordCount.Text = recordCount.ToString();//总记录数
        }

        private void btnFrist_ButtonClick(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadPagedOrders();
        }

        private void btnPre_ButtonClick(object sender, EventArgs e)
        {
            currentPage -= 1;
            LoadPagedOrders();
        }

        private void btnNext_ButtonClick(object sender, EventArgs e)
        {
            currentPage += 1;
            LoadPagedOrders();
        }

        private void BtnLast_ButtonClick(object sender, EventArgs e)
        {
            currentPage = pageCount;
            LoadPagedOrders();
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            dgv.ClearSelection();
        }

        private object lockCancelObj = new object();

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockCancelObj)
                {
                    var selectedOrders = PagedWorkOrders.Where(p => p.IsSelected).ToList();
                    if (selectedOrders.Count == 0)
                    {
                        "请选择至少一个入库单".ShowTips();
                        return;
                    }
                    var invalidOrders = selectedOrders.Where(p => p.OrderStatus > (int)InstockOrderStatusEnum.Received).Select(p => p.InstockNo).ToList();
                    if (invalidOrders.Count > 0)
                    {
                        $"入库单:{string.Join(",", invalidOrders)}状态已开始入库，不可取消".ShowTips();
                        return;
                    }
                    List<string> orderNos = new List<string>();
                    foreach (var item in selectedOrders)
                    {
                        orderNos.Add(item.InstockNo);
                        WareHouseBLL.FinishInstockOrder(item.BusinessId, (int)InstockOrderStatusEnum.Closed, item.InstockType, AppInfo.LoginUserInfo.account);
                        WareHouseBLL.UnlockTowerByOrder(item.BusinessId, AppInfo.LoginUserInfo.account);
                    }
                    $"入库单:{string.Join(",", orderNos)}取消入库成功".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }
    }

    public class InstockBarcode
    {
        public string OrderNo { get; set; } = string.Empty;
        public DateTime OrderTime { get; set; } = new DateTime(1900, 1, 1);
        public string OrderTypeDes { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public string MaterialNo { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public int InnerCount { get; set; } = 0;
        public string DeliveryOperator { get; set; } = string.Empty;
    }
}
