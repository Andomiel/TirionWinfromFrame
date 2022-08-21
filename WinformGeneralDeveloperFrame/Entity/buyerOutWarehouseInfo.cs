using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("buyerOutWarehouse")]
    public partial class buyerOutWarehouseInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///采购退货出库单号
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    ///出库日期
    [ModelBindControl("txtouttime")]
    public DateTime outtime{set;get;}=DateTime.Now;
    ///供应商
    [ModelBindControl("txtsupplierid")]
    public int supplierid{set;get;}
    ///供应商编码
    [ModelBindControl("txtsuppliercode")]
    public string suppliercode{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}