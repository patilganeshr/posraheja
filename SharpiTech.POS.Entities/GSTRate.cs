using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class GSTRate : BaseEntity
    {
        [DatabaseColumn("gst_rate_id")]
        public Int32? GSTRateId { get; set; }

        [DatabaseColumn("gst_category_id")]
        public Int32? GSTCategoryId { get; set; }

        [DatabaseColumn("gst_name")]
        public string GSTName { get; set; }

        [DatabaseColumn("gst_rate")]
        public decimal? Rate { get; set; }

        [DatabaseColumn("sale_value_amount")]
        public decimal? SaleValueAmount { get; set; }

        [DatabaseColumn("effective_from_date")]
        public string EffectiveFromDate { get; set; }

        [DatabaseColumn("effective_to_date")]
        public string EffectiveToDate { get; set; }

        [DatabaseColumn("tax_id")]
        public Int32? TaxId { get; set; }

        public string TaxName { get; set; }

        public Int32? ItemId { get; set; }

        public Int32? ItemCategoryId { get; set; }

        public string GSTApplicable { get; set; }        
        
    }
}
