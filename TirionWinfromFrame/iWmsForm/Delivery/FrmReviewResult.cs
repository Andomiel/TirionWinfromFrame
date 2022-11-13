using Business;
using DevExpress.XtraEditors;
using Entity.DataContext;
using Entity.Enums;
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
    public partial class FrmReviewResult : XtraForm
    {
        public FrmReviewResult(string orderNo)
        {
            InitializeComponent();
            List<ReviewResultItem> results = BuildReviewItems(orderNo);
            rowMergeDataGridView1.AutoGenerateColumns = false;
            rowMergeDataGridView1.DataSource = new BindingList<ReviewResultItem>(results);
            rowMergeDataGridView1.MergeColumnNames.AddRange(new List<string> { "LineNumber", "PartNumber", "NeedQty", "TotalQty", "Result" });
            rowMergeDataGridView1.MergeFocusNames.Add("LineNumber");
            rowMergeDataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色
        }

        private List<ReviewResultItem> BuildReviewItems(string orderNo)
        {
            var order = DeliveryBll.GetDeliveryOrderByNo(orderNo);
            if (order == null)
            {
                throw new OppoCoreException($"找不到当前出库单号{orderNo}对应的出库单");
            }
            List<ReviewResultItem> results = new List<ReviewResultItem>();

            var details = DeliveryBll.GetDeliveryDetails(order.BusinessId);
            var barcodes = DeliveryBll.GetDeliveryBarcodes(order.BusinessId).GroupBy(p => p.DeliveryDetailId).ToDictionary(p => p.Key, p => p.ToList());

            foreach (var item in details)
            {
                if (barcodes.ContainsKey(item.BusinessId))
                {
                    var detailBarcodes = barcodes[item.BusinessId];
                    int totalQuantity = detailBarcodes.Sum(p => p.DeliveryQuantity);
                    foreach (var barcode in detailBarcodes)
                    {
                        results.Add(new ReviewResultItem()
                        {
                            LineNumber = item.RowNum.ToString(),
                            Match = barcode.OrderStatus == (int)DeliveryBarcodeStatusEnum.Reviewed ? (int)PrepareReviewMatchEnum.Done : (int)(int)PrepareReviewMatchEnum.Not,
                            NeedQty = item.RequireCount,
                            OrderNo = orderNo,
                            PartNumber = item.MaterialNo,
                            TowerNo = barcode.DeliveryAreaId,
                            Source = GetBarcodeSource(barcode),
                            Qty = barcode.DeliveryQuantity,
                            UPN = barcode.Barcode,
                            TotalQty = totalQuantity
                        });
                    }
                }
                else
                {
                    results.Add(new ReviewResultItem()
                    {
                        LineNumber = item.RowNum.ToString(),
                        Match = (int)PrepareReviewMatchEnum.Not,
                        NeedQty = item.RequireCount,
                        OrderNo = orderNo,
                        PartNumber = item.MaterialNo,
                        TowerNo = -1,
                        Source = -1,
                        TotalQty = 0
                    });
                }
            }
            results = results.Where(p => p.TotalQty > 0).ToList();
            return results;
        }

        private int GetBarcodeSource(Wms_DeliveryBarcode barcode)
        {
            if (barcode.OrderStatus == (int)DeliveryBarcodeStatusEnum.Cancelled || barcode.OrderStatus == (int)DeliveryBarcodeStatusEnum.Delivered)
            {
                return (int)PrepareSourceEnum.Recommend;
            }
            else if (barcode.OrderStatus == (int)DeliveryBarcodeStatusEnum.Reviewed)
            {
                if (barcode.CreateUser == barcode.LastUpdateUser)
                {
                    return (int)PrepareSourceEnum.ReviewNew;
                }
                else
                {
                    return (int)PrepareSourceEnum.Recommend;
                }
            }
            else
            {
                return -1;//cannot exist
            }
        }

        private void rowMergeDataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            string rowKey = rowMergeDataGridView1.Rows[e.RowIndex].Cells["Result"].Value.ToString();
            if (rowKey.Equals("正常"))
            {
                rowMergeDataGridView1.Rows[e.RowIndex].Cells["Result"].Style.BackColor = Color.LightGreen;
            }
            else if (rowKey.Equals("超发"))
            {
                rowMergeDataGridView1.Rows[e.RowIndex].Cells["Result"].Style.BackColor = Color.Orange;
            }
            else
            {
                rowMergeDataGridView1.Rows[e.RowIndex].Cells["Result"].Style.BackColor = Color.Red;
            }
        }

        private void rowMergeDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //string rowKey = rowMergeDataGridView1.Rows[e.RowIndex].Cells["Result"].Value.ToString();
            //if (rowKey.Contains("正常"))
            //{
            //    rowMergeDataGridView1.Rows[e.RowIndex].Cells["Result"].Style.BackColor = Color.LightGreen;
            //}
            //else if (rowKey.Contains("超发"))
            //{
            //    rowMergeDataGridView1.Rows[e.RowIndex].Cells["Result"].Style.BackColor = Color.Orange;
            //}
            //else
            //{
            //    rowMergeDataGridView1.Rows[e.RowIndex].Cells["Result"].Style.BackColor = Color.Red;
            //}
        }
    }
}
