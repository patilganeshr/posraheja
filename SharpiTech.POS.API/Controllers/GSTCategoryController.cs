using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class GSTCategoryController : ApiController
    {
        private readonly Business.GSTCategory _gstCategory;

        public GSTCategoryController()
        {
            _gstCategory = new Business.GSTCategory();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllGSTCategories")]
        public List<Entities.GSTCategory> GetAllGSTCategories()
        {
            return _gstCategory.GetAllGSTCategories();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gstCategories"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveGSTCategory")]
        public Int32 SaveGSTCategory(List<Entities.GSTCategory> gstCategories)
        {
            return _gstCategory.SaveGSTCategory(gstCategories);
        }

    }
}
