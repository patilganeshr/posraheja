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
    public class PurchaseOrder
    {
        private readonly Database database;

        public PurchaseOrder()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// Add Purchase order details
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <returns></returns>
        private Int32 AddPurchaseOrder(Entities.PurchaseOrder purchaseOrder)
        {
            var purchaseOrderId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPurchaseOrder))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrder.PurchaseOrderId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseOrder.VendorId);
                    database.AddInParameter(dbCommand, "@vendor_reference_no", DbType.String, purchaseOrder.VendorReferenceNo);
                    database.AddInParameter(dbCommand, "@purchase_order_no", DbType.Int32, purchaseOrder.PurchaseOrderNo);
                    database.AddInParameter(dbCommand, "@purchase_order_date", DbType.String, purchaseOrder.PurchaseOrderDate);
                    database.AddInParameter(dbCommand, "@payment_term_id", DbType.Int32, purchaseOrder.PaymentTermId);
                    database.AddInParameter(dbCommand, "@discount_rate_for_payment", DbType.Decimal, purchaseOrder.DiscountRateForPayment);
                    database.AddInParameter(dbCommand, "@discount_applicable_before_payment_days", DbType.Int32, purchaseOrder.DiscountApplicableBeforePaymentDays);
                    database.AddInParameter(dbCommand, "@expected_delivery_date", DbType.String, purchaseOrder.ExpectedDeliveryDate);
                    database.AddInParameter(dbCommand, "@no_of_days_for_payment", DbType.Int32, purchaseOrder.NoOfDaysForPayment);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, purchaseOrder.Remarks);
                    database.AddInParameter(dbCommand, "@order_status_id", DbType.Int32, purchaseOrder.OrderStatusId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, purchaseOrder.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseOrder.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, purchaseOrder.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, purchaseOrder.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseOrderId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseOrderId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseOrderId;
        }

        /// <summary>
        /// Add Purchase Order
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddPurchaseOrder(Entities.PurchaseOrder purchaseOrder, DbTransaction transaction)
        {
            var purchaseOrderId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPurchaseOrder))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrder.PurchaseOrderId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseOrder.VendorId);
                    database.AddInParameter(dbCommand, "@vendor_reference_no", DbType.String, purchaseOrder.VendorReferenceNo);
                    database.AddInParameter(dbCommand, "@purchase_order_no", DbType.Int32, purchaseOrder.PurchaseOrderNo);
                    database.AddInParameter(dbCommand, "@purchase_order_date", DbType.String, purchaseOrder.PurchaseOrderDate);
                    database.AddInParameter(dbCommand, "@payment_term_id", DbType.Int32, purchaseOrder.PaymentTermId);
                    database.AddInParameter(dbCommand, "@discount_rate_for_payment", DbType.Decimal, purchaseOrder.DiscountRateForPayment);
                    database.AddInParameter(dbCommand, "@discount_applicable_before_payment_days", DbType.Int32, purchaseOrder.DiscountApplicableBeforePaymentDays);
                    database.AddInParameter(dbCommand, "@expected_delivery_date", DbType.String, purchaseOrder.ExpectedDeliveryDate);
                    database.AddInParameter(dbCommand, "@no_of_days_for_payment", DbType.Int32, purchaseOrder.NoOfDaysForPayment);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, purchaseOrder.Remarks);
                    database.AddInParameter(dbCommand, "@order_status_id", DbType.Int32, purchaseOrder.OrderStatusId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, purchaseOrder.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseOrder.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, purchaseOrder.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, purchaseOrder.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseOrderId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseOrderId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseOrderId;
        }

        public Boolean CheckPurchaseOrderNoIsExists(Entities.PurchaseOrder purchaseOrder)
        {
            var isPurchaseOrderNoExists = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckPurchaseOrderNoIsExists))
                {
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, purchaseOrder.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseOrder.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseOrder.VendorId);
                    database.AddInParameter(dbCommand, "@purchase_order_no", DbType.String, purchaseOrder.PurchaseOrderNo);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            isPurchaseOrderNoExists = DRE.GetBoolean(reader, "is_purchase_order_no_exists");
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

            return isPurchaseOrderNoExists;
        }

        /// <summary>
        /// Delete Purchase Order
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <returns></returns>
        private Boolean DeletePurchaseOrder(Entities.PurchaseOrder purchaseOrder)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePurchaseOrder))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrder.PurchaseOrderId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, purchaseOrder.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, purchaseOrder.DeletedByIP);

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

        //public Boolean DeleteGoodsReceiptAndInwardBypurchaseOrderId(Entities.PurchaseOrder purchaseBill)
        //{
        //    var isDeleted = false;

        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteGoodsReceiptAndInwardBypurchaseOrderId))
        //        {
        //            database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrder.purchaseOrderId);
        //            database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, purchaseOrder.DeletedBy);
        //            database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, purchaseOrder.DeletedByIP);

        //            database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

        //            var result = database.ExecuteNonQuery(dbCommand);

        //            if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
        //            {
        //                isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        dbCommand = null;
        //    }

        //    return isDeleted;
        //}

        /// <summary>
        /// Delete Purchase Order
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Boolean DeletePurchaseOrder(Entities.PurchaseOrder purchaseOrder, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePurchaseOrder))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrder.PurchaseOrderId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, purchaseOrder.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, purchaseOrder.DeletedByIP);

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
        /// Get all Purchase Orders
        /// </summary>
        /// <returns></returns>
        public List<Entities.PurchaseOrder> GetAllPurchaseOrders()
        {
            var purchaseOrders = new List<Entities.PurchaseOrder>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllPurchaseOrders))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseOrderItem = new PurchaseOrderItem();
                            //var purchaseBillCharges = new PurchaseBillChargesDetails();

                            var purchaseOrder = new Entities.PurchaseOrder
                            {
                                PurchaseOrderId = DRE.GetNullableInt32(reader, "purchase_order_id", 0),
                                PurchaseOrderNo = DRE.GetNullableInt32(reader, "purchase_order_no", null),
                                PurchaseOrderDate = DRE.GetNullableString(reader, "purchase_order_date", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                VendorReferenceNo = DRE.GetNullableString(reader, "vendor_reference_no", null),
                                TotalNoOfBales = DRE.GetNullableInt32(reader, "total_no_of_bales", null),
                                TotalOrderQty = DRE.GetNullableDecimal(reader, "total_order_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                TotalOrderAmount = DRE.GetNullableDecimal(reader, "total_order_amount", null),
                                OrderStatus = DRE.GetNullableString(reader, "order_status", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                PurchaseOrderItems = purchaseOrderItem.GetPurchaseOrderItemsByPuchaseOrderId(DRE.GetInt32(reader, "purchase_order_id"))                                
                            };

                            purchaseOrders.Add(purchaseOrder);
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

            return purchaseOrders;
        }

        public List<Entities.PurchaseOrder> GetPurchaseOrdersByVendor(Int32 vendorId)
        {
            var purchaseOrders = new List<Entities.PurchaseOrder>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseOrdersByVendorId))
                {
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseOrder = new Entities.PurchaseOrder
                            {
                                PurchaseOrderId = DRE.GetNullableInt32(reader, "purchase_order_id", 0),
                                //VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                //VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                //TransporterId = DRE.GetNullableInt32(reader, "transporter_id", null),
                                //TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                                PurchaseOrderNo = DRE.GetNullableInt32(reader, "purchase_order_no", null),
                                //ChallanNo = DRE.GetNullableString(reader, "challan_no", null),
                                //TruckNo = DRE.GetNullableString(reader, "truck_no", null),
                                //PurchaseBillDate = DRE.GetNullableString(reader, "purchase_order_date", null),
                                //GoodsReceivedDate = DRE.GetNullableString(reader, "goods_received_date", null),
                                //TotalWeight = DRE.GetNullableDecimal(reader, "total_weight", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                //SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            purchaseOrders.Add(purchaseOrder);
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

            return purchaseOrders;
        }

        public Entities.PurchaseOrder GetPurchaseOrderDetailsByID(Int32 purchaseOrderId)
        {
            var purchaseOrder = new Entities.PurchaseOrder();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseOrderDetailsByOrderId))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrderId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseOrderItem = new PurchaseOrderItem();

                            var _purchaseOrder = new Entities.PurchaseOrder
                            {
                                PurchaseOrderId = DRE.GetNullableInt32(reader, "purchase_order_id", 0),
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                VendorReferenceNo = DRE.GetNullableString(reader, "vendor_reference_no", null),
                                PurchaseOrderNo = DRE.GetNullableInt32(reader, "purchase_order_no", null),
                                PurchaseOrderDate = DRE.GetNullableString(reader, "purchase_order_date", null),
                                PaymentTermId = DRE.GetNullableInt32(reader, "payment_term_id", null),
                                DiscountRateForPayment = DRE.GetNullableDecimal(reader, "discount_rate_for_payment", null),
                                DiscountApplicableBeforePaymentDays = DRE.GetNullableInt32(reader, "discount_applicable_before_payment_days", null),
                                NoOfDaysForPayment = DRE.GetNullableInt32(reader, "no_of_days_for_payment", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                TermShortCode = DRE.GetNullableString(reader, "term_short_code", null),
                                OrderStatus = DRE.GetNullableString(reader,"order_status", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                PurchaseOrderItems = purchaseOrderItem.GetPurchaseOrderItemsByPuchaseOrderId(DRE.GetInt32(reader, "purchase_order_id"))
                            };

                            purchaseOrder = _purchaseOrder;
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

            return purchaseOrder;
        }

        public List<Entities.ClientAddress> GetVendorsByPurchaseOrderNo(Entities.PurchaseOrder purchaseOrder)
        {
            var vendors = new List<Entities.ClientAddress>();

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetVendorsByPurchaseOrderNo))
                {
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseOrder.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@purchase_order_no", DbType.String, purchaseOrder.PurchaseOrderNo);

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

        //public Entities.PurchaseOrder GetPurchaseOrderDetailsByPurchaseOrderNoVendorIdAndWorkingPeriodId(Entities.PurchaseOrder purchaseOrder)
        //{
        //    var purchaseOrderInfo = new Entities.PurchaseOrder();

        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseOrderByOrderNoVendorIdAndWorkingPeriod))
        //        {
        //            database.AddInParameter(dbCommand, "@purchase_order_no", DbType.String, purchaseOrder.PurchaseOrderNo);
        //            database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseOrder.WorkingPeriodId);
        //            database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseOrder.VendorId);

        //            using (IDataReader reader = database.ExecuteReader(dbCommand))
        //            {
        //                while (reader.Read())
        //                {
        //                    var purchaseOrderItem = new PurchaseOrderItem();

        //                    var purchaseOrderDetails = new Entities.PurchaseOrder
        //                    {
        //                        PurchaseOrderId = DRE.GetNullableInt32(reader, "purchase_order_id", 0),
        //                        VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
        //                        VendorName = DRE.GetNullableString(reader, "vendor_name", null),
        //                        VendorReferenceNo = DRE.GetNullableString(reader, "vendor_reference_no", null),
        //                        PurchaseOrderNo = DRE.GetNullableString(reader, "purchase_order_no", null),
        //                        PurchaseOrderDate = DRE.GetNullableString(reader, "purchase_order_date", null),
        //                        PaymentTermId = DRE.GetNullableString(reader, "payment_term_id", null),
        //                        DiscountRateForPayment = DRE.GetNullableDecimal(reader, "discount_rate_for_payment", null),
        //                        DiscountApplicableBeforePaymentDays = DRE.GetNullableInt32(reader, "discount_applicable_before_payment_days", null),
        //                        NoOfDaysForPayment = DRE.GetNullableInt32(reader, "no_of_days_for_payment", null),
        //                        Remarks = DRE.GetNullableString(reader, "remarks", null),
        //                        CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
        //                        CompanyName = DRE.GetNullableString(reader, "company_name", null),
        //                        BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
        //                        BranchName = DRE.GetNullableString(reader, "branch_name", null),
        //                        WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
        //                        FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
        //                        guid = DRE.GetNullableGuid(reader, "row_guid", null),
        //                        PurchaseOrderItems = purchaseOrderItem.GetPurchaseOrderItemsByPuchaseOrderId(DRE.GetInt32(reader, "purchase_order_id"))
        //                    };

        //                    purchaseOrderInfo = purchaseOrderDetails;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbCommand = null;
        //    }

        //    return purchaseOrderInfo;
        //}

        public Entities.PurchaseOrder GetPurchaseOrderDetailsByPurchaseOrderNoAndWorkingPeriodId(Entities.PurchaseOrder purchaseOrder)
        {
            var purchaseOrderInfo = new Entities.PurchaseOrder();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillByBillNoAndWorkingPeriod))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_no", DbType.String, purchaseOrder.PurchaseOrderNo);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseOrder.WorkingPeriodId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseOrderItem = new PurchaseOrderItem();

                            var purchaseOrderDetails = new Entities.PurchaseOrder
                            {
                                PurchaseOrderId = DRE.GetNullableInt32(reader, "purchase_order_id", 0),
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                VendorReferenceNo = DRE.GetNullableString(reader, "vendor_reference_no", null),
                                PurchaseOrderNo = DRE.GetNullableInt32(reader, "purchase_order_no", null),
                                PurchaseOrderDate = DRE.GetNullableString(reader, "purchase_order_date", null),
                                PaymentTermId = DRE.GetNullableInt32(reader, "payment_term_id", null),
                                DiscountRateForPayment = DRE.GetNullableDecimal(reader, "discount_rate_for_payment", null),
                                DiscountApplicableBeforePaymentDays = DRE.GetNullableInt32(reader, "discount_applicable_before_payment_days", null),
                                NoOfDaysForPayment = DRE.GetNullableInt32(reader, "no_of_days_for_payment", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                PurchaseOrderItems = purchaseOrderItem.GetPurchaseOrderItemsByPuchaseOrderId(DRE.GetInt32(reader, "purchase_order_id"))
                            };

                            purchaseOrderInfo = purchaseOrderDetails;
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

            return purchaseOrderInfo;
        }

        public Entities.PurchaseOrderItem GetItemDetailsForPurchaseByItemId(Int32 itemId)
        {
            var itemDetails = new Entities.PurchaseOrderItem();

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
                            var purchaseBillItem = new Entities.PurchaseOrderItem()
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                HSNCode = DRE.GetNullableString(reader, "hsn_code", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                IsSet = DRE.GetNullableBoolean(reader, "is_set", null),
                                OrderRate = DRE.GetNullableDecimal(reader, "order_rate", null)
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
        /// Update Purchase Order
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <returns></returns>
        private Int32 UpdatePurchaseOrder(Entities.PurchaseOrder purchaseOrder)
        {
            var purchaseOrderId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePurchaseOrder))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrder.PurchaseOrderId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseOrder.VendorId);
                    database.AddInParameter(dbCommand, "@vendor_reference_no", DbType.String, purchaseOrder.VendorReferenceNo);
                    database.AddInParameter(dbCommand, "@purchase_order_no", DbType.Int32, purchaseOrder.PurchaseOrderNo);
                    database.AddInParameter(dbCommand, "@purchase_order_date", DbType.String, purchaseOrder.PurchaseOrderDate);
                    database.AddInParameter(dbCommand, "@payment_term_id", DbType.Int32, purchaseOrder.PaymentTermId);
                    database.AddInParameter(dbCommand, "@discount_rate_for_payment", DbType.Decimal, purchaseOrder.DiscountRateForPayment);
                    database.AddInParameter(dbCommand, "@discount_applicable_before_payment_days", DbType.Int32, purchaseOrder.DiscountApplicableBeforePaymentDays);
                    database.AddInParameter(dbCommand, "@expected_delivery_date", DbType.String, purchaseOrder.ExpectedDeliveryDate);
                    database.AddInParameter(dbCommand, "@no_of_days_for_payment", DbType.Int32, purchaseOrder.NoOfDaysForPayment);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, purchaseOrder.Remarks);
                    database.AddInParameter(dbCommand, "@order_status_id", DbType.Int32, purchaseOrder.OrderStatusId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, purchaseOrder.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseOrder.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, purchaseOrder.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, purchaseOrder.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseOrderId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseOrderId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseOrderId;
        }

        /// <summary>
        /// Update Purchase Order
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdatePurchaseOrder(Entities.PurchaseOrder purchaseOrder, DbTransaction transaction)
        {
            var purchaseOrderId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePurchaseOrder))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrder.PurchaseOrderId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, purchaseOrder.VendorId);
                    database.AddInParameter(dbCommand, "@vendor_reference_no", DbType.String, purchaseOrder.VendorReferenceNo);
                    database.AddInParameter(dbCommand, "@purchase_order_no", DbType.Int32, purchaseOrder.PurchaseOrderNo);
                    database.AddInParameter(dbCommand, "@purchase_order_date", DbType.String, purchaseOrder.PurchaseOrderDate);
                    database.AddInParameter(dbCommand, "@payment_term_id", DbType.Int32, purchaseOrder.PaymentTermId);
                    database.AddInParameter(dbCommand, "@discount_rate_for_payment", DbType.Decimal, purchaseOrder.DiscountRateForPayment);
                    database.AddInParameter(dbCommand, "@discount_applicable_before_payment_days", DbType.Int32, purchaseOrder.DiscountApplicableBeforePaymentDays);
                    database.AddInParameter(dbCommand, "@expected_delivery_date", DbType.String, purchaseOrder.ExpectedDeliveryDate);
                    database.AddInParameter(dbCommand, "@no_of_days_for_payment", DbType.Int32, purchaseOrder.NoOfDaysForPayment);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, purchaseOrder.Remarks);
                    database.AddInParameter(dbCommand, "@order_status_id", DbType.Int32, purchaseOrder.OrderStatusId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, purchaseOrder.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, purchaseOrder.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, purchaseOrder.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, purchaseOrder.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseOrderId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseOrderId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseOrderId;
        }
        
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="purchaseOrderId"></param>
        ///// <returns></returns>
        //public bool CheckPurchaseOrderExistsInSalesBill(Int32 purchaseOrderId)
        //{
        //    bool IsPurchaseBillExists = false;

        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckPurchaseBillExistsInSalesBill))
        //        {
        //            database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrderId);

        //            using (IDataReader reader = database.ExecuteReader(dbCommand))
        //            {
        //                while (reader.Read())
        //                {
        //                    IsPurchaseBillExists = DRE.GetBoolean(reader, "is_purchase_bill_exists");
        //                }
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbCommand = null;
        //    }

        //    return IsPurchaseBillExists;

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        //public bool CheckPurchaseBillExistsInGoodsReceiptAndInward(Int32 purchaseOrderId)
        //{
        //    bool IsPurchaseBillExists = false;

        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckPurchaseBillExistsInGoodsReceiptsAndInward))
        //        {
        //            database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrderId);

        //            using (IDataReader reader = database.ExecuteReader(dbCommand))
        //            {
        //                while (reader.Read())
        //                {
        //                    IsPurchaseBillExists = DRE.GetBoolean(reader, "is_purchase_bill_exists");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbCommand = null;
        //    }

        //    return IsPurchaseBillExists;

        //}


        /// <summary>
        /// Save Purchase Bill
        /// </summary>
        /// <param name="purchaseOrder"></param>
        /// <returns></returns>
        public Int32 SavePurchaseOrder(Entities.PurchaseOrder purchaseOrder)
        {
            var purchaseOrderId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var purchaseOrderItemId = 0;
                        //var purchaseBillChargeId = 0;

                        if (purchaseOrder != null)
                        {
                            if (purchaseOrder.PurchaseOrderId == null || purchaseOrder.PurchaseOrderId == 0)
                            {
                                var isPurchaseOrderNoExists = CheckPurchaseOrderNoIsExists(purchaseOrder);

                                if (isPurchaseOrderNoExists == false)
                                {
                                    purchaseOrderId = AddPurchaseOrder(purchaseOrder, transaction);
                                }
                                else
                                {
                                    purchaseOrderId = -1;
                                }
                            }
                            else
                            {
                                purchaseOrderId = Convert.ToInt32(purchaseOrder.PurchaseOrderId);

                                if (purchaseOrder.IsDeleted == true)
                                {
                                    var result = DeletePurchaseOrder(purchaseOrder, transaction);

                                    if (result)
                                    {
                                        purchaseOrderId = (int)purchaseOrder.PurchaseOrderId;
                                    }
                                }
                                else
                                {
                                    if (purchaseOrder.ModifiedBy > 0 || purchaseOrder.ModifiedBy != null)
                                    {
                                        purchaseOrderId = UpdatePurchaseOrder(purchaseOrder, transaction);
                                    }
                                }
                            }

                            if (purchaseOrderId > 0)
                            {
                                if (purchaseOrder.PurchaseOrderItems != null) {

                                    foreach (Entities.PurchaseOrderItem purchaseOrderItem in purchaseOrder.PurchaseOrderItems)
                                    {
                                        purchaseOrderItem.PurchaseOrderId = purchaseOrderId;

                                        PurchaseOrderItem purchaseOrderItemDL = new PurchaseOrderItem();

                                        purchaseOrderItemId = purchaseOrderItemDL.SavePurchaseOrderItem(purchaseOrderItem, transaction);
                                    }

                                }

                            }

                            //if (purchaseOrderId > 0)
                            //{
                            //    if (purchaseOrder.PurchaseBillChargesDetails != null)
                            //    {
                            //        if (purchaseOrder.PurchaseBillChargesDetails.Count > 0)
                            //        {
                            //            foreach (Entities.PurchaseOrderChargesDetails billCharges in purchaseOrder.PurchaseBillChargesDetails)
                            //            {
                            //                billCharges.purchaseOrderId = purchaseOrderId;

                            //                PurchaseBillChargesDetails purchaseBillChargesDetails = new PurchaseBillChargesDetails();

                            //                purchaseBillChargeId = purchaseBillChargesDetails.SavePurchaseBillCharges(billCharges, transaction);

                            //                if (purchaseBillChargeId < 0)
                            //                {
                            //                    purchaseOrderId = -1;
                            //                }
                            //            }
                            //        }
                            //    }
                            //}
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

            return purchaseOrderId;

        }



    }
}
