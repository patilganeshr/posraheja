using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ItemRate : BaseEntity
    {
        [DatabaseColumn("item_rate_id")]
        public Int32? ItemRateId { get; set; }

        [DatabaseColumn("item_id")]
        public Int32? ItemId { get; set; }

        [DatabaseColumn("purchase_rate")]
        public Decimal? PurchaseRate { get; set; }

        [DatabaseColumn("discount_percent")]
        public decimal? DiscountPercent { get; set; }

        [DatabaseColumn("discount_amount")]
        public decimal? DiscountAmount { get; set; }
        
        [DatabaseColumn("transport_cost")]
        public Decimal? TransportCost { get; set; }

        [DatabaseColumn("labour_cost")]
        public Decimal? LabourCost { get; set; }

        [DatabaseColumn("gst_rate")]
        public decimal? GSTRate { get; set; }

        [DatabaseColumn("gst_rate_id")]
        public Int32? GSTRateId { get; set; }

        [DatabaseColumn("rate_effective_from_date")]
        public string RateEffectiveFromDate { get; set; }

        [DatabaseColumn("rate_effective_to_date")]
        public string RateEffectiveToDate { get; set; }

        [DatabaseColumn("is_sell_at_net_rate")]
        public bool? IsSellAtNetRate { get; set; }

        [DatabaseColumn("working_period_id")]
        public Int32? working_period_id { get; set; }

        public decimal? RateAfterDiscount { get; set; }

        public decimal? CostOfGoods { get; set; }

        public decimal? GSTAmount { get; set; }

        public decimal? TotalCost { get; set; }

        public string ItemName { get; set; }

        public string ItemQuality { get; set; }

        public List<ItemRateForCustomerCategory> CustomerCategoryRates { get; set; }
    }
}
