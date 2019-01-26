using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class DailyReceivablePayableController : ApiController
    {
        private readonly Business.DailyReceivablePayable _dailyReceivablePayable;

        public DailyReceivablePayableController()
        {
            _dailyReceivablePayable = new Business.DailyReceivablePayable();
        }

        [HttpPost]
        [Route("SaveDailyReceivablePayable")]
        public Int32 SaveDailyReceivablePayable(Entities.DailyReceivablePayable dailyRecPay)
        {
            return _dailyReceivablePayable.SaveDailyReceivablePayable(dailyRecPay);
        }

        [HttpPost]
        [Route("GetDailyReceivablePaybleData")]
        public List<Entities.DailyReceivablePayable> GetDailyReceivablePaybleData(Entities.DailyReceivablePayable dailyRecPay)
        {
            return _dailyReceivablePayable.GetDailyReceivablePaybleData(dailyRecPay);
        }

    }
}
