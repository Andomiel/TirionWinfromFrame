using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productionRequisition")]
    public partial class productionRequisitionInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///领料单号
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    ///工单号
    [ModelBindControl("txtwocode")]
    public string wocode{set;get;}
    ///销售单号
    [ModelBindControl("txtsalecode")]
    public string salecode{set;get;}
    ///领料日期
    [ModelBindControl("txtpickingtime")]
    public DateTime pickingtime{set;get;}=DateTime.Now;
    ///产品
    [ModelBindControl("txtproductID")]
    public int productID{set;get;}
    ///产品编号
    [ModelBindControl("txtproductcode")]
    public string productcode{set;get;}
    ///规格型号
    [ModelBindControl("txtproductspec")]
    public string productspec{set;get;}
    ///生产数量
    [ModelBindControl("txtnumber")]
    public decimal number{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///领料部门
    [ModelBindControl("txtpickingdept")]
    public int pickingdept{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///制单日期
    [ModelBindControl("txtcreateTime")]
    public DateTime createTime{set;get;}=DateTime.Now;
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}