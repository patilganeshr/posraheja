using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class ItemImageController : ApiController
    {
        private readonly Business.ItemImage _itemImage;

        public ItemImageController()
        {
            _itemImage = new Business.ItemImage();
        }

        [Route("GetItemImagesByItemId/{itemId}")]
        public List<Entities.ItemImage> GetItemImagesByItemId(Int32 itemId)
        {
            return _itemImage.GetItemImagesByItemId(itemId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemImage"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveItemImage")]
        public Int32 SaveItemImage(List<Entities.ItemImage> itemImages)
        {
            return _itemImage.SaveItemImage(itemImages);
        }

    }
}
