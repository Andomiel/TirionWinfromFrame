using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock")]
    public partial class stockInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///仓库名称
    [ModelBindControl("txtname")]
    public string name{set;get;}
    ///仓库地址
    [ModelBindControl("txtaddress")]
    public string address{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}