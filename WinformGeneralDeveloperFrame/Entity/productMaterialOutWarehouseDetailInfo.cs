using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productMaterialOutWarehouseDetail")]
    public partial class productMaterialOutWarehouseDetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///主表id
    [ModelBindControl("txtmasterid")]
    public int masterid{set;get;}
    ///生产领料出库单号
    [ModelBindControl("txtmastercode")]
    public string mastercode{set;get;}
    ///生产领料出库明细单号
    [ModelBindControl("txtdetailcode")]
    public string detailcode{set;get;}
    ///生产领料单号
    [ModelBindControl("txtpickcode")]
    public string pickcode{set;get;}
    ///生产领料明细单号
    [ModelBindControl("txtpickdetailcode")]
    public string pickdetailcode{set;get;}
    ///工单号
    [ModelBindControl("txtwocode")]
    public string wocode{set;get;}
    ///物料
    [ModelBindControl("txtmaterialid")]
    public int materialid{set;get;}
    ///物料编码
    [ModelBindControl("txtmaterialcode")]
    public string materialcode{set;get;}
    ///规格型号
    [ModelBindControl("txtmaterialspec")]
    public string materialspec{set;get;}
    ///物料类型
    [ModelBindControl("txtmaterialtype")]
    public int materialtype{set;get;}
    ///出库数量
    [ModelBindControl("txtnumber")]
    public decimal number{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}