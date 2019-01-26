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
    public class GoodsReceipt
    {
        private readonly Database database;

        public GoodsReceipt()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceipt"></param>
        /// <returns></returns>
        private Int32 AddGoodsReceipt(Entities.GoodsReceipt goodsReceipt)
        {
            var goodsReceiptId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertGoodsReceipt))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceipt.GoodsReceiptId);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, goodsReceipt.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@goods_receipt_no", DbType.Int32, goodsReceipt.GoodsReceiptNo);                    
                    database.AddInParameter(dbCommand, "@goods_receipt_date", DbType.String, goodsReceipt.GoodsReceiptDate);
                    database.AddInParameter(dbCommand, "@goods_received_location_id", DbType.Int32, goodsReceipt.GoodsReceivedLocationId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, goodsReceipt.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, goodsReceipt.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, goodsReceipt.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, goodsReceipt.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    goodsReceiptId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        goodsReceiptId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return goodsReceiptId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceipt"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddGoodsReceipt(Entities.GoodsReceipt goodsReceipt, DbTransaction transaction)
        {
            var goodsReceiptId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertGoodsReceipt))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceipt.GoodsReceiptId);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, goodsReceipt.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@goods_receipt_no", DbType.Int32, goodsReceipt.GoodsReceiptNo);
                    database.AddInParameter(dbCommand, "@goods_receipt_date", DbType.String, goodsReceipt.GoodsReceiptDate);
                    database.AddInParameter(dbCommand, "@goods_received_location_id", DbType.Int32, goodsReceipt.GoodsReceivedLocationId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, goodsReceipt.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, goodsReceipt.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, goodsReceipt.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, goodsReceipt.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    goodsReceiptId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        goodsReceiptId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return goodsReceiptId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceipt"></param>
        /// <returns></returns>
        private Boolean DeleteGoodsReceipt(Entities.GoodsReceipt goodsReceipt)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteGoodsReceipt))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceipt.GoodsReceiptId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, goodsReceipt.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, goodsReceipt.DeletedByIP);

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
        /// <param name="goodsReceipt"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Boolean DeleteGoodsReceipt(Entities.GoodsReceipt goodsReceipt, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteGoodsReceipt))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceipt.GoodsReceiptId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, goodsReceipt.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, goodsReceipt.DeletedByIP);

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

        public List<Entities.PurchaseBill> GetVendors()
        {
            var vendors = new List<Entities.PurchaseBill>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetVendorsForGoodsReceipt))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var vendor = new Entities.PurchaseBill
                            {
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", 0),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null)
                            };

                            vendors.Add(vendor);
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

            return vendors;
        }

        public List<Entities.PurchaseBill> GetPendingPurchaseBills(Int32 vendorId)
        {
            var purchaseBills = new List<Entities.PurchaseBill>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPendingPurchaseBills))
                {
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseBill = new Entities.PurchaseBill
                            {
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", 0),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null)
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

        public List<Entities.GoodsReceiptItem> GetPurchaseBillItems(Int32 purchaseBillId)
        {
            var goodsReceiptItems = new List<Entities.GoodsReceiptItem>();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillItemsForGoodsReceipts))
            {
                database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var goodsReceiptItem = new Entities.GoodsReceiptItem
                        {
                            GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                            GoodsReceiptId = DRE.GetNullableInt32(reader, "goods_receipt_id", null),
                            PurchaseBillItemId = DRE.GetNullableInt32(reader, "purchase_bill_item_id", null),
                            BaleNo = DRE.GetNullableString(reader, "bale_no", null),
                            LRNo = DRE.GetNullableString(reader, "lr_no", null),
                            ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                            ItemName = DRE.GetNullableString(reader, "item_name", null),
                            UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                            UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                            PurchaseQty = DRE.GetNullableDecimal(reader, "purchase_qty", null),                            
                            ReceivedQty = DRE.GetNullableDecimal(reader, "received_qty", null),                            
                            guid = DRE.GetNullableGuid(reader, "row_guid", null),
                            SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                        };

                        goodsReceiptItems.Add(goodsReceiptItem);
                    }
                }
            }

            return goodsReceiptItems;
        }

        public List<Entities.GoodsReceipt> GetAllGoodsReceipts()
        {
            var goodsReceipts = new List<Entities.GoodsReceipt>();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllGoodsReceipts))
            {
                database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, 1);
                database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, 1);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var goodsReceiptItem = new GoodsReceiptItem();

                        var goodsReceipt = new Entities.GoodsReceipt
                        {
                            GoodsReceiptId = DRE.GetNullableInt32(reader, "goods_receipt_id", null),
                            PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", null),
                            GoodsReceiptNo = DRE.GetNullableInt32(reader, "goods_receipt_no", null),
                            GoodsReceiptDate = DRE.GetNullableString(reader, "goods_receipt_date", null),
                            PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                            VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                            VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                            TransporterId = DRE.GetNullableInt32(reader, "transporter_id", null),
                            TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                            ChallanNo = DRE.GetNullableString(reader, "challan_no", null),
                            TotalQtyReceived = DRE.GetNullableDecimal(reader, "total_qty_received", null),
                            UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                            GoodsReceivedLocationId = DRE.GetNullableInt32(reader, "goods_received_location_id", null),
                            GoodsReceivedLocationName = DRE.GetNullableString(reader, "goods_received_location_name", null),
                            FinancialYear = DRE.GetNullableString(reader,"financial_year", null),
                            guid = DRE.GetNullableGuid(reader, "row_guid", null),
                            SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                            GoodsReceiptItems = goodsReceiptItem.GetGoodsReceiptItemsByGoodsReceiptId(DRE.GetInt32(reader, "goods_receipt_id"))
                        };

                        goodsReceipts.Add(goodsReceipt);
                    }
                }
            }

            return goodsReceipts;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillId"></param>
        /// <returns></returns>
        public List<Entities.GoodsReceipt> GetGoodsReceiptsByPurchaseBillId(Int32 purchaseBillId)
        {
            var goodsReceipts = new List<Entities.GoodsReceipt>();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetGoodsReceiptByPurchaseBillId))
            {
                database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var goodsReceipt = new Entities.GoodsReceipt
                        {
                            GoodsReceiptId = DRE.GetNullableInt32(reader, "goods_receipt_id", null),
                            PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", null),
                            GoodsReceiptNo = DRE.GetNullableInt32(reader, "goods_receipt_no", null),
                            GoodsReceiptDate = DRE.GetNullableString(reader, "goods_receipt_date", null),
                            PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                            PurchaseBillDate = DRE.GetNullableString(reader, "purchase_bill_date", null),
                            TotalQtyReceived = DRE.GetNullableDecimal(reader, "total_qty_received", null),
                            UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                            GoodsReceivedLocationId = DRE.GetNullableInt32(reader, "goods_received_location_id", null),
                            GoodsReceivedLocationName = DRE.GetNullableString(reader, "goods_received_location_name", null),
                            FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                            guid = DRE.GetNullableGuid(reader, "row_guid", null),
                            SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                        };

                        goodsReceipts.Add(goodsReceipt);
                    }
                }
            }

            return goodsReceipts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public List<Entities.GoodsReceipt> GetGoodsReceiptsByVendorId(Int32 vendorId)
        {
            var goodsReceipts = new List<Entities.GoodsReceipt>();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetGoodsReceiptByVendorId))
            {
                database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var goodsReceipt = new Entities.GoodsReceipt
                        {
                            GoodsReceiptId = DRE.GetNullableInt32(reader, "goods_receipt_id", null),
                            PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", null),
                            GoodsReceiptNo = DRE.GetNullableInt32(reader, "goods_receipt_no", null),
                            GoodsReceiptDate = DRE.GetNullableString(reader, "goods_receipt_date", null),
                            PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                            PurchaseBillDate = DRE.GetNullableString(reader, "purchase_bill_date", null),
                            TotalQtyReceived = DRE.GetNullableDecimal(reader, "total_qty_received", null),
                            UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                            GoodsReceivedLocationId = DRE.GetNullableInt32(reader, "goods_received_location_id", null),
                            GoodsReceivedLocationName = DRE.GetNullableString(reader, "goods_received_location_name", null),
                            FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                            guid = DRE.GetNullableGuid(reader, "row_guid", null),
                            SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                        };

                        goodsReceipts.Add(goodsReceipt);
                    }
                }
            }

            return goodsReceipts;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceipt"></param>
        /// <returns></returns>
        private Int32 UpdateGoodsReceipt(Entities.GoodsReceipt goodsReceipt)
        {
            var goodsReceiptId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateGoodsReceipt))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceipt.GoodsReceiptId);
                    database.AddInParameter(dbCommand, "@goods_receipt_date", DbType.String, goodsReceipt.GoodsReceiptDate);
                    database.AddInParameter(dbCommand, "@goods_received_location_id", DbType.Int32, goodsReceipt.GoodsReceivedLocationId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, goodsReceipt.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, goodsReceipt.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    goodsReceiptId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        goodsReceiptId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return goodsReceiptId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceipt"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdateGoodsReceipt(Entities.GoodsReceipt goodsReceipt, DbTransaction transaction)
        {
            var goodsReceiptId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateGoodsReceipt))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceipt.GoodsReceiptId);
                    database.AddInParameter(dbCommand, "@goods_receipt_date", DbType.String, goodsReceipt.GoodsReceiptDate);
                    database.AddInParameter(dbCommand, "@goods_received_location_id", DbType.Int32, goodsReceipt.GoodsReceivedLocationId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, goodsReceipt.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, goodsReceipt.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    goodsReceiptId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        goodsReceiptId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return goodsReceiptId;
        }

        public bool CheckGoodsReceiptExistsInSalesBill(Int32 goodsReceiptId)
        {
            bool IsGoodsReceiptExists = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckGoodsReceiptExistsInSalesBill))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceiptId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            IsGoodsReceiptExists = DRE.GetBoolean(reader, "is_goods_receipt_exists");
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

            return IsGoodsReceiptExists;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceipt"></param>
        /// <returns></returns>
        public Int32 SaveGoodsReceipt(Entities.GoodsReceipt goodsReceipt)
        {
            var goodsReceiptId = 0;

            if (goodsReceipt.GoodsReceiptId == null || goodsReceipt.GoodsReceiptId == 0)
            {
                goodsReceiptId = AddGoodsReceipt(goodsReceipt);
            }
            else
            {
                if (goodsReceipt.IsDeleted==true)
                {
                    goodsReceiptId =  Convert.ToInt32(DeleteGoodsReceipt(goodsReceipt));
                }
                else if (goodsReceipt.ModifiedBy != null || goodsReceipt.ModifiedBy > 0)
                {
                    goodsReceiptId =  UpdateGoodsReceipt(goodsReceipt);
                }
            }
            return goodsReceiptId;
        }

        public Int32 SaveGoodsReceipt(List<Entities.GoodsReceipt> goodsReceipts)
        {
            var goodsReceiptId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var goodsReceiptItemId = 0;

                        if (goodsReceipts.Count > 0)
                        {
                            foreach (Entities.GoodsReceipt goodsReceipt in goodsReceipts)
                            {
                                if (goodsReceipt.GoodsReceiptId == null || goodsReceipt.GoodsReceiptId == 0)
                                {
                                    goodsReceiptId = AddGoodsReceipt(goodsReceipt, transaction);
                                }
                                else
                                {
                                    if (goodsReceipt.IsDeleted == true)
                                    {
                                        var result = DeleteGoodsReceipt(goodsReceipt, transaction);

                                        if(result)
                                        {
                                            goodsReceiptId = (int)goodsReceipt.GoodsReceiptId;
                                        }
                                    }
                                    else
                                    {
                                        if (goodsReceipt.ModifiedBy > 0 || goodsReceipt.ModifiedBy != null)
                                        {
                                            goodsReceiptId = UpdateGoodsReceipt(goodsReceipt, transaction);
                                        }
                                    }
                                }

                                if (goodsReceiptId > 0)
                                {   
                                    foreach (Entities.GoodsReceiptItem goodsReceiptItem in goodsReceipt.GoodsReceiptItems)
                                    {
                                        goodsReceiptItem.GoodsReceiptId = goodsReceiptId;

                                        GoodsReceiptItem goodsReceiptItemDL = new GoodsReceiptItem();

                                        goodsReceiptItemId = goodsReceiptItemDL.SaveGoodsReceiptItem(goodsReceiptItem, transaction);
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

            return goodsReceiptId;

        }



    }
}
