using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("material")]
    public partial class materialInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///物料名称
    [ModelBindControl("txtname")]
    public string name{set;get;}
    ///物料编码
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    ///规格型号
    [ModelBindControl("txtspec")]
    public string spec{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///参考单价
    [ModelBindControl("txtreferprice")]
    public decimal referprice{set;get;}
    ///物料类别
    [ModelBindControl("txtmaterialtype")]
    public int materialtype{set;get;}
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///采购入库总量
    [ModelBindControl("txtPOinnumber")]
    public decimal POinnumber{set;get;}
    ///退货出库总量
    [ModelBindControl("txtsalereturnnumber")]
    public decimal salereturnnumber{set;get;}
    ///生产领料总量
    [ModelBindControl("txtYDProductConsume")]
    public decimal YDProductConsume{set;get;}
    ///生产退料总量
    [ModelBindControl("txtproductmaterialreturn")]
    public decimal productmaterialreturn{set;get;}
    ///库存数量
    [ModelBindControl("txtstocknumber")]
    public decimal stocknumber{set;get;}
    ///库存预警数量
    [ModelBindControl("txtstockwarnnumber")]
    public decimal stockwarnnumber{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}