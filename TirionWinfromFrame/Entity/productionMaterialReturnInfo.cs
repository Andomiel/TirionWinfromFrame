using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productionMaterialReturn")]
    public partial class productionMaterialReturnInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///退料单号
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    ///退料日期
    [ModelBindControl("txtreturntime")]
    public DateTime returntime{set;get;}=DateTime.Now;
    ///退料单位
    [ModelBindControl("txtreturndept")]
    public int returndept{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///制单日期
    [ModelBindControl("txtcreateTime")]
    public DateTime createTime{set;get;}=DateTime.Now;
    
    }
}