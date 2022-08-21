using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinformGeneralDeveloperFrame;
using WinformGeneralDeveloperFrame.Commons;
using DevExpress.XtraLayout;
using MES.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity;
namespace MES.Form
{
	public partial class FrmsysToolButton : FrmBaseForm
	{
        private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public FrmsysToolButton()
		{
			InitializeComponent();
		}
		private void FrmsysToolButton_Load(object sender, EventArgs e)
        {
		
			InitFrom(xtraTabControl1,grdList,grdListView,new LayoutControlGroup[]{layoutControlGroup1},new sysToolButtonInfo());
            InitSearchDicData();
        }
        /// <summary>
		/// 数据源初始化
		/// </summary>
		/// <returns></returns>
		private void Init()
		{
		
			




		}
        /// <summary>
		/// 搜索字段
		/// </summary>
		/// <returns></returns>
        private void InitSearchDicData()
        {
				fieldDictionary.Add("id","id");     
				fieldDictionary.Add("名称","btnName");     
				fieldDictionary.Add("编码","btnCode");     
				fieldDictionary.Add("图标","btnIcon");     
				//fieldDictionary.Add("备注","remark");     
        }
        /// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
        {
            try
            {
                sysToolButtonInfo info= (sysToolButtonInfo)this.ControlDataToModel(new sysToolButtonInfo());
                using (var db = new MESDB())
                {
                    db.sysToolButtonInfo.AddOrUpdate(info);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ShowError();
                return false;
            }
            return true;
        }
		public override void InitgrdListDataSource()
        {
			 using (var con=new MESDB())///
            {
				grdList.DataSource=con.sysToolButtonInfo.ToList();
            }
            Init();
		}
	    /// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
        public override bool CheckInput()
        {
			if(string.IsNullOrEmpty(txtbtnName.EditValue.ToString()))
			{
				"名称不能为空".ShowWarning();
				txtbtnName.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtbtnCode.EditValue.ToString()))
			{
				"编码不能为空".ShowWarning();
				txtbtnCode.Focus();
				return false;
			}
			if(string.IsNullOrEmpty(txtbtnIcon.EditValue.ToString()))
			{
				"图标不能为空".ShowWarning();
				txtbtnIcon.Focus();
				return false;
			}
			//if(string.IsNullOrEmpty(txtremark.EditValue.ToString()))
			//{
			//	"备注不能为空".ShowWarning();
			//	txtremark.Focus();
			//	return false;
			//}
			return true;
        }
        /// <summary>
		/// 删除
		/// </summary>
		/// <returns></returns>
		public override bool DelFunction()
        {
            try
            {
                sysToolButtonInfo info = (sysToolButtonInfo)this.ControlDataToModel(new sysToolButtonInfo());
                using (var db = new MESDB())
                {
                    db.Entry(info).State=EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ShowError();
                return false;
            }
            return true;
        }
        /// <summary>
		/// 搜索
		/// </summary>
		/// <returns></returns>
        public override void SearchFunction()
        {
            FrmSearch frm = new FrmSearch(fieldDictionary);
            if (frm.ShowDialog()==DialogResult.OK)
            {
                string sql = frm.sql;
                using (var db = new MESDB())
                {
                    if (string.IsNullOrEmpty(sql))
                    {
                        grdList.DataSource = db.sysToolButtonInfo.SqlQuery("select * from sysToolButton").ToList();
                    }
                    else
                    {
                        grdList.DataSource = db.sysToolButtonInfo.SqlQuery($"select * from sysToolButton where {sql}").ToList();
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string file = GetIconPath();
            if (!string.IsNullOrEmpty(file))
            {
                this.txtbtnIcon.Text = file;
            }
        }
        private string GetIconPath()
        {
            string file = FileDialogHelper.Open("选择图标文件", FileDialogHelper.ImageFilter, "", Application.StartupPath + "\\Images");
            string result = "";
            if (!string.IsNullOrEmpty(file))
            {
                result = file.Replace(Application.StartupPath, "").Trim('\\');
            }

            return result;
        }
    }
}