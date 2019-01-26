using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class DailyReceivablePayable
    {
        private readonly DataModel.DailyReceivablePayable _dailyReceivablePayable;

        public DailyReceivablePayable()
        {
            _dailyReceivablePayable = new DataModel.DailyReceivablePayable();
        }

        public Int32 SaveDailyReceivablePayable(Entities.DailyReceivablePayable dailyRecPay)
        {
            return _dailyReceivablePayable.SaveDailyReceivablePayable(dailyRecPay);
        }

        public List<Entities.DailyReceivablePayable> GetDailyReceivablePaybleData(Entities.DailyReceivablePayable dailyRecPay)
        {
            return _dailyReceivablePayable.GetDailyReceivablePaybleData(dailyRecPay);
        }

    }
}
