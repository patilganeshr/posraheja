using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class ColorController : ApiController
    {
        private readonly Business.Color _color;

        public ColorController()
        {
            _color = new Business.Color();
        }

        [Route("GetAllColorsName")]
        public List<Entities.Color> GetAllColorsName()
        {
            return _color.GetAllColorsName();
        }

    }
}
