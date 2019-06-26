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
    public class SalesValueReportInSalesPeriod
    {
        private readonly Database database;
        public SalesValueReportInSalesPeriod()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.SalesByValueReportInSalesPeriod> GetSalesByValueReportInSalesPeriods(Entities.SalesByValueReportInSalesPeriod salesByValueReportInSalesPeriod)
        {
            var salesByValueReportList = new List<Entities.SalesByValueReportInSalesPeriod>();

            try
            {
                using (DbCommand dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesByValueReportInSalesPeriod))
                {
                    database.AddInParameter(dbCommand, "@company_name", DbType.String, salesByValueReportInSalesPeriod.CompanyName);
                    database.AddInParameter(dbCommand, "@branch_name", DbType.String, salesByValueReportInSalesPeriod.BranchName);
                    database.AddInParameter(dbCommand, "@sale_type", DbType.String, salesByValueReportInSalesPeriod.SaleType);
                    database.AddInParameter(dbCommand, "@brand_name", DbType.String, salesByValueReportInSalesPeriod.BrandName);
                    database.AddInParameter(dbCommand, "@item_category_name", DbType.String, salesByValueReportInSalesPeriod.ItemCategoryName);
                    database.AddInParameter(dbCommand, "@item_name", DbType.String, salesByValueReportInSalesPeriod.ItemName);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, salesByValueReportInSalesPeriod.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@min_discount_amount", DbType.Decimal, salesByValueReportInSalesPeriod.MinDiscountAmount);
                    database.AddInParameter(dbCommand, "@max_discount_amount", DbType.Decimal, salesByValueReportInSalesPeriod.MaxDiscountAmount);
                    database.AddInParameter(dbCommand, "@sales_scheme", DbType.String, salesByValueReportInSalesPeriod.SalesScheme);
                    database.AddInParameter(dbCommand, "@salesman", DbType.String, salesByValueReportInSalesPeriod.Salesman);
                    database.AddInParameter(dbCommand, "@sales_bill_from_date", DbType.String, salesByValueReportInSalesPeriod.SalesBillFromDate);
                    database.AddInParameter(dbCommand, "@sales_bill_to_date", DbType.String, salesByValueReportInSalesPeriod.SalesBillToDate);
                    
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesByValueReport = new Entities.SalesByValueReportInSalesPeriod
                            {
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                BrandName = DRE.GetNullableString(reader, "brand_name", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                SaleQty = DRE.GetNullableDecimal(reader, "sale_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                SaleRate = DRE.GetNullableDecimal(reader, "sale_rate", null),
                                Amount = DRE.GetNullableDecimal(reader, "amount", null),
                                TotalItemAmount = DRE.GetNullableDecimal(reader, "total_item_amount", null),
                                DiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null),
                                SalesScheme = DRE.GetNullableString(reader, "sales_scheme", null),
                                SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),
                                Salesman = DRE.GetNullableString(reader, "salesman", null),
                                WholesaleRate = DRE.GetNullableDecimal(reader, "wholesale_rate", null),
                                RetailRate = DRE.GetNullableDecimal(reader, "retail_rate", null)
                            };

                            salesByValueReportList.Add(salesByValueReport);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return salesByValueReportList;
        }
    }
}
