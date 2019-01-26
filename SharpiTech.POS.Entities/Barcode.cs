using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Barcode
    {
        public Int32? VendorId{ get; set; }

        public Int32? ItemId { get; set; }

        public Int32? NoOfLabels{ get; set; }

        public Int32? LabelStartNo { get; set; }

        public string VendorName { get; set; }

        public string VendorCode { get; set; }

        public string ItemName { get; set; }

        public string ItemCode { get; set; }

        public Int32? GoodsReceiptItemId { get; set; }

        public Int32? SearchInwardNo { get; set; }

        public string InwardNo { get; set; }

        public Int32? InwardId { get; set; }

        public Int32? InwardGoodsId { get; set; }

        public bool? PrintLabelContinue { get; set; }

        public string LocationType { get; set; }
    }
}
