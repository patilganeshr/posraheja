using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class GSTCategory
    {
        private readonly DataModel.GSTCategory _gstCategory;

        public GSTCategory()
        {
            _gstCategory = new DataModel.GSTCategory();
        }

        
        public List<Entities.GSTCategory> GetAllGSTCategories()
        {
            return _gstCategory.GetAllGSTCategories();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gstCategories"></param>
        /// <returns></returns>
        public Int32 SaveGSTCategory(List<Entities.GSTCategory> gstCategories)
        {
            return _gstCategory.SaveGSTCategory(gstCategories);
        }

    }
}
