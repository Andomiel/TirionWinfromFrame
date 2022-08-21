using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quotationdetail")]
    public partial class quotationdetailInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///产品名称
    [ModelBindControl("txtproductid")]

    public int productid{set;get;}

    public string productname { set; get; }
        ///规格型号
    [ModelBindControl("txtspec")]
    public string spec{set;get;}
    ///报价数量
    [ModelBindControl("txtnumber")]
    public decimal number{set;get;}
    ///计量单位
    [ModelBindControl("txtunit")]
    public int unit{set;get;}
    ///单价
    [ModelBindControl("txtunitprice")]
    public decimal unitprice{set;get;}
    ///金额
    [ModelBindControl("txtmoney")]
    public decimal money{set;get;}
    ///仓库
    [ModelBindControl("txtstockid")]
    public int stockid{set;get;}
    ///产品编号
    [ModelBindControl("txtproductcode")]
    public string productcode{set;get;}
    ///报价单号
    [ModelBindControl("txtquotationcode")]
    public string quotationcode{set;get;}
    ///报价单
    [ModelBindControl("txtquotationid")]
    public int quotationid{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    ///明细号
    [ModelBindControl("txtquotationdetailcode")]
    public string quotationdetailcode { set; get; }
    }
    
}