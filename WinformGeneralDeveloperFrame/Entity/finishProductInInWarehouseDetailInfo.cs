using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("finishProductInInWarehouseDetail")]
    public partial class finishProductInInWarehouseDetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///主表id
    [ModelBindControl("txtmasterid")]
    public int masterid{set;get;}
    ///生产成品入库单号
    [ModelBindControl("txtmastercode")]
    public string mastercode{set;get;}
    ///完工成品入库单号
    [ModelBindControl("txtcompletionProductInWarehouseCode")]
    public string completionProductInWarehouseCode{set;get;}
    ///完工成品入库明细单号
    [ModelBindControl("txtcompletionProductInWarehouseDetailCode")]
    public string completionProductInWarehouseDetailCode{set;get;}
    ///生产成品入库明细单号
    [ModelBindControl("txtdetailcode")]
    public string detailcode{set;get;}
    ///工单号
    [ModelBindControl("txtwocode")]
    public string wocode{set;get;}
    ///销售单号
    [ModelBindControl("txtsalecode")]
    public string salecode{set;get;}
    ///销售明细单号
    [ModelBindControl("txtsaledetailcode")]
    public string saledetailcode{set;get;}
    ///产品
    [ModelBindControl("txtproductid")]
    public int productid{set;get;}
    ///产品编码
    [ModelBindControl("txtproductcode")]
    public string productcode{set;get;}
    ///规格型号
    [ModelBindControl("txtproductspec")]
    public string productspec{set;get;}
    ///入库数量
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