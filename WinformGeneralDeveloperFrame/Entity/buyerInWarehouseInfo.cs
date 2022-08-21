using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("buyerInWarehouse")]
    public partial class buyerInWarehouseInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///入库单号
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///供应商
    [ModelBindControl("txtsupplierid")]
    public int supplierid{set;get;}
    ///供应商编码
    [ModelBindControl("txtsuppliercode")]
    public string suppliercode{set;get;}
    ///入库日期
    [ModelBindControl("txtintime")]
    public DateTime intime{set;get;}=DateTime.Now;
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}