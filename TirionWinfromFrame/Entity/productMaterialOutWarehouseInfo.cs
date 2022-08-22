using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productMaterialOutWarehouse")]
    public partial class productMaterialOutWarehouseInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///生产领料出库单号
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    ///领料单位
    [ModelBindControl("txtdept")]
    public int dept{set;get;}
    ///出库日期
    [ModelBindControl("txtouttime")]
    public DateTime outtime{set;get;}=DateTime.Now;
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}