using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class CustomerCategoryController : ApiController
    {
        private readonly Business.CustomerCategory _customerCategory;

        public CustomerCategoryController()
        {
            _customerCategory = new Business.CustomerCategory();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllCustomerCategories")]
        public List<Entities.CustomerCategory> GetAllCustomerCategories()
        {
            return _customerCategory.GetAllCustomerCategories();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerCategoryId"></param>
        /// <returns></returns>
        [Route("GetCustomerCategoryByCustomerCategoryId/{customerCategoryId}")]
        public Entities.CustomerCategory GetCustomerCategoryByCustomerCategoryId(Int32 customerCategoryId)
        {
            return _customerCategory.GetCustomerCategoryByCustomerCategoryId(customerCategoryId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerCategory"></param>
        /// <returns></returns>
        [Route("SaveCustomerCategory/{customerCategory}")]
        public Int32 SaveCustomerCategory(Entities.CustomerCategory customerCategory)
        {
            return _customerCategory.SaveCustomerCategory(customerCategory);
        }

    }
}
