using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("returnsale")]
    public partial class returnsaleInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///退货日期
    [ModelBindControl("txtreturndate")]
    public DateTime? returndate{set;get;}=DateTime.Now;
    ///客户编号
    [ModelBindControl("txtcustomercode")]
    public string customercode{set;get;}
    ///客户
    [ModelBindControl("txtcustomerid")]
    public int customerid{set;get;}
    ///客户类型
    [ModelBindControl("txtcustomertype")]
    public int customertype{set;get;}
    ///联系人
    [ModelBindControl("txtcontactuser")]
    public int contactuser{set;get;}
    ///联系电话
    [ModelBindControl("txtcontactphone")]
    public string contactphone{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///退货单号
    [ModelBindControl("txtreturnsalecode")]
    public string returnsalecode{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}