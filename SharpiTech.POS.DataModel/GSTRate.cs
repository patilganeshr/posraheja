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
    public class GSTRate
    {
        private readonly Database database;

        public GSTRate()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddGSTRate(Entities.GSTRate gstRate)
        {
            var gstRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertGSTRate))
                {
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, gstRate.GSTRateId);
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstRate.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@gst_name", DbType.String, gstRate.GSTName);
                    database.AddInParameter(dbCommand, "@gst_rate", DbType.Decimal, gstRate.Rate);
                    database.AddInParameter(dbCommand, "@sale_value_amount", DbType.Decimal, gstRate.SaleValueAmount);
                    database.AddInParameter(dbCommand, "@effective_from_date", DbType.String, gstRate.EffectiveFromDate);                    
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, gstRate.TaxId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, gstRate.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, gstRate.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    gstRateId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        gstRateId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return gstRateId;
        }

        private Int32 AddGSTRate(Entities.GSTRate gstRate, DbTransaction transaction)
        {
            var gstRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertGSTRate))
                {
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, gstRate.GSTRateId);
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstRate.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@gst_name", DbType.String, gstRate.GSTName);
                    database.AddInParameter(dbCommand, "@gst_rate", DbType.Decimal, gstRate.Rate);
                    database.AddInParameter(dbCommand, "@sale_value_amount", DbType.Decimal, gstRate.SaleValueAmount);
                    database.AddInParameter(dbCommand, "@effective_from_date", DbType.String, gstRate.EffectiveFromDate);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, gstRate.TaxId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, gstRate.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, gstRate.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    gstRateId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        gstRateId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return gstRateId;
        }

        private bool DeleteGSTRate(Entities.GSTRate gstRate)
        {
            var isDeleted = true;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteGSTRate))
                {
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, gstRate.GSTRateId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, gstRate.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, gstRate.DeletedByIP);

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

        private bool DeleteGSTRate(Entities.GSTRate gstRate, DbTransaction transaction)
        {
            var isDeleted = true;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteGSTRate))
                {
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, gstRate.GSTRateId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, gstRate.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, gstRate.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

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


        private Int32 UpdateGSTRate(Entities.GSTRate gstRate)
        {
            var gstRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateGSTRate))
                {
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, gstRate.GSTRateId);
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstRate.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@gst_name", DbType.String, gstRate.GSTName);
                    database.AddInParameter(dbCommand, "@gst_rate", DbType.Decimal, gstRate.Rate);
                    database.AddInParameter(dbCommand, "@sale_value_amount", DbType.Decimal, gstRate.SaleValueAmount);
                    database.AddInParameter(dbCommand, "@effective_from_date", DbType.String, gstRate.EffectiveFromDate);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, gstRate.TaxId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, gstRate.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, gstRate.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    gstRateId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        gstRateId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return gstRateId;
        }

        private Int32 UpdateGSTRate(Entities.GSTRate gstRate, DbTransaction transaction)
        {
            var gstRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateGSTRate))
                {
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, gstRate.GSTRateId);
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstRate.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@gst_name", DbType.String, gstRate.GSTName);
                    database.AddInParameter(dbCommand, "@gst_rate", DbType.Decimal, gstRate.Rate);
                    database.AddInParameter(dbCommand, "@sale_value_amount", DbType.Decimal, gstRate.SaleValueAmount);
                    database.AddInParameter(dbCommand, "@effective_from_date", DbType.String, gstRate.EffectiveFromDate);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, gstRate.TaxId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, gstRate.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, gstRate.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    gstRateId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        gstRateId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return gstRateId;
        }

        public List<Entities.GSTRate> GetGSTRateByGSTCategoryId(Int32 gstCategoryId)
        {
            var gstRates = new List<Entities.GSTRate>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetGSTRatesByGSTCategoryId))
                {
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstCategoryId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var gstRate = new Entities.GSTRate
                            {
                                GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", 0),
                                GSTCategoryId = DRE.GetNullableInt32(reader, "gst_category_id", 0),
                                GSTName = DRE.GetNullableString(reader, "gst_name", null),
                                Rate = DRE.GetNullableDecimal(reader, "gst_rate", 0),
                                EffectiveFromDate = DRE.GetNullableString(reader, "effective_from_date", null),
                                SaleValueAmount = DRE.GetNullableDecimal(reader, "sale_value_amount", null),
                                TaxId = DRE.GetNullableInt32(reader, "tax_id", 0),
                                TaxName = DRE.GetNullableString(reader, "tax_name", null),
                                guid = DRE.GetNullableGuid(reader,"row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", 0)
                            };

                            gstRates.Add(gstRate);
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

            return gstRates;
        }

        public Entities.GSTRate GetGSTRateByItemIdGSTApplicableAndSaleRate(Entities.GSTRate gstr)
        {
            var gstRate = new Entities.GSTRate();
            
            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetGSTRateByItemIdGSTApplicableAndSaleRate))
                {
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, gstr.ItemId);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, gstr.GSTApplicable);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Decimal, gstr.Rate);
                    database.AddInParameter(dbCommand, "@effective_date", DbType.String, gstr.EffectiveFromDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var _gstRate = new Entities.GSTRate
                            {
                                GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", 0),
                                Rate = DRE.GetNullableDecimal(reader, "gst_rate", 0),
                                TaxId = DRE.GetNullableInt32(reader, "tax_id", 0)
                            };

                            gstRate =_gstRate;
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

            return gstRate;
        }

        public Entities.GSTRate GetGSTRateByGSTCategoryIdGSTApplicableAndEffectiveDate(Entities.GSTRate gstRate)
        {
            var gstRateDetails = new Entities.GSTRate();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetGSTDetailsByGSTCategoryIdGSTAppicableAndEffectiveDate))
                {
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, gstRate.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, gstRate.GSTApplicable);
                    database.AddInParameter(dbCommand, "@effective_date", DbType.String, gstRate.EffectiveFromDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var gstDetails = new Entities.GSTRate
                            {
                                GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", 0),
                                TaxId = DRE.GetNullableInt32(reader, "tax_id", 0),
                                Rate = DRE.GetNullableDecimal(reader, "gst_rate", 0)                                                                
                            };

                            gstRateDetails = gstDetails;
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

            return gstRateDetails;
        }

        public Entities.GSTRate GetGSTRateByItemCategoryIdGSTApplicablePurchaseRateAndEffectiveDate(Entities.GSTRate gstRate)
        {
            var gstRateDetails = new Entities.GSTRate();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetGSTRateByItemCategoryIdGSTApplicableAndPurchaseRate))
                {
                    database.AddInParameter(dbCommand, "@item_category_id", DbType.Int32, gstRate.ItemCategoryId);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, gstRate.GSTApplicable);
                    database.AddInParameter(dbCommand, "@purchase_rate", DbType.Decimal, gstRate.Rate);
                    database.AddInParameter(dbCommand, "@effective_date", DbType.String, gstRate.EffectiveFromDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var gstDetails = new Entities.GSTRate
                            {
                                GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", 0),
                                TaxId = DRE.GetNullableInt32(reader, "tax_id", 0),
                                Rate = DRE.GetNullableDecimal(reader, "gst_rate", 0)
                            };

                            gstRateDetails = gstDetails;
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

            return gstRateDetails;
        }

        public Entities.GSTRate GetGSTApplicable(Int32 clientAddressId)
        {
            var gstRate = new Entities.GSTRate();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetGSTApplicable))
                {
                    database.AddInParameter(dbCommand, "@client_address_id", DbType.Int32, clientAddressId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var _gstRate = new Entities.GSTRate
                            {
                                GSTName = DRE.GetNullableString(reader, "gst_applicable", null)
                            };

                            gstRate = _gstRate;
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

            return gstRate;
        }

        public Int32 SaveGSTRate(Entities.GSTRate gstRate)
        {
            var gstRateId = 0;

            if (gstRate.GSTRateId == null || gstRate.GSTRateId == 0)
            {
                gstRateId = AddGSTRate(gstRate);
            }
            else if (gstRate.IsDeleted == true)
            {
                gstRateId = Convert.ToInt32(DeleteGSTRate(gstRate));
            }
            else if (gstRate.ModifiedBy > 0 || gstRate.ModifiedBy != null)
            {
                gstRateId = UpdateGSTRate(gstRate);
            }

            return gstRateId;
        }

        public Int32 SaveGSTRate(Entities.GSTRate gstRate, DbTransaction transaction)
        {
            var gstRateId = 0;

            if (gstRate.GSTRateId == null || gstRate.GSTRateId == 0)
            {
                gstRateId = AddGSTRate(gstRate,transaction);
            }
            else if (gstRate.IsDeleted == true)
            {
                gstRateId = Convert.ToInt32(DeleteGSTRate(gstRate));
            }
            else if (gstRate.ModifiedBy > 0 || gstRate.ModifiedBy != null)
            {
                gstRateId = UpdateGSTRate(gstRate);
            }

            return gstRateId;
        }



    }
}
