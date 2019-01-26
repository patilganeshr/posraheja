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
    public class PaymentSettlement
    {
        private readonly Database database;

        public PaymentSettlement()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.PaymentSettlement> GetPaymentSettlements()
        {
            var paymentSettlements = new List<Entities.PaymentSettlement>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPaymentSettlement))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var paymentSettlement = new Entities.PaymentSettlement
                            {
                                PaymentSettlementId = DRE.GetNullableInt32(reader, "payment_settlement_id", 0),
                                SettlementOfPayment = DRE.GetNullableString(reader, "payment_settlement", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null)
                            };

                            paymentSettlements.Add(paymentSettlement);
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

            return paymentSettlements;
        }
    }
}
