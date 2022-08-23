using Entity.Enums;
using System;

namespace Entity.Dto
{
    public class InstockBarcodeDto
    {
        public string OrderNo { get; set; }

        public string MaterialNo { get; set; }

        public string Upn { get; set; }

        public int InnerQty { get; set; }

        public string Location { get; set; }

        public string Operator { get; set; }

        public int TowerNo { get; set; }

        public string TowerDisplay => EnumHelper.GetDescription(typeof(TowerEnum), TowerNo);

        public DateTime CreateTime { get; set; }
    }
}
