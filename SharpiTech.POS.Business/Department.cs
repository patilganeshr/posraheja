using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class Department
    {
        private readonly DataModel.Department _department;

        public Department()
        {
            _department = new DataModel.Department();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public Int32 SaveDepartment(Entities.Department department)
        {
            return _department.SaveDepartment(department);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public bool DeleteDepartment(Entities.Department department)
        {
            return _department.DeleteDepartment(department);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.Department> GetAllDepartments()
        {
            return _department.GetAllDepartments();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public Entities.Department GetDepartmentById(Int32 departmentId)
        {
            return _department.GetDepartmentById(departmentId);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public Entities.Department GetDepartmentByName(string departmentName)
        {
            return _department.GetDepartmentByName(departmentName);
        }

    }
}
