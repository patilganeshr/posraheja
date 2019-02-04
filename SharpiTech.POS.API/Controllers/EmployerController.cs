﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class EmployerController : ApiController
    {
        private readonly Business.Employer _employer;

        public EmployerController()
        {
            _employer = new Business.Employer();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveEmployer")]
        public Int32 SaveEmployer(Entities.Employer employer)
        {
            return _employer.SaveEmployer(employer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteEmployer")]
        public bool DeleteEmployer(Entities.Employer employer)
        {
            return _employer.DeleteEmployer(employer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllEmployers")]
        public List<Entities.Employer> GetAllEmployers()
        {
            return _employer.GetAllEmployers();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employerId"></param>
        /// <returns></returns>
        [Route("GetEmployerById/{employerId}")]
        public Entities.Employer GetEmployerById(Int32 employerId)
        {
            return _employer.GetEmployerById(employerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employerName"></param>
        /// <returns></returns>
        [Route("GetEmployerByName/{employerName}")]
        public Entities.Employer GetEmployerByName(string employerName)
        {
            return _employer.GetEmployerByName(employerName);
        }

    }
}