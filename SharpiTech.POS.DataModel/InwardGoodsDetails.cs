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
    public class InwardGoodsDetails
    {
        private readonly Database database;

        public InwardGoodsDetails()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddInwardGoodsDetails(Entities.InwardGoodsDetails inwardGoodsDetails)
        {
            var InwardGoodsId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertInwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, inwardGoodsDetails.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inwardGoodsDetails.InwardId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, inwardGoodsDetails.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, inwardGoodsDetails.ItemId);
                    database.AddInParameter(dbCommand, "@inward_qty", DbType.Decimal, inwardGoodsDetails.InwardQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, inwardGoodsDetails.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@inward_status", DbType.String, inwardGoodsDetails.InwardStatus);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, inwardGoodsDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, inwardGoodsDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, inwardGoodsDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    InwardGoodsId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        InwardGoodsId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return InwardGoodsId;
        }

        private Int32 AddInwardGoodsDetails(Entities.InwardGoodsDetails inwardGoodsDetails, DbTransaction dbTransaction)
        {
            var InwardGoodsId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertInwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, inwardGoodsDetails.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inwardGoodsDetails.InwardId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, inwardGoodsDetails.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, inwardGoodsDetails.ItemId);
                    database.AddInParameter(dbCommand, "@inward_qty", DbType.Int32, inwardGoodsDetails.InwardQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, inwardGoodsDetails.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@inward_status", DbType.String, inwardGoodsDetails.InwardStatus);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, inwardGoodsDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, inwardGoodsDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, inwardGoodsDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    InwardGoodsId = database.ExecuteNonQuery(dbCommand, dbTransaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        InwardGoodsId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return InwardGoodsId;
        }

        private bool DeleteInwardGoodsDetails(Entities.InwardGoodsDetails inwardGoodsDetails)
        {
            var IsRecordsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteInwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, inwardGoodsDetails.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, inwardGoodsDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, inwardGoodsDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsRecordsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsRecordsDeleted;
        }

        private bool DeleteInwardGoodsDetails(Entities.InwardGoodsDetails inwardGoodsDetails, DbTransaction dbTransaction)
        {
            var IsRecordsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteInwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, inwardGoodsDetails.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, inwardGoodsDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, inwardGoodsDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand, dbTransaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsRecordsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsRecordsDeleted;
        }

        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByInwardId (Int32 inwardId)
        {
            var inwardGoodsDetails = new List<Entities.InwardGoodsDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetInwardGoodsDetailsByInwardId))
                {
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inwardId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var goodsDetails = new Entities.InwardGoodsDetails
                            {
                                InwardGoodsId = DRE.GetNullableInt32(reader, "inward_goods_id", null),
                                InwardId = DRE.GetNullableInt32(reader, "inward_id", null),
                                ReferenceId = DRE.GetNullableInt32(reader, "reference_id", null),                                
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                ReceivedQty = DRE.GetNullableDecimal(reader, "received_qty", null),
                                InwardQty = DRE.GetNullableDecimal(reader, "inward_qty", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                InwardStatus = DRE.GetNullableString(reader, "inward_status", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)                                
                            };

                            inwardGoodsDetails.Add(goodsDetails);
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

            return inwardGoodsDetails;
        }

        private Int32 UpdateInwardGoodsDetails(Entities.InwardGoodsDetails inwardGoodsDetails)
        {
            var InwardGoodsId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateInwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, inwardGoodsDetails.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inwardGoodsDetails.InwardId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, inwardGoodsDetails.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, inwardGoodsDetails.ItemId);
                    database.AddInParameter(dbCommand, "@inward_qty", DbType.Decimal, inwardGoodsDetails.InwardQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, inwardGoodsDetails.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@inward_status", DbType.String, inwardGoodsDetails.InwardStatus);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, inwardGoodsDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, inwardGoodsDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, inwardGoodsDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    InwardGoodsId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        InwardGoodsId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return InwardGoodsId;
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="inwardGoodsDetails"></param>
        /// <param name="dbTransaction"></param>
        /// <returns></returns>
        private Int32 UpdateInwardGoodsDetails(Entities.InwardGoodsDetails inwardGoodsDetails, DbTransaction dbTransaction)
        {
            var InwardGoodsId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateInwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, inwardGoodsDetails.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inwardGoodsDetails.InwardId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, inwardGoodsDetails.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, inwardGoodsDetails.ItemId);
                    database.AddInParameter(dbCommand, "@inward_qty", DbType.Decimal, inwardGoodsDetails.InwardQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, inwardGoodsDetails.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@inward_status", DbType.String, inwardGoodsDetails.InwardStatus);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, inwardGoodsDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, inwardGoodsDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, inwardGoodsDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    InwardGoodsId = database.ExecuteNonQuery(dbCommand, dbTransaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        InwardGoodsId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return InwardGoodsId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inwardGoodsDetails"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Int32 SaveInwardGoodsDetails(Entities.InwardGoodsDetails inwardGoodsDetails, DbTransaction transaction)
        {
            var inwardGoodsId = 0;

            if (inwardGoodsDetails.InwardGoodsId == null || inwardGoodsDetails.InwardGoodsId == 0)
            {
                return AddInwardGoodsDetails(inwardGoodsDetails, transaction);
            }
            else
            {
                if (inwardGoodsDetails.IsDeleted == true)
                {
                    inwardGoodsId = Convert.ToInt32(DeleteInwardGoodsDetails(inwardGoodsDetails, transaction));
                }
                else if (inwardGoodsDetails.ModifiedBy != null || inwardGoodsDetails.ModifiedBy > 0)
                {
                    inwardGoodsId = UpdateInwardGoodsDetails(inwardGoodsDetails, transaction);
                }
            }

            return inwardGoodsId;
        }
    }
}
