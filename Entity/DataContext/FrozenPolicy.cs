using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataContext
{
    public class FrozenPolicy
    {
        public FrozenPolicy() { }

        public FrozenPolicy(DateTime now, PolicyTypeEnum type, string remark)
        {
            Remark = remark;
            CreateTime = now;
            UpdateTime = now;
            Enable = true;
            PolicyType = (int)type;
        }

        public int Id { get; set; }
        /// <summary>
        /// 冻结单号
        /// </summary>
        public string FrozenNo { get; set; } = $"DJ{DateTime.Now:yyyyMMddHHmmss}";
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; } = string.Empty;
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string UpdateUser { get; set; } = string.Empty;
        /// <summary>
        /// 启用标记
        /// </summary>
        public bool Enable { get; set; } = true;
        /// <summary>
        /// 附件路径
        /// </summary>
        public string FileSrc { get; set; } = string.Empty;
        /// <summary>
        /// 禁用备注
        /// </summary>
        public string Remark { get; set; } = string.Empty;
        /// <summary>
        /// 策略类型
        /// </summary>
        public int PolicyType { get; set; } = 0;
        /// <summary>
        /// 查询条件Json
        /// </summary>
        public string ConditionJson { get; set; } = string.Empty;
    }
}
