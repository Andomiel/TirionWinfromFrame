using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stockData")]
    public partial class stockDataInfo
    {
    ///代码
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    ///名称
    [ModelBindControl("txtname")]
    public string name{set;get;}
    ///今日开盘价
    [ModelBindControl("txtstartPrice")]
    public decimal startPrice{set;get;}
    ///昨日收盘价
    [ModelBindControl("txtolePrice")]
    public decimal olePrice{set;get;}
    ///当前价格
    [ModelBindControl("txtnowPrice")]
    public decimal nowPrice{set;get;}
    ///今日最高价
    [ModelBindControl("txtmaxPrice")]
    public decimal maxPrice{set;get;}
    ///今日最低价
    [ModelBindControl("txtminPrice")]
    public decimal minPrice{set;get;}
    ///竞买价
    [ModelBindControl("txtbidderPrice")]
    public decimal bidderPrice{set;get;}
    ///竞卖价
    [ModelBindControl("txtauctionPrice")]
    public decimal auctionPrice{set;get;}
    ///成交股票数
    [ModelBindControl("txtturnover")]
    public int turnover{set;get;}
    ///成交金额
    [ModelBindControl("txtturnoverPrice")]
    public decimal turnoverPrice{set;get;}
    ///买1数量
    [ModelBindControl("txtbuyOneNum")]
    public int buyOneNum{set;get;}
    ///买1价格
    [ModelBindControl("txtbuyOnePrice")]
    public decimal buyOnePrice{set;get;}
    ///买2数量
    [ModelBindControl("txtbuyTwoNum")]
    public int buyTwoNum{set;get;}
    ///买2价格
    [ModelBindControl("txtbuyTwoPrice")]
    public decimal buyTwoPrice{set;get;}
    ///买3数量
    [ModelBindControl("txtbuyThreeNum")]
    public int buyThreeNum{set;get;}
    ///买3价格
    [ModelBindControl("txtbuyThreePrice")]
    public decimal buyThreePrice{set;get;}
    ///买4数量
    [ModelBindControl("txtbuyFourNum")]
    public int buyFourNum{set;get;}
    ///买4价格
    [ModelBindControl("txtbuyFourPrice")]
    public decimal buyFourPrice{set;get;}
    ///买5数量
    [ModelBindControl("txtbuyFiveNum")]
    public int buyFiveNum{set;get;}
    ///买5价格
    [ModelBindControl("txtbuyFivePrice")]
    public decimal buyFivePrice{set;get;}
    ///卖1数量
    [ModelBindControl("txtsellOneNum")]
    public int sellOneNum{set;get;}
    ///卖1价格
    [ModelBindControl("txtsellOnePrice")]
    public decimal sellOnePrice{set;get;}
    ///卖2数量
    [ModelBindControl("txtsellTwoNum")]
    public int sellTwoNum{set;get;}
    ///卖2价格
    [ModelBindControl("txtsellTwoPrice")]
    public decimal sellTwoPrice{set;get;}
    ///卖3数量
    [ModelBindControl("txtsellThreeNum")]
    public int sellThreeNum{set;get;}
    ///卖3价格
    [ModelBindControl("txtsellThreePrice")]
    public decimal sellThreePrice{set;get;}
    ///卖4数量
    [ModelBindControl("txtsellFourNum")]
    public int sellFourNum{set;get;}
    ///卖4价格
    [ModelBindControl("txtsellFourPrice")]
    public decimal sellFourPrice{set;get;}
    ///卖5数量
    [ModelBindControl("txtsellFiveNum")]
    public int sellFiveNum{set;get;}
    ///卖5价格
    [ModelBindControl("txtsellFivePrice")]
    public decimal sellFivePrice{set;get;}
    ///时间
    [ModelBindControl("txttimeStr")]
    public DateTime timeStr{set;get;}=DateTime.Now;
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    
    }
}