using Business;
using Entity;
using Entity.Dto;
using Entity.Enums;
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
    public partial class FrmTransfer : FrmBaseForm
    {
        public FrmTransfer()
        {
            InitializeComponent();

            BindAreaCombox(cmbArea);

            cbMateType.DataSource = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(ReelTypeEnum));
            cbMateType.DisplayMember = "Description";
            cbMateType.ValueMember = "Name";

            BindAreaCombox(cbTarget);

            dtpCycleStart.Format = DateTimePickerFormat.Custom;
            dtpCycleStart.CustomFormat = " ";
            dtpCycleEnd.Format = DateTimePickerFormat.Custom;
            dtpCycleEnd.CustomFormat = " ";
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = " ";
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = " ";
            dataGridViewSelect.AutoGenerateColumns = false;
            dataGridViewSelect.DataSource = TargetBarcodes;
            dataGridViewSelect.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色
        }

        private BindingList<TransferQueryResult> TargetBarcodes = new BindingList<TransferQueryResult>();

        private void BindAreaCombox(ComboBox cb)
        {
            var areas = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(TowerEnum));
            areas.RemoveAll(p => p.Value == 3);
            cb.DataSource = areas;
            cb.DisplayMember = "Description";
            cb.ValueMember = "Value";
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            var thisDateTimePicker = sender as DateTimePicker;
            thisDateTimePicker.Format = DateTimePickerFormat.Long;
            thisDateTimePicker.CustomFormat = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MaterialQueryCondition condition = new MaterialQueryCondition
            {
                UPN = this.tbUPN.Text,
                PartNumber = this.tbPartNumber.Text,
                SaveTimeStart = Convert.ToDateTime(dtpStart.Value.ToString("yyyy-MM-dd")),
                SaveTimeEnd = Convert.ToDateTime(dtpEnd.Value.ToString("yyyy-MM-dd")).AddDays(1),
            };
            condition.haveSaveTimeQuery = dtpStart.Format != DateTimePickerFormat.Custom
                           && dtpEnd.Format != DateTimePickerFormat.Custom;

            //周期
            condition.haveCycleQuery = dtpCycleStart.Format != DateTimePickerFormat.Custom
                                    && dtpCycleEnd.Format != DateTimePickerFormat.Custom;
            condition.CycleStart = Convert.ToDateTime(dtpCycleStart.Value.ToString("yyyy-MM-dd"));
            condition.CycleEnd = Convert.ToDateTime(dtpCycleEnd.Value.ToString("yyyy-MM-dd"));
            //料盘类型
            condition.MateType = (this.cbMateType.SelectedItem as EnumItem).Name;
            //MSD
            condition.MSD = this.cbMSD.Text;
            //流水号
            condition.SerialNoStart = this.txtSerialNoStart.Text;
            condition.SerialNoEnd = this.txtSerialNoEnd.Text;
            //超期
            condition.ExceedStart = TypeParse.StrToInt(this.txtExceedStart.Text, 0);
            condition.ExceedEnd = TypeParse.StrToInt(this.txtExceedEnd.Text, 0);
            //库区
            condition.TowerNo = Convert.ToInt32(cmbArea.SelectedValue);

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
            //供货厂家
            condition.Supplier = this.TextSupply.Text;

            IEnumerable<TransferQueryResult> transferQueryResults = TransferStoregeBll.QueryTransferDetail(condition);
            TargetBarcodes.Clear();
            foreach (var item in transferQueryResults)
            {
                TargetBarcodes.Add(item);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cbTarget.SelectedIndex = -1;
            tbUPN.Text = "";
            tbPartNumber.Text = "";
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
            DateTimePickerReset(dtpCycleStart);
            DateTimePickerReset(dtpCycleEnd);
            DateTimePickerReset(dtpStart);
            DateTimePickerReset(dtpEnd);

            TargetBarcodes.Clear();
        }

        private void DateTimePickerReset(DateTimePicker dtpicker)
        {
            dtpicker.Format = DateTimePickerFormat.Custom;
            dtpicker.CustomFormat = " ";
        }

        private void btnBuildTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                int targetArea = Convert.ToInt32(this.cbTarget.SelectedValue);
                if (targetArea < 0)
                {
                    "请选择目标库区".ShowTips();
                    return;
                }

                var selectedItems = TargetBarcodes.Where(p => p.SelectFlag).ToList();
                if (selectedItems.Count == 0)
                {
                    "请至少选中一行数据！".ShowTips();
                    return;
                }

                int rowCount = 0;
                var barcodes = selectedItems.GroupBy(p => p.LockTowerNo);
                List<string> orderNos = new List<string>();
                int sortingArea = (int)TowerEnum.SortingArea;
                foreach (var item in barcodes)
                {
                    if (targetArea == item.Key || (targetArea != sortingArea && item.Key != sortingArea))
                    {
                        throw new OppoCoreException("移库单只可以移出到理料区，或者从理料区移入其他库区");
                    }

                    string orderNo = $"YKRK{DateTime.Now:yyyyMMddHHmmss}{rowCount}";

                    if (targetArea == sortingArea)
                    {
                        orderNo = $"YKCK{DateTime.Now:yyyyMMddHHmmss}{rowCount}";
                    }

                    orderNos.Add(orderNo);
                    rowCount += TransferStoregeBll.BuildTransferOrder(orderNo, item.ToList(), AppInfo.LoginUserInfo.account, targetArea, item.Key);
                }

                if (rowCount > 0)
                {
                    $"创建移库单成功:{string.Join(",", orderNos.ToArray())}".ShowTips();
                    dataGridViewSelect.DataSource = null;
                    this.cbTarget.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (TargetBarcodes.Count == 0)
            {
                return;
            }
            foreach (var item in TargetBarcodes)
            {
                item.SelectFlag = true;
            }
        }

        private void btnSelectReverse_Click(object sender, EventArgs e)
        {
            if (TargetBarcodes.Count == 0)
            {
                return;
            }
            foreach (var item in TargetBarcodes)
            {
                item.SelectFlag = !item.SelectFlag;
            }
        }

        private void cmbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int towerNo = Convert.ToInt32(cmbArea.SelectedValue);
            switch (towerNo)
            {
                case 1:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "巷道：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.BuildAbSide();
                    break;
                case 2:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "货架：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.BuildLightShelf();
                    break;
                case 3:
                    lblShelfSide.Visible = false;
                    cbShelfSide.Visible = false;
                    cbShelfSide.SelectedIndex = -1;
                    break;
                case 4:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "货架：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.BuildTransformationShelf();
                    break;
                default:
                    lblShelfSide.Visible = false;
                    cbShelfSide.Visible = false;
                    cbShelfSide.SelectedIndex = -1;
                    break;
            }
        }

        private object lockImportObj = new object();

        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockImportObj)
                {
                    var dialog = new OpenFileDialog();
                    dialog.ShowDialog();
                    if (string.IsNullOrWhiteSpace(dialog.FileName))
                    {
                        "请选择要导入的移库UPN明细".ShowTips();
                    }
                    else
                    {
                        DataTable dtFromExcel = NpoiHelper.ExcelToDataTable(dialog.FileName, "移库单明细", 0);
                        if (dtFromExcel == null || dtFromExcel.Rows.Count == 0)
                        {
                            "表格为空或者表格未关闭！".ShowTips();
                            return;
                        }

                        //移库单数据校验
                        var barcodes = CheckData(dtFromExcel);
                        var existBarcodes = TransferStoregeBll.GetBarcodesByImportUpns(barcodes);

                        var towers = existBarcodes.GroupBy(p => p.LockTowerNo).Select(p => p.Key).ToList();
                        if (towers.Count != 1)
                        {
                            "要移库的UPN中存在多个库区的料！".ShowTips();
                            return;
                        }
                        int tower = towers.First();
                        if (tower == 0)
                        {
                            cbTarget.SelectedItem = "理料区";
                        }
                        else
                        {
                            cbTarget.SelectedItem = "非理料区";
                        }

                        TargetBarcodes.Clear();
                        foreach (var item in existBarcodes)
                        {
                            TargetBarcodes.Add(item);
                        }

                        "导入成功，请检查移库明细清单，然后创建移库单!".ShowTips();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        /// <summary>
        /// 入库单数据校验
        /// </summary>
        /// <param name="dtFromExcel"></param>
        private List<string> CheckData(DataTable dtFromExcel)
        {
            List<string> barcodes = new List<string>();
            for (int i = 0; i < dtFromExcel.Rows.Count; i++)
            {
                string upn = Convert.ToString(dtFromExcel.Rows[i][0]);
                if (string.IsNullOrWhiteSpace(upn))
                {
                    throw new OppoCoreException($"第{i}行附近存在以下数据问题:UPN为空");
                }
                barcodes.Add(upn);
            }
            return barcodes;
        }
    }
}
