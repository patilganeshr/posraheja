using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpiTech.POS.API.Controllers
{
    public class InwardGoodsDetailsController : Controller
    {
        private readonly Business.InwardGoodsDetails _inwardGoodsDetails;

        public InwardGoodsDetailsController()
        {
            _inwardGoodsDetails = new Business.InwardGoodsDetails();
        }

        /// <summary>
        /// Return the list of Inward Goods Details.
        /// </summary>
        /// <param name="inwardId">Required InwardId as an integer parameter.</param>
        /// <returns>Return the collections of Inward Goods Details.</returns>
        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByInwardId(Int32 inwardId)
        {
            return _inwardGoodsDetails.GetInwardGoodsDetailsByInwardId(inwardId);
        }
    }
}