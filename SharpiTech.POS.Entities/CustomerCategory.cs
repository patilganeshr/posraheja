using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class CustomerCategory : BaseEntity
    {
        [DatabaseColumn("customer_category_id")]
        public Int32? CustomerCategoryId { get; set; }

        [DatabaseColumn("customer_category_name")]
        public string CustomerCategoryName { get; set; }

        [DatabaseColumn("customer_category_desc")]
        public string CustomerCategoryDesc { get; set; }
    }
}
