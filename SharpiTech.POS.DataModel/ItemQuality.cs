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
    public class ItemQuality
    {
        private readonly Database database;

        public ItemQuality()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQuality"></param>
        /// <returns></returns>
        private Int32 AddItemQuality(Entities.ItemQuality itemQuality)
        {
            var itemQualityId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertItemQuality))
                {
                    database.AddInParameter(dbCommand, "@item_quality_id", DbType.Int32, itemQuality.ItemQualityId);
                    database.AddInParameter(dbCommand, "@item_quality", DbType.String, itemQuality.QualityName);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, itemQuality.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, itemQuality.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemQualityId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemQualityId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemQualityId;
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQuality"></param>
        /// <returns></returns>
        public bool DeleteItemQuality(Entities.ItemQuality itemQuality)
        {
            bool isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteItemQuality))
                {
                    database.AddInParameter(dbCommand, "@item_quality_id", DbType.Int32, itemQuality.ItemQualityId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemQuality.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemQuality.DeletedByIP);

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
        /// <returns></returns>
        public List<Entities.ItemQuality> GetAllItemQualities()
        {
            var itemQualities = new List<Entities.ItemQuality>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetallItemQualities))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemQuality = new Entities.ItemQuality
                            {
                                ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", 0),
                                QualityName = DRE.GetNullableString(reader, "item_quality", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            itemQualities.Add(itemQuality);
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

            return itemQualities;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQualityId"></param>
        /// <returns></returns>
        public Entities.ItemQuality GetItemQualityById(Int32 itemQualityId)
        {
            var itemQuality = new Entities.ItemQuality();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemQualityById))
            {
                database.AddInParameter(dbCommand, "@item_quality_id", DbType.Int32, itemQualityId);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var _itemQuality = new Entities.ItemQuality
                        {
                            ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", 0),
                            QualityName = DRE.GetNullableString(reader, "item_quality", null)
                        };

                        itemQuality = _itemQuality;
                    }
                }
            }

            return itemQuality;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQualityName"></param>
        /// <returns></returns>
        public Entities.ItemQuality GetItemQualityByName(string itemQualityName)
        {
            var itemQuality = new Entities.ItemQuality();

            DbCommand dbCommand = null;

            using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemQualityByName))
            {
                database.AddInParameter(dbCommand, "@item_quality", DbType.String, itemQualityName);

                using (IDataReader reader = database.ExecuteReader(dbCommand))
                {
                    while (reader.Read())
                    {
                        var _itemQuality = new Entities.ItemQuality
                        {
                            ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", 0),
                            QualityName = DRE.GetNullableString(reader, "item_quality", null)
                        };

                        itemQuality = _itemQuality;
                    }
                }
            }

            return itemQuality;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQuality"></param>
        /// <returns></returns>
        private Int32 UpdateItemQuality(Entities.ItemQuality itemQuality)
        {
            var itemQualityId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateItemQuality))
                {
                    database.AddInParameter(dbCommand, "@item_quality_id", DbType.Int32, itemQuality.ItemQualityId);
                    database.AddInParameter(dbCommand, "@item_quality", DbType.String, itemQuality.QualityName);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, itemQuality.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, itemQuality.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemQualityId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemQualityId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemQualityId;
        }

        public Int32 SaveItemQuality(Entities.ItemQuality itemQuality)
        {
            var itemQualityId = 0;

            if (itemQuality.ItemQualityId == null || itemQuality.ItemQualityId == 0)
            {
                itemQualityId = AddItemQuality(itemQuality);
            }
            else if (itemQuality.ModifiedBy != null || itemQuality.ModifiedBy > 0)
            {
                itemQualityId = UpdateItemQuality(itemQuality);
            }
            else if (itemQuality.IsDeleted == true)
            {
                var result = UpdateItemQuality(itemQuality);
            }

            return itemQualityId;
        }
    }
}
