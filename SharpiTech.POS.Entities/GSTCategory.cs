using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class GSTCategory : BaseEntity
    {
        [DatabaseColumn("gst_category_id")]
        public Int32? GSTCategoryId { get; set; }

        [DatabaseColumn("gst_category")]
        public string GSTCategoryName { get; set; }

        [DatabaseColumn("hsn_code")]
        public string HSNCode { get; set; }

        public List<Entities.GSTRate> GSTRates { get; set; }
    }
}
