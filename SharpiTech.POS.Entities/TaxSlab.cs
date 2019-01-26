using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class TaxSlab : BaseEntity
    {
        [DatabaseColumn("tax_slab_id")]
        public Int32? TaxSlabId { get; set; }

        [DatabaseColumn("tax_name")]
        public string TaxName { get; set; }

        [DatabaseColumn("tax_rate")]
        public decimal? TaxRate { get; set; }

        [DatabaseColumn("effective_date")]
        public string EffectiveDate { get; set; }

        [DatabaseColumn("effective_year")]
        public string EffectiveYear { get; set; }

        [DatabaseColumn("show_tax_valuation")]
        public bool ShowTaxValuation { get; set; }
    }
}
