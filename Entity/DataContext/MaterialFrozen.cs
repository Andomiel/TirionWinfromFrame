using System;

namespace Entity.DataContext
{
    public class MaterialFrozen
    {
        public int Id { get; set; }

        public string UPN { get; set; }
        /// <summary>
        /// 冻结单号
        /// </summary>
        public string FrozenNo { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
