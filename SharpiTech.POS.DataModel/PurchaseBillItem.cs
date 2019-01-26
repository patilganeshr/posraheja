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
    public class PurchaseBillItem
    {
        private readonly Database database;

        public PurchaseBillItem()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillItem"></param>
        /// <returns></returns>
        private Int32 AddPurchaseBilItem(Entities.PurchaseBillItem purchaseBillItem)
        {
            var purchaseBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPurchaseBillItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_item_id", DbType.Int32, purchaseBillItem.PurchaseBillItemId);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillItem.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, purchaseBillItem.ItemId);
                    database.AddInParameter(dbCommand, "@bale_no", DbType.String, purchaseBillItem.BaleNo);
                    database.AddInParameter(dbCommand, "@lr_no", DbType.String, purchaseBillItem.LRNo);
                    database.AddInParameter(dbCommand, "@purchase_qty", DbType.Decimal, purchaseBillItem.PurchaseQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, purchaseBillItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@purchase_rate", DbType.Decimal, purchaseBillItem.PurchaseRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, purchaseBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, purchaseBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, purchaseBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, purchaseBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, purchaseBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_amount_as_per_vendor_bill", DbType.Decimal, purchaseBillItem.GSTAmountAsPerVendorBill);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, purchaseBillItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, purchaseBillItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseBillItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseBillItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddPurchaseBillItem(Entities.PurchaseBillItem purchaseBillItem, DbTransaction transaction)
        {
            var purchaseBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPurchaseBillItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_item_id", DbType.Int32, purchaseBillItem.PurchaseBillItemId);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillItem.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, purchaseBillItem.ItemId);
                    database.AddInParameter(dbCommand, "@bale_no", DbType.String, purchaseBillItem.BaleNo);
                    database.AddInParameter(dbCommand, "@lr_no", DbType.String, purchaseBillItem.LRNo);
                    database.AddInParameter(dbCommand, "@purchase_qty", DbType.Decimal, purchaseBillItem.PurchaseQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, purchaseBillItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@purchase_rate", DbType.Decimal, purchaseBillItem.PurchaseRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, purchaseBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, purchaseBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, purchaseBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, purchaseBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, purchaseBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_amount_as_per_vendor_bill", DbType.Decimal, purchaseBillItem.GSTAmountAsPerVendorBill);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, purchaseBillItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, purchaseBillItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseBillItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseBillItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillItem"></param>
        /// <returns></returns>
        private Boolean DeletePurchaseBillItem(Entities.PurchaseBillItem purchaseBillItem)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePurchaseBillItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_item_id", DbType.Int32, purchaseBillItem.PurchaseBillItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, purchaseBillItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, purchaseBillItem.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

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
        /// <param name="purchaseBillItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Boolean DeletePurchaseBillItem(Entities.PurchaseBillItem purchaseBillItem, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePurchaseBillItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_item_id", DbType.Int32, purchaseBillItem.PurchaseBillItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, purchaseBillItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, purchaseBillItem.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

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
        /// <param name="purchaseBillId"></param>
        /// <returns></returns>
        public List<Entities.PurchaseBillItem> GetPurchaseBillItemsByPuchaseBillId(Int32 purchaseBillId)
        {
            var purchaseBillItems = new List<Entities.PurchaseBillItem>();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillItemsByPurchaseBillId))
            {

                database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var purchaseBillItem = new Entities.PurchaseBillItem
                        {
                            PurchaseBillItemId = DRE.GetNullableInt32(reader, "purchase_bill_item_id", null),
                            PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", null),
                            ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                            ItemName = DRE.GetNullableString(reader, "item_name", null),
                            HSNCode = DRE.GetNullableString(reader,"hsn_code", null),
                            BaleNo = DRE.GetNullableString(reader, "bale_no", null),
                            LRNo = DRE.GetNullableString(reader, "lr_no", null),
                            PurchaseQty = DRE.GetNullableDecimal(reader, "purchase_qty", null),
                            UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                            UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                            PurchaseRate = DRE.GetNullableDecimal(reader, "purchase_rate", null),
                            TypeOfDiscount = DRE.GetNullableString(reader, "type_of_discount", null),
                            CashDiscountPercent = DRE.GetNullableDecimal(reader, "cash_discount_percent", null),
                            DiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null),
                            TaxableValue    = DRE.GetNullableDecimal(reader, "taxable_value"),
                            GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", null),
                            GSTRate = DRE.GetNullableDecimal(reader, "gst_rate", null),
                            TaxId = DRE.GetNullableInt32(reader, "tax_id", null),
                            TaxName = DRE.GetNullableString(reader, "tax_name", null),
                            Amount = DRE.GetNullableDecimal(reader, "amount", null),
                            GSTAmount = DRE.GetNullableDecimal(reader, "gst_amount", null),
                            TotalItemAmount = DRE.GetNullableDecimal(reader, "total_item_amount", null),
                            GSTAmountAsPerVendorBill = DRE.GetNullableDecimal(reader, "gst_amount_as_per_vendor_bill", null),
                            guid = DRE.GetNullableGuid(reader, "row_guid", null),
                            SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                        };

                        purchaseBillItems.Add(purchaseBillItem);
                    }
                }
            }

            return purchaseBillItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillItem"></param>
        /// <returns></returns>
        private Int32 UpdatePurchaseBillItem(Entities.PurchaseBillItem purchaseBillItem)
        {
            var purchaseBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePurchaseBillItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_item_id", DbType.Int32, purchaseBillItem.PurchaseBillItemId);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillItem.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, purchaseBillItem.ItemId);
                    database.AddInParameter(dbCommand, "@bale_no", DbType.String, purchaseBillItem.BaleNo);
                    database.AddInParameter(dbCommand, "@lr_no", DbType.String, purchaseBillItem.LRNo);
                    database.AddInParameter(dbCommand, "@purchase_qty", DbType.Decimal, purchaseBillItem.PurchaseQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, purchaseBillItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@purchase_rate", DbType.Decimal, purchaseBillItem.PurchaseRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, purchaseBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, purchaseBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, purchaseBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, purchaseBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, purchaseBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_amount_as_per_vendor_bill", DbType.Decimal, purchaseBillItem.GSTAmountAsPerVendorBill);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, purchaseBillItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, purchaseBillItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseBillItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseBillItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdatePurchaseBillItem(Entities.PurchaseBillItem purchaseBillItem, DbTransaction transaction)
        {
            var purchaseBillItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePurchaseBillItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_item_id", DbType.Int32, purchaseBillItem.PurchaseBillItemId);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillItem.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, purchaseBillItem.ItemId);
                    database.AddInParameter(dbCommand, "@bale_no", DbType.String, purchaseBillItem.BaleNo);
                    database.AddInParameter(dbCommand, "@lr_no", DbType.String, purchaseBillItem.LRNo);
                    database.AddInParameter(dbCommand, "@purchase_qty", DbType.Decimal, purchaseBillItem.PurchaseQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, purchaseBillItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@purchase_rate", DbType.Decimal, purchaseBillItem.PurchaseRate);
                    database.AddInParameter(dbCommand, "@type_of_discount", DbType.String, purchaseBillItem.TypeOfDiscount);
                    database.AddInParameter(dbCommand, "@cash_discount_percent", DbType.Decimal, purchaseBillItem.CashDiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, purchaseBillItem.DiscountAmount);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, purchaseBillItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, purchaseBillItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_amount_as_per_vendor_bill", DbType.Decimal, purchaseBillItem.GSTAmountAsPerVendorBill);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, purchaseBillItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, purchaseBillItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseBillItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseBillItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseBillItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillItem"></param>
        /// <returns></returns>
        public Int32 SavePurchaseBillItem(Entities.PurchaseBillItem purchaseBillItem)
        {
            var purchaseBillItemId = 0;

            if (purchaseBillItem.PurchaseBillItemId == null || purchaseBillItem.PurchaseBillItemId == 0)
            {
                purchaseBillItemId = AddPurchaseBilItem(purchaseBillItem);
            }
            else
            {
                if (purchaseBillItem.IsDeleted==true)
                {
                    purchaseBillItemId =  Convert.ToInt32(DeletePurchaseBillItem(purchaseBillItem));
                }
                else if (purchaseBillItem.ModifiedBy != null || purchaseBillItem.ModifiedBy > 0)
                {
                    purchaseBillItemId =  UpdatePurchaseBillItem(purchaseBillItem);
                }
            }
            return purchaseBillItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Int32 SavePurchaseBillItem(Entities.PurchaseBillItem purchaseBillItem, DbTransaction transaction)
        {
            var purchaseBillItemId = 0;

            if (purchaseBillItem.PurchaseBillItemId == null || purchaseBillItem.PurchaseBillItemId == 0)
            {
                purchaseBillItemId = AddPurchaseBillItem(purchaseBillItem, transaction);
            }
            else
            {
                if (purchaseBillItem.IsDeleted == true)
                {
                    purchaseBillItemId = Convert.ToInt32(DeletePurchaseBillItem(purchaseBillItem, transaction));
                }
                else if (purchaseBillItem.ModifiedBy != null || purchaseBillItem.ModifiedBy > 0)
                {
                    purchaseBillItemId = UpdatePurchaseBillItem(purchaseBillItem, transaction);
                }
            }

            return purchaseBillItemId;
        }

    }
}
