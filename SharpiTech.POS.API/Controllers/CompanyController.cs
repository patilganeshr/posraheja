using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly Business.Company _company;

        public CompanyController()
        {
            _company = new Business.Company();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllCompanies")]
        public List<Entities.Company> GetAllCompanies()
        {
            return _company.GetAllCompanies();
        }


        [Route("GetCompanyDetailsByCompanyId/{companyId}")]
        public Entities.Company GetCompanyDetailsByCompanyId(Int32 companyId)
        {
            return _company.GetCompanyDetailsByCompanyId(companyId);
        }

    }
}