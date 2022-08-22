using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productionBOM")]
    public partial class productionBOMInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///工程BOM编号
    [ModelBindControl("txtprojectBOMcode")]
    public string projectBOMcode{set;get;}
    ///生产BOM编号
    [ModelBindControl("txtproductionBOMcode")]
    public string productionBOMcode{set;get;}
    ///产品生产数量
    [ModelBindControl("txtnumber")]
    public decimal number{set;get;}
    ///物料编码
    [ModelBindControl("txtmaterialcode")]
    public string materialcode{set;get;}
    ///物料名称
    [ModelBindControl("txtmaterialid")]
    public int materialid{set;get;}
    ///规格型号
    [ModelBindControl("txtspec")]
    public string spec{set;get;}
    ///物料类型
    [ModelBindControl("txtmaterialtype")]
    public int materialtype{set;get;}
    ///单位用量
    [ModelBindControl("txtuintnumber")]
    public decimal uintnumber{set;get;}
    ///需求总量
    [ModelBindControl("txtneednumber")]
    public decimal neednumber{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///单价
    [ModelBindControl("txtunitprice")]
    public decimal unitprice{set;get;}
    ///总价
    [ModelBindControl("txttotalprice")]
    public decimal totalprice{set;get;}
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}