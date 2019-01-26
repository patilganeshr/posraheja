using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class SalesBillRegisterController : ApiController
    {
        private readonly Business.SalesBillRegister _salesBillRegister;

        public SalesBillRegisterController()
        {
            _salesBillRegister = new Business.SalesBillRegister();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetSalesBillRegister")]
        public List<Entities.SalesBillRegister> GetSalesBillRegister()
        {
            return _salesBillRegister.GetSalesBillRegister();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        [Route("GetSalesBillRegisterByWorkingPeriod/{workingPeriodId}")]
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            return _salesBillRegister.GetSalesBillRegisterByWorkingPeriod(workingPeriodId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [Route("GetSalesBillRegisterByCustomer/{customerId}")]
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByCustomer(Int32 customerId)
        {
            return _salesBillRegister.GetSalesBillRegisterByCustomer(customerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillRegister"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetSalesBillRegisterByFromToDate")]
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByFromToDate([FromBody] Entities.SalesBillRegister salesBillRegister)
        {
            return _salesBillRegister.GetSalesBillRegisterByFromToDate(salesBillRegister);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        [Route("GetSalesBillRegisterByCustomerAndWorkingPeriodId/{customerId}/{workingPeriodId}")]
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByCustomerAndWorkingPeriodId(Int32 customerId, Int32 workingPeriodId)
        {
            return _salesBillRegister.GetSalesBillRegisterByCustomerAndWorkingPeriodId(customerId, workingPeriodId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillRegister"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetSalesBillRegisterByCustomerAndFromToDate")]
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByCustomerAndFromToDate([FromBody] Entities.SalesBillRegister salesBillRegister)
        {
            return _salesBillRegister.GetSalesBillRegisterByCustomerAndFromToDate(salesBillRegister);
        }

    }
}
