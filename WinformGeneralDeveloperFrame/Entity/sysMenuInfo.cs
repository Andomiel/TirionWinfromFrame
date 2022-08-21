using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysMenu")]
    public partial class sysMenuInfo
    {
    ///ID
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///父id
    [ModelBindControl("txtpid")]
    public int pid{set;get;}
    ///菜单名称
    [ModelBindControl("txtname")]
    public string name{set;get;}
    ///图标
    [ModelBindControl("txticon")]
    public string icon{set;get;}
    ///菜单类型
    [ModelBindControl("txtwinformType")]
    public string winformType{set;get;}
    ///排序
    [ModelBindControl("txtsort")]
    public string sort{set;get;}
    ///有效
    [ModelBindControl("txtisEnabled")]
    public bool isEnabled{set;get;}
    ///功能按钮
    [ModelBindControl("txttoolList")]
    public string toolList{set;get;}
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
    ///是否界面
    [ModelBindControl("txtisForm")]
    public bool isForm{set;get;}
    ///是否功能按钮
    [ModelBindControl("txtisToolBtn")]
    public bool isToolBtn{set;get;}
    ///functionCode
    [ModelBindControl("txtfunctionCode")]
    public string functionCode{set;get;}
    
    }
}