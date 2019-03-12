using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ItemMargin
    {
        public string ItemCategoryName { get; set; }

        public string ItemQuality { get; set; }

        public string ItemName { get; set; }

        public decimal? PurchaseRate { get; set; }

        public decimal? LandingCost { get; set; }

        public decimal? WholesaleRate { get; set; }

        public decimal? RetailRate { get; set; }

        public decimal? Margin { get; set; }

    }
}
