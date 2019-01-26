using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class OutwardController : ApiController
    {
        private readonly Business.OutwardDetails _outwardDetails;
        private readonly Business.OutwardGoodsDetails _outwardGoodsDetails;

        public OutwardController()
        {
            _outwardDetails = new Business.OutwardDetails();
            _outwardGoodsDetails = new Business.OutwardGoodsDetails();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllOutwardDetails")]
        public List<Entities.OutwardDetails> GetAllOutwardDetails()
        {
            return _outwardDetails.GetAllOutwardDetails();
        }

        [Route("GetBaleNos")]
        public List<Entities.OutwardDetails> GetBaleNos()
        {
            return _outwardDetails.GetBaleNos();
        }

        [Route("GetPkgSlipAdditionalDetails/{pkgSlipId}")]
        public Entities.OutwardDetails GetPkgSlipAdditionalDetails(Int32 pkgSlipId)
        {
            return _outwardDetails.GetPkgSlipAdditionalDetails(pkgSlipId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetPkgSlipItems/{pkgSlipId}")]
        public List<Entities.OutwardGoodsDetails> GetPkgSlipItems(Int32 pkgSlipId)
        {
            return _outwardGoodsDetails.GetPkgSlipItems(pkgSlipId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outwardDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveOutwardDetails")]
        public Int32 SaveOutwardDetails(Entities.OutwardDetails outwardDetails)
        {
            return _outwardDetails.SaveOutwardDetails(outwardDetails);
        }


    }
}
