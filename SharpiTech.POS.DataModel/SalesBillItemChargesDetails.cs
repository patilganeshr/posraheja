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
    public class SalesBillItemChargesDetails
    {
        private readonly Database database;

        public SalesBillItemChargesDetails()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddSalesBillItemCharges(Entities.SalesBillItemChargesDetails itemChargesDetails)
        {
            var salesBillItemChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBillItemChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_charge_id", DbType.Int32, itemChargesDetails.SalesBillItemChargeId);
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, itemChargesDetails.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, itemChargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, itemChargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, itemChargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, itemChargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, itemChargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.Int32, itemChargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, itemChargesDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, itemChargesDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillItemChargeId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillItemChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillItemChargeId;
        }

        private Int32 AddSalesBillItemCharges(Entities.SalesBillItemChargesDetails itemChargesDetails, DbTransaction transaction)
        {
            var salesBillItemChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBillItemChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_charge_id", DbType.Int32, itemChargesDetails.SalesBillItemChargeId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, itemChargesDetails.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, itemChargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, itemChargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, itemChargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, itemChargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, itemChargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, itemChargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, itemChargesDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, itemChargesDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillItemChargeId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillItemChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillItemChargeId;
        }

        private bool DeleteSalesBillItemCharges(Entities.SalesBillItemChargesDetails itemChargesDetails)
        {
            var IsSalesBillItemChargeIsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBillItemChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_charge_id", DbType.Int32, itemChargesDetails.SalesBillItemChargeId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemChargesDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemChargesDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsSalesBillItemChargeIsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsSalesBillItemChargeIsDeleted;
        }

        private bool DeleteSalesBillItemCharges(Entities.SalesBillItemChargesDetails itemChargesDetails, DbTransaction transaction)
        {
            var IsSalesBillItemChargeIsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBillItemChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_charge_id", DbType.Int32, itemChargesDetails.SalesBillItemChargeId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemChargesDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemChargesDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsSalesBillItemChargeIsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsSalesBillItemChargeIsDeleted;
        }

        public List<Entities.SalesBillItemChargesDetails> GetBillitemChargesDetailsBySalesBillItemId(Int32 salesBillItemId)
        {
            var salesBillItemCharges = new List<Entities.SalesBillItemChargesDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillItemChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, salesBillItemId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemChargesDetails = new Entities.SalesBillItemChargesDetails
                            {
                                SalesBillItemChargeId = DRE.GetNullableInt32(reader, "sales_bill_item_charge_id", null),
                                SalesBillItemId = DRE.GetNullableInt32(reader, "sales_bill_item_id", 0),
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

                            salesBillItemCharges.Add(itemChargesDetails);
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

            return salesBillItemCharges;
        }

        private Int32 UpdateSalesBillItemCharges(Entities.SalesBillItemChargesDetails itemChargesDetails)
        {
            var salesBillItemChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesBillItemChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_charge_id", DbType.Int32, itemChargesDetails.SalesBillItemChargeId);
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, itemChargesDetails.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, itemChargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, itemChargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, itemChargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, itemChargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, itemChargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, itemChargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, itemChargesDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, itemChargesDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillItemChargeId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillItemChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillItemChargeId;
        }

        private Int32 UpdateSalesBillItemCharges(Entities.SalesBillItemChargesDetails itemChargesDetails, DbTransaction transaction)
        {
            var salesBillItemChargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesBillItemChargesDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_charge_id", DbType.Int32, itemChargesDetails.SalesBillItemChargeId);
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, itemChargesDetails.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, itemChargesDetails.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_amount", DbType.Decimal, itemChargesDetails.ChargeAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, itemChargesDetails.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, itemChargesDetails.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, itemChargesDetails.TaxId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.Int32, itemChargesDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, itemChargesDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, itemChargesDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillItemChargeId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillItemChargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillItemChargeId;
        }

        public Int32 SaveSalesBillItemCharges(Entities.SalesBillItemChargesDetails itemChargesDetails, DbTransaction transaction)
        {
            var result = 0;

            if (itemChargesDetails.SalesBillItemChargeId == null || itemChargesDetails.SalesBillItemChargeId == 0)
            {
                result = AddSalesBillItemCharges(itemChargesDetails, transaction);
            }
            else if (itemChargesDetails.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesBillItemCharges(itemChargesDetails, transaction));
            }
            else if (itemChargesDetails.ModifiedBy > 0)
            {
                result = UpdateSalesBillItemCharges(itemChargesDetails, transaction);
            }

            return result;
        }
    }
}
