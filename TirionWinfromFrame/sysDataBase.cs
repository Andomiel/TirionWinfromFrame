namespace TirionWinfromFrame
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sysDataBase")]
    public partial class sysDataBase
    {
        [Key]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string serverip { get; set; }

        [StringLength(50)]
        public string databasename { get; set; }

        [StringLength(200)]
        public string connecturl { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        [StringLength(50)]
        public string passsword { get; set; }
    }
}
