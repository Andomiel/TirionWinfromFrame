using WinformGeneralDeveloperFrame.Commons;

namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysDictData")]
    public partial class sysDictDataInfo
    {
    ///id
    [ModelBindControl("txtid")]
    public int id{set;get;}
    ///类型
    [ModelBindControl("txtdictTypeID")]
    public int dictTypeID{set;get;}
    ///编码
    [ModelBindControl("txtcode")]
    public string code{set;get;}
    ///值
    [ModelBindControl("txtvalue")]
    public string value{set;get;}
    ///备注
    [ModelBindControl("txtremark")]
    public string remark{set;get;}
    ///排序
    [ModelBindControl("txtsort")]
    public string sort{set;get;}
    ///创建人
    [ModelBindControl("txtcreatorId")]
    public int creatorId{set;get;}
    ///创建时间
    [ModelBindControl("txtcreateTime")]
    public DateTime? createTime{set;get;}=DateTime.Now;
    ///编辑人
    [ModelBindControl("txteditorId")]
    public int editorId{set;get;}
    ///editTime
    [ModelBindControl("txteditTime")]
    public DateTime? editTime{set;get;}=DateTime.Now;
    
    }
}