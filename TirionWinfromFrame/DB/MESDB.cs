using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using MES.Entity;
using TirionWinfromFrame.Commons;

namespace MES
{
    public partial class MESDB : DbContext
    {
        public MESDB()
        : base("name=DB")
            //: base(EncodeHelper.AES_Decrypt(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
        {
        }
        public virtual DbSet<stockDataInfo> stockDataInfo { get; set; }
        public virtual DbSet<sysMenuInfo> sysMenuInfo { get; set; }
        public virtual DbSet<sysUserInfo> sysUserInfo { get; set; }
        public virtual DbSet<sysDictDataInfo> sysDictDataInfo { get; set; }
        public virtual DbSet<sysDictTypeInfo> sysDictTypeInfo { get; set; }
        public virtual DbSet<stockInfo> stockInfo { get; set; }
        public virtual DbSet<sysDeptInfo> sysDeptInfo { get; set; }
        public virtual DbSet<sysFunctionInfo> sysFunctionInfo { get; set; }
        public virtual DbSet<sysRoleInfo> sysRoleInfo { get; set; }
        public virtual DbSet<lotteryInfo> lotteryInfo { get; set; }
        public virtual DbSet<sysToolButtonInfo> sysToolButtonInfo { get; set; }

    }
}