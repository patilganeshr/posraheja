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
    public class SalesBillItem
    {
        private readonly Database database;

        public SalesBillItem()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddSalesBillItem(Entities.SalesBillItem salesBillItem)
        {
            var salesBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBillsItem))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, salesBillItem.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBillItem.SalesBillId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, salesBillItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesBillItem.ItemId);
                    database.AddInParameter(dbCommand, "@sale_qty", DbType.Decimal, salesBillItem.SaleQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, salesBillItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Decimal, salesBillItem.SaleRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, salesBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, salesBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, salesBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@rate_adjustment", DbType.String, salesBillItem.RateAdjustment);
                    database.AddInParameter(dbCommand, "@rate_adjustment_remarks", DbType.String, salesBillItem.RateAdjustmentRemarks);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesBillItem.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesBillItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesBillItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillItemId;
        }

        private Int32 AddSalesBillItem(Entities.SalesBillItem salesBillItem, DbTransaction transaction)
        {
            var salesBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBillsItem))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, salesBillItem.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBillItem.SalesBillId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, salesBillItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesBillItem.ItemId);
                    database.AddInParameter(dbCommand, "@sale_qty", DbType.Decimal, salesBillItem.SaleQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, salesBillItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Decimal, salesBillItem.SaleRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, salesBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, salesBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, salesBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@rate_adjustment", DbType.String, salesBillItem.RateAdjustment);
                    database.AddInParameter(dbCommand, "@rate_adjustment_remarks", DbType.String, salesBillItem.RateAdjustmentRemarks);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesBillItem.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesBillItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesBillItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillItemId;
        }

        private bool DeleteSalesBillItem(Entities.SalesBillItem salesBillItem)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBillsItem))
                {
                    database.AddInParameter(dbCommand, "@sales_bills_item_id", DbType.Int32, salesBillItem.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesBillItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesBillItem.DeletedByIP);

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

        private bool DeleteSalesBillItem(Entities.SalesBillItem salesBillItem, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBillsItem))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, salesBillItem.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesBillItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesBillItem.DeletedByIP);

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

        public List<Entities.SalesBillItem> GetSalesBillItemsBySalesBillId(Int32 salesBillId)
        {
            var salesBillItems = new List<Entities.SalesBillItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillsItemsBySalesBillId))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            SalesBillItemChargesDetails billItemChargesDetails = new SalesBillItemChargesDetails();

                            var salesBillItem = new Entities.SalesBillItem
                            {
                                SalesBillItemId = DRE.GetNullableInt32(reader, "sales_bill_item_id", null),
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", 0),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", 0),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader,"unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                HSNCode = DRE.GetNullableString(reader, "hsn_code", null),
                                SaleQty = DRE.GetNullableDecimal(reader, "sale_qty", null),
                                SaleRate = DRE.GetNullableDecimal(reader, "sale_rate", null),
                                Amount = DRE.GetNullableDecimal(reader, "amount", null),
                                TypeOfDiscount = DRE.GetNullableString(reader,"type_of_discount", null),
                                CashDiscountPercent  = DRE.GetNullableDecimal(reader, "cash_discount_percent", null),
                                DiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null),
                                TotalAmountAfterDiscount = DRE.GetNullableDecimal(reader, "total_amount_after_discount", null),
                                RateAdjustment = DRE.GetNullableString(reader, "rate_adjustment", null),
                                RateAdjustmentRemarks = DRE.GetNullableString(reader, "rate_adjustment_remarks", null),
                                TaxableValue = DRE.GetNullableDecimal(reader, "amount_before_tax", null),
                                TaxId = DRE.GetNullableInt32(reader, "tax_id", null),
                                GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", null),
                                GSTRate  = DRE.GetNullableDecimal(reader, "gst_rate", null),
                                GSTName  = DRE.GetNullableString(reader,"gst_name", null),
                                GSTAmount = DRE.GetNullableDecimal(reader, "gst_amount", null),
                                TotalItemAmount = DRE.GetNullableDecimal(reader, "total_item_amount", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                                SalesBillItemCharges = billItemChargesDetails.GetBillitemChargesDetailsBySalesBillItemId(DRE.GetInt32(reader, "sales_bill_item_id"))
                            };

                            salesBillItems.Add(salesBillItem);
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

            return salesBillItems;
        }
        
        private Int32 UpdateSalesBillItem(Entities.SalesBillItem salesBillItem)
        {
            var salesBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesBillsItem))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, salesBillItem.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBillItem.SalesBillId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, salesBillItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesBillItem.ItemId);
                    database.AddInParameter(dbCommand, "@sale_qty", DbType.Decimal, salesBillItem.SaleQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, salesBillItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Decimal, salesBillItem.SaleRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, salesBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, salesBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, salesBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@rate_adjustment", DbType.String, salesBillItem.RateAdjustment);
                    database.AddInParameter(dbCommand, "@rate_adjustment_remarks", DbType.String, salesBillItem.RateAdjustmentRemarks);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesBillItem.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesBillItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesBillItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillItemId;
        }

        private Int32 UpdateSalesBillItem(Entities.SalesBillItem salesBillItem, DbTransaction transaction)
        {
            var salesBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesBillsItem))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, salesBillItem.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBillItem.SalesBillId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, salesBillItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesBillItem.ItemId);
                    database.AddInParameter(dbCommand, "@sale_qty", DbType.Decimal, salesBillItem.SaleQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, salesBillItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Decimal, salesBillItem.SaleRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, salesBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, salesBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, salesBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@rate_adjustment", DbType.String, salesBillItem.RateAdjustment);
                    database.AddInParameter(dbCommand, "@rate_adjustment_remarks", DbType.String, salesBillItem.RateAdjustmentRemarks);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesBillItem.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesBillItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesBillItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillItemId;
        }

        public Int32 SaveSalesBillItem(Entities.SalesBillItem salesBillItem)
        {
            var result = 0;

            if(salesBillItem.SalesBillItemId == null || salesBillItem.SalesBillItemId == 0)
            {
                result = AddSalesBillItem(salesBillItem);
            }
            else if(salesBillItem.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesBillItem(salesBillItem));
            } 
            else if(salesBillItem.ModifiedBy > 0)
            {
                result = UpdateSalesBillItem(salesBillItem);
            }

            return result;
        }

        public List<Entities.SalesBillItem> SearchSaleItemByItemName(string itemName)
        {
            var items = new List<Entities.SalesBillItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.SearchSaleItemsByItemName))
                {
                    database.AddInParameter(dbCommand, "@item_name", DbType.String, itemName);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var item = new Entities.SalesBillItem
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                StockQty = DRE.GetNullableDecimal(reader, "stock_qty", null)
                            };

                            items.Add(item);
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

            return items;
        }

        public Int32 SaveSalesBillItem(Entities.SalesBillItem salesBillItem, DbTransaction transaction)
        {
            var result = 0;

            if (salesBillItem.SalesBillItemId == null || salesBillItem.SalesBillItemId == 0)
            {
                result = AddSalesBillItem(salesBillItem, transaction);
            }
            else if (salesBillItem.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesBillItem(salesBillItem, transaction));

                if (result == 1)
                {
                    result = Convert.ToInt32(salesBillItem.SalesBillItemId);
                }
            }
            else if (salesBillItem.ModifiedBy > 0)
            {
                result = UpdateSalesBillItem(salesBillItem, transaction);
            }

            return result;
        }

    }
}
