using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class StateController : ApiController
    {
        private readonly Business.State _state;

        public StateController()
        {
            _state = new Business.State();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetStateByCountryId/{countryId}")]
        public List<Entities.State> GetStateByCountryId(Int32 countryId)
        {
            return _state.GetStateByCountryId(countryId);
        }
    }
}
