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
    public class SalesScheme
    {
        private readonly Database database;

        public SalesScheme()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddSalesScheme(Entities.SalesScheme salesScheme)
        {
            var salesSchemeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesScheme))
                {
                    database.AddInParameter(dbCommand, "@sales_scheme_id", DbType.Int32, salesScheme.SalesSchemeId);
                    database.AddInParameter(dbCommand, "@brand_id", DbType.Int32, salesScheme.BrandId);
                    database.AddInParameter(dbCommand, "@item_category_id", DbType.String, salesScheme.ItemCategoryId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesScheme.ItemId);
                    database.AddInParameter(dbCommand, "@discount_percent", DbType.Decimal, salesScheme.DiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, salesScheme.DiscountAmount);
                    database.AddInParameter(dbCommand, "@max_discount_amount", DbType.Decimal, salesScheme.MaxDiscountAmount);
                    database.AddInParameter(dbCommand, "@buy_qty", DbType.Int32, salesScheme.BuyQty);
                    database.AddInParameter(dbCommand, "@free_qty", DbType.String, salesScheme.FreeQty);
                    database.AddInParameter(dbCommand, "@sale_start_date", DbType.String, salesScheme.SaleStartDate);
                    database.AddInParameter(dbCommand, "@sale_end_date", DbType.String, salesScheme.SaleEndDate);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesScheme.BranchId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesScheme.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesScheme.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesSchemeId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesSchemeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesSchemeId;
        }

        private bool DeleteSalesScheme(Entities.SalesScheme salesScheme)
        {
            var IsSchemedDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesScheme))
                {
                    database.AddInParameter(dbCommand, "@sales_scheme_id", DbType.Int32, salesScheme.SalesSchemeId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesScheme.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesScheme.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsSchemedDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsSchemedDeleted;
        }

        private Int32 UpdateSalesScheme(Entities.SalesScheme salesScheme)
        {
            var salesSchemeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesScheme))
                {
                    database.AddInParameter(dbCommand, "@sales_scheme_id", DbType.Int32, salesScheme.SalesSchemeId);
                    database.AddInParameter(dbCommand, "@brand_id", DbType.Int32, salesScheme.BrandId);
                    database.AddInParameter(dbCommand, "@item_category_id", DbType.String, salesScheme.ItemCategoryId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesScheme.ItemId);
                    database.AddInParameter(dbCommand, "@discount_percent", DbType.Decimal, salesScheme.DiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, salesScheme.DiscountAmount);
                    database.AddInParameter(dbCommand, "@max_discount_amount", DbType.Decimal, salesScheme.MaxDiscountAmount);
                    database.AddInParameter(dbCommand, "@buy_qty", DbType.Int32, salesScheme.BuyQty);
                    database.AddInParameter(dbCommand, "@free_qty", DbType.String, salesScheme.FreeQty);
                    database.AddInParameter(dbCommand, "@sale_start_date", DbType.String, salesScheme.SaleStartDate);
                    database.AddInParameter(dbCommand, "@sale_end_date", DbType.String, salesScheme.SaleEndDate);            
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesScheme.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesScheme.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesSchemeId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesSchemeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesSchemeId;
        }

        public List<Entities.SalesScheme> GetAllSalesSchemes()
        {
            var salesSchemes = new List<Entities.SalesScheme>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllSalesSchemes))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesScheme = new Entities.SalesScheme
                            {
                                SalesSchemeId = DRE.GetNullableInt32(reader, "sales_scheme_id", 0),
                                BrandId = DRE.GetNullableInt32(reader, "brand_id", 0),
                                BrandName = DRE.GetNullableString(reader, "brand_name", null),
                                ItemCategoryId = DRE.GetNullableInt32(reader, "item_category_id", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                ItemId = DRE.GetNullableInt32(reader,"item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                DiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null),
                                DiscountPercent = DRE.GetNullableDecimal(reader, "discount_percent", null),
                                MaxDiscountAmount = DRE.GetNullableDecimal(reader, "max_discount_amount", null),
                                SaleStartDate = DRE.GetNullableString(reader, "sale_start_date", null),
                                SaleEndDate = DRE.GetNullableString(reader, "sale_end_date", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null)
                            };

                            salesSchemes.Add(salesScheme);
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

            return salesSchemes;
        }

        public Entities.SalesScheme GetSalesSchemeDetails(Int32 itemId, string effectiveDate)
        {
            var salesScheme = new Entities.SalesScheme();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesSchemeDetailsByItem))
                {
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);
                    database.AddInParameter(dbCommand, "@effective_date", DbType.String, effectiveDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesSchemeDetails = new Entities.SalesScheme
                            {
                                SalesSchemeId = DRE.GetNullableInt32(reader, "sales_scheme_id", 0),
                                SchemeName = DRE.GetNullableString(reader, "sales_scheme", null),
                                DiscountPercent = DRE.GetNullableDecimal(reader, "discount_percent", null),
                                DiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null)
                            };

                            salesScheme = salesSchemeDetails;
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

            return salesScheme;
        }

        public Int32 SaveSalesScheme(Entities.SalesScheme salesScheme)
        {
            var salesSchemeId = 0;


            if (salesScheme.SalesSchemeId == null || salesScheme.SalesSchemeId == 0)
            {
                salesSchemeId = AddSalesScheme(salesScheme);
            }
            else if (salesScheme.ModifiedBy != null || salesScheme.ModifiedBy > 0)
            {
                salesSchemeId = UpdateSalesScheme(salesScheme);
            }
            else if (salesScheme.IsDeleted == true)
            {
                var result = DeleteSalesScheme(salesScheme);

                if (result == true)
                {
                    salesSchemeId = 1;
                }
            }

            return salesSchemeId;
        }


    }
}
