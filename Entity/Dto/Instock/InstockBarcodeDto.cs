using Entity.Enums;
using System;
using System.ComponentModel;

namespace Entity.Dto
{
    public class InstockBarcodeDto : INotifyPropertyChanged
    {
        public string OrderNo { get; set; }

        public string MaterialNo { get; set; }

        /// <summary>
        /// 入库单明细Id
        /// </summary>
        public string InstockDetailId { get; set; } = string.Empty;

        public string Upn { get; set; }

        private int _innerQty = 0;
        public int InnerQty
        {
            get { return _innerQty; }
            set
            {
                if (_innerQty != value)
                {
                    _innerQty = value;
                    RaisePropertyChange(nameof(InnerQty));
                }
            }
        }

        public string Location { get; set; }

        public string Operator { get; set; }

        public int TowerNo { get; set; }

        public string TowerDisplay => EnumHelper.GetDescription(typeof(TowerEnum), TowerNo);

        public DateTime CreateTime { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
