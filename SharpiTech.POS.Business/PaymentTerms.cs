using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class PaymentTerms
    {
        private readonly DataModel.PaymentTerms _paymentTerms;

        public PaymentTerms()
        {
            _paymentTerms = new DataModel.PaymentTerms();
        }

        public List<Entities.PaymentTerms> GetAllPaymentTerms()
        {
            return _paymentTerms.GetAllPaymentTerms();
        }

        public Int32 SavePaymentTerms(Entities.PaymentTerms paymentTerms)
        {
            return _paymentTerms.SavePaymentTerms(paymentTerms);
        }

    }
}
