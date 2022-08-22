using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quotation")]
    public partial class quotationInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///客户
    [ModelBindControl("txtcustomerid")]
    public int customerid{set;get;}
    ///报价日期
    [ModelBindControl("txtquotationdate")]
    public DateTime quotationdate{set;get;}=DateTime.Now;
    ///客户编码
    [ModelBindControl("txtcustomercode")]
    public string customercode{set;get;}
    ///客户类型
    [ModelBindControl("txtcustomertype")]
    public int customertype{set;get;}
    ///联系人
    [ModelBindControl("txtcustomeruser")]
    public int customeruser{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///送货地址
    [ModelBindControl("txtdeliveraddress")]
    public string deliveraddress{set;get;}
    ///报价单号
    [ModelBindControl("txtquotationcode")]
    public string quotationcode{set;get;}
    ///remark
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    ///总价
    [ModelBindControl("txttotalprice")]
    public decimal totalprice { set; get; }
    }
}