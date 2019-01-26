using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Data;

namespace SharpiTech.POS.Business
{
    public class SalesBillItemRegister
    {
        private readonly DataModel.SalesBillItemRegister _salesBillItemRegister;

        public SalesBillItemRegister()
        {
            _salesBillItemRegister = new DataModel.SalesBillItemRegister();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegister()
        {
            return _salesBillItemRegister.GetSalesBillItemRegister();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            return _salesBillItemRegister.GetSalesBillItemRegisterByWorkingPeriod(workingPeriodId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByCustomer(Int32 customerId)
        {
            return _salesBillItemRegister.GetSalesBillItemRegisterByCustomer(customerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillItemRegister"></param>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByFromToDate(Entities.SalesBillItemRegister salesBillItemRegister)
        {
            return _salesBillItemRegister.GetSalesBillItemRegisterByFromToDate(salesBillItemRegister);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>        
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByCustomerAndWorkingPeriodId(Int32 customerId, Int32 workingPeriodId)
        {
            return _salesBillItemRegister.GetSalesBillItemRegisterByCustomerAndWorkingPeriodId(customerId, workingPeriodId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillItemRegister"></param>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByCustomerAndFromToDate(Entities.SalesBillItemRegister salesBillItemRegister)
        {
            return _salesBillItemRegister.GetSalesBillItemRegisterByCustomerAndFromToDate(salesBillItemRegister);
        }


    }
}
