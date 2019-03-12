using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class PaymentTermsController : ApiController
    {
        private readonly Business.PaymentTerms _paymentTerms;

        public PaymentTermsController()
        {
            _paymentTerms = new Business.PaymentTerms();
        }

        [Route("GetAllPaymentTerms")]
        public List<Entities.PaymentTerms> GetAllPaymentTerms()
        {
            return _paymentTerms.GetAllPaymentTerms();
        }

        [HttpPost]
        [Route("SavePaymentTerms")]
        public Int32 SavePaymentTerms(Entities.PaymentTerms paymentTerms)
        {
            return _paymentTerms.SavePaymentTerms(paymentTerms);
        }

    }
}
