using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class productInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///产品名称
    [ModelBindControl("txtproductname")]
    public string productname{set;get;}
    ///规格
    [ModelBindControl("txtspec")]
    public string spec{set;get;}
    ///默认单价
    [ModelBindControl("txtdefaultprice")]
    public decimal defaultprice{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit {set;get;}
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///产品类别
    [ModelBindControl("txtproducttype")]
    public int producttype {set;get;}
    ///产品编号
    [ModelBindControl("txtproductcode")]
    public string productcode{set;get;}
    ///库存
    [ModelBindControl("txtstocknumber")]
    public decimal stocknumber
    {
        // ReSharper disable once ArrangeAccessorOwnerBody
        set {  }
        get {return  productinnumber + customerreturnnumber - saleoutnumber; }
    }
    ///期初数量
    [ModelBindControl("txtstartnumber")]
    public decimal startnumber{set;get;}
    ///期初总价
    [ModelBindControl("txtstartprice")]
    public decimal startprice{set;get;}
    ///生产入库数量
    [ModelBindControl("txtproductinnumber")]
    public decimal productinnumber{set;get;}
    ///销售出库数量
    [ModelBindControl("txtsaleoutnumber")]
    public decimal saleoutnumber{set;get;}
    ///客户退货数量
    [ModelBindControl("txtcustomerreturnnumber")]
    public decimal customerreturnnumber{set;get;}
    ///库存预警数量
    [ModelBindControl("txtstockwarnnumber")]
    public decimal stockwarnnumber{set;get;}
    ///创建人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///创建时间
    [ModelBindControl("txtcreateTime")]
    public DateTime? createTime{set;get;}=DateTime.Now;
    ///编辑人
    [ModelBindControl("txteditorId")]
    public int editorId{set;get;}
    ///编辑时间
    [ModelBindControl("txteditTime")]
    public DateTime? editTime{set;get;}=DateTime.Now;
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}