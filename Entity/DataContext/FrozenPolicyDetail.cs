using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataContext
{
    public class FrozenPolicyDetail
    {
        public FrozenPolicyDetail()
        { }

        public FrozenPolicyDetail(string frozenNo)
        {
            FrozenNo = frozenNo;
        }

        public FrozenPolicyDetail(string frozenNo, string upn)
        {
            FrozenNo = frozenNo;
            FieldName = "UPN";
            FieldDes = "UPN";
            Operator = (int)PolicyOperator.Eq;
            FieldValue = upn;
        }

        public int Id { get; set; }
        /// <summary>
        /// 冻结单号
        /// </summary>
        public string FrozenNo { get; set; }
        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { get; set; } = string.Empty;
        /// <summary>
        /// 字段描述
        /// </summary>
        public string FieldDes { get; set; } = string.Empty;
        /// <summary>
        /// 运算符
        /// </summary>
        public int Operator { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string FieldValue { get; set; }
    }
}
