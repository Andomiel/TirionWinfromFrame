using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("buyerInWarehouseDetail")]
    public partial class buyerInWarehouseDetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///主表id
    [ModelBindControl("txtmasterid")]
    public int masterid{set;get;}
    ///采购入库单号
    [ModelBindControl("txtmastercode")]
    public string mastercode{set;get;}
    ///采购入库明细单号
    [ModelBindControl("txtdetailcode")]
    public string detailcode{set;get;}
    ///采购明细单号
    [ModelBindControl("txtbuyerdetailcode")]
    public string buyerdetailcode{set;get;}
    ///采购单号
    [ModelBindControl("txtbuyercode")]
    public string buyercode{set;get;}
    ///物料
    [ModelBindControl("txtmaterialid")]
    public int materialid{set;get;}
    ///物料编号
    [ModelBindControl("txtmaterialcode")]
    public string materialcode{set;get;}
    ///规格型号
    [ModelBindControl("txtmaterialspec")]
    public string materialspec{set;get;}
    ///入库数量
    [ModelBindControl("txtnumber")]
    public decimal number{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///remark
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}