using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("returnsaledetail")]
    public partial class returnsaledetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///退货单主表
    [ModelBindControl("txtreturnsaleid")]
    public int returnsaleid{set;get;}
    ///退货单号
    [ModelBindControl("txtreturnsalecode")]
    public string returnsalecode{set;get;}
    ///出货单号
    [ModelBindControl("txtdeliversalecode")]
    public string deliversalecode{set;get;}
    ///销售单号
    [ModelBindControl("txtsalecode")]
    public string salecode{set;get;}
    ///产品编号
    [ModelBindControl("txtproductcode")]
    public string productcode{set;get;}
    ///产品名称
    [ModelBindControl("txtproductname")]
    public string productname{set;get;}
    ///规格型号
    [ModelBindControl("txtproductspec")]
    public string productspec{set;get;}
    ///仓库
    [ModelBindControl("txtwarehouse")]
    public int warehouse{set;get;}
    ///退货数量
    [ModelBindControl("txtreturnnumber")]
    public decimal returnnumber{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    ///明细号
    [ModelBindControl("txtreturnsaledetailcode")]
    public string returnsaledetailcode { set; get; }
    }
}