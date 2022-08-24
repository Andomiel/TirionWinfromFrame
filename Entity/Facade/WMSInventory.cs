namespace Entity.Facade
{
    public class WMSInventory
    {
        /// <summary>
        /// 仓库号
        /// </summary>
        public string WAREHOUSE_ID { get; set; } = "WMWHSE7";

        /// <summary>
        /// 库存组织
        /// </summary>
        public string LOT02 { get; set; }

        /// <summary>
        /// ERP库位
        /// </summary>
        public string LOT03 { get; set; }

        /// <summary>
        /// 物料号
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string MATERIAL_NAME { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string QTY { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string UNIT { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string IWMS_QTY { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        public string Difference { get; set; }
    }
}
