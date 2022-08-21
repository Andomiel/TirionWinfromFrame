using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("requisitiondetail")]
    public partial class requisitiondetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///请购单主表
    [ModelBindControl("txtrequisitionid")]
    public int requisitionid{set;get;}
    ///请购单号
    [ModelBindControl("txtrequisitioncode")]
    public string requisitioncode{set;get;}
    ///物料名称
    [ModelBindControl("txtmaterialid")]
    public int materialid{set;get;}
    ///物料编码
    [ModelBindControl("txtmaterialcode")]
    public string materialcode{set;get;}
    ///规格型号
    [ModelBindControl("txtmaterialspec")]
    public string materialspec{set;get;}
    ///计量单位
    [ModelBindControl("txtmaterialunit")]
    public int materialunit{set;get;}
    ///请购数量
    [ModelBindControl("txtrequisitionnumber")]
    public decimal requisitionnumber{set;get;}
    ///单价
    [ModelBindControl("txtunitprice")]
    public decimal unitprice{set;get;}
    ///金额
    [ModelBindControl("txtmoney")]
    public decimal money{set;get;}
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    ///明细号
    [ModelBindControl("txtrequisitiondetailcode")]
    public string requisitiondetailcode { set; get; }
    }
}