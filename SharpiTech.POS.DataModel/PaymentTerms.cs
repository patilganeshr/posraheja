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
    public class PaymentTerms
    {
        private readonly Database database;

        public PaymentTerms()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddPaymentTerms (Entities.PaymentTerms paymentTerms)
        {
            var paymentTermId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPaymentTerms))
                {
                    database.AddInParameter(dbCommand, "@payment_term_id", DbType.Int32, paymentTerms.PaymentTermId);
                    database.AddInParameter(dbCommand, "@term_short_code", DbType.String, paymentTerms.TermShortCode);
                    database.AddInParameter(dbCommand, "@term_short_desc", DbType.String, paymentTerms.TermShortDesc);
                    database.AddInParameter(dbCommand, "@term_meaning", DbType.String, paymentTerms.TermMeaning);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, paymentTerms.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, paymentTerms.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    paymentTermId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        paymentTermId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return paymentTermId;
        }

        private bool DeletePaymentTerms(Entities.PaymentTerms paymentTerms)
        {
            bool IsPaymentTermDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePaymentTerms))
                {
                    database.AddInParameter(dbCommand, "@payment_term_id", DbType.Int32, paymentTerms.PaymentTermId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, paymentTerms.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, paymentTerms.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsPaymentTermDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsPaymentTermDeleted;
        }

        private Int32 UpdatePaymentTerms(Entities.PaymentTerms paymentTerms)
        {
            var paymentTermId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePaymentTerms))
                {
                    database.AddInParameter(dbCommand, "@payment_term_id", DbType.Int32, paymentTerms.PaymentTermId);
                    database.AddInParameter(dbCommand, "@term_short_code", DbType.String, paymentTerms.TermShortCode);
                    database.AddInParameter(dbCommand, "@term_short_desc", DbType.String, paymentTerms.TermShortDesc);
                    database.AddInParameter(dbCommand, "@term_meaning", DbType.String, paymentTerms.TermMeaning);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, paymentTerms.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, paymentTerms.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    paymentTermId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        paymentTermId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return paymentTermId;
        }


        public List<Entities.PaymentTerms> GetAllPaymentTerms()
        {

            var paymentTerms = new List<Entities.PaymentTerms>();


            DbCommand dbCommand = null;

            try {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllPaymentTerms))
                {
                    using(IDataReader dataReader = database.ExecuteReader(dbCommand))
                    {
                        while (dataReader.Read())
                        {
                            var paymentTerm = new Entities.PaymentTerms()
                            {
                                PaymentTermId = DRE.GetNullableInt32(dataReader, "payment_term_id", null),
                                TermShortCode = DRE.GetNullableString(dataReader, "term_short_code", null),
                                TermShortDesc = DRE.GetNullableString(dataReader, "term_short_desc", null),
                                TermMeaning = DRE.GetNullableString(dataReader, "term_meaning", null)
                            };

                            paymentTerms.Add(paymentTerm);
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


            return paymentTerms;
        }

        public Int32 SavePaymentTerms(Entities.PaymentTerms paymentTerms)
        {
            var paymentTermsId = 0;

            if (paymentTerms.PaymentTermId == null || paymentTerms.PaymentTermId == 0)
            {
                paymentTermsId = AddPaymentTerms(paymentTerms);
            }
            else if (paymentTerms.IsDeleted == true)
            {
                paymentTermsId = Convert.ToInt32(DeletePaymentTerms(paymentTerms));
            }
            else if (paymentTerms.ModifiedBy > 0 || paymentTerms.ModifiedBy != null)
            {
                paymentTermsId = UpdatePaymentTerms(paymentTerms);
            }

            return paymentTermsId;
        }

    }
}
