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
    public class ItemSetSubItem
    {
        private readonly Database database;

        public ItemSetSubItem()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddSetItem(Entities.ItemSetSubItem itemSetSubItem)
        {
            var itemSetSubItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertItemSetSubItem))
                {
                    database.AddInParameter(dbCommand, "@item_set_sub_item_id", DbType.Int32, itemSetSubItem.ItemSetSubItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemSetSubItem.ItemId);
                    database.AddInParameter(dbCommand, "@sub_item_id", DbType.Int32, itemSetSubItem.SubItemId);
                    database.AddInParameter(dbCommand, "@sub_item_net_qty", DbType.String, itemSetSubItem.SubItemNetQty);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, itemSetSubItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, itemSetSubItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemSetSubItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemSetSubItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemSetSubItemId;
        }

        private Int32 AddSetItem(Entities.ItemSetSubItem itemSetSubItem, DbTransaction transaction)
        {
            var itemSetSubItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertItemSetSubItem))
                {
                    database.AddInParameter(dbCommand, "@item_set_sub_item_id", DbType.Int32, itemSetSubItem.ItemSetSubItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemSetSubItem.ItemId);
                    database.AddInParameter(dbCommand, "@sub_item_id", DbType.Int32, itemSetSubItem.SubItemId);
                    database.AddInParameter(dbCommand, "@sub_item_net_qty", DbType.String, itemSetSubItem.SubItemNetQty);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, itemSetSubItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, itemSetSubItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemSetSubItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemSetSubItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemSetSubItemId;
        }

        //public bool CheckSubItemIsExists(string itemName, Int32 brandId, Int32 itemQualityId)
        //{
        //    bool isExists = true;

        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckItemNameIsExists))
        //        {
        //            database.AddInParameter(dbCommand, "@item_name", DbType.String, itemName);
        //            database.AddInParameter(dbCommand, "@brand_id", DbType.Int32, brandId);
        //            database.AddInParameter(dbCommand, "@item_quality_id", DbType.Int32, itemQualityId);

        //            using (IDataReader reader = database.ExecuteReader(dbCommand))
        //            {
        //                while (reader.Read())
        //                {
        //                    isExists = DRE.GetBoolean(reader, "is_item_exists");
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

        //    return isExists;
        //}

        private bool DeleteSetItem(Entities.ItemSetSubItem itemSetSubItem)
        {
            var isDeleted = true;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteItemSetSubItem))
                {
                    database.AddInParameter(dbCommand, "@item_set_sub_item_id", DbType.Int32, itemSetSubItem.ItemSetSubItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemSetSubItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemSetSubItem.DeletedByIP);

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

        private bool DeleteSetItem(Entities.ItemSetSubItem itemSetSubItem, DbTransaction transaction)
        {
            var isDeleted = true;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteItemSetSubItem))
                {
                    database.AddInParameter(dbCommand, "@item_set_sub_item_id", DbType.Int32, itemSetSubItem.ItemSetSubItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemSetSubItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemSetSubItem.DeletedByIP);

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

        private bool DeleteSetItemByItemId(Entities.ItemSetSubItem itemSetSubItem)
        {
            var isDeleted = true;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteItemSetSubItemsByItemId))
                {
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemSetSubItem.ItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemSetSubItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemSetSubItem.DeletedByIP);

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

        public bool DeleteSetItemByItemId(Entities.ItemSetSubItem itemSetSubItem, DbTransaction transaction)
        {
            var isDeleted = true;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteItemSetSubItemsByItemId))
                {
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemSetSubItem.ItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemSetSubItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemSetSubItem.DeletedByIP);

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

        public List<Entities.ItemSetSubItem> GetSubItems()
        {
            var itemSetSubItems = new List<Entities.ItemSetSubItem>();

            DbCommand dbCommand = null;

            try
            {
                dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSetSubItems);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var itemSetSubItem = new Entities.ItemSetSubItem
                        {
                            SubItemId = DRE.GetNullableInt32(reader, "sub_item_id", null),
                            SubItemName = DRE.GetNullableString(reader, "sub_item_name", null)                           
                        };

                        itemSetSubItems.Add(itemSetSubItem);
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

            return itemSetSubItems;
        }

        public List<Entities.ItemSetSubItem> GetSetItemsByItemId(Int32 itemId)
        {
            var setItems = new List<Entities.ItemSetSubItem>();

            DbCommand dbCommand = null;

            try
            {
                dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSetItemsByItemId);

                database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var setItem = new Entities.ItemSetSubItem
                        {
                            ItemSetSubItemId = DRE.GetNullableInt32(reader, "item_set_sub_item_id", 0),
                            ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                            ItemName = DRE.GetNullableString(reader, "item_name", null),
                            SubItemId = DRE.GetNullableInt32(reader, "sub_item_id", null),
                            SubItemName = DRE.GetNullableString(reader, "sub_item_name", null),
                            SubItemNetQty = DRE.GetNullableInt32(reader, "sub_item_net_qty", null),
                            guid = DRE.GetNullableGuid(reader, "row_guid", null),
                            SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                        };

                        setItems.Add(setItem);
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

            return setItems;
        }

        private Int32 UpdateSetItem(Entities.ItemSetSubItem itemSetSubItem)
        {
            var itemSetSubItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateItemSetSubItem))
                {
                    database.AddInParameter(dbCommand, "@item_set_sub_item_id", DbType.Int32, itemSetSubItem.ItemSetSubItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemSetSubItem.ItemId);
                    database.AddInParameter(dbCommand, "@sub_item_id", DbType.Int32, itemSetSubItem.SubItemId);
                    database.AddInParameter(dbCommand, "@sub_item_net_qty", DbType.String, itemSetSubItem.SubItemNetQty);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, itemSetSubItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, itemSetSubItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemSetSubItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemSetSubItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemSetSubItemId;
        }

        private Int32 UpdateSetItem(Entities.ItemSetSubItem itemSetSubItem, DbTransaction transaction)
        {
            var itemSetSubItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateItemSetSubItem))
                {
                    database.AddInParameter(dbCommand, "@item_set_sub_item_id", DbType.Int32, itemSetSubItem.ItemSetSubItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemSetSubItem.ItemId);
                    database.AddInParameter(dbCommand, "@sub_item_id", DbType.Int32, itemSetSubItem.SubItemId);
                    database.AddInParameter(dbCommand, "@sub_item_net_qty", DbType.String, itemSetSubItem.SubItemNetQty);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, itemSetSubItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, itemSetSubItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemSetSubItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemSetSubItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemSetSubItemId;
        }

        public Int32 SaveItemSet(Entities.ItemSetSubItem itemSetSubItem)
        {
            var itemSetSubItemId = 0;

            if (itemSetSubItem.ItemSetSubItemId == null || itemSetSubItem.ItemSetSubItemId == 0)
            {
                itemSetSubItemId = AddSetItem(itemSetSubItem);
            }
            else if (itemSetSubItem.ModifiedBy != null || itemSetSubItem.ModifiedBy > 0)
            {
                itemSetSubItemId = UpdateSetItem(itemSetSubItem);
            }
            else if (itemSetSubItem.IsDeleted == true)
            {
                var result = DeleteSetItem(itemSetSubItem);
            }

            return itemSetSubItemId;
        }

        public Int32 SaveItemSet(Entities.ItemSetSubItem itemSetSubItem, DbTransaction transaction)
        {
            var itemSetSubItemId = 0;

            if (itemSetSubItem.ItemSetSubItemId == null || itemSetSubItem.ItemSetSubItemId == 0)
            {
                itemSetSubItemId = AddSetItem(itemSetSubItem, transaction);
            }
            else if (itemSetSubItem.ModifiedBy != null || itemSetSubItem.ModifiedBy > 0)
            {
                itemSetSubItemId = UpdateSetItem(itemSetSubItem, transaction);
            }
            else if (itemSetSubItem.IsDeleted == true)
            {
                var result = DeleteSetItem(itemSetSubItem, transaction);

                if (result == true)
                {
                    itemSetSubItemId = 1;
                }
                else
                {
                    itemSetSubItemId = 0;
                }
            }

            return itemSetSubItemId;
        }
    }
}
