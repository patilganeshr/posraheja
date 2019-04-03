using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class SalesSchemeController : ApiController
    {
        private readonly Business.SalesScheme _salesScheme;

        public SalesSchemeController()
        {
            _salesScheme = new Business.SalesScheme();            
        }

        [Route("GetAllSalesSchemes")]
        public List<Entities.SalesScheme> GetAllSalesSchemes()
        {
            return _salesScheme.GetAllSalesSchemes();
        }

        //[Route("GetSalesSchemeDetails/{itemId}/{effectiveDate}")]
        //public Entities.SalesScheme GetSalesSchemeDetails(Int32 itemId, string effectiveDate)
        //{
        //    return _salesScheme.GetSalesSchemeDetails(itemId, effectiveDate);
        //}

        [Route("GetSalesSchemeDetails/{itemId}/{effectiveDate}")]
        public List<Entities.SalesScheme> GetSalesSchemeDetails(Int32 itemId, string effectiveDate)
        {
            return _salesScheme.GetSalesSchemeDetails(itemId, effectiveDate);
        }

        [HttpPost]
        [Route("SaveSalesScheme")]
        public Int32 SaveSalesScheme(Entities.SalesScheme salesScheme)
        {
            return _salesScheme.SaveSalesScheme(salesScheme);
        }

    }
}
