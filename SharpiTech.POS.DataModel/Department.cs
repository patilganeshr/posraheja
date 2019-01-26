using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using DRE = DataRecordExtensions.DataRecordExtensions;

namespace SharpiTech.POS.DataModel
{
    public class Department
    {
        private readonly Database database;

        public Department()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        private Int32 AddDepartment(Entities.Department department)
        {
            var departmentId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertDepartment))
                {
                    database.AddInParameter(dbCommand, "@department_id", DbType.Int32, department.DepartmentId);
                    database.AddInParameter(dbCommand, "@department_name", DbType.String, department.DepartmentName);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, department.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, department.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    departmentId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        departmentId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbCommand = null;
            }

            return departmentId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public bool DeleteDepartment(Entities.Department department)
        {
            bool isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteDepartment))
                {
                    database.AddInParameter(dbCommand, "@department_id", DbType.Int32, department.DepartmentId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, department.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, department.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbCommand = null;
            }

            return isDeleted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.Department> GetAllDepartments()
        {
            var departments = new List<Entities.Department>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllDepartments))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var department = new Entities.Department
                            {
                                DepartmentId = DRE.GetNullableInt32(reader, "department_id", 0),
                                DepartmentName = DRE.GetNullableString(reader, "department_name", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            departments.Add(department);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand = null;
            }

            return departments;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public Entities.Department GetDepartmentById(Int32 departmentId)
        {
            var department = new Entities.Department();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetDepartmentById))
            {
                database.AddInParameter(dbCommand, "@department_id", DbType.Int32, departmentId);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var _department = new Entities.Department
                        {
                            DepartmentId = DRE.GetNullableInt32(reader, "department_id", 0),
                            DepartmentName = DRE.GetNullableString(reader, "department_name", null)
                        };

                        department = _department;
                    }
                }
            }

            return department;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public Entities.Department GetDepartmentByName(string departmentName)
        {
            var department = new Entities.Department();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetDepartmentByName))
            {
                database.AddInParameter(dbCommand, "@department_name", DbType.String, departmentName);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var _department = new Entities.Department
                        {
                            DepartmentId = DRE.GetNullableInt32(reader, "department_id", 0),
                            DepartmentName = DRE.GetNullableString(reader, "department_name", null)
                        };

                        department = _department;
                    }
                }
            }

            return department;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        private Int32 UpdateDepartment(Entities.Department department)
        {
            var departmentId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateDepartment))
                {
                    database.AddInParameter(dbCommand, "@department_id", DbType.Int32, department.DepartmentId);
                    database.AddInParameter(dbCommand, "@department_name", DbType.String, department.DepartmentName);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, department.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, department.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    departmentId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        departmentId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbCommand = null;
            }

            return departmentId;
        }

        public Int32 SaveDepartment(Entities.Department department)
        {
            var departmentId = 0;

            if (department.DepartmentId == null || department.DepartmentId == 0)
            {
                departmentId = AddDepartment(department);
            }
            else if (department.ModifiedBy != null || department.ModifiedBy > 0)
            {
                departmentId = UpdateDepartment(department);
            }
            else if(department.IsDeleted ==true)
            {
                var result =DeleteDepartment(department);
            }

            return departmentId;
        }
    }
}
