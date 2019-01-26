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
    public class PurchaseBillChargesDetails
    {
        private readonly Database database;

        public PurchaseBillChargesDetails()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddPurchaseBillCharges(Entities.PurchaseBillChargesDetails chargesDetails)
        {
            var PurchaseBillChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPurchaseBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_charge_id", DbType.Int32, chargesDetails.PurchaseBillChargeId);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, chargesDetails.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, chargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, chargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, chargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, chargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, chargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, chargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, chargesDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, chargesDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    PurchaseBillChargeId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        PurchaseBillChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return PurchaseBillChargeId;
        }

        private Int32 AddPurchaseBillCharges(Entities.PurchaseBillChargesDetails chargesDetails, DbTransaction transaction)
        {
            var PurchaseBillChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPurchaseBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_charge_id", DbType.Int32, chargesDetails.PurchaseBillChargeId);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, chargesDetails.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, chargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, chargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, chargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, chargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, chargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, chargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, chargesDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, chargesDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    PurchaseBillChargeId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        PurchaseBillChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return PurchaseBillChargeId;
        }

        private bool DeletePurchaseBillCharges(Entities.PurchaseBillChargesDetails chargesDetails)
        {
            var IsPurchaseBillChargeIsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePurchaseBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_charge_id", DbType.Int32, chargesDetails.PurchaseBillChargeId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, chargesDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, chargesDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsPurchaseBillChargeIsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsPurchaseBillChargeIsDeleted;
        }

        private bool DeletePurchaseBillCharges(Entities.PurchaseBillChargesDetails chargesDetails, DbTransaction transaction)
        {
            var IsPurchaseBillChargeIsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePurchaseBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_charge_id", DbType.Int32, chargesDetails.PurchaseBillChargeId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, chargesDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, chargesDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsPurchaseBillChargeIsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsPurchaseBillChargeIsDeleted;
        }

        public List<Entities.PurchaseBillChargesDetails> GetBillChargesDetailsByPurchaseBillId(Int32 PurchaseBillId)
        {
            var PurchaseBillCharges = new List<Entities.PurchaseBillChargesDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, PurchaseBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var chargesDetails = new Entities.PurchaseBillChargesDetails
                            {
                                PurchaseBillChargeId = DRE.GetNullableInt32(reader, "purchase_bill_charge_id", null),
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", 0),
                                ChargeId = DRE.GetNullableInt32(reader, "charge_id", null),
                                ChargeName = DRE.GetNullableString(reader, "charge_name", null),
                                ChargeAmount = DRE.GetNullableDecimal(reader, "charge_amount", null),
                                IsTaxInclusive = DRE.GetNullableBoolean(reader, "is_tax_inclusive", null),
                                GSTRateId    = DRE.GetNullableInt32(reader, "gst_rate_id", null),
                                TaxId = DRE.GetNullableInt32(reader, "tax_id", null),
                                GSTRate = DRE.GetNullableDecimal(reader, "gst_rate", null),
                                GSTName = DRE.GetNullableString(reader, "gst_name", null),
                                TaxableValue = DRE.GetNullableDecimal(reader, "taxable_value", null),
                                GSTAmount =DRE.GetNullableDecimal(reader, "gst_amount", null),
                                TotalAmount = DRE.GetNullableDecimal(reader, "total_amount", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            PurchaseBillCharges.Add(chargesDetails);
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

            return PurchaseBillCharges;
        }

        private Int32 UpdatePurchaseBillCharges(Entities.PurchaseBillChargesDetails chargesDetails)
        {
            var PurchaseBillChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePurchaseBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_charge_id", DbType.Int32, chargesDetails.PurchaseBillChargeId);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, chargesDetails.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, chargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, chargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, chargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, chargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, chargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, chargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, chargesDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, chargesDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    PurchaseBillChargeId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        PurchaseBillChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return PurchaseBillChargeId;
        }

        private Int32 UpdatePurchaseBillCharges(Entities.PurchaseBillChargesDetails chargesDetails, DbTransaction transaction)
        {
            var PurchaseBillChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePurchaseBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_charge_id", DbType.Int32, chargesDetails.PurchaseBillChargeId);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, chargesDetails.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, chargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, chargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, chargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, chargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, chargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, chargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, chargesDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, chargesDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    PurchaseBillChargeId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        PurchaseBillChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return PurchaseBillChargeId;
        }

        public Int32 SavePurchaseBillCharges(Entities.PurchaseBillChargesDetails chargesDetails, DbTransaction transaction)
        {
            var result = 0;

            if (chargesDetails.PurchaseBillChargeId == null || chargesDetails.PurchaseBillChargeId == 0)
            {
                result = AddPurchaseBillCharges(chargesDetails, transaction);
            }
            else if (chargesDetails.IsDeleted == true)
            {
                result = Convert.ToInt32(DeletePurchaseBillCharges(chargesDetails, transaction));
            }
            else if (chargesDetails.ModifiedBy > 0)
            {
                result = UpdatePurchaseBillCharges(chargesDetails, transaction);
            }

            return result;
        }
    }
}
