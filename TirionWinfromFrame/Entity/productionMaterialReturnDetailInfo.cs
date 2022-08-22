using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("productionMaterialReturnDetail")]
    public partial class productionMaterialReturnDetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///主表id
    [ModelBindControl("txtmasterid")]
    public int masterid{set;get;}
    ///退料单号
    [ModelBindControl("txtmastercode")]
    public string mastercode{set;get;}
    ///退料明细单号
    [ModelBindControl("txtdetailcode")]
    public string detailcode{set;get;}
    ///领料单号
    [ModelBindControl("txtpickcode")]
    public string pickcode{set;get;}

    ///领料明细单号
    [ModelBindControl("txtpickdetailcode")]
    public string pickdetailcode { set; get; }
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
    ///退料原因
    [ModelBindControl("txtreason")]
    public string reason{set;get;}
    ///退料数量
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