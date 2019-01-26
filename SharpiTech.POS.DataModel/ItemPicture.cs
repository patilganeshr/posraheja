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
    public class ItemPicture
    {
        private readonly Database database;

        public ItemPicture()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemPicture"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddItemPicture(Entities.ItemPicture itemPicture, DbTransaction transaction)
        {
            var itemPictureId = 0;

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertAddressType))
                {
                    database.AddInParameter(dbCommand, "@item_picture_id", DbType.Int32, itemPicture.ItemPictureId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemPicture.ItemId);
                    database.AddInParameter(dbCommand, "@item_picture_name", DbType.String, itemPicture.ItemPictureName);
                    database.AddInParameter(dbCommand, "@item_picture_path", DbType.String, itemPicture.ItemPicturePath);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, itemPicture.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, itemPicture.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemPictureId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemPictureId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemPictureId;
        }

        private bool DeleteItemPicture(Entities.ItemPicture itemPicture, DbTransaction transaction)
        {
            bool IsItemPictureDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertAddressType))
                {
                    database.AddInParameter(dbCommand, "@item_picture_id", DbType.Int32, itemPicture.ItemPictureId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemPicture.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemPicture.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsItemPictureDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsItemPictureDeleted;
        }

        private Int32 UpdateItemPicture(Entities.ItemPicture itemPicture, DbTransaction transaction)
        {
            var itemPictureId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertAddressType))
                {
                    database.AddInParameter(dbCommand, "@item_picture_id", DbType.Int32, itemPicture.ItemPictureId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemPicture.ItemId);
                    database.AddInParameter(dbCommand, "@item_picture_name", DbType.String, itemPicture.ItemPictureName);
                    database.AddInParameter(dbCommand, "@item_picture_path", DbType.String, itemPicture.ItemPicturePath);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, itemPicture.ModifiedByIP);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, itemPicture.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemPictureId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemPictureId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemPictureId;
        }

        public Int32 SaveItemPicture(Entities.ItemPicture itemPicture, DbTransaction transaction)
        {
            var itemPictureId = 0;

            if (itemPicture.ItemPictureId == null || itemPicture.ItemPictureId == 0)
            {
                itemPictureId = AddItemPicture(itemPicture, transaction);
            }
            else if (itemPicture.ModifiedBy != null || itemPicture.ModifiedBy > 0)
            {
                itemPictureId = UpdateItemPicture(itemPicture, transaction);
            }
            else if (itemPicture.IsDeleted == true)
            {
                var result = DeleteItemPicture(itemPicture, transaction);

                if (result == true)
                {
                    itemPictureId = 1;
                }
                else
                {
                    itemPictureId = 0;
                }
            }

            return itemPictureId;
        }
    }
}
