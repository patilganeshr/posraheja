using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class PurchaseBillRegisterController : ApiController
    {
        private readonly Business.PurchaseBillRegister _purchaseBillRegister;

        public PurchaseBillRegisterController()
        {
            _purchaseBillRegister = new Business.PurchaseBillRegister();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetPurchaseBillRegiser")]
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegister()
        {
            return _purchaseBillRegister.GetPurchaseBillRegister();
        }

        [Route("GetPurchaseBillRegisterByWorkingPeriod/{workingPeriodId}")]
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            return _purchaseBillRegister.GetPurchaseBillRegisterByWorkingPeriod(workingPeriodId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        [Route("GetPurchaseBillRegisterByVendor/{vendorId}")]
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByVendor(Int32 vendorId)
        {
            return _purchaseBillRegister.GetPurchaseBillRegisterByVendor(vendorId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillRegister"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPurchaseBillRegisterByPeriod")]
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByPeriod([FromBody] Entities.PurchaseBillRegister purchaseBillRegister)
        { 
            return _purchaseBillRegister.GetPurchaseBillRegisterByPeriod(purchaseBillRegister);
        }

        [Route("GetPurchaseBillRegisterByWorkingPeriodAndVendor/{workingPeriodId}/{vendorId}")]
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByWorkingPeriodAndVendor(Int32 workingPeriodId, Int32 vendorId)
        {
            return _purchaseBillRegister.GetPurchaseBillRegisterByWorkingPeriodAndVendor(workingPeriodId, vendorId);
        }

        [Route("GetPurchaseBillRegisterByVendorAndFromToDate/{vendorId}/{fromDate}/{toDate}")]
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByVendorAndFromToDate(Int32 vendorId, string fromDate, string toDate)
        {
            return _purchaseBillRegister.GetPurchaseBillRegisterByVendorAndFromToDate(vendorId, fromDate, toDate);
        }

    }
}
