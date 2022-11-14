using Business;
using Entity;
using Entity.Dto;
using Entity.Enums;
using Newtonsoft.Json;
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
    public partial class FrmFrozenPolicy : FrmBaseForm
    {
        public FrmFrozenPolicy()
        {
            InitializeComponent();
            cmbArea.DataSource = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(TowerEnum));
            cmbArea.DisplayMember = "Description";
            cmbArea.ValueMember = "Value";
            cbMateType.DataSource = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(ReelTypeEnum));
            cbMateType.DisplayMember = "Description";
            cbMateType.ValueMember = "Name";

            dtpCycleStart.Format = DateTimePickerFormat.Custom;
            dtpCycleStart.CustomFormat = " ";
            dtpCycleEnd.Format = DateTimePickerFormat.Custom;
            dtpCycleEnd.CustomFormat = " ";
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = " ";
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = " ";
            dataGridViewSelect.AutoGenerateColumns = false;
            dataGridViewSelect.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色

            dataGridViewPolicy.AutoGenerateColumns = false;
            dataGridViewPolicy.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色

            QueryPolicies();
        }

        private void QueryPolicies()
        {
            var list = FrozenPolicyBll.GetAllFrozenPolicies();
            string reason = tbReason.Text.Trim();
            if (!string.IsNullOrWhiteSpace(reason))
            {
                list = list.Where(p => p.Remark.Contains(reason)).ToList();
            }
            dataGridViewPolicy.DataSource = new BindingList<PolicyView>(list);
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            var thisDateTimePicker = sender as DateTimePicker;
            thisDateTimePicker.Format = DateTimePickerFormat.Long;
            thisDateTimePicker.CustomFormat = null;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var condition = BuildConditions();
            List<FrozenQueryItem> inventories = FrozenPolicyBll.GetInventory(condition);
            this.dataGridViewSelect.DataSource = new BindingList<FrozenQueryItem>(inventories);
        }

        private MaterialQueryCondition BuildConditions()
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
                    condition.MachineId = string.IsNullOrWhiteSpace(cbShelfSide.Text) ? string.Empty : $"SWHY0{this.cbShelfSide.Text}";
                    break;
                case 4:
                    condition.MachineId = this.cbShelfSide.Text;
                    break;
            }
            //供货厂家
            condition.Supplier = this.TextSupply.Text;
            return condition;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbExcelFile.Text = "";
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
            dataGridViewSelect.DataSource = null;
        }

        private void DateTimePickerReset(DateTimePicker dtpicker)
        {
            dtpicker.Format = DateTimePickerFormat.Custom;
            dtpicker.CustomFormat = " ";
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (dataGridViewSelect.DataSource == null)
            {
                return;
            }
            var queryInfo = new List<FrozenQueryItem>(dataGridViewSelect.DataSource as BindingList<FrozenQueryItem>);
            queryInfo.ForEach(p => p.SelectFlag = true);
            dataGridViewSelect.DataSource = new BindingList<FrozenQueryItem>(queryInfo);
        }

        private void btnSelectReverse_Click(object sender, EventArgs e)
        {
            if (dataGridViewSelect.DataSource == null)
            {
                return;
            }
            var queryInfo = new List<FrozenQueryItem>(dataGridViewSelect.DataSource as BindingList<FrozenQueryItem>);
            queryInfo.ForEach(p => p.SelectFlag = p.SelectFlag ? false : true);
            dataGridViewSelect.DataSource = new BindingList<FrozenQueryItem>(queryInfo);
        }

        private void cmbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int tower = TypeParse.StrToInt(cmbArea.SelectedValue, -1);
            switch (tower)
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

        private void btnBuild_Click(object sender, EventArgs e)
        {
            PolicyCreateResult createResult = new PolicyCreateResult();
            FrmBuildRemind frmBuildRemind = new FrmBuildRemind();
            frmBuildRemind.StartPosition = FormStartPosition.CenterScreen;
            var dialogResult = frmBuildRemind.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
            //按条件
            else if (dialogResult == DialogResult.OK)
            {
                var condition = BuildConditions();
                if (condition.EmptyCondition)
                {
                    return;
                }
                createResult = FrozenPolicyBll.SavePolicy(condition, frmBuildRemind.txtRemark, AppInfo.LoginUserInfo.account);
            }
            //选择UPN
            else if (dialogResult == DialogResult.Yes)
            {
                if (dataGridViewSelect.DataSource == null)
                {
                    return;
                }
                List<FrozenQueryItem> items = new List<FrozenQueryItem>(dataGridViewSelect.DataSource as BindingList<FrozenQueryItem>);
                var selectedItems = items.Where(p => p.SelectFlag).ToList();
                if (selectedItems.Count == 0)
                {
                    "请至少选中一行数据！".ShowTips();
                    return;
                }
                List<string> upns = selectedItems.Select(p => p.ReelID).ToList();
                createResult = FrozenPolicyBll.SavePolicy(upns, frmBuildRemind.txtRemark, AppInfo.LoginUserInfo.account);
            }

            AfterSavePolicy(createResult);
        }

        private void btnPolicyOperate_Click(object sender, EventArgs e)
        {
            List<PolicyView> items = new List<PolicyView>(dataGridViewPolicy.DataSource as BindingList<PolicyView>);
            var selectedItems = items.Where(p => p.SelectFlag).ToList();
            FrozenOperateType operateEnum = FrozenOperateType.Unable;
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btnEnable":
                    operateEnum = FrozenOperateType.Enable;
                    if (selectedItems.Count != 1)
                    {
                        "请选择一行数据！".ShowTips();
                        return;
                    }
                    if (selectedItems.First().Enable)
                    {
                        return;
                    }
                    break;
                case "btnUnable":
                    operateEnum = FrozenOperateType.Unable;
                    if (selectedItems.Count != 1)
                    {
                        "请选择一行数据！".ShowTips();
                        return;
                    }
                    if (!selectedItems.First().Enable)
                    {
                        return;
                    }
                    break;
                case "btnDel":
                    operateEnum = FrozenOperateType.Del;
                    if (selectedItems.Count == 0)
                    {
                        "请至少选择一行数据！".ShowTips();
                        return;
                    }
                    break;
            }

            bool opearteResult = FrozenPolicyBll.OperatePolicyEnable(selectedItems, operateEnum, AppInfo.LoginUserInfo.account);
            if (opearteResult)
            {
                $"冻结策略{EnumHelper.GetDescription(operateEnum)}成功".ShowTips();
                QueryPolicies();
            }
            else
            {
                "执行失败".ShowTips();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                tbExcelFile.Text = openFileDialog1.FileName;

                string filePath = tbExcelFile.Text;
                if (!string.IsNullOrWhiteSpace(tbExcelFile.Text))
                {
                    DataTable dtFromExcel = NpoiHelper.ExcelToDataTable(filePath, null, 0);
                    if (dtFromExcel == null || dtFromExcel.Rows.Count == 0)
                    {
                        "表格为空或者表格已被其他应用打开！".ShowTips();
                        return;
                    }
                    List<string> upns = dtFromExcel.AsEnumerable()
                                                   .Where(p => !string.IsNullOrWhiteSpace(p.Field<string>(0)))
                                                   .Select(p => p.Field<string>(0)).ToList();
                    if (upns.Count > 0)
                    {
                        FrmBuildRemind frmBuildRemind = new FrmBuildRemind(FrozenRemindBtnType.OnlyUpns);
                        frmBuildRemind.StartPosition = FormStartPosition.CenterScreen;
                        var dialogResult = frmBuildRemind.ShowDialog();
                        if (dialogResult == DialogResult.Cancel)
                        { return; }
                        PolicyCreateResult createResult = FrozenPolicyBll.SavePolicy(upns, frmBuildRemind.txtRemark, AppInfo.LoginUserInfo.account);
                        AfterSavePolicy(createResult);
                    }
                }
                else
                {
                    "请选择正确的Excel文件".ShowTips();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void AfterSavePolicy(PolicyCreateResult saveResult)
        {
            if (saveResult.Result)
            {
                PolicyView policyView = new PolicyView()
                {
                    Id = saveResult.Policy.Id,
                    FrozenNo = saveResult.Policy.FrozenNo,
                    CreateTime = saveResult.Policy.CreateTime,
                    CreateUser = saveResult.Policy.CreateUser,
                    UpdateTime = saveResult.Policy.UpdateTime,
                    UpdateUser = saveResult.Policy.UpdateUser,
                    Enable = saveResult.Policy.Enable,
                    FileSrc = saveResult.Policy.FileSrc,
                    Remark = saveResult.Policy.Remark,
                    PolicyType = saveResult.Policy.PolicyType,
                    ConditionJson = saveResult.Policy.ConditionJson,
                    PolicyDetail = JsonConvert.SerializeObject(saveResult.Details)
                };
                if (dataGridViewPolicy.DataSource == null)
                {
                    dataGridViewPolicy.DataSource = new BindingList<PolicyView>();
                }
                var list = dataGridViewPolicy.DataSource as BindingList<PolicyView>;
                list.Add(policyView);
            }
            else
            {
                "策略保存失败！".ShowTips();
            }
        }

        private void btnDlExcelTemp_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel Office97-2003(*.xls)|.xls|Excel Office2007及以上(*.xlsx)|*.xlsx";
            dialog.FilterIndex = 0;
            dialog.OverwritePrompt = true;
            dialog.InitialDirectory = "D:\\";
            dialog.FileName = $"Excel模板_冻结策略导入UPN";
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            List<string> sampleCell = new List<string>
            {
                "举例：4873244-W003S-17630-00578","举例：8040275-A1092-21707-00010"
            };
            string fileFullName = NpoiHelper.ExportToExcel(dialog.FileName, sampleCell, "UPN列表");
            if (!string.IsNullOrWhiteSpace(fileFullName))
            {
                System.Diagnostics.Process.Start("explorer", "/select," + fileFullName);
            }
        }

        private void txtExceed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private object lockStrategyObj = new object();

        private void btnStrategyQuery_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockStrategyObj)
                {
                    QueryPolicies();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }
    }
}
