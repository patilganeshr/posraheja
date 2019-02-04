﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class Employer
    {
        private readonly DataModel.Employer _employer;

        public Employer()
        {
            _employer = new DataModel.Employer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employer"></param>
        /// <returns></returns>
        public Int32 SaveEmployer(Entities.Employer employer)
        {
            return _employer.SaveEmployer(employer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employer"></param>
        /// <returns></returns>
        public bool DeleteEmployer(Entities.Employer employer)
        {
            return _employer.DeleteEmployer(employer);
        }

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        public List<Entities.Employer> GetAllEmployers()
        {
            return _employer.GetAllEmployers();
        }
                
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employerId"></param>
        /// <returns></returns>
        public Entities.Employer GetEmployerById(Int32 employerId)
        {
            return _employer.GetEmployerById(employerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employerName"></param>
        /// <returns></returns>
        public Entities.Employer GetEmployerByName(string employerName)
        {
            return _employer.GetEmployerByName(employerName);
        }

    }
}