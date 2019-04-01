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
    public class SalesSchemeRegister
    {
        private readonly Database database;

        public SalesSchemeRegister()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.SalesSchemeRegister> GetSalesSchemesRegister()
        {
            var salesSchemes = new List<Entities.SalesSchemeRegister>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesSchemesRegister))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesSchemeRegister = new Entities.SalesSchemeRegister
                            {
                                BrandName = DRE.GetNullableString(reader, "brand_name", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),                                
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                DiscountPercent = DRE.GetNullableDecimal(reader, "discount_percent", null),
                                DiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null),
                                MaxDiscountAmount = DRE.GetNullableDecimal(reader, "max_discount_amount", null),
                                SaleStartDate = DRE.GetNullableString(reader, "sale_start_date", null),
                                SaleEndDate = DRE.GetNullableString(reader, "sale_end_date", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                SalesSchemeId = DRE.GetNullableInt32(reader, "sales_scheme_id", 0),
                                BrandId = DRE.GetNullableInt32(reader, "brand_id", 0),
                                ItemCategoryId = DRE.GetNullableInt32(reader, "item_category_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null)
                            };

                            salesSchemes.Add(salesSchemeRegister);
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

    }
}
