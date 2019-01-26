using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class Brand
    {
        private readonly DataModel.Brand _brand;

        public Brand()
        {
            _brand = new DataModel.Brand();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public Int32 AddBrand(Entities.Brand brand)
        {
            return _brand.AddBrand(brand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public bool DeleteBrand(Entities.Brand brand)
        {
            return _brand.DeleteBrand(brand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public Int32 UpdateBrand(Entities.Brand brand)
        {
            return _brand.UpdateBrand(brand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.Brand> GetAllBrands()
        {
            return _brand.GetAllBrands();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public Entities.Brand GetBrandById(Int32 brandId)
        {
            return _brand.GetBrandById(brandId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        public Entities.Brand GetBrandByName(string brandName)
        {
            return _brand.GetBrandByName(brandName);
        }

        public Int32 SaveBrand(Entities.Brand brand)
        {
            return _brand.SaveBrand(brand);
        }
    }
}
