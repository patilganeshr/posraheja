using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ItemQuality : BaseEntity
    {
        [DatabaseColumn("item_quality_id")]
        public Int32? ItemQualityId { get; set; }

        [DatabaseColumn("item_quality")]
        public string QualityName { get; set; }
        
    }
}
