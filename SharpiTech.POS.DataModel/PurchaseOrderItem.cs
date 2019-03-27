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
    public class PurchaseOrderItem
    {
        private readonly Database database;

        public PurchaseOrderItem()
        {
            database = DBConnect.getDBConnection();
        }

                /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrderItem"></param>
        /// <returns></returns>
        private Int32 AddPurchaseOrderItem(Entities.PurchaseOrderItem purchaseOrderItem)
        {
            var purchaseOrderItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPurchaseOrderItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_item_id", DbType.Int32, purchaseOrderItem.PurchaseOrderItemId);
                    database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrderItem.PurchaseOrderId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, purchaseOrderItem.ItemId);
                    database.AddInParameter(dbCommand, "@no_of_bales", DbType.Int32, purchaseOrderItem.NoOfBales);
                    database.AddInParameter(dbCommand, "@order_qty", DbType.Decimal, purchaseOrderItem.OrderQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, purchaseOrderItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@order_rate", DbType.Decimal, purchaseOrderItem.OrderRate);
                    database.AddInParameter(dbCommand, "@fabric_cutout_length", DbType.Int32, purchaseOrderItem.FabricCutOutLenght);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, purchaseOrderItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, purchaseOrderItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseOrderItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseOrderItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseOrderItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrderItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddPurchaseOrderItem(Entities.PurchaseOrderItem purchaseOrderItem, DbTransaction transaction)
        {
            var purchaseOrderItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPurchaseOrderItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_item_id", DbType.Int32, purchaseOrderItem.PurchaseOrderItemId);
                    database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrderItem.PurchaseOrderId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, purchaseOrderItem.ItemId);
                    database.AddInParameter(dbCommand, "@design_id", DbType.Int32, purchaseOrderItem.DesignId);
                    database.AddInParameter(dbCommand, "@color_id", DbType.Int32, purchaseOrderItem.ColorId);
                    database.AddInParameter(dbCommand, "@no_of_bales", DbType.Int32, purchaseOrderItem.NoOfBales);
                    database.AddInParameter(dbCommand, "@order_qty", DbType.Decimal, purchaseOrderItem.OrderQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, purchaseOrderItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@order_rate", DbType.Decimal, purchaseOrderItem.OrderRate);
                    database.AddInParameter(dbCommand, "@fabric_cutout_length", DbType.Int32, purchaseOrderItem.FabricCutOutLenght);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, purchaseOrderItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, purchaseOrderItem.CreatedByIP);
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseOrderItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseOrderItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseOrderItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrderItem"></param>
        /// <returns></returns>
        private Boolean DeletePurchaseOrderItem(Entities.PurchaseOrderItem purchaseOrderItem)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePurchaseOrderItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_item_id", DbType.Int32, purchaseOrderItem.PurchaseOrderItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, purchaseOrderItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, purchaseOrderItem.DeletedByIP);

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
        /// <param name="purchaseOrderItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Boolean DeletePurchaseOrderItem(Entities.PurchaseOrderItem purchaseOrderItem, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePurchaseOrderItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_item_id", DbType.Int32, purchaseOrderItem.PurchaseOrderItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, purchaseOrderItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, purchaseOrderItem.DeletedByIP);

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
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        public List<Entities.PurchaseOrderItem> GetPurchaseOrderItemsByPuchaseOrderId(Int32 purchaseOrderId)
        {
            var purchaseOrderItems = new List<Entities.PurchaseOrderItem>();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseOrderItemsByPurchaseOrderId))
            {

                database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrderId);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var purchaseOrderItem = new Entities.PurchaseOrderItem
                        {
                            PurchaseOrderItemId = DRE.GetNullableInt32(reader, "purchase_order_item_id", null),
                            PurchaseOrderId = DRE.GetNullableInt32(reader, "purchase_order_id", null),
                            ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                            ItemName = DRE.GetNullableString(reader, "item_name", null),
                            HSNCode = DRE.GetNullableString(reader,"hsn_code", null),
                            NoOfBales = DRE.GetNullableInt32(reader, "no_of_bales", null),
                            FabricCutOutLenght = DRE.GetNullableInt32(reader, "fabric_cutout_length", null),
                            OrderQty = DRE.GetNullableDecimal(reader, "order_qty", null),
                            UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                            UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                            OrderRate = DRE.GetNullableDecimal(reader, "order_rate", null),
                            Discount = DRE.GetNullableDecimal(reader, "discount", null),
                            ItemAmount = DRE.GetNullableDecimal(reader, "item_amount", null),
                            guid = DRE.GetNullableGuid(reader, "row_guid", null)
                        };

                        purchaseOrderItems.Add(purchaseOrderItem);
                    }
                }
            }

            return purchaseOrderItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrderItem"></param>
        /// <returns></returns>
        private Int32 UpdatePurchaseOrderItem(Entities.PurchaseOrderItem purchaseOrderItem)
        {
            var purchaseOrderItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePurchaseOrderItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_item_id", DbType.Int32, purchaseOrderItem.PurchaseOrderItemId);
                    database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrderItem.PurchaseOrderId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, purchaseOrderItem.ItemId);
                    database.AddInParameter(dbCommand, "@no_of_bales", DbType.Int32, purchaseOrderItem.NoOfBales);
                    database.AddInParameter(dbCommand, "@order_qty", DbType.Decimal, purchaseOrderItem.OrderQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, purchaseOrderItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@order_rate", DbType.Decimal, purchaseOrderItem.OrderRate);
                    database.AddInParameter(dbCommand, "@fabric_cutout_length", DbType.Int32, purchaseOrderItem.FabricCutOutLenght);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, purchaseOrderItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, purchaseOrderItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseOrderItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseOrderItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseOrderItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrderItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdatePurchaseOrderItem(Entities.PurchaseOrderItem purchaseOrderItem, DbTransaction transaction)
        {
            var purchaseOrderItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePurchaseOrderItem))
                {
                    database.AddInParameter(dbCommand, "@purchase_order_item_id", DbType.Int32, purchaseOrderItem.PurchaseOrderItemId);
                    database.AddInParameter(dbCommand, "@purchase_order_id", DbType.Int32, purchaseOrderItem.PurchaseOrderId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, purchaseOrderItem.ItemId);
                    database.AddInParameter(dbCommand, "@no_of_bales", DbType.Int32, purchaseOrderItem.NoOfBales);
                    database.AddInParameter(dbCommand, "@order_qty", DbType.Decimal, purchaseOrderItem.OrderQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, purchaseOrderItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@order_rate", DbType.Decimal, purchaseOrderItem.OrderRate);
                    database.AddInParameter(dbCommand, "@fabric_cutout_length", DbType.Int32, purchaseOrderItem.FabricCutOutLenght); database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, purchaseOrderItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, purchaseOrderItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, purchaseOrderItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    purchaseOrderItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        purchaseOrderItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return purchaseOrderItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrderItem"></param>
        /// <returns></returns>
        public Int32 SavePurchaseOrderItem(Entities.PurchaseOrderItem purchaseOrderItem)
        {
            var purchaseOrderItemId = 0;

            if (purchaseOrderItem.PurchaseOrderItemId == null || purchaseOrderItem.PurchaseOrderItemId == 0)
            {
                purchaseOrderItemId = AddPurchaseOrderItem(purchaseOrderItem);
            }
            else
            {
                if (purchaseOrderItem.IsDeleted==true)
                {
                    purchaseOrderItemId =  Convert.ToInt32(DeletePurchaseOrderItem(purchaseOrderItem));
                }
                else if (purchaseOrderItem.ModifiedBy != null || purchaseOrderItem.ModifiedBy > 0)
                {
                    purchaseOrderItemId =  UpdatePurchaseOrderItem(purchaseOrderItem);
                }
            }
            return purchaseOrderItemId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrderItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Int32 SavePurchaseOrderItem(Entities.PurchaseOrderItem purchaseOrderItem, DbTransaction transaction)
        {
            var purchaseOrderItemId = 0;

            if (purchaseOrderItem.PurchaseOrderItemId == null || purchaseOrderItem.PurchaseOrderItemId == 0)
            {
                purchaseOrderItemId = AddPurchaseOrderItem(purchaseOrderItem, transaction);
            }
            else
            {
                if (purchaseOrderItem.IsDeleted == true)
                {
                    purchaseOrderItemId = Convert.ToInt32(DeletePurchaseOrderItem(purchaseOrderItem, transaction));
                }
                else if (purchaseOrderItem.ModifiedBy != null || purchaseOrderItem.ModifiedBy > 0)
                {
                    purchaseOrderItemId = UpdatePurchaseOrderItem(purchaseOrderItem, transaction);
                }
            }

            return purchaseOrderItemId;
        }

    }

}
