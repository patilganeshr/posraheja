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
    public class SalesBillPaymentDetails
    {
        private readonly Database database;

        public SalesBillPaymentDetails()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddSalesBillPaymentDetails(Entities.SalesBillPaymentDetails paymentDetails)
        {
            var salesBillPaymentId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBillsPaymentDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_payment_id", DbType.Int32, paymentDetails.SalesBillPaymentId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, paymentDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@payment_settlement_id", DbType.Int32, paymentDetails.PaymentSettlementId);
                    database.AddInParameter(dbCommand, "@mode_of_payment_id", DbType.Int32, paymentDetails.ModeOfPaymentId);
                    database.AddInParameter(dbCommand, "@cash_amount", DbType.Decimal, paymentDetails.CashAmount);
                    database.AddInParameter(dbCommand, "@credit_card_no", DbType.String, paymentDetails.CreditCardNo);
                    database.AddInParameter(dbCommand, "@credit_card_amount", DbType.Decimal, paymentDetails.CreditCardAmount);
                    database.AddInParameter(dbCommand, "@cheque_no", DbType.String, paymentDetails.ChequeNo);
                    database.AddInParameter(dbCommand, "@cheque_date", DbType.String, paymentDetails.ChequeDate);
                    database.AddInParameter(dbCommand, "@cheque_drawn_on", DbType.String, paymentDetails.ChequeDrawnOn);
                    database.AddInParameter(dbCommand, "@cheque_amount  ", DbType.Decimal, paymentDetails.ChequeAmount);
                    database.AddInParameter(dbCommand, "@net_banking_reference_no", DbType.String, paymentDetails.NetBankingReferenceNo);
                    database.AddInParameter(dbCommand, "@net_banking_amount", DbType.Decimal, paymentDetails.NetBankingAmount);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, paymentDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, paymentDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, paymentDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillPaymentId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillPaymentId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillPaymentId;
        }

        private Int32 AddSalesBillPaymentDetails(Entities.SalesBillPaymentDetails paymentDetails, DbTransaction transaction)
        {
            var salesBillPaymentId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBillsPaymentDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_payment_id", DbType.Int32, paymentDetails.SalesBillPaymentId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, paymentDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@payment_settlement_id", DbType.Int32, paymentDetails.PaymentSettlementId);
                    database.AddInParameter(dbCommand, "@mode_of_payment_id", DbType.Int32, paymentDetails.ModeOfPaymentId);
                    database.AddInParameter(dbCommand, "@cash_amount", DbType.Decimal, paymentDetails.CashAmount);
                    database.AddInParameter(dbCommand, "@credit_card_no", DbType.String, paymentDetails.CreditCardNo);
                    database.AddInParameter(dbCommand, "@credit_card_amount", DbType.Decimal, paymentDetails.CreditCardAmount);
                    database.AddInParameter(dbCommand, "@cheque_no", DbType.String, paymentDetails.ChequeNo);
                    database.AddInParameter(dbCommand, "@cheque_date", DbType.String, paymentDetails.ChequeDate);
                    database.AddInParameter(dbCommand, "@cheque_drawn_on", DbType.String, paymentDetails.ChequeDrawnOn);
                    database.AddInParameter(dbCommand, "@cheque_amount  ", DbType.Decimal, paymentDetails.ChequeAmount);
                    database.AddInParameter(dbCommand, "@net_banking_reference_no", DbType.String, paymentDetails.NetBankingReferenceNo);
                    database.AddInParameter(dbCommand, "@net_banking_amount", DbType.Decimal, paymentDetails.NetBankingAmount);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, paymentDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, paymentDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, paymentDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillPaymentId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillPaymentId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillPaymentId;
        }

        private bool DeleteSalesBillPaymentDetails(Entities.SalesBillPaymentDetails paymentDetails)
        {
            var IsPaymentDetailsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBillsPaymentDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_payment_id", DbType.Int32, paymentDetails.SalesBillPaymentId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, paymentDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, paymentDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsPaymentDetailsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsPaymentDetailsDeleted;
        }

        private bool DeleteSalesBillPaymentDetails(Entities.SalesBillPaymentDetails paymentDetails, DbTransaction transaction)
        {
            var IsPaymentDetailsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBillsPaymentDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_payment_id", DbType.Int32, paymentDetails.SalesBillPaymentId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, paymentDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, paymentDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsPaymentDetailsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsPaymentDetailsDeleted;
        }

        public List<Entities.SalesBillPaymentDetails> GetPaymentDetailsBySalesBillId(Int32 salesBillId)
        {
            var salesBillPaymentDetails = new List<Entities.SalesBillPaymentDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillsPaymentDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var paymentDetails = new Entities.SalesBillPaymentDetails
                            {
                                SalesBillPaymentId = DRE.GetNullableInt32(reader, "sales_bill_payment_id", null),
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", 0),
                                PaymentSettlementId = DRE.GetNullableInt32(reader, "payment_settlement_id", null),
                                ModeOfPaymentId = DRE.GetNullableInt32(reader, "mode_of_payment_id", null),
                                CashAmount = DRE.GetNullableDecimal(reader, "cash_amount", null),
                                CreditCardNo = DRE.GetNullableString(reader, "credit_card_no", null),
                                CreditCardAmount = DRE.GetNullableDecimal(reader, "credit_card_amount", null),
                                ChequeNo = DRE.GetNullableString(reader, "cheque_no", null),
                                ChequeDate = DRE.GetNullableString(reader, "cheque_date", null),
                                ChequeDrawnOn = DRE.GetNullableString(reader, "cheque_drawn_on", null),
                                ChequeAmount = DRE.GetNullableDecimal(reader, "cheque_amount", null),
                                NetBankingReferenceNo = DRE.GetNullableString(reader, "net_banking_reference_no", null),
                                NetBankingAmount = DRE.GetNullableDecimal(reader, "net_banking_amount", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null)
                            };

                            salesBillPaymentDetails.Add(paymentDetails);
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

            return salesBillPaymentDetails;
        }

        private Int32 UpdateSalesBillPaymentDetails(Entities.SalesBillPaymentDetails paymentDetails)
        {
            var salesBillPaymentId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBillsPaymentDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_payment_id", DbType.Int32, paymentDetails.SalesBillPaymentId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, paymentDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@payment_settlement_id", DbType.Int32, paymentDetails.PaymentSettlementId);
                    database.AddInParameter(dbCommand, "@mode_of_payment_id", DbType.Int32, paymentDetails.ModeOfPaymentId);
                    database.AddInParameter(dbCommand, "@cash_amount", DbType.Decimal, paymentDetails.CashAmount);
                    database.AddInParameter(dbCommand, "@credit_card_no", DbType.String, paymentDetails.CreditCardNo);
                    database.AddInParameter(dbCommand, "@credit_card_amount", DbType.Decimal, paymentDetails.CreditCardAmount);
                    database.AddInParameter(dbCommand, "@cheque_no", DbType.String, paymentDetails.ChequeNo);
                    database.AddInParameter(dbCommand, "@cheque_date", DbType.String, paymentDetails.ChequeDate);
                    database.AddInParameter(dbCommand, "@cheque_drawn_on", DbType.String, paymentDetails.ChequeDrawnOn);
                    database.AddInParameter(dbCommand, "@cheque_amount  ", DbType.Decimal, paymentDetails.ChequeAmount);
                    database.AddInParameter(dbCommand, "@net_banking_reference_no", DbType.String, paymentDetails.NetBankingReferenceNo);
                    database.AddInParameter(dbCommand, "@net_banking_amount", DbType.Decimal, paymentDetails.NetBankingAmount);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, paymentDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, paymentDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, paymentDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillPaymentId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillPaymentId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillPaymentId;
        }

        private Int32 UpdateSalesBillPaymentDetails(Entities.SalesBillPaymentDetails paymentDetails, DbTransaction transaction)
        {
            var salesBillPaymentId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesBillsPaymentDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_payment_id", DbType.Int32, paymentDetails.SalesBillPaymentId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, paymentDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@payment_settlement_id", DbType.Int32, paymentDetails.PaymentSettlementId);
                    database.AddInParameter(dbCommand, "@mode_of_payment_id", DbType.Int32, paymentDetails.ModeOfPaymentId);
                    database.AddInParameter(dbCommand, "@cash_amount", DbType.Decimal, paymentDetails.CashAmount);
                    database.AddInParameter(dbCommand, "@credit_card_no", DbType.String, paymentDetails.CreditCardNo);
                    database.AddInParameter(dbCommand, "@credit_card_amount", DbType.Decimal, paymentDetails.CreditCardAmount);
                    database.AddInParameter(dbCommand, "@cheque_no", DbType.String, paymentDetails.ChequeNo);
                    database.AddInParameter(dbCommand, "@cheque_date", DbType.String, paymentDetails.ChequeDate);
                    database.AddInParameter(dbCommand, "@cheque_drawn_on", DbType.String, paymentDetails.ChequeDrawnOn);
                    database.AddInParameter(dbCommand, "@cheque_amount  ", DbType.Decimal, paymentDetails.ChequeAmount);
                    database.AddInParameter(dbCommand, "@net_banking_reference_no", DbType.String, paymentDetails.NetBankingReferenceNo);
                    database.AddInParameter(dbCommand, "@net_banking_amount", DbType.Decimal, paymentDetails.NetBankingAmount);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, paymentDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, paymentDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, paymentDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillPaymentId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillPaymentId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillPaymentId;
        }
        
        public Int32 SaveSalesBillPaymentDetails(Entities.SalesBillPaymentDetails paymentDetails, DbTransaction transaction)
        {
            var result = 0;

            if (paymentDetails.SalesBillPaymentId == null || paymentDetails.SalesBillPaymentId == 0)
            {
                result = AddSalesBillPaymentDetails(paymentDetails, transaction);
            }
            else if (paymentDetails.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesBillPaymentDetails(paymentDetails, transaction));
            }
            else if (paymentDetails.ModifiedBy > 0)
            {
                result = UpdateSalesBillPaymentDetails(paymentDetails, transaction);
            }

            return result;
        }

    }
}
