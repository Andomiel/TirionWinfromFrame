using Business;
using DevExpress.XtraEditors;
using Entity.Dto.Delivery;
using Entity.Enums.General;
using System;
using System.Windows.Forms;
using TirionWinfromFrame.Commons;

namespace TirionWinfromFrame
{
    public partial class FrmDiscreteAdd : XtraForm
    {
        public FrmDiscreteAdd(CfgDiscreteDto cfgRegister)
        {
            InitializeComponent();
            Config = cfgRegister;
            Load += FrmChangePwd_Load;
        }

        protected CfgDiscreteDto Config;

        private void FrmChangePwd_Load(object sender, EventArgs e)
        {
            if (Config == null || Config.Id == 0)
            {
                teMaterialNo.Text = string.Empty;
                teRemark.Text = string.Empty;
                ceStatus.Checked = true;
            }
            else
            {
                teMaterialNo.Text = Config.MaterialNo;
                teRemark.Text = Config.Remark;
                ceStatus.Checked = Config.RecordStatus == (int)RegisterStatusEnum.Valid;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInput())
                {
                    if (Config == null || Config.Id == 0)
                    {
                        DiscreteBusiness.InsertDiscreteCfg(teMaterialNo.Text.Trim(), teRemark.Text.Trim(), ceStatus.Checked, AppInfo.LoginUserInfo.account);
                        "新增散料测试配置成功".ShowTips();
                    }
                    else
                    {
                        DiscreteBusiness.UpdateDiscreteCfg(teMaterialNo.Text.Trim(), teRemark.Text.Trim(), ceStatus.Checked, Config.Id, AppInfo.LoginUserInfo.account);
                        "修改散料测试配置成功".ShowTips();
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }

        }

        private void BtnCanel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(teMaterialNo.Text))
            {
                "料号表达式不能为空".ShowWarning();
                teMaterialNo.Focus();
                return false;
            }
            //int materialLength = teMaterialNo.Text.Trim().Length;
            //if (materialLength != 7 && materialLength != 12)
            //{
            //    "必须为7位老料号或者12位新料号".ShowWarning();
            //    teMaterialNo.Focus();
            //    return false;
            //}
            //Regex regex = new Regex(teMaterialNo.Text.Trim());
            //regex.
            return true;
        }

    }
}
