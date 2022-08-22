using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("workorder")]
    public partial class workorderInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///工单号
    [ModelBindControl("txtwordordercode")]
    public string wordordercode{set;get;}
    ///销售单号
    [ModelBindControl("txtsalecode")]
    public string salecode{set;get;}
    ///销售明细单号
    [ModelBindControl("txtsaledetailcode")]
    public string saledetailcode{set;get;}
    ///工单类型
    [ModelBindControl("txtworkordertype")]
    public int workordertype{set;get;}
    ///生产日期
    [ModelBindControl("txtproductdate")]
    public DateTime productdate{set;get;}=DateTime.Now;
    ///生产单位
    [ModelBindControl("txtproductdept")]
    public int productdept{set;get;}
    ///产品编号
    [ModelBindControl("txtproductcode")]
    public string productcode{set;get;}
    ///产品名称
    [ModelBindControl("txtproductid")]
    public int productid{set;get;}
    ///规格型号
    [ModelBindControl("txtspec")]
    public string spec{set;get;}
    ///生产数量
    [ModelBindControl("txtproductnumber")]
    public decimal productnumber{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///完工日期
    [ModelBindControl("txtfinishdate")]
    public DateTime finishdate{set;get;}=DateTime.Now;
    ///交货日期
    [ModelBindControl("txtdeliverdate")]
    public DateTime deliverdate{set;get;}=DateTime.Now;
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///制单日期
    [ModelBindControl("txtcreateTime")]
    public DateTime createTime{set;get;}=DateTime.Now;
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}

    ///BOM
    [ModelBindControl("txtbomid")]
    public int bomid { set; get; }

    }
}