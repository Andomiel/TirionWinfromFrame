using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productBOM")]
    public partial class productBOMInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///客户
    [ModelBindControl("txtcustomerid")]
    public int customerid{set;get;}
    ///客户编码
    [ModelBindControl("txtcustomercode")]
    public string customercode{set;get;}
    ///产品编号
    [ModelBindControl("txtproductcode")]
    public string productcode{set;get;}
    ///产品
    [ModelBindControl("txtproductid")]
    public int productid{set;get;}
    ///规格型号
    [ModelBindControl("txtspec")]
    public string spec{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///版本号
    [ModelBindControl("txtversion")]
    public string version{set;get;}
    ///BOM编号
    [ModelBindControl("txtproductBOMcode")]
    public string productBOMcode{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}

    /// <summary>
    /// 单位成本
    /// </summary>
    [ModelBindControl("txtunitcost")]
    public decimal unitcost { set; get; }

    ///创建人
    [ModelBindControl("txtcreatorId")]
    public int creatorId { set; get; }
    ///创建时间
    [ModelBindControl("txtcreateTime")]
    public DateTime createTime { set; get; } = DateTime.Now;
    ///编辑人
    [ModelBindControl("txteditorId")]
    public int editorId { set; get; }
    ///编辑时间
    [ModelBindControl("txteditTime")]
    public DateTime editTime { set; get; } = DateTime.Now;
    }
}