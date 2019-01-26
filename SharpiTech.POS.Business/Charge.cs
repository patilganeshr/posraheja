using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class Charge
    {
        private readonly DataModel.Charge _charge;

        public Charge()
        {
            _charge = new DataModel.Charge();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.Charge> GetAllCharges()
        {
            return _charge.GetAllCharges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chargeId"></param>
        /// <returns></returns>
        public Entities.Charge GetChargeDetailsByChargeId (Int32 chargeId)
        {
            return _charge.GetChargeDetailsByChargeId(chargeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chargeName"></param>
        /// <returns></returns>
        public Entities.Charge GetChargeDetailsByChargeName(string chargeName)
        {
            return _charge.GetChargeDetailsByChargeName(chargeName);
        }
         
        public Int32 SaveCharge(Entities.Charge charge)
        {
            return _charge.SaveCharge(charge);
        }
    }
}
