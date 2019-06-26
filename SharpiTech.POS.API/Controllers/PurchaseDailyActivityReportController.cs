using SharpiTech.POS.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class PurchaseDailyActivityReportController : ApiController
    {
        private readonly Business.PurchaseDailyActivityReport _purchaseDailyActivityReport;

        public PurchaseDailyActivityReportController()
        {
            _purchaseDailyActivityReport = new Business.PurchaseDailyActivityReport();
        }

        [HttpPost]
        [Route("GetPurchaseBillsDetails")]
        public List<Entities.PurchaseDailyActivityReport> GetPurchaseBillsDetails([FromBody] Entities.PurchaseDailyActivityReport purchaseDailyActivityReport)
        {
            return _purchaseDailyActivityReport.GetPurchaseBillsDetails(purchaseDailyActivityReport);
        }

    }
}
