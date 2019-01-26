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
    public class JobWorkReport
    {
        private readonly Database database;

        public JobWorkReport()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.JobWorkItemsBalanceQtyReport> GetBalanceQtyDetails()
        {
            var balanceQtyList = new List<Entities.JobWorkItemsBalanceQtyReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetJobWorkItemsBalanceQty))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var listItem = new Entities.JobWorkItemsBalanceQtyReport()
                            {
                                JobWorkId = DRE.GetNullableInt32(reader, "job_work_id", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                                PurchaseBillDate = DRE.GetNullableString(reader, "purchase_bill_date", null),
                                BaleNo = DRE.GetNullableString(reader, "bale_no", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                PurchaseItem = DRE.GetNullableString(reader, "purchase_item", null),
                                PurchaseQty = DRE.GetNullableDecimal(reader, "purchase_qty", null),
                                ChallanNo = DRE.GetNullableString(reader, "challan_no", null),
                                ChallanDate = DRE.GetNullableString(reader, "challan_date", null),
                                SentMtrs = DRE.GetNullableDecimal(reader, "sent_mtrs", null),
                                KaragirName = DRE.GetNullableString(reader, "karagir_name", null),
                                KaragirBillNo = DRE.GetNullableString(reader, "karagir_bill_no", null),
                                UsedMtrs = DRE.GetNullableDecimal(reader, "used_mtrs", null),
                                BalanceMtrs = DRE.GetNullableDecimal(reader, "balance_mtrs", null)
                            };

                            balanceQtyList.Add(listItem);
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

            return balanceQtyList;
        }


    }
}
