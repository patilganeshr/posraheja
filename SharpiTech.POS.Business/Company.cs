﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class Company
    {
        private readonly DataModel.Company _company;

        public Company()
        {
            _company = new DataModel.Company();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.Company> GetAllCompanies()
        {
            return _company.GetAllCompanies();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public Entities.Company GetCompanyDetailsByCompanyId(Int32 companyId)
        {
            return _company.GetCompanyDetailsByCompanyId(companyId);
        }

    }
}