using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customerInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///客户名称phonenumber
    [ModelBindControl("txtcustomername")] 
    public string customername{set;get;}
    ///客户类别
    [ModelBindControl("txtcustomertype")]
    public int customertype{set;get;}
    ///联系人
    [ModelBindControl("txtcontactuser")]
    public int contactuser{set;get;}
    ///客户地址
    [ModelBindControl("txtaddress")]

    public string address{set;get;}
    ///电话phonenumber
    [ModelBindControl("txtphonenumber")]
    public string phonenumber { set; get; }
        ///期初应收款
        [ModelBindControl("txtstartreceipt")]
    public decimal startreceipt{set;get;}
    ///客户编号
    [ModelBindControl("txtcustomercode")]
    public string customercode{set;get;}
    ///应收款总额
    [ModelBindControl("txttotalreceivables")]
    public decimal totalreceivables{set;get;}
    ///已结款总额
    [ModelBindControl("txttotalamountsettled")]
    public decimal totalamountsettled{set;get;}
    ///未结款总额
    [ModelBindControl("txttotaloutstandingamount")]
    public decimal totaloutstandingamount{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}