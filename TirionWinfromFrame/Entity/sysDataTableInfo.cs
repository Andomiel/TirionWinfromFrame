using WinformGeneralDeveloperFrame.Commons;
namespace MES.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysDataTable")]
    public partial class sysDataTableInfo
    {
    [Key]
    [ModelBindControl("txtDataTableName")]
    public string DataTableName{set;get;}
    [ModelBindControl("txtDataTableSql")]
    public string DataTableSql{set;get;}
    [ModelBindControl("txtDataTableUrl")]
    public string DataTableUrl{set;get;}
    
    }
}