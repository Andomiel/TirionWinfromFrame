using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("saleOutWarehouse")]
    public partial class saleOutWarehouseInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///销售出库单号
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    ///出库日期
    [ModelBindControl("txtouttime")]
    public DateTime outtime{set;get;}=DateTime.Now;
    ///出库单位
    [ModelBindControl("txtdept")]
    public int dept{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///制单日期
    [ModelBindControl("txtcreateTime")]
    public DateTime createTime{set;get;}=DateTime.Now;
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}