using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class TypeOfTransferController : ApiController
    {
        private readonly Business.TypeOfTransfer _typeOfTransfer;

        public TypeOfTransferController()
        {
            _typeOfTransfer = new Business.TypeOfTransfer();
        }

        [Route("GetTransferTypes")]
        public List<Entities.TypeOfTransfer> GetTransferTypes()
        {
            return _typeOfTransfer.GetTransferTypes();
        }
    }
}
