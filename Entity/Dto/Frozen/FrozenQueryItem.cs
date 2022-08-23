using Entity.Enums;
using System;

namespace Entity.Dto
{
    public class FrozenQueryItem
    {
        public bool SelectFlag { get; set; } = false;
        public string ReelID { get; set; }
        public string QRcode { get; set; }
        public string PartNumber { get; set; }
        public string Manufacturer { get; set; }
        public int LockTowerNo { get; set; }
        public string Tower { get; set; }
        public string LockLocation { get; set; }
        public string LockMachineID { get; set; }
        public string ABSide { get; set; }
        public string Way => ChooseWayValue();
        public DateTime SaveTime { get; set; }
        public int Qty { get; set; }
        public string DateCode { get; set; }
        public string SerialNo { get; set; }
        public string ReelType { get; set; }
        public string ReelTypeDes => EnumHelper.GetDescription(typeof(ReelTypeEnum), ReelType);

        public DateTime DateCodeDate => QueryConditionConvert.DateCdoeToCycleDate(DateCode, ReelID);

        private string ChooseWayValue()
        {
            if (LockTowerNo == 1)
            {
                return ABSide;
            }
            else
            {
                return LockMachineID;
            }
        }
    }

}
