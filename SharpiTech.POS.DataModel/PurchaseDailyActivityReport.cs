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
    public class PurchaseDailyActivityReport
    {
        private readonly Database database;

        public PurchaseDailyActivityReport()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.PurchaseDailyActivityReport> GetPurchaseBillsDetails(Entities.PurchaseDailyActivityReport purchaseDailyActivityReport)
        {
            var purchaseDailyActivities = new List<Entities.PurchaseDailyActivityReport>();

            try
            {
                using (DbCommand dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseDailyActivityReport))
                {
                    database.AddInParameter(dbCommand, "@from_date", DbType.String, purchaseDailyActivityReport.FromDate);
                    database.AddInParameter(dbCommand, "@to_date", DbType.String, purchaseDailyActivityReport.ToDate);
                    database.AddInParameter(dbCommand, "@user_id", DbType.Int32, purchaseDailyActivityReport.UserId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseDailyActivity = new Entities.PurchaseDailyActivityReport()
                            {
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                                PurchaseBillDate = DRE.GetNullableString(reader, "purchase_bill_date", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                PurchaseCost = DRE.GetNullableDecimal(reader, "purchase_cost", null),
                                WholesaleRate = DRE.GetNullableDecimal(reader, "wholesale_rate", null),
                                RetailRate = DRE.GetNullableDecimal(reader, "retail_rate", null),
                                EntryBy = DRE.GetNullableString(reader, "entry_by", null)
                            };

                            purchaseDailyActivities.Add(purchaseDailyActivity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return purchaseDailyActivities;
        }

    }
}
