using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productBOMdetail")]
    public partial class productBOMdetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///父项
    [ModelBindControl("txtpid")]
    public int pid{set;get;}
    ///BOM主表
    [ModelBindControl("txtproductBOMid")]
    public int productBOMid{set;get;}
    ///BOM编号
    [ModelBindControl("txtproductBOMcode")]
    public string productBOMcode{set;get;}
    ///产品编号
    [ModelBindControl("txtproductcode")]
    public string productcode{set;get;}
    ///物料id
    [ModelBindControl("txtmaterialid")]
    public int materialid{set;get;}
    ///物料名称
    [ModelBindControl("txtmaterialname")]
    public string materialname{set;get;}
    ///物料编号
    [ModelBindControl("txtmaterialcode")]
    public string materialcode{set;get;}
    ///规格型号
    [ModelBindControl("txtmaterialspec")]
    public string materialspec{set;get;}
    ///物料类型
    [ModelBindControl("txtmaterialtype")]
    public int materialtype{set;get;}
    ///单位用量
    [ModelBindControl("txtunitusenumber")]
    public decimal unitusenumber{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///单价
    [ModelBindControl("txtunitprice")]
    public decimal unitprice{set;get;}
    ///金额
    [ModelBindControl("txtmoney")]
    public decimal money{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    ///明细号
    [ModelBindControl("txtproductBOMdetailcode")]
    public string productBOMdetailcode { set; get; }
    }
}