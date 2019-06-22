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
    public class ItemImage
    {
        private readonly Database database;

        public ItemImage()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddItemImage(Entities.ItemImage itemImage)
        {
            var itemImageId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertItemImage))
                {
                    database.AddInParameter(dbCommand, "@item_image_id", DbType.Int32, itemImage.ItemImageId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemImage.ItemId);
                    database.AddInParameter(dbCommand, "@color_id", DbType.Int32, itemImage.ColorId);
                    database.AddInParameter(dbCommand, "@design_id", DbType.Int32, itemImage.DesignId);
                    database.AddInParameter(dbCommand, "@item_image_name", DbType.String, itemImage.ItemImageName);
                    database.AddInParameter(dbCommand, "@item_image_path", DbType.String, itemImage.ItemImagePath);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, itemImage.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, itemImage.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemImageId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemImageId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemImageId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemImage"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddItemImage(Entities.ItemImage itemImage, DbTransaction transaction)
        {
            var itemImageId = 0;

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertItemImage))
                {
                    database.AddInParameter(dbCommand, "@item_image_id", DbType.Int32, itemImage.ItemImageId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemImage.ItemId);
                    database.AddInParameter(dbCommand, "@color_id", DbType.Int32, itemImage.ColorId);
                    database.AddInParameter(dbCommand, "@design_id", DbType.Int32, itemImage.DesignId);
                    database.AddInParameter(dbCommand, "@item_image_name", DbType.String, itemImage.ItemImageName);
                    database.AddInParameter(dbCommand, "@item_image_path", DbType.String, itemImage.ItemImagePath);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, itemImage.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, itemImage.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemImageId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemImageId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemImageId;
        }

        private bool DeleteItemImage(Entities.ItemImage itemImage)
        {
            bool IsItemImageDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteItemImage))
                {
                    database.AddInParameter(dbCommand, "@item_image_id", DbType.Int32, itemImage.ItemImageId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemImage.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemImage.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsItemImageDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsItemImageDeleted;
        }

        private bool DeleteItemImage(Entities.ItemImage itemImage, DbTransaction transaction)
        {
            bool IsItemImageDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteItemImage))
                {
                    database.AddInParameter(dbCommand, "@item_image_id", DbType.Int32, itemImage.ItemImageId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemImage.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemImage.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsItemImageDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsItemImageDeleted;
        }

        private Int32 UpdateItemImage(Entities.ItemImage itemImage)
        {
            var itemImageId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateItemImage))
                {
                    database.AddInParameter(dbCommand, "@item_image_id", DbType.Int32, itemImage.ItemImageId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemImage.ItemId);
                    database.AddInParameter(dbCommand, "@color_id", DbType.Int32, itemImage.ColorId);
                    database.AddInParameter(dbCommand, "@design_id", DbType.Int32, itemImage.DesignId);
                    database.AddInParameter(dbCommand, "@item_image_name", DbType.String, itemImage.ItemImageName);
                    database.AddInParameter(dbCommand, "@item_image_path", DbType.String, itemImage.ItemImagePath);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, itemImage.ModifiedByIP);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, itemImage.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemImageId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemImageId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemImageId;
        }

        private Int32 UpdateItemImage(Entities.ItemImage itemImage, DbTransaction transaction)
        {
            var itemImageId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateItemImage))
                {
                    database.AddInParameter(dbCommand, "@item_image_id", DbType.Int32, itemImage.ItemImageId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemImage.ItemId);
                    database.AddInParameter(dbCommand, "@color_id", DbType.Int32, itemImage.ColorId);
                    database.AddInParameter(dbCommand, "@design_id", DbType.Int32, itemImage.DesignId);
                    database.AddInParameter(dbCommand, "@item_image_name", DbType.String, itemImage.ItemImageName);
                    database.AddInParameter(dbCommand, "@item_image_path", DbType.String, itemImage.ItemImagePath);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, itemImage.ModifiedByIP);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, itemImage.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemImageId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemImageId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemImageId;
        }

        public List<Entities.ItemImage> GetItemImagesByItemId(Int32 itemId)
        {
            var itemImages = new List<Entities.ItemImage>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemImagesByItemId))
                {
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemImage = new Entities.ItemImage()
                            {
                                ItemImageId = DRE.GetNullableInt32(reader, "item_image_id", 0),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                ItemCode = DRE.GetNullableString(reader, "item_code", null),
                                ColorId = DRE.GetNullableInt32(reader, "color_id", null),
                                ItemColor = DRE.GetNullableString(reader, "color_name", null),
                                DesignId = DRE.GetNullableInt32(reader, "design_id", null),
                                ItemImageName = DRE.GetNullableString(reader, "item_image_name", null),
                                ItemImagePath = DRE.GetNullableString(reader, "item_image_path", null)
                            };

                            itemImages.Add(itemImage);
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

            return itemImages;
        }

        public Int32 SaveItemImage(List<Entities.ItemImage> itemImages)
        {
            var itemImageId = 0;

            if (itemImages != null)
            {
                if (itemImages.Count > 0)
                {
                    foreach (Entities.ItemImage itemImage in itemImages)
                    {
                        if (itemImage.ItemImageId == null || itemImage.ItemImageId == 0)
                        {
                            itemImageId = AddItemImage(itemImage);
                        }
                        else if (itemImage.ModifiedBy != null || itemImage.ModifiedBy > 0)
                        {
                            itemImageId = UpdateItemImage(itemImage);
                        }
                        else if (itemImage.IsDeleted == true)
                        {
                            var result = DeleteItemImage(itemImage);

                            if (result == true)
                            {
                                itemImageId = 1;
                            }
                            else
                            {
                                itemImageId = 0;
                            }
                        }
                    }
                }
            }

            return itemImageId;
        }
    }
}
