using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysFunction")]
    public partial class sysFunctionInfo
    {
    ///ID
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///父ID
    [ModelBindControl("txtpid")]
    public int pid{set;get;}
    ///名称
    [ModelBindControl("txtname")]
    public string name{set;get;}
    ///权限编码
    [ModelBindControl("txtfunctionCode")]
    public string functionCode{set;get;}
    ///toolBtnID
    [ModelBindControl("txttoolBtnID")]
    public int toolBtnID{set;get;}
    
    }
}