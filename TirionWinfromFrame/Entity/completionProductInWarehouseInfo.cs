using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("completionProductInWarehouse")]
    public partial class completionProductInWarehouseInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///入库日期
    [ModelBindControl("txtintime")]
    public DateTime intime{set;get;}=DateTime.Now;
    ///入库单位
    [ModelBindControl("txtdept")]
    public int dept{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///制单时间
    [ModelBindControl("txtcreateTime")]
    public DateTime createTime{set;get;}=DateTime.Now;
    ///入库单号
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    
    }
}