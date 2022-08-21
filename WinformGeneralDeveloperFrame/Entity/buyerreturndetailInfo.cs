using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("buyerreturndetail")]
    public partial class buyerreturndetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///采购明细单号
    [ModelBindControl("txtbuyerdetailcode")]
    public string buyerdetailcode{set;get;}
    ///采购单号
    [ModelBindControl("txtbuyercode")]
    public string buyercode{set;get;}
    ///物料编码
    [ModelBindControl("txtmaterialcode")]
    public string materialcode{set;get;}
    ///物料名称
    [ModelBindControl("txtmaterialid")]
    public int materialid{set;get;}
    ///规格型号
    [ModelBindControl("txtmaterialspec")]
    public string materialspec{set;get;}
    ///退货数量
    [ModelBindControl("txtreturnnumber")]
    public decimal returnnumber{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///采购单价
    [ModelBindControl("txtunitprice")]
    public decimal unitprice{set;get;}
    ///金额
    [ModelBindControl("txtmoney")]
    public decimal money{set;get;}
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///退货单号
    [ModelBindControl("txtreturnbuyercode")]
    public string returnbuyercode{set;get;}
    ///退货明细单号
    [ModelBindControl("txtreturnbuyerdetailcode")]
    public string returnbuyerdetailcode{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    public int buyerreturnid { set; get; }
    }
}