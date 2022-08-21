using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using MES.Entity;
using WinformGeneralDeveloperFrame.Commons;

//using MES.Entity;

namespace WinformGeneralDeveloperFrame
{
    public partial class DB : DbContext
    {
        public DB()
            :base("DB")
            //: base(EncodeHelper.AES_Decrypt(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
        {
        }

        public virtual DbSet<sysDataBase> sysDataBase { get; set; }
        public virtual DbSet<sysDataTableInfo> sysDataTableInfo { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<sysDataBase>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sysDataBase>()
                .Property(e => e.serverip)
                .IsUnicode(false);

            modelBuilder.Entity<sysDataBase>()
                .Property(e => e.databasename)
                .IsUnicode(false);

            modelBuilder.Entity<sysDataBase>()
                .Property(e => e.connecturl)
                .IsUnicode(false);

            modelBuilder.Entity<sysDataBase>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<sysDataBase>()
                .Property(e => e.passsword)
                .IsUnicode(false);
        }
    }
}
