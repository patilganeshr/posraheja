using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class StockReport
    {
        private readonly DataModel.StockReport _stockReport;

        public StockReport()
        {
            _stockReport = new DataModel.StockReport();
        }

        public List<Entities.StockReport> GetStockAsOnDate()
        {
            return _stockReport.GetStockAsOnDate();
        }

        public List<Entities.StockReport> GetStockAsOnDateByItemwiseWithPurchaseCost()
        {
            return _stockReport.GetStockAsOnDateByItemwiseWithPurchaseCost();
        }

        /// <summary>
        /// Get Stock Report as on date
        /// </summary>
        /// <returns>Will return a list of Stock Report.</returns>
        public List<Entities.StockReport> GetStockOfAllItems()
        {
            return _stockReport.GetStockOfAllItems();
        }

        /// <summary>
        /// Get Stock Report By Item Id
        /// </summary>
        /// <param name="itemId">Required an integer value as Item Id</param>
        /// <returns>Will return a list of Stock Report.</returns>
        public List<Entities.StockReport> GetStockByItemId(Int32 itemId)
        {
            return _stockReport.GetStockByItemId(itemId);
        }

        /// <summary>
        /// Get Stock Report By Item Name
        /// </summary>
        /// <param name="itemName">Required a string value as Item Name.</param>
        /// <returns>Will return a list of Stock Report.</returns>
        public List<Entities.StockReport> GetStockByItemName(string itemName)
        {
            return _stockReport.GetStockByItemName(itemName);
        }

        /// <summary>
        /// Get Stock Report By Item Category Wise
        /// </summary>
        /// <returns>Will return a list of Stock Report.</returns>
        public List<Entities.StockReport> GetStockItemCategoryWise()
        {
            return _stockReport.GetStockItemCategoryWise();
        }

        /// <summary>
        /// Get Stock Report Item Categorywise By Item Category Id
        /// </summary>
        /// <param name="itemCategoryId">Required an integer value as Item Category Id.</param>
        /// <returns>Will return a list of Stock Report Entity.</returns>
        public List<Entities.StockReport> GetStockItemCategoryWiseByItemCategoryId(Int32 itemCategoryId)
        {
            return _stockReport.GetStockItemCategoryWiseByItemCategoryId(itemCategoryId);
        }

        /// <summary>
        /// Get Stock Report Item Category Wise and Item Wise
        /// </summary>
        /// <returns>Will return a list of Stock Report Entity.</returns>
        public List<Entities.StockReport> GetStockItemCategoryWiseAndItemQualityWise()
        {
            return _stockReport.GetStockItemCategoryWiseAndItemQualityWise();
        }

        /// <summary>
        /// Get Stock Location Wise Item Quality Wise and Item Wise
        /// </summary>
        /// <returns>Will return a list of Stock Report Entity.</returns>
        public List<Entities.StockReport> GetStockLocationWiseItemQualitWiseAndItemWise()
        {
            return _stockReport.GetStockLocationWiseItemQualitWiseAndItemWise();
        }

        /// <summary>
        /// Get Stock Location Wise Item Wise By Item Id
        /// </summary>
        /// <param name="itemId">Required an integer value of Item Id.</param>
        /// <returns>Will return a list of Stock Report Entity.</returns>
        public List<Entities.StockReport> GetStockLocationWiseItemWiseByItemId(Int32 itemId)
        {
            return _stockReport.GetStockLocationWiseItemWiseByItemId(itemId);
        }

        /// <summary>
        /// Get Stock Report Location Wise Item Quality Wise and Item Wise
        /// </summary>
        /// <returns>Will return a list of Stock Report Entity.</returns>
        public List<Entities.StockReport> GetStockLocationWiseAndItemWiseByLoctionId(Int32 locationId)
        {
            return _stockReport.GetStockLocationWiseAndItemWiseByLoctionId(locationId);
        }


    }
}
