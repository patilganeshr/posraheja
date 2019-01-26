using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class TaxSlabSubHead : BaseEntity
    {
        [DatabaseColumn("tax_slab_sub_head_id")]
        public Int32 TaxSlabSubHeadId { get; set; }

        [DatabaseColumn("tax_slab_id")]
        public Int32 TaxSlabId { get; set; }

        [DatabaseColumn("tax_sub_head_name")]
        public string TaxSubHeadName { get; set; }

        [DatabaseColumn("tax_rate")]
        public Decimal TaxRate { get; set; }
    }
}
