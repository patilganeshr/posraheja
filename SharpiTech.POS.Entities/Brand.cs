using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Brand : BaseEntity
    {
        [DatabaseColumn("brand_id")]
        public Int32? BrandId { get; set; }

        [DatabaseColumn("brand_name")]
        public string BrandName { get; set; }
                
    }
}
