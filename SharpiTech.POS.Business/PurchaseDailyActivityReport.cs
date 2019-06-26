using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class PurchaseDailyActivityReport
    {
        private readonly DataModel.PurchaseDailyActivityReport _purchaseDailyActivityReport;

        public PurchaseDailyActivityReport()
        {
            _purchaseDailyActivityReport = new DataModel.PurchaseDailyActivityReport();
        }

        public List<Entities.PurchaseDailyActivityReport> GetPurchaseBillsDetails(Entities.PurchaseDailyActivityReport purchaseDailyActivityReport)
        {
            return _purchaseDailyActivityReport.GetPurchaseBillsDetails(purchaseDailyActivityReport);
        }

    }
}
