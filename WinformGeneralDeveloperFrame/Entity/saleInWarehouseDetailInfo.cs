using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("saleInWarehouseDetail")]
    public partial class saleInWarehouseDetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}

    ///id
    [ModelBindControl("txtmasterid")]
    public int masterid { set; get; }
        ///销售出库单号
        [ModelBindControl("txtreturnsalecode")]
    public string returnsalecode{set;get;}
    ///销售出库明细单号
    [ModelBindControl("txtreturnsaledetailcode")]
    public string returnsaledetailcode{set;get;}
    ///销售退货入库单号
    [ModelBindControl("txtmastercode")]
    public string mastercode{set;get;}
    ///销售退货入库明细单号
    [ModelBindControl("txtdetailcode")]
    public string detailcode{set;get;}
    ///销售单号
    [ModelBindControl("txtsalecode")]
    public string salecode{set;get;}
    ///销售明细单号
    [ModelBindControl("txtsaledetailcode")]
    public string saledetailcode{set;get;}
    ///产品
    [ModelBindControl("txtproductID")]
    public int productID{set;get;}
    ///产品编号
    [ModelBindControl("txtproductcode")]
    public string productcode{set;get;}
    ///规格型号
    [ModelBindControl("txtspec")]
    public string spec{set;get;}
    ///入库数量
    [ModelBindControl("txtnumber")]
    public decimal number{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///warehouse
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}