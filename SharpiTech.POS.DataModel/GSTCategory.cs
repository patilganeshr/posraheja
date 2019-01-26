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
    public class GSTCategory
    {
        private readonly Database database;

        public GSTCategory()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddGSTCategory(Entities.GSTCategory gstCategory)
        {
            var gstCategoryId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertGSTCategory))
                {
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstCategory.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@gst_category", DbType.String, gstCategory.GSTCategoryName);
                    database.AddInParameter(dbCommand, "@hsn_code", DbType.String, gstCategory.HSNCode);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, gstCategory.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, gstCategory.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    gstCategoryId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        gstCategoryId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return gstCategoryId;
        }

        private Int32 AddGSTCategory(Entities.GSTCategory gstCategory, DbTransaction transaction)
        {
            var gstCategoryId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertGSTCategory))
                {
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstCategory.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@gst_category", DbType.String, gstCategory.GSTCategoryName);
                    database.AddInParameter(dbCommand, "@hsn_code", DbType.String, gstCategory.HSNCode);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, gstCategory.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, gstCategory.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    gstCategoryId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        gstCategoryId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return gstCategoryId;
        }

        private bool DeleteGSTCategory(Entities.GSTCategory gstCategory)
        {
            var IsDeleted = true;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteGSTCategory))
                {
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstCategory.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, gstCategory.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, gstCategory.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsDeleted;
        }

        private bool DeleteGSTCategory(Entities.GSTCategory gstCategory, DbTransaction transaction)
        {
            var IsDeleted = true;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteGSTCategory))
                {
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstCategory.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, gstCategory.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, gstCategory.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsDeleted;
        }

        public List<Entities.GSTCategory> GetAllGSTCategories()
        {
            var gstCategories = new List<Entities.GSTCategory>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllGSTCategories))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            GSTRate gstRate = new GSTRate();

                            var gstCategory = new Entities.GSTCategory
                            {
                                GSTCategoryId = DRE.GetNullableInt32(reader, "gst_category_id", 0),
                                GSTCategoryName = DRE.GetNullableString(reader, "gst_category", null),
                                HSNCode = DRE.GetNullableString(reader, "hsn_code", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                                GSTRates = gstRate.GetGSTRateByGSTCategoryId(DRE.GetInt32(reader, "gst_category_id"))
                            };

                            gstCategories.Add(gstCategory);
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

            return gstCategories;
        }

        private Int32 UpdateGSTCategory(Entities.GSTCategory gstCategory)
        {
            var gstCategoryId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateGSTCategory))
                {
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstCategory.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@gst_category", DbType.String, gstCategory.GSTCategoryName);
                    database.AddInParameter(dbCommand, "@hsn_code", DbType.String, gstCategory.HSNCode);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, gstCategory.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, gstCategory.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    gstCategoryId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        gstCategoryId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return gstCategoryId;
        }

        private Int32 UpdateGSTCategory(Entities.GSTCategory gstCategory, DbTransaction transaction)
        {
            var gstCategoryId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateGSTCategory))
                {
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstCategory.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@gst_category", DbType.String, gstCategory.GSTCategoryName);
                    database.AddInParameter(dbCommand, "@hsn_code", DbType.String, gstCategory.HSNCode);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, gstCategory.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, gstCategory.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    gstCategoryId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        gstCategoryId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return gstCategoryId;
        }

        public Int32 SaveGSTCategory(List<Entities.GSTCategory> gstCategories)
        {
            var gstCategoryId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var gstRateId = 0;

                        if (gstCategories.Count > 0)
                        {
                            foreach (Entities.GSTCategory gstCategory in gstCategories)
                            {
                                if (gstCategory.GSTCategoryId == null || gstCategory.GSTCategoryId == 0)
                                {
                                    gstCategoryId = AddGSTCategory(gstCategory, transaction);
                                }
                                else
                                {
                                    if (gstCategory.IsDeleted == true)
                                    {
                                        var result = DeleteGSTCategory(gstCategory, transaction);
                                    }
                                    else
                                    {
                                        if (gstCategory.ModifiedBy > 0 || gstCategory.ModifiedBy != null)
                                        {
                                            gstCategoryId = UpdateGSTCategory(gstCategory, transaction);
                                        }
                                    }
                                }

                                if (gstCategoryId > 0)
                                {
                                    foreach (Entities.GSTRate gstRate in gstCategory.GSTRates)
                                    {
                                        gstRate.GSTCategoryId = gstCategoryId;

                                        GSTRate gstRateDL = new GSTRate();

                                        gstRateId = gstRateDL.SaveGSTRate(gstRate, transaction);
                                    }
                                }

                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        db = null;
                    }
                }
            }

            return gstCategoryId;
        }

    }
}
