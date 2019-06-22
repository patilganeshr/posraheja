using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class ItemImage
    {
        private readonly DataModel.ItemImage _itemImage;

        public ItemImage()
        {
            _itemImage = new DataModel.ItemImage();
        }

        public List<Entities.ItemImage> GetItemImagesByItemId(Int32 itemId)
        {
            return _itemImage.GetItemImagesByItemId(itemId);
        }

        public Int32 SaveItemImage(List<Entities.ItemImage> itemImages)
        {
            return _itemImage.SaveItemImage(itemImages);
        }
        
    }
}
