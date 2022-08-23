
using System;

namespace Entity.DataContext
{
    /// <summary>
    /// IWMS 物料基本信息表，部分字段
    /// </summary>
    public class SMTZDMaterial
    {
        /// <summary>
        /// 唯一码
        /// </summary>
        public string ReelID { get; set; }

        /// <summary>
        /// 料号
        /// </summary>
        public string Part_Number { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public string DateCode { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public string Batch { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Qty { get; set; }

        /// <summary>
        /// 最小包装数
        /// </summary>
        public int MinPacking { get; set; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string InStockOrderNo { get; set; }

        /// <summary>
        /// 出库单号（未使用）
        /// </summary>
        public string OutStockOrderNo { get; set; }

        /// <summary>
        /// 出库单号（使用中）
        /// </summary>
        public string Work_Order_No { get; set; } = "";

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? SaveTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 料盘类型
        /// </summary>
        public string ReelType { get; set; }

        /// <summary>
        /// MSD
        /// </summary>
        public string MSD { get; set; }

        /// <summary>
        /// 是否过期
        /// </summary>
        public string MsdOverdue { get; set; }

        /// <summary>
        /// 是否锁定料，Y：锁定料
        /// </summary>
        public string Lock { get; set; }

        /// <summary>
        /// 储位，0：理料区
        /// </summary>
        public int LockTowerNo { get; set; }

        /// <summary>
        /// 料盘尺寸
        /// </summary>
        public string ReelSize { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        public string MatType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string op_type { get; set; } = "0";

        /// <summary>
        /// 
        /// </summary>
        public bool isSave { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public bool isTake { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public bool isTakeCheck { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public bool isTakeDelivery { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public string LockLocation { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        public int LightColor { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public string SerialNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string QRCode { get; set; } = "";

        /// <summary>
        /// 生产厂家
        /// </summary>
        public string WZ_SCCJ { get; set; } = "";

        /// <summary>
        /// 烘烤状态，0 正常，1待烘烤，2烘烤中
        /// </summary>
        public int BakeState { get; set; } = 0;

        public string Status { get; set; } = "0";
    }
}
