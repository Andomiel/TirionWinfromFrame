using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("buyerdetail")]
    public partial class buyerdetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///主表
    [ModelBindControl("txtbuyerid")]
    public int buyerid{set;get;}
    ///采购单号
    [ModelBindControl("txtbuyercode")]
    public string buyercode{set;get;}
    ///请购单号
    [ModelBindControl("txtrequisitioncode")]
    public string requisitioncode{set;get;}
    ///物料
    [ModelBindControl("txtmaterialid")]
    public int materialid{set;get;}
    ///物料编码
    [ModelBindControl("txtmaterialcode")]
    public string materialcode{set;get;}
    ///规格型号
    [ModelBindControl("txtmaterialspec")]
    public string materialspec{set;get;}
    ///计量单位
    [ModelBindControl("txtmaterialunit")]
    public int materialunit{set;get;}
    ///请购数量
    [ModelBindControl("txtbuyernumber")]
    public decimal buyernumber{set;get;}
    ///单价
    [ModelBindControl("txtunitprice")]
    public decimal unitprice{set;get;}
    ///金额
    [ModelBindControl("txtmoney")]
    public decimal money{set;get;}
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///交货总量
    [ModelBindControl("txtdelivernumber")]
    public decimal delivernumber{set;get;}
    ///退货总量
    [ModelBindControl("txtreturnnumber")]
    public decimal returnnumber{set;get;}
    ///实际交货总量
    [ModelBindControl("txtrealdelivernumber")]
    public decimal realdelivernumber{set;get;}
    ///未交货数量
    [ModelBindControl("txtnodelivernumber")]
    public decimal nodelivernumber{set;get;}
    ///已结算数量
    [ModelBindControl("txtfinishnumber")]
    public decimal finishnumber{set;get;}
    ///未结算数量
    [ModelBindControl("txtnofinishnumber")]
    public decimal nofinishnumber{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    ///明细号
    [ModelBindControl("txtbuyerdetailcode")]
    public string buyerdetailcode { set; get; }


    }
}