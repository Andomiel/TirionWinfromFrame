using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sale")]
    public partial class saleInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///销售单号
    [ModelBindControl("txtsaleordercode")]
    public string saleordercode{set;get;}
    ///订单日期
    [ModelBindControl("txtorderdate")]
    public DateTime orderdate{set;get;}=DateTime.Now;
    ///客户
    [ModelBindControl("txtcustomerid")]
    public int customerid{set;get;}
    ///客户编号
    [ModelBindControl("txtcustomercode")]
    public string customercode{set;get;}
    ///客户类型
    [ModelBindControl("txtcustomertype")]
    public int customertype{set;get;}
    ///客户单号
    [ModelBindControl("txtcustomerordercode")]
    public string customerordercode{set;get;}
    ///联系人
    [ModelBindControl("txtcontactuser")]
    public int contactuser{set;get;}
    ///联系电话
    [ModelBindControl("txtcontactphone")]
    public string contactphone{set;get;}
    ///送货地址
    [ModelBindControl("txtdeliveraddress")]
    public string deliveraddress{set;get;}
    ///业务员
    [ModelBindControl("txtsalesman")]
    public int salesman{set;get;}
    ///完货日期
    [ModelBindControl("txtfinishdate")]
    public DateTime finishdate{set;get;}=DateTime.Now;
    ///制单人
    [ModelBindControl("txtcreatorId")]
    public int creatorId { set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}