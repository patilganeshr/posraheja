using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class VoucherSyncController : ApiController
    {

        private readonly Business.VoucherSync _voucherSync;

        public VoucherSyncController()
        {
            _voucherSync = new Business.VoucherSync();
        }

        [Route("GetVoucherType")]
        public List<Entities.VoucherType> GetVoucherType()
        {
            return _voucherSync.GetVoucherType();
        }

        [HttpPost]
        [Route("PostVoucherDataToTally")]
        public Int32 PostVoucherDataToTally(Entities.VoucherSync voucherSync)
        {
            return _voucherSync.PostVoucherDataToTally(voucherSync);
        }


    }
}
