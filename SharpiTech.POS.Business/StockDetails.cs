using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class StockDetails
    {
        private readonly DataModel.StockDetails _stockDetails;

        public StockDetails()
        {
            _stockDetails = new DataModel.StockDetails();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.StockDetails> GetStockDetails()
        {
            return _stockDetails.GetStockDetails();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockDetails"></param>
        /// <returns></returns>
        public Int32 SaveStockDetails(Entities.StockDetails stockDetails)
        {
            return _stockDetails.SaveStockDetails(stockDetails);
        }

    }
}
