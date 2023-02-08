using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class InstockDetailDto : INotifyPropertyChanged
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; } = 0;

        /// <summary>
        /// 明细业务Id
        /// </summary>
        public string BusinessId { get; set; } = string.Empty;

        /// <summary>
        /// 入库单Id
        /// </summary>
        public string InstockId { get; set; } = string.Empty;

        /// <summary>
        /// 料号
        /// </summary>
        public string MaterialNo { get; set; } = string.Empty;

        /// <summary>
        /// 入库数量
        /// </summary>
        public int RequireCount { get; set; } = 0;

        /// <summary>
        /// 状态,0 未入库，1 入库中，2 入库完成
        /// </summary>
        public int DetailStatus { get; set; } = 0;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; } = string.Empty;

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// 最后更新人
        /// </summary>
        public string LastUpdateUser { get; set; } = string.Empty;

        public string ReceiveStatusDisplay
        {
            get
            {
                if (Barcodes.Count == 0)
                {
                    return "未入库";
                }
                else
                {
                    int totalCount = ActualCount;
                    if (RequireCount > totalCount)
                    {
                        return "短收";
                    }
                    else if (RequireCount == totalCount)
                    {
                        return "正常";
                    }
                    else
                    {
                        return "超收";
                    }
                }
            }
        }

        private int _actualCount = 0;

        public int ActualCount
        {
            get { return _actualCount; }
            set
            {
                if (_actualCount != value)
                {
                    _actualCount = value;
                    RaisePropertyChange(nameof(ActualCount));
                    RaisePropertyChange(nameof(ReceiveStatusDisplay));
                }
            }
        }

        private BindingList<InstockBarcodeDto> _barcodes = new BindingList<InstockBarcodeDto>();

        public BindingList<InstockBarcodeDto> Barcodes
        {
            get { return _barcodes; }
            set
            {
                if (_barcodes != value)
                {
                    _barcodes = value;
                    RaisePropertyChange(nameof(Barcodes));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
