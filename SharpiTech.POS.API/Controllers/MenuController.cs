using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class MenuController : ApiController
    {
        private readonly Business.Menu _menu;

        public MenuController()
        {
            _menu = new Business.Menu();
        }

        /// <summary>ssss
        /// Gets list of menus by role id.
        /// </summary>
        /// <param name="roleId">Specifies the role id.</param>
        /// <returns>A collection of menus.</returns>
        [Route("GetMenusByRoleId")]
        public List<Entities.Menu> GetMenusByRoleId(Int32 roleId)
        {
            return _menu.GetMenusByRoleId(roleId);
        }
    }
}
