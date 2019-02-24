using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class JobWorkItemSentToKaragir
    {

        public string ChallanNo { get; set; }

        public string ChallanDate { get; set; }

        public string PurchaseItem { get; set; }

        public decimal? SentMtrs { get; set; }

        public string UnitCode { get; set; }

        public string KaragirName { get; set; }

        public string PurchaseBillNo { get; set; }

        public string BaleNo { get; set; }

        public string PurchaseBillDate { get; set; }

        public string VendorName { get; set; }

        public decimal? PurchaseQty { get; set; }

    }
}
