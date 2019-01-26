using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Data;

namespace SharpiTech.POS.Business
{
    public class SalesBillRegister
    {
        private readonly DataModel.SalesBillRegister _salesBillRegister;

        public SalesBillRegister()
        {
            _salesBillRegister = new DataModel.SalesBillRegister();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.SalesBillRegister> GetSalesBillRegister()
        {
            return _salesBillRegister.GetSalesBillRegister();
        }

        public List<Entities.SalesBillRegister> GetSalesBillRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            return _salesBillRegister.GetSalesBillRegisterByWorkingPeriod(workingPeriodId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByCustomer(Int32 customerId)
        {
            return _salesBillRegister.GetSalesBillRegisterByCustomer(customerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillRegister"></param>
        /// <returns></returns>
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByFromToDate(Entities.SalesBillRegister salesBillRegister)
        {
            return _salesBillRegister.GetSalesBillRegisterByFromToDate(salesBillRegister);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByCustomerAndWorkingPeriodId(Int32 customerId, Int32 workingPeriodId)
        {
            return _salesBillRegister.GetSalesBillRegisterByCustomerAndWorkingPeriodId(customerId, workingPeriodId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillRegister"></param>
        /// <returns></returns>
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByCustomerAndFromToDate(Entities.SalesBillRegister salesBillRegister)
        {
            return _salesBillRegister.GetSalesBillRegisterByCustomerAndFromToDate(salesBillRegister);
        }

    }
}
