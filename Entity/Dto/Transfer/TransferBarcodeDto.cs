using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class TransferBarcodeDto
    {
        public string TransferId { get; set; }

        public string MaterialNo { get; set; }

        public string Barcode { get; set; }

        public int Qty { get; set; }

        public int BarcodeStatus { get; set; }
    }
}
