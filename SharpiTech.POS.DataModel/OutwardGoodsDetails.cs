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
    public class OutwardGoodsDetails
    {
        private readonly Database database;

        public OutwardGoodsDetails()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outwardGoodsDetails"></param>
        /// <returns></returns>
        private Int32 AddOutwardGoodsDetails(Entities.OutwardGoodsDetails outwardGoodsDetails)
        {
            var outwardGoodsId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertOutwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_goods_id", DbType.Int32, outwardGoodsDetails.OutwardGoodsId);
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outwardGoodsDetails.OutwardId);
                    database.AddInParameter(dbCommand, "@pkg_slip_item_id", DbType.Int32, outwardGoodsDetails.PkgSlipItemId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, outwardGoodsDetails.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, outwardGoodsDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, outwardGoodsDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    outwardGoodsId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        outwardGoodsId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return outwardGoodsId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outwardGoodsDetails"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddOutwardGoodsDetails(Entities.OutwardGoodsDetails outwardGoodsDetails, DbTransaction transaction)
        {
            var outwardGoodsId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertOutwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_goods_id", DbType.Int32, outwardGoodsDetails.OutwardGoodsId);
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outwardGoodsDetails.OutwardId);
                    database.AddInParameter(dbCommand, "@pkg_slip_item_id", DbType.Int32, outwardGoodsDetails.PkgSlipItemId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, outwardGoodsDetails.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, outwardGoodsDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, outwardGoodsDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    outwardGoodsId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        outwardGoodsId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return outwardGoodsId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outwardGoodsDetails"></param>
        /// <returns></returns>
        private bool DeleteOutwardGoodsDetails(Entities.OutwardGoodsDetails outwardGoodsDetails)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteOutwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_goods_id", DbType.Int32, outwardGoodsDetails.OutwardGoodsId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, outwardGoodsDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, outwardGoodsDetails.DeletedByIP);

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
        /// <param name="outwardGoodsDetails"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool DeleteOutwardGoodsDetails(Entities.OutwardGoodsDetails outwardGoodsDetails, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteOutwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_goods_id", DbType.Int32, outwardGoodsDetails.OutwardGoodsId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, outwardGoodsDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, outwardGoodsDetails.DeletedByIP);

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

        public List<Entities.OutwardGoodsDetails> GetPkgSlipItems(Int32 pkgSlipId)
        {
            var pkgSlips = new List<Entities.OutwardGoodsDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPkgSlipItemsForOutwardByPkgSlipId))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlipId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var outwardGoodsDetails = new Entities.OutwardGoodsDetails
                            {
                                OutwardId = DRE.GetNullableInt32(reader, "outward_id", null),
                                OutwardGoodsId = DRE.GetNullableInt32(reader, "outward_goods_id", null),
                                PkgSlipId = DRE.GetNullableInt32(reader, "pkg_slip_id", null),
                                PkgSlipItemId = DRE.GetNullableInt32(reader, "pkg_slip_item_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                PkgSlipNo = DRE.GetNullableInt32(reader, "pkg_slip_no", null),
                                PkgSlipDate = DRE.GetNullableString(reader, "pkg_slip_date", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                TotalPkgSlipQty = DRE.GetNullableDecimal(reader, "total_pkg_slip_qty", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null)
                            };

                            pkgSlips.Add(outwardGoodsDetails);
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

            return pkgSlips;
        }

        public List<Entities.OutwardGoodsDetails> GetOutwardGoodsDetailsByOutwardId(Int32 outwardId)
        {
            var outwardGoods = new List<Entities.OutwardGoodsDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetOutwardGoodsDetailsByOutwardId))
                {
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outwardId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var goodsDetails = new Entities.OutwardGoodsDetails
                            {
                                OutwardGoodsId = DRE.GetNullableInt32(reader, "outward_goods_id", null),
                                OutwardId = DRE.GetNullableInt32(reader, "outward_id", null),
                                PkgSlipItemId = DRE.GetNullableInt32(reader, "pkg_slip_item_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                PkgSlipId = DRE.GetNullableInt32(reader, "pkg_slip_id", null),
                                PkgSlipNo = DRE.GetNullableInt32(reader, "pkg_slip_no", null),
                                PkgSlipDate = DRE.GetNullableString(reader, "pkg_slip_date", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                TotalPkgSlipQty = DRE.GetNullableDecimal(reader, "total_pkg_slip_qty", null),
                            };

                            outwardGoods.Add(goodsDetails);
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

            return outwardGoods;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outwardGoodsDetails"></param>
        /// <returns></returns>
        private Int32 UpdateOutwardGoodsDetails(Entities.OutwardGoodsDetails outwardGoodsDetails)
        {
            var outwardGoodsId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateOutwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_goods_id", DbType.Int32, outwardGoodsDetails.OutwardGoodsId);
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outwardGoodsDetails.OutwardId);
                    database.AddInParameter(dbCommand, "@pkg_slip_item_id", DbType.Int32, outwardGoodsDetails.PkgSlipItemId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, outwardGoodsDetails.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, outwardGoodsDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, outwardGoodsDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    outwardGoodsId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        outwardGoodsId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return outwardGoodsId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outwardGoodsDetails"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdateOutwardGoodsDetails(Entities.OutwardGoodsDetails outwardGoodsDetails, DbTransaction transaction)
        {
            var outwardGoodsId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateOutwardGoodsDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_goods_id", DbType.Int32, outwardGoodsDetails.OutwardGoodsId);
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outwardGoodsDetails.OutwardId);
                    database.AddInParameter(dbCommand, "@pkg_slip_item_id", DbType.Int32, outwardGoodsDetails.PkgSlipItemId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, outwardGoodsDetails.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, outwardGoodsDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, outwardGoodsDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    outwardGoodsId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        outwardGoodsId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return outwardGoodsId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outwardGoodsDetails"></param>
        /// <returns></returns>
        public Int32 SaveOutwardGoodsDetails(Entities.OutwardGoodsDetails outwardGoodsDetails)
        {
            var outwardGoodsId = 0;

            if (outwardGoodsDetails.OutwardGoodsId == null || outwardGoodsDetails.OutwardGoodsId == 0)
            {
               outwardGoodsId = AddOutwardGoodsDetails(outwardGoodsDetails);
            }
            else if (outwardGoodsDetails.ModifiedBy != null || outwardGoodsDetails.ModifiedBy > 0)
            {
                outwardGoodsId = UpdateOutwardGoodsDetails(outwardGoodsDetails);
            }
            else
            {
                var result = DeleteOutwardGoodsDetails(outwardGoodsDetails);
            }

            return outwardGoodsId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outwardGoodsDetails"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Int32 SaveOutwardGoodsDetails(Entities.OutwardGoodsDetails outwardGoodsDetails, DbTransaction transaction)
        {
            var outwardGoodsId = 0;

            if (outwardGoodsDetails.OutwardGoodsId == null || outwardGoodsDetails.OutwardGoodsId == 0)
            {
                outwardGoodsId = AddOutwardGoodsDetails(outwardGoodsDetails, transaction);
            }
            if (outwardGoodsDetails.IsDeleted == true)
            {
                var result = DeleteOutwardGoodsDetails(outwardGoodsDetails, transaction);

                if (result)
                {
                   outwardGoodsId = (Int32)outwardGoodsDetails.OutwardId;
                }
                else
                {
                    outwardGoodsId = -1;
                }
            }
            else
            {
                if (outwardGoodsDetails.ModifiedBy > 0 || outwardGoodsDetails.ModifiedBy != null)
                {
                    outwardGoodsId = UpdateOutwardGoodsDetails(outwardGoodsDetails, transaction);
                }
            }

            return outwardGoodsId;
        }
    }
}
