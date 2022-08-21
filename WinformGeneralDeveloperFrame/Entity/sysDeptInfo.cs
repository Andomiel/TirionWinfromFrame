using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysDept")]
    public partial class sysDeptInfo
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
    ///地址
    [ModelBindControl("txtaddress")]
    public string address{set;get;}
    ///电话
    [ModelBindControl("txtphone")]
    public string phone{set;get;}
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