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
    public class PurchaseBill
    {
        private readonly Database database;

        public PurchaseBill()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBill"></param>
        /// <returns></returns>
        private Int32 AddPurchaseBill(Entities.PurchaseBill purchaseBill)
        {
            var purchaseBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPurchaseBill))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBill.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseBill.VendorId);
                    database.AddInParameter(dbCommand, "@purchase_bill_no", DbType.String, purchaseBill.PurchaseBillNo);
                    database.AddInParameter(dbCommand, "@purchase_bill_date", DbType.String, purchaseBill.PurchaseBillDate);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, purchaseBill.TransporterId);
                    database.AddInParameter(dbCommand, "@challan_no", DbType.String, purchaseBill.ChallanNo);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, purchaseBill.GSTApplicable);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, purchaseBill.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@is_tax_round_off", DbType.Boolean, purchaseBill.IsTaxRoundOff);
                    database.AddInParameter(dbCommand, "@is_composition_bill", DbType.Boolean, purchaseBill.IsCompositionBill);
                    database.AddInParameter(dbCommand, "@is_sample", DbType.Boolean, purchaseBill.IsSample);
                    database.AddInParameter(dbCommand, "@total_gst_amount_as_per_vendor_bill", DbType.Decimal, purchaseBill.TotalGSTAmountAsPerVendorBill);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, purchaseBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, purchaseBill.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, purchaseBill.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseBillId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseBillId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBill"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddPurchaseBill(Entities.PurchaseBill purchaseBill, DbTransaction transaction)
        {
            var purchaseBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPurchaseBill))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBill.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseBill.VendorId);
                    database.AddInParameter(dbCommand, "@purchase_bill_no", DbType.String, purchaseBill.PurchaseBillNo);
                    database.AddInParameter(dbCommand, "@purchase_bill_date", DbType.String, purchaseBill.PurchaseBillDate);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, purchaseBill.TransporterId);
                    database.AddInParameter(dbCommand, "@challan_no", DbType.String, purchaseBill.ChallanNo);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, purchaseBill.GSTApplicable);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, purchaseBill.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@is_tax_round_off", DbType.Boolean, purchaseBill.IsTaxRoundOff);
                    database.AddInParameter(dbCommand, "@is_composition_bill", DbType.Boolean, purchaseBill.IsCompositionBill);
                    database.AddInParameter(dbCommand, "@is_sample", DbType.Boolean, purchaseBill.IsSample);
                    database.AddInParameter(dbCommand, "@total_gst_amount_as_per_vendor_bill", DbType.Decimal, purchaseBill.TotalGSTAmountAsPerVendorBill);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, purchaseBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, purchaseBill.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, purchaseBill.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseBillId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseBillId;
        }

        public Boolean CheckPurchaseBillNoIsExists(Entities.PurchaseBill purchaseBill)
        {
            var isPurchaseBillNoExists = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckPurchaseBillNoIsExists))
                {
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, purchaseBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseBill.VendorId);
                    database.AddInParameter(dbCommand, "@purchase_bill_no", DbType.String, purchaseBill.PurchaseBillNo);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            isPurchaseBillNoExists = DRE.GetBoolean(reader, "is_purchase_bill_no_exists");
                        }
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

            return isPurchaseBillNoExists;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBill"></param>
        /// <returns></returns>
        private Boolean DeletePurchaseBill(Entities.PurchaseBill purchaseBill)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePurchaseBill))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBill.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, purchaseBill.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, purchaseBill.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return isDeleted;
        }

        public Boolean DeleteGoodsReceiptAndInwardByPurchaseBillId(Entities.PurchaseBill purchaseBill)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteGoodsReceiptAndInwardByPurchaseBillId))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBill.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, purchaseBill.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, purchaseBill.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return isDeleted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBill"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Boolean DeletePurchaseBill(Entities.PurchaseBill purchaseBill, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePurchaseBill))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBill.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, purchaseBill.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, purchaseBill.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return isDeleted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.PurchaseBill> GetAllPurchaseBills()
        {
            var purchaseBills = new List<Entities.PurchaseBill>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllPurchaseBills))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseBillItem = new PurchaseBillItem();
                            var purchaseBillCharges = new PurchaseBillChargesDetails();

                            var purchaseBill = new Entities.PurchaseBill
                            {
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", 0),
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                TransporterId = DRE.GetNullableInt32(reader, "transporter_id", null),
                                TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                                PurchaseBillDate = DRE.GetNullableString(reader, "purchase_bill_date", null),
                                ChallanNo = DRE.GetNullableString(reader, "challan_no", null),
                                GSTApplicable = DRE.GetNullableString(reader, "gst_applicable", null),
                                IsTaxInclusive = DRE.GetNullableBoolean(reader, "is_tax_inclusive", null),
                                IsTaxRoundOff = DRE.GetNullableBoolean(reader, "is_tax_round_off", null),
                                IsCompositionBill = DRE.GetNullableBoolean(reader, "is_composition_bill", null),
                                IsSample = DRE.GetNullableBoolean(reader, "is_sample", null),
                                TotalGSTAmountAsPerVendorBill = DRE.GetNullableDecimal(reader, "total_gst_amount_as_per_vendor_bill", null),
                                TotalQty = DRE.GetNullableDecimal(reader, "total_qty", null),
                                UnitOfMeasurement = DRE.GetNullableString(reader, "unit_code", null),
                                TotalAmount = DRE.GetNullableDecimal(reader, "total_amount", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                                PurchaseBillItems = purchaseBillItem.GetPurchaseBillItemsByPuchaseBillId(DRE.GetInt32(reader, "purchase_bill_id")),
                                PurchaseBillChargesDetails = purchaseBillCharges.GetBillChargesDetailsByPurchaseBillId(DRE.GetInt32(reader, "purchase_bill_id"))
                            };

                            purchaseBills.Add(purchaseBill);
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

            return purchaseBills;
        }

        public List<Entities.PurchaseBill> GetPurchaseBillsByVendor(Int32 vendorId)
        {
            var purchaseBills = new List<Entities.PurchaseBill>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillsByVendorId))
                {
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseBill = new Entities.PurchaseBill
                            {
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", 0),
                                //VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                //VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                //TransporterId = DRE.GetNullableInt32(reader, "transporter_id", null),
                                //TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                                //ChallanNo = DRE.GetNullableString(reader, "challan_no", null),
                                //TruckNo = DRE.GetNullableString(reader, "truck_no", null),
                                //PurchaseBillDate = DRE.GetNullableString(reader, "purchase_bill_date", null),
                                //GoodsReceivedDate = DRE.GetNullableString(reader, "goods_received_date", null),
                                //TotalWeight = DRE.GetNullableDecimal(reader, "total_weight", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                //SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            purchaseBills.Add(purchaseBill);
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

            return purchaseBills;
        }

        public Entities.PurchaseBill GetPurchaseBillDetailsByID(Int32 purchaseBillId)
        {
            var purchaseBill = new Entities.PurchaseBill();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillByBillId))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseBillItem = new PurchaseBillItem();

                            var _purchaseBill = new Entities.PurchaseBill
                            {
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", 0),
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                TransporterId = DRE.GetNullableInt32(reader, "transporter_id", null),
                                TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                                PurchaseBillDate = DRE.GetNullableString(reader, "purchase_bill_date", null),
                                ChallanNo = DRE.GetNullableString(reader, "challan_no", null),
                                GSTApplicable = DRE.GetNullableString(reader, "gst_applicable", null),
                                IsTaxInclusive = DRE.GetNullableBoolean(reader, "is_tax_inclusive", null),
                                IsTaxRoundOff = DRE.GetNullableBoolean(reader, "is_tax_round_off", null),
                                IsCompositionBill = DRE.GetNullableBoolean(reader, "is_composition_bill", null),
                                IsSample = DRE.GetNullableBoolean(reader, "is_sample", null),
                                TotalGSTAmountAsPerVendorBill = DRE.GetNullableDecimal(reader, "total_gst_amount_as_per_vendor_bill", null),
                                TotalQty = DRE.GetNullableDecimal(reader, "total_qty", null),
                                TotalAmount = DRE.GetNullableDecimal(reader, "total_amount", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                PurchaseBillItems = purchaseBillItem.GetPurchaseBillItemsByPuchaseBillId(DRE.GetInt32(reader, "purchase_bill_id"))
                            };

                            purchaseBill = _purchaseBill;
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

            return purchaseBill;
        }

        public List<Entities.ClientAddress> GetVendorsByPurchaseBillNo(Entities.PurchaseBill purchaseBill)
        {
            var vendors = new List<Entities.ClientAddress>();

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetVendorsByPurchaseBillNo))
                {
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@purchase_bill_no", DbType.String, purchaseBill.PurchaseBillNo);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var vendor = new Entities.ClientAddress()
                            {
                                ClientAddressId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                ClientAddressName = DRE.GetNullableString(reader, "vendor_name", null)
                            };

                            vendors.Add(vendor);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand = null;
            }
           
            return vendors;
        }

        public Entities.PurchaseBill GetPurchaseBillDetailsByPurchaseBillNoVendorIdAndWorkingPeriodId(Entities.PurchaseBill purchaseBill)
        {
            var purchaseBillInfo = new Entities.PurchaseBill();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillByBillNoVendorIdAndWorkingPeriod))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_no", DbType.String, purchaseBill.PurchaseBillNo);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseBill.VendorId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseBillItem = new PurchaseBillItem();

                            var purchaseBillDetails = new Entities.PurchaseBill
                            {
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", 0),
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                TransporterId = DRE.GetNullableInt32(reader, "transporter_id", null),
                                TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                                PurchaseBillDate = DRE.GetNullableString(reader, "purchase_bill_date", null),
                                ChallanNo = DRE.GetNullableString(reader, "challan_no", null),
                                GSTApplicable = DRE.GetNullableString(reader, "gst_applicable", null),
                                IsTaxInclusive = DRE.GetNullableBoolean(reader, "is_tax_inclusive", null),
                                IsTaxRoundOff = DRE.GetNullableBoolean(reader, "is_tax_round_off", null),
                                IsCompositionBill = DRE.GetNullableBoolean(reader, "is_composition_bill", null),
                                IsSample = DRE.GetNullableBoolean(reader, "is_sample", null),
                                TotalGSTAmountAsPerVendorBill = DRE.GetNullableDecimal(reader, "total_gst_amount_as_per_vendor_bill", null),
                                TotalQty = DRE.GetNullableDecimal(reader, "total_qty", null),
                                TotalAmount = DRE.GetNullableDecimal(reader, "total_amount", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                PurchaseBillItems = purchaseBillItem.GetPurchaseBillItemsByPuchaseBillId(DRE.GetInt32(reader, "purchase_bill_id"))
                            };

                            purchaseBillInfo = purchaseBillDetails;
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

            return purchaseBillInfo;
        }

        public Entities.PurchaseBill GetPurchaseBillDetailsByPurchaseBillNoAndWorkingPeriodId(Entities.PurchaseBill purchaseBill)
        {
            var purchaseBillInfo = new Entities.PurchaseBill();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillByBillNoAndWorkingPeriod))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_no", DbType.String, purchaseBill.PurchaseBillNo);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseBill.WorkingPeriodId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseBillItem = new PurchaseBillItem();

                            var purchaseBillDetails = new Entities.PurchaseBill
                            {
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", 0),
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                TransporterId = DRE.GetNullableInt32(reader, "transporter_id", null),
                                TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                                PurchaseBillDate = DRE.GetNullableString(reader, "purchase_bill_date", null),
                                ChallanNo = DRE.GetNullableString(reader, "challan_no", null),
                                GSTApplicable = DRE.GetNullableString(reader, "gst_applicable", null),
                                IsTaxInclusive = DRE.GetNullableBoolean(reader, "is_tax_inclusive", null),
                                IsTaxRoundOff = DRE.GetNullableBoolean(reader, "is_tax_round_off", null),
                                IsCompositionBill = DRE.GetNullableBoolean(reader, "is_composition_bill", null),
                                IsSample = DRE.GetNullableBoolean(reader, "is_sample", null),
                                TotalGSTAmountAsPerVendorBill = DRE.GetNullableDecimal(reader, "total_gst_amount_as_per_vendor_bill", null),
                                TotalQty = DRE.GetNullableDecimal(reader, "total_qty", null),
                                TotalAmount = DRE.GetNullableDecimal(reader, "total_amount", null),
                                CompanyId =DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                PurchaseBillItems = purchaseBillItem.GetPurchaseBillItemsByPuchaseBillId(DRE.GetInt32(reader, "purchase_bill_id"))
                            };

                            purchaseBillInfo = purchaseBillDetails;
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

            return purchaseBillInfo;
        }

        public Entities.PurchaseBillItem GetItemDetailsForPurchaseByItemId(Int32 itemId)
        {
            var itemDetails = new Entities.PurchaseBillItem();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemDetailsByItemId))
                {
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseBillItem = new Entities.PurchaseBillItem()
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                HSNCode = DRE.GetNullableString(reader, "hsn_code", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                IsSet = DRE.GetNullableBoolean(reader, "is_set", null),
                                IsSellAtNetRate = DRE.GetNullableBoolean(reader, "is_sell_at_net_rate", null),
                                PurchaseRate = DRE.GetNullableDecimal(reader, "purchase_rate", null)
                            };

                            itemDetails = purchaseBillItem;
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

            return itemDetails;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBill"></param>
        /// <returns></returns>
        private Int32 UpdatePurchaseBill(Entities.PurchaseBill purchaseBill)
        {
            var purchaseBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePurchaseBill))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBill.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseBill.VendorId);
                    database.AddInParameter(dbCommand, "@purchase_bill_no", DbType.String, purchaseBill.PurchaseBillNo);
                    database.AddInParameter(dbCommand, "@purchase_bill_date", DbType.String, purchaseBill.PurchaseBillDate);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, purchaseBill.TransporterId);
                    database.AddInParameter(dbCommand, "@challan_no", DbType.String, purchaseBill.ChallanNo);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, purchaseBill.GSTApplicable);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, purchaseBill.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@is_tax_round_off", DbType.Boolean, purchaseBill.IsTaxRoundOff);
                    database.AddInParameter(dbCommand, "@is_composition_bill", DbType.Boolean, purchaseBill.IsCompositionBill);
                    database.AddInParameter(dbCommand, "@is_sample", DbType.Boolean, purchaseBill.IsSample);
                    database.AddInParameter(dbCommand, "@total_gst_amount_as_per_vendor_bill", DbType.Decimal, purchaseBill.TotalGSTAmountAsPerVendorBill);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, purchaseBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, purchaseBill.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, purchaseBill.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseBillId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseBillId;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="purchaseBill"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdatePurchaseBill(Entities.PurchaseBill purchaseBill, DbTransaction transaction)
        {
            var purchaseBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePurchaseBill))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBill.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseBill.VendorId);
                    database.AddInParameter(dbCommand, "@purchase_bill_no", DbType.String, purchaseBill.PurchaseBillNo);
                    database.AddInParameter(dbCommand, "@purchase_bill_date", DbType.String, purchaseBill.PurchaseBillDate);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, purchaseBill.TransporterId);
                    database.AddInParameter(dbCommand, "@challan_no", DbType.String, purchaseBill.ChallanNo);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, purchaseBill.GSTApplicable);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, purchaseBill.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@is_tax_round_off", DbType.Boolean, purchaseBill.IsTaxRoundOff);
                    database.AddInParameter(dbCommand, "@is_composition_bill", DbType.Boolean, purchaseBill.IsCompositionBill);
                    database.AddInParameter(dbCommand, "@is_sample", DbType.Boolean, purchaseBill.IsSample);
                    database.AddInParameter(dbCommand, "@total_gst_amount_as_per_vendor_bill", DbType.Decimal, purchaseBill.TotalGSTAmountAsPerVendorBill);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, purchaseBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, purchaseBill.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, purchaseBill.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseBillId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseBillId;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillId"></param>
        /// <returns></returns>
        public bool CheckPurchaseBillExistsInSalesBill(Int32 purchaseBillId)
        {
            bool IsPurchaseBillExists = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckPurchaseBillExistsInSalesBill))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            IsPurchaseBillExists = DRE.GetBoolean(reader, "is_purchase_bill_exists");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand = null;
            }

            return IsPurchaseBillExists;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillId"></param>
        /// <returns></returns>
        public bool CheckPurchaseBillExistsInGoodsReceiptAndInward(Int32 purchaseBillId)
        {
            bool IsPurchaseBillExists = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckPurchaseBillExistsInGoodsReceiptsAndInward))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            IsPurchaseBillExists = DRE.GetBoolean(reader, "is_purchase_bill_exists");
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

            return IsPurchaseBillExists;

        }


        /// <summary>
        /// Save Purchase Bill
        /// </summary>
        /// <param name="purchaseBill"></param>
        /// <returns></returns>
        public Int32 SavePurchaseBill(Entities.PurchaseBill purchaseBill)
        {
            var purchaseBillId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var purchaseBillItemId = 0;
                        var purchaseBillChargeId = 0;

                        if (purchaseBill != null)
                        {
                            if (purchaseBill.PurchaseBillId == null || purchaseBill.PurchaseBillId == 0)
                            {
                                var isPurchaseBillNoExists = CheckPurchaseBillNoIsExists(purchaseBill);

                                if (isPurchaseBillNoExists == false)
                                {
                                    purchaseBillId = AddPurchaseBill(purchaseBill, transaction);
                                }
                                else
                                {
                                    purchaseBillId = -1;
                                }
                            }
                            else
                            {
                                purchaseBillId = Convert.ToInt32(purchaseBill.PurchaseBillId);

                                if (purchaseBill.IsDeleted == true)
                                {
                                    var result = DeletePurchaseBill(purchaseBill, transaction);

                                    if (result)
                                    {
                                        purchaseBillId = (int)purchaseBill.PurchaseBillId;
                                    }
                                }
                                else
                                {
                                    if (purchaseBill.ModifiedBy > 0 || purchaseBill.ModifiedBy != null)
                                    {
                                        purchaseBillId = UpdatePurchaseBill(purchaseBill, transaction);
                                    }
                                }
                            }

                            if (purchaseBillId > 0)
                            {
                                if (purchaseBill.PurchaseBillItems != null) {

                                    foreach (Entities.PurchaseBillItem purchaseBillItem in purchaseBill.PurchaseBillItems)
                                    {
                                        purchaseBillItem.PurchaseBillId = purchaseBillId;

                                        PurchaseBillItem purchaseBillItemDL = new PurchaseBillItem();

                                        purchaseBillItemId = purchaseBillItemDL.SavePurchaseBillItem(purchaseBillItem, transaction);
                                    }

                                }

                            }

                            if (purchaseBillId > 0)
                            {
                                if (purchaseBill.PurchaseBillChargesDetails != null)
                                {
                                    if (purchaseBill.PurchaseBillChargesDetails.Count > 0)
                                    {
                                        foreach (Entities.PurchaseBillChargesDetails billCharges in purchaseBill.PurchaseBillChargesDetails)
                                        {
                                            billCharges.PurchaseBillId = purchaseBillId;

                                            PurchaseBillChargesDetails purchaseBillChargesDetails = new PurchaseBillChargesDetails();

                                            purchaseBillChargeId = purchaseBillChargesDetails.SavePurchaseBillCharges(billCharges, transaction);

                                            if (purchaseBillChargeId < 0)
                                            {
                                                purchaseBillId = -1;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        db = null;
                    }
                }
            }

            return purchaseBillId;

        }



    }
}
