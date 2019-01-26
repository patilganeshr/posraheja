using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Charge : BaseEntity
    {
        [DatabaseColumn("charge_id")]
        public Int32? ChargeId { get; set;}

        [DatabaseColumn("charge_name")]
        public string ChargeName { get; set; }

        [DatabaseColumn("charge_desc")]
        public string ChargeDesc { get; set; }

        [DatabaseColumn("gst_category_id")]
        public Int32? GSTCategoryId { get; set; }

        public string GSTCategoryName { get; set; }
    }
}
