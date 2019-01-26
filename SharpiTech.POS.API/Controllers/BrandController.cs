using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class BrandController : ApiController
    {
        private readonly Business.Brand _brand;

        public BrandController()
        {
            _brand = new Business.Brand();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddBrand")]
        public Int32 AddBrand(Entities.Brand brand)
        {
            return _brand.AddBrand(brand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteBrand")]
        public bool DeleteBrand(Entities.Brand brand)
        {
            return _brand.DeleteBrand(brand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [Route("UpdateBrand")]
        public Int32 UpdateBrand(Entities.Brand brand)
        {
            return _brand.UpdateBrand(brand);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllBrands")]
        public List<Entities.Brand> GetAllBrands()
        {
            return _brand.GetAllBrands();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [Route("GetBrandById/{brandId}")]
        public Entities.Brand GetBrandById(Int32 brandId)
        {
            return _brand.GetBrandById(brandId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brandName"></param>
        /// <returns></returns>
        [Route("GetBrandByName/{brandName}")]
        public Entities.Brand GetBrandByName(string brandName)
        {
            return _brand.GetBrandByName(brandName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveBrand")]
        public Int32 SaveBrand(Entities.Brand brand)
        {
            return _brand.SaveBrand(brand);
        }

    }
}
