using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class TaxSlabController : ApiController
    {
        private readonly Business.TaxSlab _taxSlab;

        public TaxSlabController()
        {
            _taxSlab = new Business.TaxSlab();
        }

        [Route("GetTaxSlabs")]
        public List<Entities.TaxSlab> GetTaxSlabs()
        {
            return _taxSlab.GetTaxSlabs();
        }

    }
}
