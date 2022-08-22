using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productMaterialInWarehouse")]
    public partial class productMaterialInWarehouseInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///入库单号
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    ///入库日期
    [ModelBindControl("txtintime")]
    public DateTime intime{set;get;}=DateTime.Now;
    ///退料单位
    [ModelBindControl("txtdept")]
    public int dept{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}