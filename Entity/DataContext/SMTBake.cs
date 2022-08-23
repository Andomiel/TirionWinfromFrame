namespace Entity.DataContext
{
    public class SMTBake
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 物料唯一码
        /// </summary>
        public string Upn { get; set; }

        /// <summary>
        /// MSD等级
        /// </summary>
        public string MsdLevel { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
    }
}
