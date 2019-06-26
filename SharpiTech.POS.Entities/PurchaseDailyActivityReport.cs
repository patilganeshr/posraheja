using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class PurchaseDailyActivityReport
    {
        public Int32? PurchaseBillId { get; set; }

        public string PurchaseBillNo { get; set; }

        public string PurchaseBillDate { get; set; }

        public string VendorName { get; set; }

        public string ItemName { get; set; }

        public decimal? PurchaseCost { get; set; }

        public decimal? WholesaleRate { get; set; }

        public decimal? RetailRate { get; set; }

        public string EntryBy { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public Int32? UserId { get; set; }


    }
}
