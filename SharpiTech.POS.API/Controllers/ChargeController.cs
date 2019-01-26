using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class ChargeController : ApiController
    {
        private readonly Business.Charge _charge;

        public ChargeController()
        {
            _charge = new Business.Charge();
        }
                
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllCharges")]
        public List<Entities.Charge> GetAllCharges()
        {
            return _charge.GetAllCharges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chargeId"></param>
        /// <returns></returns>
        [Route("GetChargeDetailsByChargeId/{chargeId}")]
        public Entities.Charge GetChargeDetailsByChargeId(Int32 chargeId)
        {
            return _charge.GetChargeDetailsByChargeId(chargeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chargeName"></param>
        /// <returns></returns>
        [Route("GetChargeDetailsByChargeName/{chargeName}")]
        public Entities.Charge GetChargeDetailsByChargeName(string chargeName)
        {
            return _charge.GetChargeDetailsByChargeName(chargeName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="charge"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveCharge")]
        public Int32 SaveCharge(Entities.Charge charge)
        {
            return _charge.SaveCharge(charge);
        }
    }
}
