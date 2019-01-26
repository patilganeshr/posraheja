using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class ItemCategoryController : ApiController
    {
        private readonly Business.ItemCategory _itemCategory;

        public ItemCategoryController()
        {
            _itemCategory = new Business.ItemCategory();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveItemCategory")]
        public Int32 SaveItemCategory(Entities.ItemCategory itemCategory)
        {
            return _itemCategory.SaveItemCategory(itemCategory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteItemCategory")]
        public bool DeleteItemCategory(Entities.ItemCategory itemCategory)
        {
            return _itemCategory.DeleteItemCategory(itemCategory);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllItemCategories")]
        public List<Entities.ItemCategory> GetAllItemCategories()
        {
            return _itemCategory.GetAllItemCategories();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCategoryId"></param>
        /// <returns></returns>
        [Route("GetItemCategoryById/{itemCategoryId}")]
        public Entities.ItemCategory GetItemCategoryById(Int32 itemCategoryId)
        {
            return _itemCategory.GetItemCategoryById(itemCategoryId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCategoryName"></param>
        /// <returns></returns>
        [Route("GetItemCategoryByName/{itemCategoryName}")]
        public Entities.ItemCategory GetItemCategoryByName(string itemCategoryName)
        {
            return _itemCategory.GetItemCategoryByName(itemCategoryName);
        }

    }
}
