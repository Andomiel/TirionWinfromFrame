using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("saleInWarehouse")]
    public partial class saleInWarehouseInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///入库日期
    [ModelBindControl("txtinTime")]
    public DateTime inTime{set;get;}=DateTime.Now;
    ///入库单位
    [ModelBindControl("txtdept")]
    public int dept{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///制单日期
    [ModelBindControl("txtcreateTime")]
    public DateTime createTime{set;get;}=DateTime.Now;
    ///入库单号
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    
    }
}