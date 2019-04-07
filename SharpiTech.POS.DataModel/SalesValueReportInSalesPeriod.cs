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

        public List<Entities.SalesByValueReportInSalesPeriod> GetSalesByValueReportInSalesPeriods(Entities.SalesByValueReportInSalesPeriod salesByValueReport)
        {
            var salesByValueReportList = new List<Entities.SalesByValueReportInSalesPeriod>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesByValueReportInSalesPeriod))
                {
                    database.AddInParameter(dbCommand, "@brand_id", DbType.Int32, salesByValueReport.BrandId);
                    database.AddInParameter(dbCommand, "@item_category_id", DbType.Int32, salesByValueReport.ItemCategoryId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesByValueReport.ItemId);
                    database.AddInParameter(dbCommand, "@salesman_id", DbType.Int32, salesByValueReport.SalesmanId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesValueReport = new Entities.SalesByValueReportInSalesPeriod
                            {
                                BrandName = DRE.GetNullableString(reader, "brand_name", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                SaleQty = DRE.GetNullableDecimal(reader, "sale_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                TotalItemAmount = DRE.GetNullableDecimal(reader, "total_item_amount", null),
                                SalesScheme = DRE.GetNullableString(reader, "sales_scheme", null),
                                Salesman = DRE.GetNullableString(reader, "salesman", null)
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
            finally
            {
                dbCommand = null;
            }

            return salesByValueReportList;
        }
    }
}
