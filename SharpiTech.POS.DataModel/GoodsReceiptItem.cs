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
    public class GoodsReceiptItem
    {
        private readonly Database database;

        public GoodsReceiptItem()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceiptItem"></param>
        /// <returns></returns>
        private Int32 AddGoodsReceiptItem(Entities.GoodsReceiptItem goodsReceiptItem)
        {
            var goodsReceiptItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertGoodsReceiptItems))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, goodsReceiptItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceiptItem.GoodsReceiptId);
                    database.AddInParameter(dbCommand, "@purchase_bill_item_id", DbType.Int32, goodsReceiptItem.PurchaseBillItemId);
                    database.AddInParameter(dbCommand, "@received_qty", DbType.Decimal, goodsReceiptItem.ReceivedQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, goodsReceiptItem.UnitOfMeasurementId);                    
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, goodsReceiptItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, goodsReceiptItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    goodsReceiptItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        goodsReceiptItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return goodsReceiptItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceiptItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddGoodsReceiptItem(Entities.GoodsReceiptItem goodsReceiptItem, DbTransaction transaction)
        {
            var goodsReceiptItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertGoodsReceiptItems))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, goodsReceiptItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceiptItem.GoodsReceiptId);
                    database.AddInParameter(dbCommand, "@purchase_bill_item_id", DbType.Int32, goodsReceiptItem.PurchaseBillItemId);
                    database.AddInParameter(dbCommand, "@received_qty", DbType.Decimal, goodsReceiptItem.ReceivedQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, goodsReceiptItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, goodsReceiptItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, goodsReceiptItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    goodsReceiptItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        goodsReceiptItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return goodsReceiptItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceiptItem"></param>
        /// <returns></returns>
        private Boolean DeleteGoodsReceiptItem(Entities.GoodsReceiptItem goodsReceiptItem)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteGoodsReceiptItems))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, goodsReceiptItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, goodsReceiptItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, goodsReceiptItem.DeletedByIP);

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
        /// <param name="goodsReceiptItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Boolean DeleteGoodsReceiptItem(Entities.GoodsReceiptItem goodsReceiptItem, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteGoodsReceiptItems))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, goodsReceiptItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, goodsReceiptItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, goodsReceiptItem.DeletedByIP);

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

        public List<Entities.GoodsReceiptItem> GetGoodsReceiptItemsByGoodsReceiptId(Int32 goodsReceiptId)
        {
            var goodsReceiptItems = new List<Entities.GoodsReceiptItem>();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetGoodsReceiptItemsByGoodsReceiptId))
            {
                database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceiptId);
 
                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var goodsReceiptItem = new Entities.GoodsReceiptItem
                        {
                            GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                            GoodsReceiptId = DRE.GetNullableInt32(reader, "goods_receipt_id", null),
                            PurchaseBillItemId = DRE.GetNullableInt32(reader, "purchase_bill_item_id", null),
                            BaleNo = DRE.GetNullableString(reader,"bale_no", null),
                            LRNo = DRE.GetNullableString(reader, "lr_no", null),
                            ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                            ItemName = DRE.GetNullableString(reader,"item_name", null),
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceiptItem"></param>
        /// <returns></returns>
        private Int32 UpdateGoodsReceiptItem(Entities.GoodsReceiptItem goodsReceiptItem)
        {
            var goodsReceiptItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateGoodsReceiptItems))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, goodsReceiptItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceiptItem.GoodsReceiptId);
                    database.AddInParameter(dbCommand, "@purchase_bill_item_id", DbType.Int32, goodsReceiptItem.PurchaseBillItemId);
                    database.AddInParameter(dbCommand, "@received_qty", DbType.Decimal, goodsReceiptItem.ReceivedQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, goodsReceiptItem.UnitOfMeasurementId);                    
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, goodsReceiptItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, goodsReceiptItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    goodsReceiptItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        goodsReceiptItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return goodsReceiptItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceiptItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdateGoodsReceiptItem(Entities.GoodsReceiptItem goodsReceiptItem, DbTransaction transaction)
        {
            var goodsReceiptItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateGoodsReceiptItems))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, goodsReceiptItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceiptItem.GoodsReceiptId);
                    database.AddInParameter(dbCommand, "@purchase_bill_item_id", DbType.Int32, goodsReceiptItem.PurchaseBillItemId);
                    database.AddInParameter(dbCommand, "@received_qty", DbType.Decimal, goodsReceiptItem.ReceivedQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, goodsReceiptItem.UnitOfMeasurementId);                    
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, goodsReceiptItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, goodsReceiptItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    goodsReceiptItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        goodsReceiptItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return goodsReceiptItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceiptItem"></param>
        /// <returns></returns>
        public Int32 SaveGoodsReceiptItem(Entities.GoodsReceiptItem goodsReceiptItem)
        {
            var goodsReceiptItemId = 0;

            if (goodsReceiptItem.GoodsReceiptItemId == null || goodsReceiptItem.GoodsReceiptItemId == 0)
            {
                goodsReceiptItemId = AddGoodsReceiptItem(goodsReceiptItem);
            }
            else
            {
                if (goodsReceiptItem.IsDeleted==true)
                {
                    goodsReceiptItemId =  Convert.ToInt32(DeleteGoodsReceiptItem(goodsReceiptItem));
                }
                else if (goodsReceiptItem.ModifiedBy != null || goodsReceiptItem.ModifiedBy > 0)
                {
                    goodsReceiptItemId =  UpdateGoodsReceiptItem(goodsReceiptItem);
                }
            }
            return goodsReceiptItemId;
        }


        public Int32 SaveGoodsReceiptItem(Entities.GoodsReceiptItem goodsReceiptItem, DbTransaction transaction)
        {
            var goodsReceiptItemId = 0;

            if (goodsReceiptItem.GoodsReceiptItemId == null || goodsReceiptItem.GoodsReceiptItemId == 0)
            {
                goodsReceiptItemId = AddGoodsReceiptItem(goodsReceiptItem, transaction);
            }
            else
            {
                if (goodsReceiptItem.IsDeleted == true)
                {
                    goodsReceiptItemId = Convert.ToInt32(DeleteGoodsReceiptItem(goodsReceiptItem, transaction));
                }
                else if (goodsReceiptItem.ModifiedBy != null || goodsReceiptItem.ModifiedBy > 0)
                {
                    goodsReceiptItemId = UpdateGoodsReceiptItem(goodsReceiptItem, transaction);
                }
            }
            return goodsReceiptItemId;
        }
    }
}
