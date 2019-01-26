using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class ItemSetSubItemController : ApiController
    {
        private readonly Business.ItemSetSubItem _itemSetSubItem;

        public ItemSetSubItemController()
        {
            _itemSetSubItem = new Business.ItemSetSubItem();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>        
        [Route("GetSubItems")]
        public List<Entities.ItemSetSubItem> GetSubItems()
        {
            return _itemSetSubItem.GetSubItems();
        }

        [Route("GetSetItemsByItemId/{itemId}")]
        public List<Entities.ItemSetSubItem> GetSetItemsByItemId(Int32 itemId)
        {
            return _itemSetSubItem.GetSetItemsByItemId(itemId);
        }

        [HttpPost]
        [Route("SaveItemSet")]
        public Int32 SaveItemSet(Entities.ItemSetSubItem itemSetSubItem)
        {
            return _itemSetSubItem.SaveItemSet(itemSetSubItem);
        }


    }
}
