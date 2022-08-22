
using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("buyerreturn")]
    public partial class buyerreturnInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///退货日期
    [ModelBindControl("txtreturndate")]
    public DateTime returndate{set;get;}=DateTime.Now;
    ///供应商编号
    [ModelBindControl("txtsuppliercode")]
    public string suppliercode{set;get;}
    ///供应商名称
    [ModelBindControl("txtsupplierid")]
    public int supplierid{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///采购退货单号
    [ModelBindControl("txtreturnbuyercode")]
    public string returnbuyercode{set;get;}
    ///金额
    [ModelBindControl("txttotalprice")]
    public decimal totalprice{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}