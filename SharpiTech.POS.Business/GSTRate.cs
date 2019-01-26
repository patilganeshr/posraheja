using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class GSTRate
    {
        private readonly DataModel.GSTRate _gstRate;

        public GSTRate()
        {
            _gstRate = new DataModel.GSTRate();
        }

        public Entities.GSTRate GetGSTRateByItemIdGSTApplicableAndSaleRate(Entities.GSTRate gstr)
        {
            return _gstRate.GetGSTRateByItemIdGSTApplicableAndSaleRate(gstr);// itemId,gstApplicable, saleRate, effectiveDate);
        }

        public Entities.GSTRate GetGSTRateByGSTCategoryIdGSTApplicableAndEffectiveDate(Entities.GSTRate gstRate)
        {
            return _gstRate.GetGSTRateByGSTCategoryIdGSTApplicableAndEffectiveDate(gstRate);
        }

        public Entities.GSTRate GetGSTRateByItemCategoryIdGSTApplicablePurchaseRateAndEffectiveDate(Entities.GSTRate gstRate)
        {
            return _gstRate.GetGSTRateByItemCategoryIdGSTApplicablePurchaseRateAndEffectiveDate(gstRate);
        }

        public Entities.GSTRate GetGSTApplicable(Int32 clientAddressId)
        {
            return _gstRate.GetGSTApplicable(clientAddressId);
        }

        public Int32 SaveGSTRate(Entities.GSTRate gstRate)
        {
            return _gstRate.SaveGSTRate(gstRate);
        }


    }
}
