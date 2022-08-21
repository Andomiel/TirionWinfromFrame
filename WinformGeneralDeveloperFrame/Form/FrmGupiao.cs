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
	public partial class Frmstock : FrmBaseForm
	{
		private Dictionary<string, string> fieldDictionary = new Dictionary<string, string>();
		public Frmstock()
		{
			InitializeComponent();
		}
		private void Frmstock_Load(object sender, EventArgs e)
		{

			InitFrom(xtraTabControl1, grdList, grdListView, new LayoutControlGroup[] { layoutControlGroup1 }, new stockInfo());
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
			fieldDictionary.Add("代码", "code");
			fieldDictionary.Add("名称", "name");
			fieldDictionary.Add("今日开盘价", "startPrice");
			fieldDictionary.Add("昨日收盘价", "olePrice");
			fieldDictionary.Add("当前价格", "nowPrice");
			fieldDictionary.Add("今日最高价", "maxPrice");
			fieldDictionary.Add("今日最低价", "minPrice");
			fieldDictionary.Add("竞买价", "bidderPrice");
			fieldDictionary.Add("竞卖价", "auctionPrice");
			fieldDictionary.Add("成交股票数", "turnover");
			fieldDictionary.Add("成交金额", "turnoverPrice");
			fieldDictionary.Add("买1数量", "buyOneNum");
			fieldDictionary.Add("买1价格", "buyOnePrice");
			fieldDictionary.Add("买2数量", "buyTwoNum");
			fieldDictionary.Add("买2价格", "buyTwoPrice");
			fieldDictionary.Add("买3数量", "buyThreeNum");
			fieldDictionary.Add("买3价格", "buyThreePrice");
			fieldDictionary.Add("买4数量", "buyFourNum");
			fieldDictionary.Add("买4价格", "buyFourPrice");
			fieldDictionary.Add("买5数量", "buyFiveNum");
			fieldDictionary.Add("买5价格", "buyFivePrice");
			fieldDictionary.Add("卖1数量", "sellOneNum");
			fieldDictionary.Add("卖1价格", "sellOnePrice");
			fieldDictionary.Add("卖2数量", "sellTwoNum");
			fieldDictionary.Add("卖2价格", "sellTwoPrice");
			fieldDictionary.Add("卖3数量", "sellThreeNum");
			fieldDictionary.Add("卖3价格", "sellThreePrice");
			fieldDictionary.Add("卖4数量", "sellFourNum");
			fieldDictionary.Add("卖4价格", "sellFourPrice");
			fieldDictionary.Add("卖5数量", "sellFiveNum");
			fieldDictionary.Add("卖5价格", "sellFivePrice");
			fieldDictionary.Add("时间", "timeStr");
			fieldDictionary.Add("id", "id");
		}
		/// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		public override bool SaveFunction()
		{
			try
			{
				stockInfo info = (stockInfo)this.ControlDataToModel(new stockInfo());
				using (var db = new MESDB())
				{
					db.stockInfo.AddOrUpdate(info);
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
			using (var con = new MESDB())///
			{
				grdList.DataSource = con.stockInfo.ToList();
			}
			Init();
		}
		/// <summary>
		/// 字段为空校验
		/// </summary>
		/// <returns></returns>
		public override bool CheckInput()
		{
			if (string.IsNullOrEmpty(txtcode.EditValue.ToString()))
			{
				"代码不能为空".ShowWarning();
				txtcode.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtname.EditValue.ToString()))
			{
				"名称不能为空".ShowWarning();
				txtname.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtstartPrice.EditValue.ToString()))
			{
				"今日开盘价不能为空".ShowWarning();
				txtstartPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtolePrice.EditValue.ToString()))
			{
				"昨日收盘价不能为空".ShowWarning();
				txtolePrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtnowPrice.EditValue.ToString()))
			{
				"当前价格不能为空".ShowWarning();
				txtnowPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtmaxPrice.EditValue.ToString()))
			{
				"今日最高价不能为空".ShowWarning();
				txtmaxPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtminPrice.EditValue.ToString()))
			{
				"今日最低价不能为空".ShowWarning();
				txtminPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtbidderPrice.EditValue.ToString()))
			{
				"竞买价不能为空".ShowWarning();
				txtbidderPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtauctionPrice.EditValue.ToString()))
			{
				"竞卖价不能为空".ShowWarning();
				txtauctionPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtturnover.EditValue.ToString()))
			{
				"成交股票数不能为空".ShowWarning();
				txtturnover.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtturnoverPrice.EditValue.ToString()))
			{
				"成交金额不能为空".ShowWarning();
				txtturnoverPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtbuyOneNum.EditValue.ToString()))
			{
				"买1数量不能为空".ShowWarning();
				txtbuyOneNum.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtbuyOnePrice.EditValue.ToString()))
			{
				"买1价格不能为空".ShowWarning();
				txtbuyOnePrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtbuyTwoNum.EditValue.ToString()))
			{
				"买2数量不能为空".ShowWarning();
				txtbuyTwoNum.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtbuyTwoPrice.EditValue.ToString()))
			{
				"买2价格不能为空".ShowWarning();
				txtbuyTwoPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtbuyThreeNum.EditValue.ToString()))
			{
				"买3数量不能为空".ShowWarning();
				txtbuyThreeNum.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtbuyThreePrice.EditValue.ToString()))
			{
				"买3价格不能为空".ShowWarning();
				txtbuyThreePrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtbuyFourNum.EditValue.ToString()))
			{
				"买4数量不能为空".ShowWarning();
				txtbuyFourNum.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtbuyFourPrice.EditValue.ToString()))
			{
				"买4价格不能为空".ShowWarning();
				txtbuyFourPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtbuyFiveNum.EditValue.ToString()))
			{
				"买5数量不能为空".ShowWarning();
				txtbuyFiveNum.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtbuyFivePrice.EditValue.ToString()))
			{
				"买5价格不能为空".ShowWarning();
				txtbuyFivePrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtsellOneNum.EditValue.ToString()))
			{
				"卖1数量不能为空".ShowWarning();
				txtsellOneNum.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtsellOnePrice.EditValue.ToString()))
			{
				"卖1价格不能为空".ShowWarning();
				txtsellOnePrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtsellTwoNum.EditValue.ToString()))
			{
				"卖2数量不能为空".ShowWarning();
				txtsellTwoNum.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtsellTwoPrice.EditValue.ToString()))
			{
				"卖2价格不能为空".ShowWarning();
				txtsellTwoPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtsellThreeNum.EditValue.ToString()))
			{
				"卖3数量不能为空".ShowWarning();
				txtsellThreeNum.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtsellThreePrice.EditValue.ToString()))
			{
				"卖3价格不能为空".ShowWarning();
				txtsellThreePrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtsellFourNum.EditValue.ToString()))
			{
				"卖4数量不能为空".ShowWarning();
				txtsellFourNum.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtsellFourPrice.EditValue.ToString()))
			{
				"卖4价格不能为空".ShowWarning();
				txtsellFourPrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtsellFiveNum.EditValue.ToString()))
			{
				"卖5数量不能为空".ShowWarning();
				txtsellFiveNum.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtsellFivePrice.EditValue.ToString()))
			{
				"卖5价格不能为空".ShowWarning();
				txtsellFivePrice.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txttimeStr.EditValue.ToString()))
			{
				"时间不能为空".ShowWarning();
				txttimeStr.Focus();
				return false;
			}
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
				stockInfo info = (stockInfo)this.ControlDataToModel(new stockInfo());
				using (var db = new MESDB())
				{
					db.Entry(info).State = EntityState.Deleted;
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
			if (frm.ShowDialog() == DialogResult.OK)
			{
				string sql = frm.sql;
				using (var db = new MESDB())
				{
					if (string.IsNullOrEmpty(sql))
					{
						grdList.DataSource = db.stockInfo.SqlQuery("select * from stock").ToList();
					}
					else
					{
						grdList.DataSource = db.stockInfo.SqlQuery($"select * from stock where {sql}").ToList();
					}
				}
			}
		}
	}
}