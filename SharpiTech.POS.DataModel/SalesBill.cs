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
    public class SalesBill
    {
        private readonly Database database;

        public SalesBill()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddSalesBill(Entities.SalesBill salesBill)
        {
            var salesBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBill))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBill.SalesBillId);
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesBill.SalesOrderId);
                    database.AddInParameter(dbCommand, "@sales_bill_no", DbType.Int32, salesBill.SalesBillNo);
                    database.AddInParameter(dbCommand, "@sales_bill_date", DbType.String, salesBill.SalesBillDate);
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, salesBill.CustomerId);
                    database.AddInParameter(dbCommand, "@consignee_id", DbType.Int32, salesBill.ConsigneeId);
                    database.AddInParameter(dbCommand, "@salesman_id", DbType.Int32, salesBill.SalesmanId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, salesBill.SaleTypeId);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, salesBill.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, salesBill.GSTApplicable);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesBill.BranchId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesBill.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesBill.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesBill.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillId;
        }

        private Int32 AddSalesBill(Entities.SalesBill salesBill, DbTransaction transaction)
        {
            var salesBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBill))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBill.SalesBillId);
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesBill.SalesOrderId);
                    database.AddInParameter(dbCommand, "@sales_bill_no", DbType.Int32, salesBill.SalesBillNo);
                    database.AddInParameter(dbCommand, "@sales_bill_date", DbType.String, salesBill.SalesBillDate);
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, salesBill.CustomerId);
                    database.AddInParameter(dbCommand, "@consignee_id", DbType.Int32, salesBill.ConsigneeId);
                    database.AddInParameter(dbCommand, "@salesman_id", DbType.Int32, salesBill.SalesmanId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, salesBill.SaleTypeId);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, salesBill.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, salesBill.GSTApplicable);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesBill.BranchId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesBill.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesBill.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesBill.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillId;
        }

        private bool DeleteSalesBill(Entities.SalesBill salesBill)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBill))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBill.SalesBillId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesBill.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesBill.DeletedByIP);
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

        private bool DeleteSalesBill(Entities.SalesBill salesBill, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBill))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBill.SalesBillId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesBill.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesBill.DeletedByIP);
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

        public List<Entities.SalesBill> GetSalesBillsByBranchId(Int32 branchId, Int32 workingPeriodId)
        {
            var salesBills = new List<Entities.SalesBill>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillsByBranchId))
                {
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, branchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            SalesBillItem salesBillItem = new SalesBillItem();
                            SalesBillDeliveryDetails deliveryDetails = new SalesBillDeliveryDetails();
                            SalesBillPaymentDetails paymentDetails = new SalesBillPaymentDetails();
                            SalesBillChargesDetails billChargesDetails = new SalesBillChargesDetails();
                            
                            var salesBill = new Entities.SalesBill
                            {
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", 0),
                                SalesBillNo = DRE.GetNullableInt32(reader, "sales_bill_no", null),
                                SalesBillDate = DRE.GetNullableString(reader, "sales_order_no_series", null),
                                CustomerId = DRE.GetNullableInt32(reader, "customer_id", null),
                                SaleTypeId = DRE.GetNullableInt32(reader, "sale_type_id", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                TotalSaleQty = DRE.GetNullableDecimal(reader, "total_sale_qty", null),
                                TotalSaleAmount = DRE.GetNullableDecimal(reader, "total_sale_amount", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                                SalesBillDeliveryDetails = deliveryDetails.GetDeliveryDetailsBySalesBillId(DRE.GetInt32(reader, "sales_bill_id")),
                                SalesBillPaymentDetails = paymentDetails.GetPaymentDetailsBySalesBillId(DRE.GetInt32(reader, "sales_bill_id")),
                                SalesBillChargesDetails = billChargesDetails.GetBillChargesDetailsBySalesBillId(DRE.GetInt32(reader, "sales_bill_id")),
                                SalesBillItems = salesBillItem.GetSalesBillItemsBySalesBillId(DRE.GetInt32(reader, "sales_bill_id"))
                            };

                            salesBills.Add(salesBill);
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

            return salesBills;
        }

        public bool CheckSalesBillNoIsExists(Entities.SalesBill salesBill)
        {
            bool isBillNoExists = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckSalesBillNoIsExists))
                {
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, salesBill.SaleTypeId);
                    database.AddInParameter(dbCommand, "@sales_bill_no", DbType.Int32, salesBill.SalesBillNo);
                    
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            isBillNoExists = DRE.GetBoolean(reader, "is_bill_no_exists");
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

            return isBillNoExists;
        }

        public List<Entities.SalesBill> GetSalesBillsBySaleType(Int32 branchId, Int32 workingPeriodId, Int32 saleTypeId)
        {
            var salesBills = new List<Entities.SalesBill>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillsBySaleType))
                {
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, branchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, saleTypeId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            SalesBillItem salesBillItem = new SalesBillItem();
                            SalesBillPaymentDetails salesBillPayment = new SalesBillPaymentDetails();
                            SalesBillDeliveryDetails salesBillDelivery = new SalesBillDeliveryDetails();

                            var salesBill = new Entities.SalesBill
                            {
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", 0),
                                SalesBillNo = DRE.GetNullableInt32(reader, "sales_bill_no", null),
                                SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),
                                CustomerId = DRE.GetNullableInt32(reader, "customer_id", null),
                                CustomerName = DRE.GetNullableString(reader, "customer_name", null),
                                ConsigneeId = DRE.GetNullableInt32(reader, "consignee_id", null),
                                ConsigneeName = DRE.GetNullableString(reader, "consignee_name", null),
                                SaleTypeId = DRE.GetNullableInt32(reader, "sale_type_id", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                TotalSaleQty  = DRE.GetNullableDecimal(reader,"total_sale_qty", null),
                                TotalSaleAmount = DRE.GetNullableDecimal(reader, "total_sale_amount", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear =DRE.GetNullableString(reader,"financial_year", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader,"company_name", null),
                                SalesmanId = DRE.GetNullableInt32(reader, "salesman_id", null),
                                SalesmanName = DRE.GetNullableString(reader, "salesman_name", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                                SalesBillItems = salesBillItem.GetSalesBillItemsBySalesBillId(DRE.GetInt32(reader, "sales_bill_id")),
                                SalesBillPaymentDetails = salesBillPayment.GetPaymentDetailsBySalesBillId(DRE.GetInt32(reader, "sales_bill_id")),
                                SalesBillDeliveryDetails = salesBillDelivery.GetDeliveryDetailsBySalesBillId(DRE.GetInt32(reader, "sales_bill_id"))
                            };

                            salesBills.Add(salesBill);
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

            return salesBills;
        }

        public List<Entities.SalesBill> GetSalesBillsByCustomerId(Int32 customerId, Int32 workingPeriodId)
        {
            var salesBills = new List<Entities.SalesBill>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillsByCustomerId))
                {
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, customerId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesBill = new Entities.SalesBill
                            {
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", 0),
                                SalesBillNo = DRE.GetNullableInt32(reader, "sales_bill_no", null),
                                SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),
                                CustomerId = DRE.GetNullableInt32(reader, "customer_id", null),
                                SaleTypeId = DRE.GetNullableInt32(reader, "sale_type_id", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                TotalSaleQty = DRE.GetNullableDecimal(reader, "total_sale_qty", null),
                                TotalSaleAmount = DRE.GetNullableDecimal(reader, "total_sale_amount", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            salesBills.Add(salesBill);
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

            return salesBills;
        }

        public Entities.SalesBill GetSalesBillDetailsBySalesBillId(Int32 salesBillId)
        {
            var salesBillDetails = new Entities.SalesBill();

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillDetailsById))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBillId);

                    using(IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesBill = new Entities.SalesBill()
                            {
                                SalesBillNo=  DRE.GetNullableInt32(reader, "sales_bill_no", 0),
                                SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),
                                CustomerId = DRE.GetNullableInt32(reader, "customer_id", null),
                                SaleTypeId = DRE.GetNullableInt32(reader, "sale_type_id", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                TotalSaleQty = DRE.GetNullableDecimal(reader, "total_sale_qty", null),
                                TotalSaleAmount = DRE.GetNullableDecimal(reader, "total_sale_amount", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),

                            };
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

            return salesBillDetails;
        }

        public Entities.SalesBill GetSalesBillDetailsByWorkingPeriodSaleTypeAndSalesBillNo(Int32 workingPeriodId, Int32 saleTypeId, Int32 salesBillNo)
        {
            var salesBillDetails = new Entities.SalesBill();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillDetailsByWorkingPeriodSaleTypeAndSalesBillNo))
                {
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, saleTypeId);
                    database.AddInParameter(dbCommand, "@sales_bill_no", DbType.Int32, salesBillNo);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesBillItem = new SalesBillItem();
                            var salesBillPayment = new SalesBillPaymentDetails();
                            var salesBillDelivery = new SalesBillDeliveryDetails();
                            
                            var salesBill = new Entities.SalesBill()
                            {
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", 0),
                                SalesBillNo = DRE.GetNullableInt32(reader, "sales_bill_no", 0),
                                SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),
                                CustomerId = DRE.GetNullableInt32(reader, "customer_id", null),
                                CustomerName = DRE.GetNullableString(reader, "customer_name", null),
                                ConsigneeId = DRE.GetNullableInt32(reader, "consignee_id", null),
                                ConsigneeName = DRE.GetNullableString(reader, "consignee_name", null),
                                SaleTypeId = DRE.GetNullableInt32(reader, "sale_type_id", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader,"company_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                IsTaxInclusive = DRE.GetNullableBoolean(reader, "is_tax_inclusive", false),
                                GSTApplicable = DRE.GetNullableString(reader, "gst_applicable", null),
                                SalesmanId =DRE.GetNullableInt32(reader, "salesman_id", null),
                                SalesmanName = DRE.GetNullableString(reader,"salesman_name", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                IsDeleted = DRE.GetNullableBoolean(reader, "is_deleted", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SalesBillItems = salesBillItem.GetSalesBillItemsBySalesBillId(DRE.GetInt32(reader, "sales_bill_id")),
                                SalesBillPaymentDetails = salesBillPayment.GetPaymentDetailsBySalesBillId(DRE.GetInt32(reader, "sales_bill_id")),
                                SalesBillDeliveryDetails = salesBillDelivery.GetDeliveryDetailsBySalesBillId(DRE.GetInt32(reader, "sales_bill_id"))
                            };

                            salesBillDetails = salesBill;
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

            return salesBillDetails;
        }

        public List<Entities.TypeOfSale> GetTypeOfSales()
        {
            var typeOfSales = new List<Entities.TypeOfSale>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetTypeOfSales))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var typeOfSale = new Entities.TypeOfSale()
                            {
                                SaleTypeId = DRE.GetNullableInt32(reader, "sale_type_id", 0),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null)                                
                            };

                            typeOfSales.Add(typeOfSale);
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

            return typeOfSales;
        }

        public Entities.SalesBillItem GetItemsListByGoodsReceiptBarcode(Int32 goodsReceiptItemId)
        {
            var itemDetails = new Entities.SalesBillItem();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemsListByGoodsReceiptBarcode))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, goodsReceiptItemId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesBillItem = new Entities.SalesBillItem()
                            {
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                InwardGoodsId = 0,
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                HSNCode = DRE.GetNullableString(reader, "hsn_code", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                IsSet = DRE.GetNullableBoolean(reader, "is_set", null),
                                IsSellAtNetRate = DRE.GetNullableBoolean(reader, "is_sell_at_net_rate", null),
                                SaleRate = DRE.GetNullableDecimal(reader, "flat_rate", null),
                                SalesSchemeId = DRE.GetNullableInt32(reader, "sales_scheme_id", null),
                                Scheme = DRE.GetNullableString(reader, "scheme", null),
                                TypeOfDiscount = DRE.GetNullableString(reader, "type_of_discount", null),
                                SchemeDiscountPercent = DRE.GetNullableDecimal(reader, "discount_percent", null),
                                SchemeDiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null)
                            };

                            itemDetails = salesBillItem;
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

        public Entities.SalesBillItem GetItemsListByGoodsReceiptAndInwardGoodsBarcode (Int32 goodsReceiptItemId, Int32 inwardGoodsId)
        {
            var itemDetails = new Entities.SalesBillItem();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemsListByGoodsReceiptAndInwardGoodsBarcode))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, goodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, inwardGoodsId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesBillItem = new Entities.SalesBillItem()
                            {
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                InwardGoodsId = DRE.GetNullableInt32(reader, "inward_goods_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                HSNCode = DRE.GetNullableString(reader, "hsn_code", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                IsSet = DRE.GetNullableBoolean(reader,"is_set", null),
                                IsSellAtNetRate = DRE.GetNullableBoolean(reader,"is_sell_at_net_rate", null),
                                SaleRate = DRE.GetNullableDecimal(reader, "flat_rate", null)
                            };

                            itemDetails = salesBillItem;
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

        public List<Entities.SaleItemRateHistory> GetItemRateHistory(Int32 customerId, Int32 itemId, Int32 saleTypeId)
        {
            var itemRateHistory = new List<Entities.SaleItemRateHistory>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRateHistoryFromSalesBill))
                {
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, customerId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, saleTypeId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var saleItemRateHistory = new Entities.SaleItemRateHistory()
                            {
                                CustomerName = DRE.GetNullableString(reader, "customer_name", null),
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", null),
                                SalesBillNo = DRE.GetNullableInt32(reader, "sales_bill_no", null),
                                SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),
                                SaleRate = DRE.GetNullableDecimal(reader, "sale_rate", null)
                            };

                            itemRateHistory.Add(saleItemRateHistory);
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

            return itemRateHistory;
        }

        public Entities.SalesBillItem GetItemDetailsByItemId(Int32 itemId)
        {
            var itemDetails = new Entities.SalesBillItem();

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
                            var salesBillItem = new Entities.SalesBillItem()
                            {
                                GoodsReceiptItemId = 0,
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                HSNCode = DRE.GetNullableString(reader, "hsn_code", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                IsSet = DRE.GetNullableBoolean(reader, "is_set", null),
                                IsSellAtNetRate = DRE.GetNullableBoolean(reader, "is_sell_at_net_rate", null),
                                SaleRate = DRE.GetNullableDecimal(reader, "flat_rate", null)
                            };

                            itemDetails = salesBillItem;
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

        public List<Entities.SalesBill> GetSaleRateHistoryByCustomerAndItem(Int32 customerId, Int32 itemId)
        {
            var saleRateHistory = new List<Entities.SalesBill>();

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSaleRateHistoryByCustomerAndItem))
                {
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, customerId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        var rateHistory = new Entities.SalesBill()
                        {
                            SalesBillId= DRE.GetNullableInt32(reader, "sales_bill_id", null),
                            SalesBillNo = DRE.GetNullableInt32(reader, "sales_bill_no", null),
                            SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),
                            SaleRate = DRE.GetNullableDecimal(reader, "sale_rate", null)
                        };

                        saleRateHistory.Add(rateHistory);
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

            return saleRateHistory;
        }

        public bool CancelSalesBill(Entities.SalesBill salesBill)
        {
            bool IsSalesBillCancelled = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CancelSalesBill))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBill.SalesBillId);
                    database.AddInParameter(dbCommand, "@cancelled_by", DbType.Int32, salesBill.CancelledBy);
                    
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsSalesBillCancelled = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsSalesBillCancelled;
        }

        private Int32 UpdateSalesBill(Entities.SalesBill salesBill)
        {
            var salesBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesBill))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBill.SalesBillId);
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesBill.SalesOrderId);                    
                    database.AddInParameter(dbCommand, "@sales_bill_date", DbType.String, salesBill.SalesBillDate);
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, salesBill.CustomerId);
                    database.AddInParameter(dbCommand, "@consignee_id", DbType.Int32, salesBill.ConsigneeId);
                    database.AddInParameter(dbCommand, "@salesman_id", DbType.Int32, salesBill.SalesmanId);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, salesBill.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, salesBill.GSTApplicable);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesBill.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesBill.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesBill.ModifiedByIP);
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillId;
        }

        private Int32 UpdateSalesBill(Entities.SalesBill salesBill, DbTransaction transaction)
        {
            var salesBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesBill))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBill.SalesBillId);
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesBill.SalesOrderId);                    
                    database.AddInParameter(dbCommand, "@sales_bill_date", DbType.String, salesBill.SalesBillDate);
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, salesBill.CustomerId);
                    database.AddInParameter(dbCommand, "@consignee_id", DbType.Int32, salesBill.ConsigneeId);
                    database.AddInParameter(dbCommand, "@salesman_id", DbType.Int32, salesBill.SalesmanId);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, salesBill.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, salesBill.GSTApplicable);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesBill.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesBill.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesBill.ModifiedByIP);
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillId;
        }

        public Int32 SaveSalesBill(Entities.SalesBill salesBill)
        {
            var salesBillId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var salesBillItemId = 0;
                        var salesBillDeliveryId = 0;
                        var salesBillPaymentId = 0;
                        var salesBillChargeId = 0;

                        if (salesBill != null)
                        {
                            if (salesBill.SalesBillId == null || salesBill.SalesBillId == 0)
                            {
                                salesBillId = AddSalesBill(salesBill, transaction);
                            }
                            else
                            {
                                if (salesBill.IsDeleted == true)
                                {
                                    var result = DeleteSalesBill(salesBill, transaction);

                                    salesBillId = Convert.ToInt32(salesBill.SalesBillId);
                                }
                                else
                                {
                                    if (salesBill.ModifiedBy > 0 || salesBill.ModifiedBy != null)
                                    {
                                        salesBillId = UpdateSalesBill(salesBill, transaction);

                                        // If records failed to save
                                        if (salesBillItemId < 0)
                                        {
                                            salesBillId = -1;
                                        }
                                    }
                                }
                            }

                            if (salesBillId > 0)
                            {
                                // Save Delivery Detials
                                if (salesBill.SalesBillDeliveryDetails != null)
                                {
                                    if (salesBill.SalesBillDeliveryDetails.Count > 0)
                                    {
                                        foreach (Entities.SalesBillDeliveryDetails deliveryDetails in salesBill.SalesBillDeliveryDetails)
                                        {
                                            deliveryDetails.SalesBillId = salesBillId;

                                            SalesBillDeliveryDetails deliveryDetailsDAL = new SalesBillDeliveryDetails();

                                            salesBillDeliveryId = deliveryDetailsDAL.SaveSalesBillDeliveryDetails(deliveryDetails, transaction);

                                            // If records failed to save
                                            if (salesBillItemId < 0)
                                            {
                                                salesBillId = -1;
                                            }
                                        }
                                    }
                                }

                                // Save Payment Details
                                if (salesBill.SalesBillPaymentDetails != null)
                                {
                                    if (salesBill.SalesBillPaymentDetails.Count > 0)
                                    {
                                        foreach (Entities.SalesBillPaymentDetails paymentDetails in salesBill.SalesBillPaymentDetails)
                                        {
                                            paymentDetails.SalesBillId = salesBillId;

                                            SalesBillPaymentDetails paymentDetailsDAL = new SalesBillPaymentDetails();

                                            salesBillPaymentId = paymentDetailsDAL.SaveSalesBillPaymentDetails(paymentDetails, transaction);

                                            // If records failed to save
                                            if (salesBillPaymentId < 0)
                                            {
                                                salesBillId = -1;
                                            }
                                        }
                                    }
                                }

                                if (salesBill.SalesBillChargesDetails != null)
                                {
                                    if (salesBill.SalesBillChargesDetails.Count > 0)
                                    {
                                        foreach (Entities.SalesBillChargesDetails billCharges in salesBill.SalesBillChargesDetails)
                                        {
                                            billCharges.SalesBillId = salesBillId;

                                            SalesBillChargesDetails salesBillChargesDetails = new SalesBillChargesDetails();

                                            salesBillChargeId = salesBillChargesDetails.SaveSalesBillCharges(billCharges, transaction);

                                            if (salesBillChargeId < 0)
                                            {
                                                salesBillId = -1;
                                            }
                                        }
                                    }
                                }

                                // Save sales bill items
                                foreach (Entities.SalesBillItem salesBillItem in salesBill.SalesBillItems)
                                {
                                    salesBillItem.SalesBillId = salesBillId;

                                    SalesBillItem salesBillItemDL = new SalesBillItem();

                                    salesBillItemId = salesBillItemDL.SaveSalesBillItem(salesBillItem, transaction);

                                    var salesBillItemChargeId = 0;

                                    if (salesBillItemId > 0)
                                    {
                                        if (salesBillItem.SalesBillItemCharges != null)
                                        {

                                            if (salesBillItem.SalesBillItemCharges.Count > 0)
                                            {
                                                foreach (Entities.SalesBillItemChargesDetails itemCharges in salesBillItem.SalesBillItemCharges)
                                                {
                                                    itemCharges.SalesBillItemId = salesBillItemId;

                                                    SalesBillItemChargesDetails itemChargesDetailsDAL = new SalesBillItemChargesDetails();

                                                    salesBillItemChargeId = itemChargesDetailsDAL.SaveSalesBillItemCharges(itemCharges, transaction);

                                                    // If records failed to save
                                                    if (salesBillItemId < 0)
                                                    {
                                                        salesBillId = -1;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (salesBillId > 0)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        salesBillId = -1;
                        transaction.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        db = null;
                    }
                }
            }

            return salesBillId;
        }

    }
}
