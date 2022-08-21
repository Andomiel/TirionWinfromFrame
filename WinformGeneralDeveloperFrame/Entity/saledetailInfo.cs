using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("saledetail")]
    public partial class saledetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///产品
    [ModelBindControl("txtproductid")]
    public int productid{set;get;}
    ///规格型号
    [ModelBindControl("txtproductspec")]
    public string productspec{set;get;}
    ///数量
    [ModelBindControl("txtsalenumber")]
    public decimal salenumber{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///单价
    [ModelBindControl("txtunitprice")]
    public decimal unitprice{set;get;}
    ///金额
    [ModelBindControl("txtmoney")]
    public decimal money{set;get;}
    ///交货日期
    [ModelBindControl("txtdeliverdate")]
    public DateTime deliverdate{set;get;}=DateTime.Now;
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///已排产量
    [ModelBindControl("txtreadynumber")]
    public decimal readynumber{set;get;}
    ///待排产量
    [ModelBindControl("txtnoreadynumber")]
    public decimal noreadynumber{set;get;}
    ///已完工量
    [ModelBindControl("txtfinishnumber")]
    public decimal finishnumber{set;get;}
    ///已出货量
    [ModelBindControl("txtoutnumber")]
    public decimal outnumber{set;get;}
    ///退货量
    [ModelBindControl("txtreturnnumber")]
    public decimal returnnumber{set;get;}
    ///未交货数量
    [ModelBindControl("txtnodelivernumber")]
    public decimal nodelivernumber{set;get;}
    ///实际交货数量
    [ModelBindControl("txtdelivernumber")]
    public decimal delivernumber{set;get;}
    ///已结算数量
    [ModelBindControl("txtclosenumber")]
    public decimal closenumber{set;get;}
    ///未结算数量
    [ModelBindControl("txtnoclosenumber")]
    public decimal noclosenumber{set;get;}
    ///物料成本
    [ModelBindControl("txtmaterialcost")]
    public decimal materialcost{set;get;}
    ///实际物料成本
    [ModelBindControl("txtrealmaterialcost")]
    public decimal realmaterialcost{set;get;}
    ///产品编号
    [ModelBindControl("txtproductcode")]
    public string productcode{set;get;}
    ///销售主表
    [ModelBindControl("txtsaleid")]
    public int saleid{set;get;}
    ///销售单号
    [ModelBindControl("txtsalecode")]
    public string salecode{set;get;}
    
    ///明细号
    [ModelBindControl("txtsaledetailcode")]
    public string saledetailcode { set; get; }
    }
}