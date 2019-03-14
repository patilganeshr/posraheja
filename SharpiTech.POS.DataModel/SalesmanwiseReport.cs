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
using System.Reflection;

namespace SharpiTech.POS.DataModel
{
    public class SalesmanwiseReport
    {
        private readonly Database database;

        public SalesmanwiseReport()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.SalesmanwiseReport> GetDailySalesQtyReport(Int32? salesmanId, string salesBillDate)
        {
            var salesmanwiseReportList = new List<Entities.SalesmanwiseReport>();
            
            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesmanwiseDailySalesQtyReport))
                {
                    database.AddInParameter(dbCommand, "@salesman_id", DbType.Int32, salesmanId);
                    database.AddInParameter(dbCommand, "@sales_bill_date", DbType.String, salesBillDate);

                    using(IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read()) {

                            var salesmanwiseReport = new Entities.SalesmanwiseReport()
                            {
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                Salesman = DRE.GetNullableString(reader, "salesman", null),
                                SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),
                                MonthName = DRE.GetNullableString(reader, "month_name", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                SaleQty = DRE.GetNullableDecimal(reader, "sale_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                MonthId = DRE.GetNullableInt32(reader, "month_id", null),
                                SaleTypeId = DRE.GetNullableInt32(reader, "sale_type_id", null),
                                ItemCategoryId = DRE.GetNullableInt32(reader, "item_category_id", null),
                                ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null)
                            };

                            salesmanwiseReportList.Add(salesmanwiseReport);
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

            return salesmanwiseReportList;

        }

        public List<Entities.SalesmanwiseReport> GetDailySalesQtyReportWithSaleRateAndPurchaseRate(Int32? salesmanId, string salesBillDate)
        {
            var salesmanwiseReportList = new List<Entities.SalesmanwiseReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesmanwiseDailySalesQtyReportWithSaleRateAndPurchaseRate))
                {
                    database.AddInParameter(dbCommand, "@salesman_id", DbType.Int32, salesmanId);
                    database.AddInParameter(dbCommand, "@sales_bill_date", DbType.String, salesBillDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {

                            var salesmanwiseReport = new Entities.SalesmanwiseReport()
                            {
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                Salesman = DRE.GetNullableString(reader, "salesman", null),
                                SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),
                                MonthName = DRE.GetNullableString(reader, "month_name", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                SaleQty = DRE.GetNullableDecimal(reader, "sale_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                SaleRate = DRE.GetNullableDecimal(reader,"sale_rate", null),
                                PurchaseRate =DRE.GetNullableDecimal(reader, "purchase_rate", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                MonthId = DRE.GetNullableInt32(reader, "month_id", null),
                                SaleTypeId = DRE.GetNullableInt32(reader, "sale_type_id", null),
                                ItemCategoryId = DRE.GetNullableInt32(reader, "item_category_id", null),
                                ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null)
                            };

                            salesmanwiseReportList.Add(salesmanwiseReport);
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

            return salesmanwiseReportList;

        }


        public List<Entities.SalesmanwiseReport> GetSalesmanwiseItemwiseDailySalesValueReport(Int32? salesmanId, string fromDate, string toDate)
        {
            var salesmanwiseReportList = new List<Entities.SalesmanwiseReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesmanwiseItemwiseDailySalesValueReport))
                {
                    database.AddInParameter(dbCommand, "@salesman_id", DbType.Int32, salesmanId);
                    database.AddInParameter(dbCommand, "@from_date", DbType.String, fromDate);
                    database.AddInParameter(dbCommand, "@to_date", DbType.String, toDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {

                            var salesmanwiseReport = new Entities.SalesmanwiseReport()
                            {
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                Salesman = DRE.GetNullableString(reader, "salesman", null),
                                SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),
                                MonthName = DRE.GetNullableString(reader, "month_name", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                SaleValue = DRE.GetNullableDecimal(reader, "sale_value", null),
                                WholesaleValue = DRE.GetNullableDecimal(reader, "wholesale_value", null),
                                RetailValue = DRE.GetNullableDecimal(reader, "retail_value", null)
                            };

                            salesmanwiseReportList.Add(salesmanwiseReport);
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

            return salesmanwiseReportList;

        }

        

    }
}
