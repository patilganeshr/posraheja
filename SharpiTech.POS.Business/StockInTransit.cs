using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class StockInTransit
    {
        private readonly DataModel.StockInTransit _stockInTransit;

        public StockInTransit()
        {
            _stockInTransit = new DataModel.StockInTransit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.StockInTransit> GetStockInTransitDetails()
        {
            return _stockInTransit.GetStockInTransitDetails();
        }
    }
}
