using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class ItemRateForCustomerCategory
    {
        private readonly DataModel.ItemRateForCustomerCategory _ircc;

        public ItemRateForCustomerCategory()
        {
            _ircc = new DataModel.ItemRateForCustomerCategory();
        }

        public List<Entities.ItemRateForCustomerCategory> GetCustomerCategories()
        {
            return _ircc.GetCustomerCategories();
        }

        public List<Entities.ItemRateForCustomerCategory> GetItemRateForCustomerCategoryByItemId(Int32 itemId)
        {
            return _ircc.GetItemRateForCustomerCategoryByItemId(itemId);
        }

        public List<Entities.ItemRateForCustomerCategory> GetItemRatesForCustomerCategoryByItemRateId(Int32 itemRateId)
        {
            return _ircc.GetItemRatesForCustomerCategoryByItemRateId(itemRateId);
        }
        public Int32 SaveItemRateForCustomerCategory(Entities.ItemRateForCustomerCategory ircc)
        {
            return _ircc.SaveItemRateForCustomerCategory(ircc);
        }

        public List<Entities.ItemRateForSalesBills> SearchItemRatesByItemNameAndQuality(string itemName)
        {
            return _ircc.SearchItemRatesByItemNameAndQuality(itemName);
        }

        /// <summary>
        /// Get Wholesale and Retails Rates of Items for particular item 
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<Entities.ItemRateForSalesBills> GetWholesaleAndRetailRatesOfItems(Int32 itemId)
        {
            return _ircc.GetWholesaleAndRetailRatesOfItems(itemId);
        }

        /// <summary>
        /// Get Wholesale and Retail Rates of All Items
        /// </summary>
        /// <returns></returns>
        public List<Entities.ItemRateForSalesBills> GetWholesaleAndRetailRatesOfAllItems()
        {
            return _ircc.GetWholesaleAndRetailRatesOfAllItems();
        }

        /// <summary>
        /// Get Wholesale and Retail Rates of Sales Bill Items 
        /// </summary>
        /// <param name="salesBillId"></param>
        /// <returns></returns>
        public List<Entities.ItemRateForSalesBills> GetWholesaleAndRetailsRatesOfSalesBillItem(Int32 salesBillId)
        {
            return _ircc.GetWholesaleAndRetailsRatesOfSalesBillItem(salesBillId);
        }

    }
}
