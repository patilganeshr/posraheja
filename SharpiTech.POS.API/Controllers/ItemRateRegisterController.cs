using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class ItemRateRegisterController : ApiController
    {
        private readonly Business.ItemRateRegister _itemRateRegister;

        public ItemRateRegisterController()
        {
            _itemRateRegister = new Business.ItemRateRegister();
        }

        /// <summary>
        /// Get Item Rate Register
        /// </summary>
        /// <returns></returns>
        [Route("GetItemRateRegister")]
        public List<Entities.ItemRateRegister> GetItemRateRegister()
        {
            return _itemRateRegister.GetItemRateRegister();
        }

        [Route("GetItemRateRegisterByWorkingPeriod/{workingPeriodId}")]
        public List<Entities.ItemRateRegister> GetItemRateRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            return _itemRateRegister.GetItemRateRegisterByWorkingPeriod(workingPeriodId);
        }

        [Route("GetItemMarginByCategorywiseQualitywiseCostwise")]
        public List<Entities.ItemMargin> GetItemMarginByCategorywiseQualitywiseCostwise()
        {
            return _itemRateRegister.GetItemMarginByCategorywiseQualitywiseCostwise();
        }


    }
}
