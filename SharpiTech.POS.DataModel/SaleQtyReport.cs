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
    public class SaleQtyReport
    {
        private readonly Database database;

        public SaleQtyReport()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// Get Stock as On Date
        /// </summary>
        /// <returns>Will return a list of Stock Report.</returns>
        public List<Entities.SaleQtyReport> GetSaleQtyOfAllItemCategories()
        {
            var saleQtyList = new List<Entities.SaleQtyReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSaleQtyOfAllItemCategories))
                {

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var saleQty = new Entities.SaleQtyReport
                            {
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                MonthName = DRE.GetNullableString(reader, "month_name", null),
                                ItemCategoryId = DRE.GetNullableInt32(reader, "item_category_id", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                SaleQty = DRE.GetNullableDecimal(reader, "sale_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null)
                            };

                            saleQtyList.Add(saleQty);
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

            return saleQtyList;
        }

        public List<Entities.SaleQtyReport> GetSaleQtyOfAllItemCategoriesAndItemQualities()
        {
            var saleQtyList = new List<Entities.SaleQtyReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSaleQtyOfAllItemCategoriesAndItemQualities))
                {

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var saleQty = new Entities.SaleQtyReport
                            {
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                MonthName = DRE.GetNullableString(reader, "month_name", null),
                                ItemCategoryId = DRE.GetNullableInt32(reader, "item_category_id", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                SaleQty = DRE.GetNullableDecimal(reader, "sale_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null)
                            };

                            saleQtyList.Add(saleQty);
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

            return saleQtyList;
        }

        public List<Entities.SaleQtyReport> GetSaleQtyOfAllItemCategoriesItemQualitiesAndItem()
        {
            var saleQtyList = new List<Entities.SaleQtyReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSaleQtyOfAllItemCategoriesItemQualitiesAndItems))
                {

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var saleQty = new Entities.SaleQtyReport
                            {
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                MonthName = DRE.GetNullableString(reader, "month_name", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                SaleQty = DRE.GetNullableDecimal(reader, "sale_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                CompanyId = DRE.GetNullableInt32(reader,"company_id", null),
                                BranchId = DRE.GetNullableInt32(reader,"branch_id", null),
                                MonthId = DRE.GetNullableInt32(reader,"month_id", null),
                                SaleTypeId = DRE.GetNullableInt32(reader,"sale_type_id", null),
                                ItemCategoryId = DRE.GetNullableInt32(reader, "item_category_id", null),
                                ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null)
                            };

                            saleQtyList.Add(saleQty);
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

            return saleQtyList;
        }


    }
}
