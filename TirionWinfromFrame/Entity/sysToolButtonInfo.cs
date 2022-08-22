using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysToolButton")]
    public partial class sysToolButtonInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///名称
    [ModelBindControl("txtbtnName")]
    public string btnName{set;get;}
    ///编码
    [ModelBindControl("txtbtnCode")]
    public string btnCode{set;get;}
    ///图标
    [ModelBindControl("txtbtnIcon")]
    public string btnIcon{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    
    }
}