using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Facade
{
    public class LightShelfRequest
    {
        public LightShelfRequest(int color = 3)
        {
            this.color = color;
        }

        /// <summary>
        /// 工单号
        /// 必传：否
        /// </summary>
        public string orderId { get; set; } = string.Empty;
        /// <summary>
        /// 发料类型0：read ID发料  1：PN+数量发料，默认0
        /// 必传：是
        /// </summary>
        public int issueType { get; set; } = 0;
        /// <summary>
        /// 发料颜色（3:蓝，4:黄，5:紫，6:青），默认为3
        /// 必传：是
        /// </summary>
        public int color { get; set; } = 3;
        /// <summary>
        /// 0撤销,1备料发料,2站位发料,3续料，默认为1
        /// 必传：是
        /// </summary>
        public int action { get; set; } = 1;

        public List<Material> data { get; set; } = new List<Material>();
        /// <summary>
        /// 发料的库位名称
        /// </summary>
        public string warehouseName { get; set; } = string.Empty;
        public string reserve { get; set; } = string.Empty;
    }

    public class Material
    {
        public Material(string reelId)
        {
            realID = reelId;
        }
        /// <summary>
        /// 物料唯一码(条码)
        /// 必传：否
        /// </summary>
        public string realID { get; set; } = string.Empty;
    }

    public class LightMaterial : Material
    {
        public LightMaterial(string reelId, string pn, int qty)
            : base(reelId)
        {
            partNum = pn;
            quantity = qty;
        }

        /// <summary>
        /// 物料PN
        /// 必传：否
        /// </summary>
        public string partNum { get; set; } = string.Empty;
        /// <summary>
        /// 物料需求数量
        /// 必传：否
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// 机台名称
        /// 必传：否
        /// </summary>
        public string machine { get; set; } = string.Empty;
        /// <summary>
        /// 站位信息
        /// 必传：否
        /// </summary>
        public string station { get; set; } = string.Empty;
    }

}
