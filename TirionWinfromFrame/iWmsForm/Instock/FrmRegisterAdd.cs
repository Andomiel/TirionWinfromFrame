using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Commons;
using DevExpress.XtraEditors;
using Entity.Dto.Instock;
using Entity.Enums.General;
using MES;
using MES.Entity;
using TirionWinfromFrame.Commons;

namespace TirionWinfromFrame
{
    public partial class FrmRegisterAdd : XtraForm
    {
        public FrmRegisterAdd(CfgRegisterDto cfgRegister)
        {
            InitializeComponent();
            Config = cfgRegister;
            Load += FrmChangePwd_Load;
        }

        protected CfgRegisterDto Config;

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
                        GeneralBusiness.InsertRegisterCfg(teMaterialNo.Text.Trim(), teRemark.Text.Trim(), ceStatus.Checked, AppInfo.LoginUserInfo.account);
                        "新增配置成功".ShowTips();
                    }
                    else
                    {
                        GeneralBusiness.UpdateRegisterCfg(teMaterialNo.Text.Trim(), teRemark.Text.Trim(), ceStatus.Checked, Config.Id, AppInfo.LoginUserInfo.account);
                        "修改配置成功".ShowTips();
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
                "料号不能为空".ShowWarning();
                teMaterialNo.Focus();
                return false;
            }
            int materialLength = teMaterialNo.Text.Trim().Length;
            if (materialLength != 7 && materialLength != 12)
            {
                "必须为7位老料号或者12位新料号".ShowWarning();
                teMaterialNo.Focus();
                return false;
            }
            return true;
        }

    }
}
