using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class ItemRateController : ApiController
    {
        private readonly Business.ItemRate _itemRate;
        private readonly Business.ItemRateForCustomerCategory _ircc;

        public ItemRateController()
        {
            _itemRate = new Business.ItemRate();
            _ircc = new Business.ItemRateForCustomerCategory();
        }

        [Route("GetAllItemsRates")]
        public List<Entities.ItemRate> GetAllItemsRates()
        {
            return _itemRate.GetAllItemsRates();
        }

        [Route("GetItemsRatesByItemId/{itemId}")]
        public List<Entities.ItemRate> GetItemsRatesByItemId(Int32 itemId)
        {
            return _itemRate.GetItemsRatesByItemId(itemId);
        }

        [Route("GetItemRateByItemRateId/{itemRateId}")]
        public Entities.ItemRate GetItemRateByItemRateId(Int32 itemRateId)
        {
            return _itemRate.GetItemRateByItemRateId(itemRateId);
        }

        [Route("GetItemRateForCustomerCategoryByItemId/{itemId}")]
        public List<Entities.ItemRateForCustomerCategory> GetItemRateForCustomerCategoryByItemId(Int32 itemId)
        {
            return _ircc.GetItemRateForCustomerCategoryByItemId(itemId);
        }

        [Route("GetItemRatesForCustomerCategoryByItemRateId/{itemRateId}")]
        public List<Entities.ItemRateForCustomerCategory> GetItemRatesForCustomerCategoryByItemRateId(Int32 itemRateId)
        {
            return _ircc.GetItemRatesForCustomerCategoryByItemRateId(itemRateId);
        }

        [Route("GetCustomerCategories")]
        public List<Entities.ItemRateForCustomerCategory> GetCustomerCategories()
        {
            return _ircc.GetCustomerCategories();
        }

        [Route("GetItemRateForCustomerCategoriesByItemRateId/{itemRateId}")]
        public List<Entities.ItemRateForCustomerCategory> GetItemRateForCustomerCategoriesByItemRateId(Int32 itemRateId)
        {
            return _ircc.GetItemRateForCustomerCategoryByItemId(itemRateId);
        }

        [HttpPost]
        [Route("SaveItemRate")]
        public Int32 SaveItemRate(List<Entities.ItemRate> itemRates)
        {
            return _itemRate.SaveItemRate(itemRates);
        }

        [HttpGet]
        [Route("SearchItemRateByItemName/{itemName}")]
        public List<Entities.ItemRateForSalesBills> SearchItemRatesByItemNameAndQuality(string itemName)
        {
            return _ircc.SearchItemRatesByItemNameAndQuality(itemName);
        }

        /// <summary>
        /// Get Wholesale and Retails Rates of Items for particular item 
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWholesaleAndRetailRatesOfItems/{itemId}")]
        public List<Entities.ItemRateForSalesBills> GetWholesaleAndRetailRatesOfItems(Int32 itemId)
        {
            return _ircc.GetWholesaleAndRetailRatesOfItems(itemId);
        }

        /// <summary>
        /// Get Wholesale and Retail Rates of All Items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWholesaleAndRetailRatesOfAllItems")]
        public List<Entities.ItemRateForSalesBills> GetWholesaleAndRetailRatesOfAllItems()
        {
            return _ircc.GetWholesaleAndRetailRatesOfAllItems();
        }

        /// <summary>
        /// Get Wholesale and Retail Rates of Sales Bill Items 
        /// </summary>
        /// <param name="salesBillId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWholesaleAndRetailsRatesOfSalesBillItem/{salesBillId}")]
        public List<Entities.ItemRateForSalesBills> GetWholesaleAndRetailsRatesOfSalesBillItem(Int32 salesBillId)
        {
            return _ircc.GetWholesaleAndRetailsRatesOfSalesBillItem(salesBillId);
        }

    }
}
