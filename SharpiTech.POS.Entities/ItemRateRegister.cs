using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ItemRateRegister
    {
        public string ItemCode{ get; set; }

        public string ItemCategoryName { get; set; }

        public string BrandName { get; set; }

        public string ItemQuality { get; set; }

        public string ItemName { get; set; }

        public decimal? PurchaseRate { get; set; }

        public decimal? TotalExps { get; set; }

        public decimal? WholesaleRate { get; set; }

        public decimal? RetailRate { get; set; }

        public string RateEffectiveFromDate { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }
    }
}
