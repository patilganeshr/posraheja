using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class SalesBillItemRegisterController : ApiController
    {
        private readonly Business.SalesBillItemRegister _salesBillItemRegister;

        public SalesBillItemRegisterController()
        {
            _salesBillItemRegister = new Business.SalesBillItemRegister();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetSalesBillItemRegister")]
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegister()
        {
            return _salesBillItemRegister.GetSalesBillItemRegister();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        [Route("GetSalesBillItemRegisterByWorkingPeriod/{workingPeriodId}")]
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            return _salesBillItemRegister.GetSalesBillItemRegisterByWorkingPeriod(workingPeriodId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [Route("GetSalesBillItemRegisterByCustomer/{customerId}")]
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByCustomer(Int32 customerId)
        {
            return _salesBillItemRegister.GetSalesBillItemRegisterByCustomer(customerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillItemRegister"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetSalesBillItemRegisterByFromToDate")]
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByFromToDate([FromBody] Entities.SalesBillItemRegister salesBillItemRegister)
        {
            return _salesBillItemRegister.GetSalesBillItemRegisterByFromToDate(salesBillItemRegister);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>        
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        [Route("GetSalesBillItemRegisterByCustomerAndWorkingPeriodId/{customerId}/{workingPeriodId}")]
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByCustomerAndWorkingPeriodId(Int32 customerId, Int32 workingPeriodId)
        {
            return _salesBillItemRegister.GetSalesBillItemRegisterByCustomerAndWorkingPeriodId(customerId, workingPeriodId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillItemRegister"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetSalesBillItemRegisterByCustomerAndFromToDate")]
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByCustomerAndFromToDate([FromBody] Entities.SalesBillItemRegister salesBillItemRegister)
        {
            return _salesBillItemRegister.GetSalesBillItemRegisterByCustomerAndFromToDate(salesBillItemRegister);
        }


    }
}
