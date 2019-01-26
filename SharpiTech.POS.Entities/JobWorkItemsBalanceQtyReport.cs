using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class JobWorkItemsBalanceQtyReport
    {
        public Int32? JobWorkId { get; set; }

        public string PurchaseBillNo { get; set; }

        public string BaleNo { get; set; }

        public string PurchaseBillDate { get; set; }

        public string VendorName { get; set; }

        public string PurchaseItem { get; set; }

        public decimal? PurchaseQty { get; set; }

        public string ChallanNo { get; set; }

        public string ChallanDate { get; set; }

        public decimal? SentMtrs { get; set; }

        public string KaragirName { get; set; }

        public string KaragirBillNo { get; set; }

        public decimal? UsedMtrs { get; set; }

        public decimal? BalanceMtrs { get; set; }

    }
}
