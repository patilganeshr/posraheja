using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class DepartmentController : ApiController
    {
        private readonly Business.Department _department;

        public DepartmentController()
        {
            _department = new Business.Department();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveDepartment")]
        public Int32 SaveDepartment(Entities.Department department)
        {
            return _department.SaveDepartment(department);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteDepartment")]
        public bool DeleteDepartment(Entities.Department department)
        {
            return _department.DeleteDepartment(department);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllDepartments")]
        public List<Entities.Department> GetAllDepartments()
        {
            return _department.GetAllDepartments();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [Route("GetDepartmentById/{departmentId}")]
        public Entities.Department GetDepartmentById(Int32 departmentId)
        {
            return _department.GetDepartmentById(departmentId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        [Route("GetDepartmentByName/{departmentName}")]
        public Entities.Department GetDepartmentByName(string departmentName)
        {
            return _department.GetDepartmentByName(departmentName);
        }

    }
}
