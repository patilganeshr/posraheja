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
    public class CustomerCategory
    {
        private readonly Database database;

        public CustomerCategory()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddCustomerCategory(Entities.CustomerCategory customerCategory)
        {
            var customerCategoryId = 0;

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertCustomerCategory))
                {
                    database.AddInParameter(dbCommand, "@customer_category_id", DbType.Int32, customerCategory.CustomerCategoryId);
                    database.AddInParameter(dbCommand, "@customer_category_name", DbType.String,  customerCategory.CustomerCategoryName);
                    database.AddInParameter(dbCommand, "@customer_category_desc", DbType.String, customerCategory.CustomerCategoryDesc);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, customerCategory.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.Int32, customerCategory.CreatedByIP);                    
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    customerCategoryId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand,"@return_value") != DBNull.Value)
                    {
                        customerCategoryId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand = null;
            }

            return customerCategoryId;
        }

        private bool DeleteCustomerCategory(Entities.CustomerCategory customerCategory)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteCustomerCategory))
                {
                    database.AddInParameter(dbCommand, "@customer_category_id", DbType.Int32, customerCategory.CustomerCategoryId);
                    database.AddInParameter(dbCommand, "@customer_category_name", DbType.String, customerCategory.CustomerCategoryName);
                    database.AddInParameter(dbCommand, "@customer_category_desc", DbType.String, customerCategory.CustomerCategoryDesc);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, customerCategory.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.Int32, customerCategory.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return isDeleted;
        }

        public List<Entities.CustomerCategory> GetAllCustomerCategories()
        {
            var customerCategories = new List<Entities.CustomerCategory>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllCustomerCategories))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var customerCategory = new Entities.CustomerCategory
                            {
                                CustomerCategoryId = DRE.GetNullableInt32(reader, "customer_category_id", 0),
                                CustomerCategoryName = DRE.GetNullableString(reader, "customer_category_name", null),
                                CustomerCategoryDesc = DRE.GetNullableString(reader, "customer_category_desc", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            customerCategories.Add(customerCategory);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand = null;
            }

            return customerCategories;
        }

        public Entities.CustomerCategory GetCustomerCategoryByCustomerCategoryId(Int32 customerCategoryId)
        {
            var customerCategory = new Entities.CustomerCategory();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetCustomerCategoryById))
                {
                    database.AddInParameter(dbCommand, "@customer_category_id", DbType.Int32, customerCategoryId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var _customerCategory = new Entities.CustomerCategory
                            {
                                CustomerCategoryId = DRE.GetNullableInt32(reader, "customer_category_id", 0),
                                CustomerCategoryName = DRE.GetNullableString(reader, "customer_category_name", null),
                                CustomerCategoryDesc = DRE.GetNullableString(reader, "customer_category_desc", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null)
                            };

                             customerCategory = _customerCategory;
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

            return customerCategory;
        }

        private Int32 UpdateCustomerCategory(Entities.CustomerCategory customerCategory)
        {
            var customerCategoryId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateCustomerCategory))
                {
                    database.AddInParameter(dbCommand, "@customer_category_id", DbType.Int32, customerCategory.CustomerCategoryId);
                    database.AddInParameter(dbCommand, "@customer_category_name", DbType.String, customerCategory.CustomerCategoryName);
                    database.AddInParameter(dbCommand, "@customer_category_desc", DbType.String, customerCategory.CustomerCategoryDesc);
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    customerCategoryId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        customerCategoryId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return customerCategoryId;
        }

        public Int32 SaveCustomerCategory(Entities.CustomerCategory customerCategory)
        {
            var customerCategoryId = 0;

            if (customerCategory.CustomerCategoryId == null || customerCategory.CustomerCategoryId == 0)
            {
                customerCategoryId = AddCustomerCategory(customerCategory);
            }
            else if (customerCategory.IsDeleted == true)
            {
                customerCategoryId = Convert.ToInt32(DeleteCustomerCategory(customerCategory));
            }
            else if(customerCategory.ModifiedBy > 0 || customerCategory.ModifiedBy != null)
            {
                customerCategoryId = UpdateCustomerCategory(customerCategory);
            }

            return customerCategoryId;
        }


    }
}
