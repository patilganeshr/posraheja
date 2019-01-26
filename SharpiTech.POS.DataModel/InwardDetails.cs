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
    public class InwardDetails
    {
        private readonly Database database;

        public InwardDetails()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inward"></param>
        /// <returns></returns>
        private Int32 AddInwardDetails(Entities.InwardDetails inward)
        {
            var inwardId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertInwardDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inward.InwardId);
                    database.AddInParameter(dbCommand, "@inward_no", DbType.Int32, inward.InwardNo);
                    database.AddInParameter(dbCommand, "@inward_date", DbType.String, inward.InwardDate);
                    database.AddInParameter(dbCommand, "@reference_id", DbType.Int32, inward.ReferenceId);
                    database.AddInParameter(dbCommand, "@from_location_id", DbType.Int32, inward.FromLocationId);
                    database.AddInParameter(dbCommand, "@to_location_id", DbType.Int32, inward.ToLocationId);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, inward.TransporterId);
                    database.AddInParameter(dbCommand, "@vehicle_no", DbType.String, inward.VehicleNo);
                    database.AddInParameter(dbCommand, "@reference_type", DbType.String, inward.ReferenceType);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, inward.Remarks);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, inward.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, inward.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, inward.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, inward.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    inwardId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        inwardId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return inwardId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inward"></param>
        /// <param name="dbTransaction"></param>
        /// <returns></returns>
        private Int32 AddInwardDetails(Entities.InwardDetails inward, DbTransaction dbTransaction)
        {
            var inwardId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertInwardDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inward.InwardId);
                    database.AddInParameter(dbCommand, "@inward_no", DbType.Int32, inward.InwardNo);
                    database.AddInParameter(dbCommand, "@inward_date", DbType.String, inward.InwardDate);
                    database.AddInParameter(dbCommand, "@reference_id", DbType.Int32, inward.ReferenceId);
                    database.AddInParameter(dbCommand, "@from_location_id", DbType.Int32, inward.FromLocationId);
                    database.AddInParameter(dbCommand, "@to_location_id", DbType.Int32, inward.ToLocationId);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, inward.TransporterId);
                    database.AddInParameter(dbCommand, "@vehicle_no", DbType.String, inward.VehicleNo);
                    database.AddInParameter(dbCommand, "@reference_type", DbType.String, inward.ReferenceType);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, inward.Remarks);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, inward.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, inward.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, inward.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, inward.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    inwardId = database.ExecuteNonQuery(dbCommand, dbTransaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        inwardId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return inwardId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inward"></param>
        /// <returns></returns>
        private bool DeleteInwardDetails(Entities.InwardDetails inward)
        {
            var IsRecordDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteInwardDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inward.InwardId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, inward.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, inward.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsRecordDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsRecordDeleted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inward"></param>
        /// <param name="dbTransaction"></param>
        /// <returns></returns>
        private bool DeleteInwardDetails(Entities.InwardDetails inward, DbTransaction dbTransaction)
        {
            var IsRecordDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteInwardDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inward.InwardId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, inward.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, inward.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand, dbTransaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsRecordDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsRecordDeleted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.InwardDetails> GetAllInwardDetails()
        {
            var inwards = new List<Entities.InwardDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllInwardDetails))
                {

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var inwardGoodsDetails = new InwardGoodsDetails();

                            var inwardDetails = new Entities.InwardDetails
                            {
                                InwardId = DRE.GetNullableInt32(reader, "inward_id", null),
                                InwardNo = DRE.GetNullableInt32(reader, "inward_no", null),
                                InwardDate = DRE.GetNullableString(reader, "inward_date", null),
                                ReferenceId = DRE.GetNullableInt32(reader, "reference_id", null),
                                ReferenceType = DRE.GetNullableString(reader, "reference_type", null),
                                ReferenceNo = DRE.GetNullableString(reader, "reference_no", null),
                                FromLocationId = DRE.GetNullableInt32(reader, "from_location_id", null),
                                FromLocationName = DRE.GetNullableString(reader, "from_location_name", null),
                                ToLocationId = DRE.GetNullableInt32(reader, "to_location_id", null),
                                ToLocationName = DRE.GetNullableString(reader, "to_location_name", null),
                                TypeOfTransfer = DRE.GetNullableString(reader,"transfer_type", null),
                                TypeOfTransferId = DRE.GetNullableInt32(reader, "type_of_transfer_id", null),
                                TransporterId = DRE.GetNullableInt32(reader, "transporter_id", null),
                                TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                                VehicleNo = DRE.GetNullableString(reader, "vehicle_no", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                InwardGoodsDetails = inwardGoodsDetails.GetInwardGoodsDetailsByInwardId(DRE.GetInt32(reader, "inward_id"))
                            };

                            inwards.Add(inwardDetails);
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

            return inwards;
        }

        /// <summary>
        /// Get Reference No.'s from Goods Receipt
        /// </summary>
        /// <returns>Return as List</returns>
        public List<Entities.InwardDetails> GetReferenceNosFromGoodsReceipt()
        {
            var referenceNos = new List<Entities.InwardDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetInwardReferenceNosFromGoodsReceipts))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var referenceNo = new Entities.InwardDetails
                            {
                                ReferenceId = DRE.GetNullableInt32(reader, "goods_receipt_id", null),
                                ReferenceNo = DRE.GetNullableString(reader, "goods_receipt_no", null)
                            };

                            referenceNos.Add(referenceNo);
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

            return referenceNos;
        }

        /// <summary>
        /// Get Reference No.'s from Outward
        /// </summary>
        /// <returns>Return as List</returns>
        public List<Entities.InwardDetails> GetReferenceNosFromOutwards()
        {
            var referenceNos = new List<Entities.InwardDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetInwardReferenceNosFromOutwards))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var referenceNo = new Entities.InwardDetails
                            {
                                ReferenceId = DRE.GetNullableInt32(reader, "outward_id", null),
                                ReferenceNo = DRE.GetNullableString(reader, "outward_no", null)
                            };

                            referenceNos.Add(referenceNo);
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

            return referenceNos;
        }

        /// <summary>
        /// Get Reference No.'s from Job Work
        /// </summary>
        /// <returns>Return as List</returns>
        public List<Entities.InwardDetails> GetReferenceNosFromJobWork()
        {
            var referenceNos = new List<Entities.InwardDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetInwardReferenceNosFromGoodsReceipts))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var referenceNo = new Entities.InwardDetails
                            {
                                ReferenceId = DRE.GetNullableInt32(reader, "job_work_id", null),
                                ReferenceNo = DRE.GetNullableString(reader, "job_work_no", null)
                            };

                            referenceNos.Add(referenceNo);
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

            return referenceNos;
        }

        public List<Entities.InwardDetails> GetReferenceNoFromInward(Int32 inwardId)
        {
            var referenceNos = new List<Entities.InwardDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetInwardReferenceNoFromInward))
                {
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inwardId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var referenceNo = new Entities.InwardDetails
                            {
                                ReferenceId = DRE.GetNullableInt32(reader, "reference_id", null),
                                ReferenceNo = DRE.GetNullableString(reader, "reference_no", null)
                            };

                            referenceNos.Add(referenceNo);
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

            return referenceNos;
        }

        /// <summary>
        /// Get Reference No. Details from Goods Rececipt
        /// </summary>
        /// <param name="goodsReceiptId">Required GoodsReceiptId as an integer parameter.</param>
        /// <returns></returns>
        public Entities.InwardDetails GetReferenceNoDetailsByGoodsReceiptId(Int32 goodsReceiptId)
        {
            var referenceNoDetails = new Entities.InwardDetails();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetInwardReferenceNoDetailsByGoodsReceiptId))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceiptId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var referenceDetails = new Entities.InwardDetails
                            {
                                ReferenceDate = DRE.GetNullableString(reader, "goods_receipt_date", null),
                                FromLocationId = DRE.GetNullableInt32(reader, "goods_received_location_id", null),
                                FromLocationName = DRE.GetNullableString(reader, "goods_received_location_name", null)
                            };

                            referenceNoDetails = referenceDetails;
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

            return referenceNoDetails;
        }

        /// <summary>
        /// Get Reference No. details from Outward
        /// </summary>
        /// <param name="outwardId">Required OutwardId as an integer parameter.</param>
        /// <returns></returns>
        public Entities.InwardDetails GetReferenceNoDetailsByOutwardId(Int32 outwardId)
        {
            var referenceNoDetails = new Entities.InwardDetails();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetInwardReferenceNoDetailsByOutwardId))
                {
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outwardId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var referenceDetails = new Entities.InwardDetails
                            {
                                ReferenceDate = DRE.GetNullableString(reader, "outward_date", null),
                                FromLocationId = DRE.GetNullableInt32(reader, "location_id", null),
                                FromLocationName = DRE.GetNullableString(reader, "goods_received_location_name", null),
                                TypeOfTransfer = DRE.GetNullableString(reader, "transfer_type", null)
                            };

                            referenceNoDetails = referenceDetails;
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

            return referenceNoDetails;
        }

        /// <summary>
        /// Get Inward Goods Details by GoodsReceiptId.
        /// </summary>
        /// <param name="goodsReceiptId">Required GoodsReceiptId as an integer parameter.</param>
        /// <returns></returns>
        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByGoodsReceiptId(Int32 goodsReceiptId)
        {
            var inwardGoodDetails = new List<Entities.InwardGoodsDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetInwardGoodsDetailsByGoodsReceiptId))
                {
                    database.AddInParameter(dbCommand, "@goods_receipt_id", DbType.Int32, goodsReceiptId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var goodsDetails = new Entities.InwardGoodsDetails
                            {
                                InwardGoodsId = DRE.GetNullableInt32(reader, "inward_goods_id", null),
                                InwardId = DRE.GetNullableInt32(reader, "inward_id", null),
                                GoodsReceiptId = DRE.GetNullableInt32(reader, "goods_receipt_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                ReceivedQty = DRE.GetNullableDecimal(reader, "received_qty", null),
                                InwardQty = DRE.GetNullableDecimal(reader, "inward_qty", null),
                                InwardStatus = DRE.GetNullableString(reader, "inward_status", null)
                            };

                            inwardGoodDetails.Add(goodsDetails);
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

            return inwardGoodDetails;
        }

        /// <summary>
        /// Get Inward Goods Details by OutwardId.
        /// </summary>
        /// <param name="outwardId">Required OutwardId as an integer parameter.</param>
        /// <returns></returns>
        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByOutwardId(Int32 outwardId)
        {
            var inwardGoodDetails = new List<Entities.InwardGoodsDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetInwardGoodsDetailsByOutwardId))
                {
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outwardId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var goodsDetails = new Entities.InwardGoodsDetails
                            {
                                InwardGoodsId = DRE.GetNullableInt32(reader, "inward_goods_id", null),
                                InwardId = DRE.GetNullableInt32(reader, "inward_id", null),
                                OutwardId = DRE.GetNullableInt32(reader, "outward_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                PkgQty = DRE.GetNullableDecimal(reader, "pkg_qty", null),                                
                                InwardQty = DRE.GetNullableDecimal(reader, "inward_qty", null),
                                InwardStatus = DRE.GetNullableString(reader, "inward_status", null)
                            };

                            inwardGoodDetails.Add(goodsDetails);
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

            return inwardGoodDetails;
        }

        /// <summary>
        /// Get Inward Goods Details by OutwardId.
        /// </summary>
        /// <param name="jobWorkId">Required JobWorkId as an integer parameter.</param>
        /// <returns></returns>
        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByJobWorkId(Int32 jobWorkId)
        {
            var inwardGoodDetails = new List<Entities.InwardGoodsDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetInwardGoodsDetailsByOutwardId))
                {
                    database.AddInParameter(dbCommand, "@job_work_id", DbType.Int32, jobWorkId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var goodsDetails = new Entities.InwardGoodsDetails
                            {
                                InwardGoodsId = DRE.GetNullableInt32(reader, "inward_goods_id", null),
                                InwardId = DRE.GetNullableInt32(reader, "inward_id", null),
                                JobWorkId = DRE.GetNullableInt32(reader, "job_work_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                PkgQty = DRE.GetNullableDecimal(reader, "pkg_qty", null),
                                InwardQty = DRE.GetNullableDecimal(reader, "inward_qty", null),
                                InwardStatus = DRE.GetNullableString(reader, "inward_status", null)
                            };

                            inwardGoodDetails.Add(goodsDetails);
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

            return inwardGoodDetails;
        }

        /// <summary>
        /// Update Inward Details.
        /// </summary>
        /// <param name="inward">Required inward as an object of a InwardDetails.</param>
        /// <returns></returns>
        private Int32 UpdateInwardDetails(Entities.InwardDetails inward)
        {
            var inwardId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateInwardDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inward.InwardId);
                    database.AddInParameter(dbCommand, "@inward_no", DbType.Int32, inward.InwardNo);
                    database.AddInParameter(dbCommand, "@inward_date", DbType.String, inward.InwardDate);
                    database.AddInParameter(dbCommand, "@reference_id", DbType.Int32, inward.ReferenceId);
                    database.AddInParameter(dbCommand, "@from_location_id", DbType.Int32, inward.FromLocationId);
                    database.AddInParameter(dbCommand, "@to_location_id", DbType.Int32, inward.ToLocationId);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, inward.TransporterId);
                    database.AddInParameter(dbCommand, "@vehicle_no", DbType.String, inward.VehicleNo);
                    database.AddInParameter(dbCommand, "@reference_type", DbType.String, inward.ReferenceType);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, inward.Remarks);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, inward.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, inward.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, inward.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, inward.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    inwardId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        inwardId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return inwardId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inward"></param>
        /// <param name="dbTransaction"></param>
        /// <returns></returns>
        private Int32 UpdateInwardDetails(Entities.InwardDetails inward, DbTransaction dbTransaction)
        {
            var inwardId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateInwardDetails))
                {
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inward.InwardId);
                    database.AddInParameter(dbCommand, "@inward_no", DbType.Int32, inward.InwardNo);
                    database.AddInParameter(dbCommand, "@inward_date", DbType.String, inward.InwardDate);
                    database.AddInParameter(dbCommand, "@reference_id", DbType.Int32, inward.ReferenceId);
                    database.AddInParameter(dbCommand, "@from_location_id", DbType.Int32, inward.FromLocationId);
                    database.AddInParameter(dbCommand, "@to_location_id", DbType.Int32, inward.ToLocationId);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, inward.TransporterId);
                    database.AddInParameter(dbCommand, "@vehicle_no", DbType.String, inward.VehicleNo);
                    database.AddInParameter(dbCommand, "@reference_type", DbType.String, inward.ReferenceType);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, inward.Remarks);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, inward.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, inward.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, inward.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, inward.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    inwardId = database.ExecuteNonQuery(dbCommand, dbTransaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        inwardId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return inwardId;
        }

        public bool CheckInwardExistsInSalesBill(Int32 inwardId)
        {
            bool IsInwardExists = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckInwardExistsInSalesBill))
                {
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inwardId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            IsInwardExists = DRE.GetBoolean(reader, "is_inward_exists");
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

            return IsInwardExists;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inwards"></param>
        /// <returns></returns>
        public Int32 SaveInwardDetails(List<Entities.InwardDetails> inwards)
        {
            var inwardId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var inwardGoodsId = 0;

                        if (inwards.Count > 0)
                        {
                            foreach (Entities.InwardDetails inward in inwards)
                            {
                                if (inward.InwardId == null || inward.InwardId == 0)
                                {
                                    inwardId = AddInwardDetails(inward, transaction);
                                }
                                else
                                {
                                    if (inward.IsDeleted == true)
                                    {
                                        var result = DeleteInwardDetails(inward, transaction);

                                        if (result)
                                        {
                                            inwardId = (int)inward.InwardId;
                                        }
                                    }
                                    else
                                    {
                                        if (inward.ModifiedBy > 0 || inward.ModifiedBy != null)
                                        {
                                            inwardId = UpdateInwardDetails(inward, transaction);
                                        }
                                    }
                                }

                                if (inwardId > 0)
                                {
                                    foreach (Entities.InwardGoodsDetails inwardGoods in inward.InwardGoodsDetails)
                                    {
                                        inwardGoods.InwardId = inwardId;

                                        InwardGoodsDetails inwardGoodsDetails = new InwardGoodsDetails();

                                        inwardGoodsId = inwardGoodsDetails.SaveInwardGoodsDetails(inwardGoods, transaction);
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

            return inwardId;
        }

    }
}
