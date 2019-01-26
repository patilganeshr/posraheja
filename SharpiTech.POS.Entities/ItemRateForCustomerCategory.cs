using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ItemRateForCustomerCategory :BaseEntity
    {
        [DatabaseColumn("customer_category_item_rate_id")]
        public Int32? CustomerCategoryItemRateId{ get; set; }

        [DatabaseColumn("customer_category_id")]
        public Int32? CustomerCategoryId { get; set; }

        [DatabaseColumn("item_rate_id")]
        public Int32? ItemRateId { get; set; }

        public Int32? ItemId { get; set; }

        [DatabaseColumn("rate_in_percent")]
        public decimal? RateInPercent { get; set; }

        [DatabaseColumn("flat_rate")]
        public decimal? FlatRate { get; set; }

        public string CustomerCategoryName { get; set; }

        public string CustomerCategoryDesc { get; set; }
    }
}
