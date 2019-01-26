using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class CustomerCategory
    {
        private readonly DataModel.CustomerCategory _customerCategory;

        public CustomerCategory()
        {
            _customerCategory = new DataModel.CustomerCategory();
        }

        public List<Entities.CustomerCategory> GetAllCustomerCategories()
        {
            return _customerCategory.GetAllCustomerCategories();
        }

        public Entities.CustomerCategory GetCustomerCategoryByCustomerCategoryId(Int32 customerCategoryId)
        {
            return _customerCategory.GetCustomerCategoryByCustomerCategoryId(customerCategoryId);
        }

        public Int32 SaveCustomerCategory(Entities.CustomerCategory customerCategory)
        {
            return _customerCategory.SaveCustomerCategory(customerCategory);
        }

    }
}
