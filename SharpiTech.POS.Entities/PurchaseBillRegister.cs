using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class PurchaseBillRegister
    {
        public string PurchaseBillDate { get; set; }

        public string PurchaseBillNo { get; set; }

        public string VendorName { get; set; }

        public string LRNo {get;set;}

        public string TransporterName { get; set; }

        public string ItemQuality { get; set; }

        public string ItemName { get; set; }

        public decimal? PurchaseQty { get; set; }

        public string UnitCode { get; set; }

        public decimal? PurchaseRate { get; set; }

        public decimal? AddLess { get; set; }

        public decimal? TaxableValue { get; set; }

        public decimal? GSTAmount { get; set; }

        public decimal? TotalAmount { get; set; }

        public string GoodsReceiptDate { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }
    }
}
