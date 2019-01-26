using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class PurchaseBillRegister
    {
        private readonly DataModel.PurchaseBillRegister _purchaseBillRegister;

        public PurchaseBillRegister()
        {
            _purchaseBillRegister = new DataModel.PurchaseBillRegister();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegister()
        {
            return _purchaseBillRegister.GetPurchaseBillRegister();
        }

        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            return _purchaseBillRegister.GetPurchaseBillRegisterByWorkingPeriod(workingPeriodId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByVendor(Int32 vendorId)
        {
            return _purchaseBillRegister.GetPurchaseBillRegisterByVendor(vendorId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillRegister"></param>
        /// <returns></returns>
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByPeriod(Entities.PurchaseBillRegister purchaseBillRegister)
        {
            return _purchaseBillRegister.GetPurchaseBillRegisterByPeriod(purchaseBillRegister);
        }

        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByWorkingPeriodAndVendor(Int32 workingPeriodId, Int32 vendorId)
        {
            return _purchaseBillRegister.GetPurchaseBillRegisterByWorkingPeriodAndVendor(workingPeriodId, vendorId);
        }

        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByVendorAndFromToDate(Int32 vendorId, string fromDate, string toDate)
        {
            return _purchaseBillRegister.GetPurchaseBillRegisterByVendorAndFromToDate(vendorId, fromDate, toDate);
        }

    }
}
