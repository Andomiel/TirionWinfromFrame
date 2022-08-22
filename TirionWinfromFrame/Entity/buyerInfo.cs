using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("buyer")]
    public partial class buyerInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///采购单号
    [ModelBindControl("txtbuyercode")]
    public string buyercode{set;get;}
    ///采购日期
    [ModelBindControl("txtbuyerdate")]
    public DateTime buyerdate{set;get;}=DateTime.Now;
    ///供应商
    [ModelBindControl("txtsupplierid")]
    public int supplierid{set;get;}
    ///供应商编码
    [ModelBindControl("txtsuppliercode")]
    public string suppliercode{set;get;}
    ///完货日期
    [ModelBindControl("txtdeliverdate")]
    public DateTime deliverdate{set;get;}=DateTime.Now;
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///金额
    [ModelBindControl("txttotalprice")]
    public decimal totalprice{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}