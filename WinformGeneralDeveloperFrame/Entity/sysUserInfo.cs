using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysUser")]
    public partial class sysUserInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///工号
    [ModelBindControl("txtaccount")]
    public string account{set;get;}
    ///用户名
    [ModelBindControl("txtusername")]
    public string username{set;get;}
    ///密码
    [ModelBindControl("txtpassword")]
    public string password{set;get;}
    ///邮件
    [ModelBindControl("txtemail")]
    public string email{set;get;}
    ///电话
    [ModelBindControl("txtmobilephone")]
    public string mobilephone{set;get;}
    ///部门
    [ModelBindControl("txtdeptId")]
    public int deptId{set;get;}
    ///有效
    [ModelBindControl("txtisEnabled")]
    public bool isEnabled{set;get;}
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