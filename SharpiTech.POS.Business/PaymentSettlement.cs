using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class PaymentSettlement
    {
        private readonly DataModel.PaymentSettlement _paymentSettlement;

        public PaymentSettlement()
        {
            _paymentSettlement = new DataModel.PaymentSettlement();
        }

        public List<Entities.PaymentSettlement> GetPaymentSettlements()
        {
            return _paymentSettlement.GetPaymentSettlements();
        }

    }
}
