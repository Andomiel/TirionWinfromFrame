using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("supplier")]
    public partial class supplierInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///供应商名称
    [ModelBindControl("txtsuppliername")]
    public string suppliername{set;get;}
    ///厂商类型
    [ModelBindControl("txtmanufacturertype")]
    public int manufacturertype{set;get;}
    ///联系人
    [ModelBindControl("txtcontacts")]
    public int contacts{set;get;}
    ///供应商地址
    [ModelBindControl("txtaddress")]
    public string address{set;get;}
    ///增值税税率
    [ModelBindControl("txtvatrate")]
    public decimal vatrate{set;get;}
    ///纳税人识别号
    [ModelBindControl("txttaxpayeridentity")]
    public string taxpayeridentity{set;get;}
    ///对方收款账号
    [ModelBindControl("txtbankaccount")]
    public string bankaccount{set;get;}
    ///供应商编号
    [ModelBindControl("txtsuppliercode")]
    public string suppliercode{set;get;}
    ///应付款总额
    [ModelBindControl("txtpayments")]
    public decimal payments{set;get;}
    ///已结款总额
    [ModelBindControl("txttotalamountsettled")]
    public decimal totalamountsettled{set;get;}
    ///未结款总额
    [ModelBindControl("txttotaloutstandingamount")]
    public decimal totaloutstandingamount{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    ///创建人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///创建时间
    [ModelBindControl("txtcreateTime")]
    public DateTime? createTime{set;get;}=DateTime.Now;
    ///修改人
    [ModelBindControl("txteditorId")]
    public int editorId{set;get;}
    ///修改时间
    [ModelBindControl("txteditTime")]
    public DateTime? editTime{set;get;}=DateTime.Now;
    
    }
}