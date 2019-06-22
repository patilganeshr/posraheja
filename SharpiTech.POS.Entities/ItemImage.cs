using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ItemImage : BaseEntity
    {
        public Int32? ItemImageId { get; set; }

        [DatabaseColumn("item_id")]
        public Int32? ItemId { get; set; }

        public Int32? ColorId { get; set; }

        public Int32? DesignId { get; set; }

        [DatabaseColumn("item_picture_name")]
        public string ItemImageName { get; set; }

        [DatabaseColumn("item_picture_path")]
        public string ItemImagePath { get; set; }
        
        public string ItemName { get; set; }

        public string ItemCode { get; set; }

        public string ItemColor { get; set; }

        public string Design { get; set; }


    }
}
