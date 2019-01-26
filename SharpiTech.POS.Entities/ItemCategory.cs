using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ItemCategory : BaseEntity
    {
        [DatabaseColumn("item_category_id")]
        public Int32? ItemCategoryId { get; set; }

        [DatabaseColumn("item_category_name")]
        public string ItemCategoryName { get; set; }

        [DatabaseColumn("item_category_desc")]
        public string ItemCategoryDesc { get; set; }

        [DatabaseColumn("gst_category_id")]
        public Int32? GSTCategoryId { get; set; }
        
        public string GSTCategoryName { get; set; }
    }
}
