using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ItemSetSubItem : BaseEntity
    {
        [DatabaseColumn("item_set_sub_item_id")]
        public Int32? ItemSetSubItemId { get; set; }

        [DatabaseColumn("item_id")]
        public Int32? ItemId { get; set; }

        [DatabaseColumn("sub_item_id")]
        public Int32? SubItemId { get; set; }

        [DatabaseColumn("sub_item_net_qty")]
        public Int32? SubItemNetQty { get; set; }
        
        public string ItemName { get; set; }

        public string SubItemName { get; set; }
    }
}
