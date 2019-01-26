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
    public class SalesReturnBillItem
    {
        private readonly Database database;

        public SalesReturnBillItem()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddSalesReturnBillItem(Entities.SalesReturnBillItem salesReturnBillItem)
        {
            var salesReturnBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesReturnBillItem))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_item_id", DbType.Int32, salesReturnBillItem.SalesReturnBillItemId);
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBillItem.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, salesReturnBillItem.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesReturnBillItem.ItemId);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, salesReturnBillItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@return_qty", DbType.Decimal, salesReturnBillItem.ReturnQty);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Int32, salesReturnBillItem.SaleRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, salesReturnBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, salesReturnBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, salesReturnBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, salesReturnBillItem.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesReturnBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesReturnBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@item_remakrs", DbType.String, salesReturnBillItem.ItemRemarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesReturnBillItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesReturnBillItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesReturnBillItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBillItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddSalesReturnBillItem(Entities.SalesReturnBillItem salesReturnBillItem, DbTransaction transaction)
        {
            var salesReturnBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesReturnBillItem))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_item_id", DbType.Int32, salesReturnBillItem.SalesReturnBillItemId);
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBillItem.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@sales_bill_item_id", DbType.Int32, salesReturnBillItem.SalesBillItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesReturnBillItem.ItemId);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, salesReturnBillItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@return_qty", DbType.Decimal, salesReturnBillItem.ReturnQty);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Int32, salesReturnBillItem.SaleRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, salesReturnBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, salesReturnBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, salesReturnBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, salesReturnBillItem.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesReturnBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesReturnBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@item_remarks", DbType.String, salesReturnBillItem.ItemRemarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesReturnBillItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesReturnBillItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesReturnBillItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBillItem"></param>
        /// <returns></returns>
        private bool DeleteSalesReturnBillItem(Entities.SalesReturnBillItem salesReturnBillItem)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesReturnBillItem))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_item_id", DbType.Int32, salesReturnBillItem.SalesReturnBillItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesReturnBillItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesReturnBillItem.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return isDeleted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBillItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool DeleteSalesReturnBillItem(Entities.SalesReturnBillItem salesReturnBillItem, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesReturnBillItem))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_item_id", DbType.Int32, salesReturnBillItem.SalesReturnBillItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesReturnBillItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesReturnBillItem.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return isDeleted;
        }

        private Int32 UpdateSalesReturnBillItem(Entities.SalesReturnBillItem salesReturnBillItem)
        {
            var salesReturnBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesReturnBillItem))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_item_id", DbType.Int32, salesReturnBillItem.SalesReturnBillItemId);
                    database.AddInParameter(dbCommand, "@return_qty", DbType.Decimal, salesReturnBillItem.ReturnQty);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Decimal, salesReturnBillItem.SaleRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, salesReturnBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, salesReturnBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, salesReturnBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, salesReturnBillItem.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesReturnBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesReturnBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@item_remarks", DbType.String, salesReturnBillItem.ItemRemarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesReturnBillItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesReturnBillItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesReturnBillItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBillItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdateSalesReturnBillItem(Entities.SalesReturnBillItem salesReturnBillItem, DbTransaction transaction)
        {
            var salesReturnBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesReturnBillItem))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_item_id", DbType.Int32, salesReturnBillItem.SalesReturnBillItemId);
                    database.AddInParameter(dbCommand, "@return_qty", DbType.Decimal, salesReturnBillItem.ReturnQty);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Decimal, salesReturnBillItem.SaleRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, salesReturnBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, salesReturnBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, salesReturnBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, salesReturnBillItem.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesReturnBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesReturnBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@item_remarks", DbType.String, salesReturnBillItem.ItemRemarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesReturnBillItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesReturnBillItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesReturnBillItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBillId"></param>
        /// <returns></returns>
        public List<Entities.SalesReturnBillItem> GetSalesReturnBillItemsBySalesReturnBillId(Int32 salesReturnBillId)
        {
            var salesReturnBillItems = new List<Entities.SalesReturnBillItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesReturnBillItemBySalesBillReturnId))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesReturnBillItem = new Entities.SalesReturnBillItem
                            {
                                SalesReturnBillItemId = DRE.GetNullableInt32(reader, "sales_return_bill_item_id", null),
                                SalesReturnBillId = DRE.GetNullableInt32(reader, "sales_return_bill_id", null),
                                SalesBillItemId = DRE.GetNullableInt32(reader, "sales_bill_item_id", null),                                
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                HSNCode = DRE.GetNullableString(reader, "hsn_code", null),
                                ReturnQty = DRE.GetNullableDecimal(reader, "return_qty", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                SaleRate = DRE.GetNullableDecimal(reader, "sale_rate", null),                                
                                TypeOfDiscount = DRE.GetNullableString(reader, "type_of_discount", null),
                                CashDiscountPercent = DRE.GetNullableDecimal(reader, "cash_discount_percent", null),
                                DiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null),
                                IsTaxInclusive = DRE.GetNullableBoolean(reader, "is_tax_inclusive", null),
                                TaxableValue = DRE.GetNullableDecimal(reader, "taxable_value", null),
                                GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", null),
                                GSTRate = DRE.GetNullableDecimal(reader, "gst_rate", null),
                                TaxId = DRE.GetNullableInt32(reader, "tax_id", null),
                                GSTName = DRE.GetNullableString(reader, "gst_name", null),
                                GSTAmount = DRE.GetNullableDecimal(reader, "gst_amount", null),
                                TotalItemAmount = DRE.GetNullableDecimal(reader, "total_item_amount", null),
                                ItemRemarks = DRE.GetNullableString(reader, "item_remarks", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null)
                            };

                            salesReturnBillItems.Add(salesReturnBillItem);
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

            return salesReturnBillItems;

        }

        
        //TODO: This method may not be required
        //public List<Entities.SalesReturnBillItem> GetSalesReturnBillItemsByBarcode(Int32 goodsReceiptItemId)
        //{
        //    var salesReturnBillItems = new List<Entities.SalesReturnBillItem>();

        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesReturnBillItemsByBarcode))
        //        {
        //            database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, goodsReceiptItemId);

        //            using (IDataReader reader = database.ExecuteReader(dbCommand))
        //            {
        //                while (reader.Read())
        //                {
        //                    var salesReturnBillItem = new Entities.SalesReturnBillItem
        //                    {
        //                        GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
        //                        ItemId = DRE.GetNullableInt32(reader, "item_id", null),
        //                        ItemName = DRE.GetNullableString(reader, "item_name", null),
        //                        HSNCode = DRE.GetNullableString(reader, "hsn_code", null),
        //                        UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
        //                        UnitCode = DRE.GetNullableString(reader, "unit_code", null)                                
        //                    };

        //                    salesReturnBillItems.Add(salesReturnBillItem);
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

        //    return salesReturnBillItems;
        //}

        public List<Entities.SalesReturnBillItem> GetSalesReturnBillItemsByConsignee(Int32 consigneeId)
        {
            var salesReturnBillItems = new List<Entities.SalesReturnBillItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesReturnBillItemsByConsignee))
                {
                    database.AddInParameter(dbCommand, "@consignee_id", DbType.Int32, consigneeId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesReturnBillItem = new Entities.SalesReturnBillItem
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                HSNCode = DRE.GetNullableString(reader, "hsn_code", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                ReturnQty = DRE.GetNullableDecimal(reader, "balance_qty", null),
                                TypeOfDiscount = DRE.GetNullableString(reader, "type_of_discount", null),
                                CashDiscountPercent = DRE.GetNullableDecimal(reader, "cash_discount_percent", null),
                                GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", null),
                                GSTRate = DRE.GetNullableDecimal(reader, "gst_rate", null),
                                TaxId = DRE.GetNullableInt32(reader, "tax_id", null),
                                SalesBillItemId = DRE.GetNullableInt32(reader, "sales_bill_item_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null)
                            };

                            salesReturnBillItems.Add(salesReturnBillItem);
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

            return salesReturnBillItems;
        }

        public List<Entities.SalesReturnBillItem> GetSalesReturnBillItemsByItemName(string itemName)
        {
            var salesReturnBillItems = new List<Entities.SalesReturnBillItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesReturnBillItemsByBarcode))
                {
                    database.AddInParameter(dbCommand, "@item_name", DbType.String, itemName);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesReturnBillItem = new Entities.SalesReturnBillItem
                            {
                                GoodsReceiptItemId = 0,
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                HSNCode = DRE.GetNullableString(reader, "hsn_code", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null)
                            };

                            salesReturnBillItems.Add(salesReturnBillItem);
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

            return salesReturnBillItems;
        }

        public Int32 SaveSalesBillReturnItem(Entities.SalesReturnBillItem salesReturnBillItem, DbTransaction transaction)
        {
            var result = 0;

            if (salesReturnBillItem.SalesReturnBillItemId == null || salesReturnBillItem.SalesReturnBillItemId == 0)
            {
                result = AddSalesReturnBillItem(salesReturnBillItem, transaction);
            }
            else if (salesReturnBillItem.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesReturnBillItem(salesReturnBillItem, transaction));

                if (result == 1)
                {
                    result = Convert.ToInt32(salesReturnBillItem.SalesReturnBillItemId);
                }
            }
            else if (salesReturnBillItem.ModifiedBy > 0)
            {
                result = UpdateSalesReturnBillItem(salesReturnBillItem, transaction);
            }

            return result;
        }

    }
}
