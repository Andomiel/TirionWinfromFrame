using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("deliversale")]
    public partial class deliversaleInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///客户
    [ModelBindControl("txtcustomerid")]
    public int customerid{set;get;}
    ///客户编号
    [ModelBindControl("txtcustomercode")]
    public string customercode{set;get;}
    ///出货日期
    [ModelBindControl("txtdeliverdate")]
    public DateTime? deliverdate{set;get;}=DateTime.Now;
    ///客户类型
    [ModelBindControl("txtcustomertype")]
    public int customertype{set;get;}
    ///联系人
    [ModelBindControl("txtcontactuser")]
    public int contactuser{set;get;}
    ///送货地址
    [ModelBindControl("txtdeliveraddress")]
    public string deliveraddress{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///出货单号
    [ModelBindControl("txtdeliversalecode")]
    public string deliversalecode{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}