using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class SalesSchemeRegisterController : ApiController
    {
        private readonly Business.SalesSchemeRegister _salesSchemeRegister;

        public SalesSchemeRegisterController()
        {
            _salesSchemeRegister = new Business.SalesSchemeRegister();
        }

        [Route("GetSalesSchemesRegister")]
        public List<Entities.SalesSchemeRegister> GetSalesSchemeRegister()
        {
            return _salesSchemeRegister.GetSalesSchemesRegister();
        }


    }
}
