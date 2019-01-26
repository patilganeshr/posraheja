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
    public class Employer
    {
        private readonly Database database;

        public Employer()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employer"></param>
        /// <returns></returns>
        private Int32 AddEmployer(Entities.Employer employer)
        {
            var employerId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertEmployer))
                {
                    database.AddInParameter(dbCommand, "@employer_id", DbType.Int32, employer.EmployerId);
                    database.AddInParameter(dbCommand, "@employer_name", DbType.String, employer.EmployerName);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, employer.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, employer.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    employerId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        employerId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return employerId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employer"></param>
        /// <returns></returns>
        public bool DeleteEmployer(Entities.Employer employer)
        {
            bool isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteEmployer))
                {
                    database.AddInParameter(dbCommand, "@employer_id", DbType.Int32, employer.EmployerId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, employer.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, employer.DeletedByIP);

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
        /// /
        /// </summary>
        /// <returns></returns>
        public List<Entities.Employer> GetAllEmployers()
        {
            var employers = new List<Entities.Employer>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllEmployers))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var employer = new Entities.Employer
                            {
                                EmployerId = DRE.GetNullableInt32(reader, "employer_id", 0),
                                EmployerName = DRE.GetNullableString(reader, "employer_name", null)
                            };

                            employers.Add(employer);
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

            return employers;
        }
                
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employerId"></param>
        /// <returns></returns>
        public Entities.Employer GetEmployerById(Int32 employerId)
        {
            var employer = new Entities.Employer();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetEmployerById))
            {
                database.AddInParameter(dbCommand, "@employer_id", DbType.Int32, employerId);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var _employer = new Entities.Employer
                        {
                            EmployerId = DRE.GetNullableInt32(reader, "employer_id", null),
                            EmployerName = DRE.GetNullableString(reader, "employer_name", null)
                        };

                        employer = _employer;
                    }
                }
            }

            return employer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employerName"></param>
        /// <returns></returns>
        public Entities.Employer GetEmployerByName(string employerName)
        {
            var employer = new Entities.Employer();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetEmployerByName))
            {
                database.AddInParameter(dbCommand, "@employer_name", DbType.String, employerName);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var _employer = new Entities.Employer
                        {
                            EmployerId = DRE.GetNullableInt32(reader, "employer_id", null),
                            EmployerName = DRE.GetNullableString(reader, "employer_name", null)
                        };

                        employer = _employer;
                    }
                }
            }

            return employer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employer"></param>
        /// <returns></returns>
        private Int32 UpdateEmployer(Entities.Employer employer)
        {
            var employerId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateEmployer))
                {
                    database.AddInParameter(dbCommand, "@employer_id", DbType.Int32, employer.EmployerId);
                    database.AddInParameter(dbCommand, "@employer_name", DbType.String, employer.EmployerName);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, employer.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, employer.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    employerId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        employerId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return employerId;
        }

        public Int32 SaveEmployer(Entities.Employer employer)
        {
            var employerId = 0;

            if (employer.EmployerId == null || employer.EmployerId == 0)
            {
                employerId = AddEmployer(employer);
            }
            else if (employer.ModifiedBy != null || employer.ModifiedBy > 0)
            {
                employerId = UpdateEmployer(employer);
            }
            else if (employer.IsDeleted == true)
            {
                var result = DeleteEmployer(employer);
            }

            return employerId;
        }
    }
}
