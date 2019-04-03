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
    public class SalesBillItemSalesScheme
    {
        private readonly Database database;

        public SalesBillItemSalesScheme()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.SalesBillItemSalesScheme> GetSalesSchemeDetails(Int32 salesBillItemId)
        {
            var salesBillItemSalesSchemes = new List<Entities.SalesBillItemSalesScheme>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillItemsSalesSchemeDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, salesBillItemId);
                    
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesBillItemSalesScheme = new Entities.SalesBillItemSalesScheme
                            {
                                SalesSchemeId = DRE.GetNullableInt32(reader, "sales_scheme_id", 0),
                                SchemeName = DRE.GetNullableString(reader, "sales_scheme", null),
                                DiscountPercent = DRE.GetNullableDecimal(reader, "discount_percent", null),
                                DiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null)
                            };

                            salesBillItemSalesSchemes.Add(salesBillItemSalesScheme);
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

            return salesBillItemSalesSchemes;
        }


    }
}
