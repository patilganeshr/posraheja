using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ItemPicture : BaseEntity
    {
        [DatabaseColumn("item_picture_id")]
        public Int32? ItemPictureId { get; set; }

        [DatabaseColumn("item_id")]
        public Int32? ItemId { get; set; }

        [DatabaseColumn("item_picture_name")]
        public string ItemPictureName { get; set; }

        [DatabaseColumn("item_picture_path")]
        public string ItemPicturePath { get; set; }
        
        public string ItemName { get; set; }

    }
}
