using TirionWinfromFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysRole")]
    public partial class sysRoleInfo
    {
    ///ID
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///公司id
    [ModelBindControl("txtcompanyId")]
    public int companyId{set;get;}
    ///公司名称
    [ModelBindControl("txtcompanyName")]
    public string companyName{set;get;}
    ///角色名称
    [ModelBindControl("txtname")]
    public string name{set;get;}
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
    
    }
}