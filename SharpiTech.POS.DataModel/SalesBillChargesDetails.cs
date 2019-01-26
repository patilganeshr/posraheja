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
    public class SalesBillChargesDetails
    {
        private readonly Database database;

        public SalesBillChargesDetails()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddSalesBillCharges(Entities.SalesBillChargesDetails chargesDetails)
        {
            var salesBillChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_charge_id", DbType.Int32, chargesDetails.SalesBillChargeId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, chargesDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, chargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, chargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, chargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, chargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, chargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, chargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, chargesDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, chargesDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillChargeId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillChargeId;
        }

        private Int32 AddSalesBillCharges(Entities.SalesBillChargesDetails chargesDetails, DbTransaction transaction)
        {
            var salesBillChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_charge_id", DbType.Int32, chargesDetails.SalesBillChargeId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, chargesDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, chargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, chargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, chargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, chargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, chargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, chargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, chargesDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, chargesDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillChargeId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillChargeId;
        }

        private bool DeleteSalesBillCharges(Entities.SalesBillChargesDetails chargesDetails)
        {
            var IsSalesBillChargeIsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_charge_id", DbType.Int32, chargesDetails.SalesBillChargeId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, chargesDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, chargesDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsSalesBillChargeIsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsSalesBillChargeIsDeleted;
        }

        private bool DeleteSalesBillCharges(Entities.SalesBillChargesDetails chargesDetails, DbTransaction transaction)
        {
            var IsSalesBillChargeIsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_charge_id", DbType.Int32, chargesDetails.SalesBillChargeId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, chargesDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, chargesDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsSalesBillChargeIsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsSalesBillChargeIsDeleted;
        }

        public List<Entities.SalesBillChargesDetails> GetBillChargesDetailsBySalesBillId(Int32 salesBillId)
        {
            var salesBillCharges = new List<Entities.SalesBillChargesDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var chargesDetails = new Entities.SalesBillChargesDetails
                            {
                                SalesBillChargeId = DRE.GetNullableInt32(reader, "sales_bill_charge_id", null),
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", 0),
                                ChargeId = DRE.GetNullableInt32(reader, "charge_id", null),
                                ChargeName = DRE.GetNullableString(reader, "charge_name", null),
                                ChargeAmount = DRE.GetNullableDecimal(reader, "charge_amount", null),
                                IsTaxInclusive = DRE.GetNullableBoolean(reader, "is_tax_inclusive", null),
                                GSTRateId    = DRE.GetNullableInt32(reader, "gst_rate_id", null),
                                TaxId = DRE.GetNullableInt32(reader, "tax_id", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            salesBillCharges.Add(chargesDetails);
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

            return salesBillCharges;
        }

        private Int32 UpdateSalesBillCharges(Entities.SalesBillChargesDetails chargesDetails)
        {
            var salesBillChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_charge_id", DbType.Int32, chargesDetails.SalesBillChargeId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, chargesDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, chargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, chargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, chargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, chargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, chargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, chargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, chargesDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, chargesDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillChargeId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillChargeId;
        }

        private Int32 UpdateSalesBillCharges(Entities.SalesBillChargesDetails chargesDetails, DbTransaction transaction)
        {
            var salesBillChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesBillChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_charge_id", DbType.Int32, chargesDetails.SalesBillChargeId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, chargesDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, chargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, chargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, chargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, chargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, chargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, chargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, chargesDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, chargesDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillChargeId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillChargeId;
        }

        public Int32 SaveSalesBillCharges(Entities.SalesBillChargesDetails chargesDetails, DbTransaction transaction)
        {
            var result = 0;

            if (chargesDetails.SalesBillChargeId == null || chargesDetails.SalesBillChargeId == 0)
            {
                result = AddSalesBillCharges(chargesDetails, transaction);
            }
            else if (chargesDetails.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesBillCharges(chargesDetails, transaction));
            }
            else if (chargesDetails.ModifiedBy > 0)
            {
                result = UpdateSalesBillCharges(chargesDetails, transaction);
            }

            return result;
        }
    }
}
