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
    public class PkgSlipItem
    {
        private readonly Database database;

        public PkgSlipItem()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// Add Pkg Slip Items
        /// </summary>
        /// <param name="pkgSlipItem"
        /// ></param>
        /// <returns></returns>
        private Int32 AddPkgSlipItem(Entities.PkgSlipItem pkgSlipItem)
        {
            var pkgSlipItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPkgSlipItem))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_item_id", DbType.Int32, pkgSlipItem.PkgSlipItemId);
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlipItem.PkgSlipId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, pkgSlipItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, pkgSlipItem.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, pkgSlipItem.ItemId);
                    database.AddInParameter(dbCommand, "@bale_no", DbType.String, pkgSlipItem.BaleNo);
                    database.AddInParameter(dbCommand, "@pkg_qty", DbType.Decimal, pkgSlipItem.PkgQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, pkgSlipItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, pkgSlipItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, pkgSlipItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    pkgSlipItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        pkgSlipItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return pkgSlipItemId;
        }

        /// <summary>
        /// Add Pkg Slip Items
        /// </summary>
        /// <param name="pkgSlipItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddPkgSlipItem(Entities.PkgSlipItem pkgSlipItem, DbTransaction transaction)
        {
            var pkgSlipItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertPkgSlipItem))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_item_id", DbType.Int32, pkgSlipItem.PkgSlipItemId);
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlipItem.PkgSlipId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, pkgSlipItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, pkgSlipItem.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, pkgSlipItem.ItemId);
                    database.AddInParameter(dbCommand, "@bale_no", DbType.String, pkgSlipItem.BaleNo);
                    database.AddInParameter(dbCommand, "@pkg_qty", DbType.Decimal, pkgSlipItem.PkgQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, pkgSlipItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, pkgSlipItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, pkgSlipItem.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    pkgSlipItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        pkgSlipItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return pkgSlipItemId;
        }

        /// <summary>
        /// Delete Pkg Slip Item
        /// </summary>
        /// <param name="pkgSlipItem"></param>
        /// <returns></returns>
        private bool DeletePkgSlipItem(Entities.PkgSlipItem pkgSlipItem)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePkgSlipItem))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_item_id", DbType.Int32, pkgSlipItem.PkgSlipItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, pkgSlipItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, pkgSlipItem.DeletedByIP);

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
        /// Delete Pkg Slip Item
        /// </summary>
        /// <param name="pkgSlipItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool DeletePkgSlipItem(Entities.PkgSlipItem pkgSlipItem, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeletePkgSlipItem))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_item_id", DbType.Int32, pkgSlipItem.PkgSlipItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, pkgSlipItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, pkgSlipItem.DeletedByIP);

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

        public List<Entities.PkgSlipItem> GetItemsByPurchaseBillIdBaleNoAndLocationId(Int32 purchaseBillId, string baleNo, Int32 locationId)
        {
            var pkgSlipItems = new List<Entities.PkgSlipItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPkgSlipItemsByPurchaseBillIdBaleNoAndLocationId))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);
                    database.AddInParameter(dbCommand, "@bale_no", DbType.Int32, baleNo);
                    database.AddInParameter(dbCommand, "@location_id", DbType.Int32, locationId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var pkgSlipItem = new Entities.PkgSlipItem
                            {
                                PkgSlipItemId = DRE.GetNullableInt32(reader, "pkg_slip_item_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                PkgQty = DRE.GetNullableDecimal(reader, "pkg_qty", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null)
                            };

                            pkgSlipItems.Add(pkgSlipItem);
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

            return pkgSlipItems;
        }

        public List<Entities.PkgSlipItem> GetBaleItemsByPurchaseBillIdAndLocationId(Int32 purchaseBillId, Int32 locationId)
        {
            var pkgSlipItems = new List<Entities.PkgSlipItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetBaleItemsByPurchaseBillIdAndLocationId))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);
                    database.AddInParameter(dbCommand, "@location_id", DbType.Int32, locationId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var pkgSlipItem = new Entities.PkgSlipItem
                            {
                                PkgSlipItemId = DRE.GetNullableInt32(reader, "pkg_slip_item_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                BaleNo = DRE.GetNullableString(reader, "bale_no", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                PkgQty = DRE.GetNullableDecimal(reader, "pkg_qty", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null)
                            };

                            pkgSlipItems.Add(pkgSlipItem);
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

            return pkgSlipItems;
        }

        public List<Entities.PkgSlipItem> GetPkgSlipItemsByBarcodeOrItemName(Entities.PkgSlipItem pkgSlipItem)
        {
            var pkgSlipItems = new List<Entities.PkgSlipItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPkgSlipItemsByBarcodeOrItemName))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, pkgSlipItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, pkgSlipItem.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@item_name", DbType.String, pkgSlipItem.ItemName);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var item = new Entities.PkgSlipItem
                            {
                                PkgSlipItemId = DRE.GetNullableInt32(reader, "pkg_slip_item_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                InwardGoodsId = DRE.GetNullableInt32(reader, "inward_goods_id", null),
                                ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", null),
                                BaleNo = DRE.GetNullableString(reader, "bale_no", null),
                                //ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                PkgQty = DRE.GetNullableDecimal(reader, "pkg_qty", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null)
                            };

                            pkgSlipItems.Add(item);
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

            return pkgSlipItems;
        }

        public List<Entities.PkgSlipItem> GetGoodsReceivedItems()
        {
            var pkgSlipItems = new List<Entities.PkgSlipItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetGoodsReceivedItemsForPkgSlip))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var pkgSlipItem = new Entities.PkgSlipItem
                            {
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                PkgQty = DRE.GetNullableDecimal(reader, "received_qty", null)
                            };

                            pkgSlipItems.Add(pkgSlipItem);
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

            return pkgSlipItems;
        }


        /// <summary>
        /// Get Pkg Slip items by pkg slip id
        /// </summary>
        /// <param name="pkgSlipId"></param>
        /// <returns></returns>
        public List<Entities.PkgSlipItem> GetPkgSlipItemsByPkgSlipId(Int32 pkgSlipId)
        {
            var pkgSlipItems = new List<Entities.PkgSlipItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPkgSlipItemByPkgSlipId))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlipId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var pkgSlipItem = new Entities.PkgSlipItem
                            {
                                PkgSlipItemId = DRE.GetNullableInt32(reader, "pkg_slip_item_id", 0),
                                PkgSlipId = DRE.GetNullableInt32(reader, "pkg_slip_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                InwardGoodsId = DRE.GetNullableInt32(reader, "inward_goods_id", null),
                                BaleNo = DRE.GetNullableString(reader, "bale_no", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                PkgQty = DRE.GetNullableDecimal(reader, "pkg_qty", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            pkgSlipItems.Add(pkgSlipItem);
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

            return pkgSlipItems;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pkgSlipItem"></param>
        /// <returns></returns>
        private Int32 UpdatePkgSlipItem(Entities.PkgSlipItem pkgSlipItem)
        {
            var pkgSlipItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePkgSlipItem))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_item_id", DbType.Int32, pkgSlipItem.PkgSlipItemId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, pkgSlipItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, pkgSlipItem.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, pkgSlipItem.ItemId);
                    database.AddInParameter(dbCommand, "@bale_no", DbType.String, pkgSlipItem.BaleNo);
                    database.AddInParameter(dbCommand, "@pkg_qty", DbType.Decimal, pkgSlipItem.PkgQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, pkgSlipItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, pkgSlipItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, pkgSlipItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    pkgSlipItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        pkgSlipItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return pkgSlipItemId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pkgSlipItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdatePkgSlipItem(Entities.PkgSlipItem pkgSlipItem, DbTransaction transaction)
        {
            var pkgSlipItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdatePkgSlipItem))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_item_id", DbType.Int32, pkgSlipItem.PkgSlipItemId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, pkgSlipItem.GoodsReceiptItemId);
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, pkgSlipItem.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, pkgSlipItem.ItemId);
                    database.AddInParameter(dbCommand, "@bale_no", DbType.String, pkgSlipItem.BaleNo);
                    database.AddInParameter(dbCommand, "@pkg_qty", DbType.Decimal, pkgSlipItem.PkgQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, pkgSlipItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, pkgSlipItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, pkgSlipItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    pkgSlipItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        pkgSlipItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return pkgSlipItemId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pkgSlipItem"></param>
        /// <returns></returns>
        public Int32 SavePkgSlipItem(Entities.PkgSlipItem pkgSlipItem)
        {
            var pkgSlipItemId = 0;

            if (pkgSlipItem.PkgSlipItemId == null || pkgSlipItem.PkgSlipItemId == 0)
            {
                pkgSlipItemId = AddPkgSlipItem(pkgSlipItem);
            }
            else if (pkgSlipItem.IsDeleted == true)
            {
                var result = DeletePkgSlipItem(pkgSlipItem);
            }
            else if (pkgSlipItem.ModifiedBy > 0 || pkgSlipItem.ModifiedBy != null)
            {
                pkgSlipItemId = UpdatePkgSlipItem(pkgSlipItem);
            }

            return pkgSlipItemId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="pkgSlipItem"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Int32 SavePkgSlipItem(Entities.PkgSlipItem pkgSlipItem, DbTransaction transaction)
        {
            var pkgSlipItemId = 0;

            if (pkgSlipItem.PkgSlipItemId == null || pkgSlipItem.PkgSlipItemId == 0)
            {
                pkgSlipItemId = AddPkgSlipItem(pkgSlipItem, transaction);
            }
            else if (pkgSlipItem.IsDeleted == true)
            {
                var result = DeletePkgSlipItem(pkgSlipItem, transaction);

                if (result)
                {
                    pkgSlipItemId = Convert.ToInt32(pkgSlipItem.PkgSlipItemId);
                }
            }
            else if (pkgSlipItem.ModifiedBy > 0 || pkgSlipItem.ModifiedBy != null)
            {
                pkgSlipItemId = UpdatePkgSlipItem(pkgSlipItem, transaction);
            }

            return pkgSlipItemId;
        }

    }
}
