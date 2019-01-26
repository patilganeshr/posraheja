using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class ItemSetSubItem
    {
        private readonly DataModel.ItemSetSubItem _itemSetSubItem;

        public ItemSetSubItem()
        {
            _itemSetSubItem = new DataModel.ItemSetSubItem();
        }

        public List<Entities.ItemSetSubItem> GetSubItems()
        {
            return _itemSetSubItem.GetSubItems();
        }

        public List<Entities.ItemSetSubItem> GetSetItemsByItemId(Int32 itemId)
        {
            return _itemSetSubItem.GetSetItemsByItemId(itemId);
        }

        public Int32 SaveItemSet(Entities.ItemSetSubItem itemSetSubItem)
        {
             return _itemSetSubItem.SaveItemSet(itemSetSubItem);
        }

    }
}
