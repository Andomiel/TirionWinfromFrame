using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("requisition")]
    public partial class requisitionInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///请购单编号
    [ModelBindControl("txtrequisitioncode")]
    public string requisitioncode{set;get;}
    ///请购部门
    [ModelBindControl("txtdeptid")]
    public int deptid{set;get;}
    ///请购日期
    [ModelBindControl("txtrequisitiondate")]
    public DateTime requisitiondate{set;get;}=DateTime.Now;
    ///交货日期
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
    public decimal remark{set;get;}
    
    }
}