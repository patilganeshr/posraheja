using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class StockDetailsController : ApiController
    {
        private readonly Business.StockDetails _stockDetails;

        public StockDetailsController()
        {
            _stockDetails = new Business.StockDetails();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetStockDetails")]
        public List<Entities.StockDetails> GetStockDetails()
        {
            return _stockDetails.GetStockDetails();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveStockDetails")]
        public Int32 SaveStockDetails(Entities.StockDetails stockDetails)
        {
            return _stockDetails.SaveStockDetails(stockDetails);
        }


    }
}
