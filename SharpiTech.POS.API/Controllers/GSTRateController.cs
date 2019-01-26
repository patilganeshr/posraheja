using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class GSTRateController : ApiController
    {
        private readonly Business.GSTRate _gstRate;

        public GSTRateController()
        {
            _gstRate = new Business.GSTRate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetGSTRateByItemIdGSTApplicableAndSaleRate")]
        public Entities.GSTRate GetGSTRateByItemIdGSTApplicableAndSaleRate([FromBody] Entities.GSTRate gstr)
        //Int32 itemId, string gstApplicable, decimal saleRate, string effectiveDate)
        {
            return _gstRate.GetGSTRateByItemIdGSTApplicableAndSaleRate(gstr); // itemId, gstApplicable, saleRate, effectiveDate);
        }

        [HttpPost]
        [Route("GetGSTRateByGSTCategoryIdGSTApplicableAndEffectiveDate")]
        public Entities.GSTRate GetGSTRateByGSTCategoryIdGSTApplicableAndEffectiveDate([FromBody] Entities.GSTRate gstRate)
        {
            return _gstRate.GetGSTRateByGSTCategoryIdGSTApplicableAndEffectiveDate(gstRate);
        }

        [HttpPost]
        [Route("GetGSTRateByItemCategoryIdGSTApplicablePurchaseRateAndEffectiveDate")]
        public Entities.GSTRate GetGSTRateByItemCategoryIdGSTApplicablePurchaseRateAndEffectiveDate([FromBody] Entities.GSTRate gstRate)
        {
            return _gstRate.GetGSTRateByItemCategoryIdGSTApplicablePurchaseRateAndEffectiveDate(gstRate);
        }

        [Route("GetGSTApplicable/{clientAddressId}")]
        public Entities.GSTRate GetGSTApplicable(Int32 clientAddressId)
        {
            return _gstRate.GetGSTApplicable(clientAddressId);
        }

    }
}
