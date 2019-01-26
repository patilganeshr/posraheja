using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class ItemQualityController : ApiController
    {
        private readonly Business.ItemQuality _itemQuality;

        public ItemQualityController()
        {
            _itemQuality = new Business.ItemQuality();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQuality"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveItemQuality")]
        public Int32 SaveItemQuality(Entities.ItemQuality itemQuality)
        {
            return _itemQuality.SaveItemQuality(itemQuality);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQuality"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteItemQuality")]
        public bool DeleteItemQuality(Entities.ItemQuality itemQuality)
        {
            return _itemQuality.DeleteItemQuality(itemQuality);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllItemQualities")]
        public List<Entities.ItemQuality> GetAllItemQualities()
        {
            return _itemQuality.GetAllItemQualities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQualityId"></param>
        /// <returns></returns>
        [Route("GetItemQualityById/{itemQualityId}")]
        public Entities.ItemQuality GetItemQualityById(Int32 itemQualityId)
        {
            return _itemQuality.GetItemQualityById(itemQualityId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQualityName"></param>
        /// <returns></returns>
        [Route("GetItemQualityByName/{itemQualityName}")]
        public Entities.ItemQuality GetItemQualityByName(string itemQualityName)
        {
            return _itemQuality.GetItemQualityByName(itemQualityName);
        }


    }
}
