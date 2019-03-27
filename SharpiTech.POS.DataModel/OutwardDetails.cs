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
    public class OutwardDetails
    {
        private readonly Database database;

        public OutwardDetails()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outward"></param>
        /// <returns></returns>
        private Int32 AddOutwardDetails(Entities.OutwardDetails outward)
        {
            var outwardId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertOutwardDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outward.OutwardId);
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, outward.PkgSlipId);
                    database.AddInParameter(dbCommand, "@outward_no", DbType.Int32, outward.OutwardNo);
                    database.AddInParameter(dbCommand, "@outward_date", DbType.String, outward.OutwardDate);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.String, outward.TransporterId);
                    database.AddInParameter(dbCommand, "@vehicle_no", DbType.String, outward.VehicleNo);
                    database.AddInParameter(dbCommand, "@location_id", DbType.Int32, outward.GoodsSentLocationId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, outward.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, outward.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, outward.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, outward.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    outwardId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        outwardId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return outwardId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outward"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddOutwardDetails(Entities.OutwardDetails outward, DbTransaction transaction)
        {
            var outwardId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertOutwardDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outward.OutwardId);
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, outward.PkgSlipId);
                    database.AddInParameter(dbCommand, "@outward_no", DbType.Int32, outward.OutwardNo);
                    database.AddInParameter(dbCommand, "@outward_date", DbType.String, outward.OutwardDate);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.String, outward.TransporterId);
                    database.AddInParameter(dbCommand, "@vehicle_no", DbType.String, outward.VehicleNo);
                    database.AddInParameter(dbCommand, "@location_id", DbType.Int32, outward.GoodsSentLocationId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, outward.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, outward.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, outward.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, outward.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    outwardId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        outwardId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return outwardId;
        }

        private bool DeleteOutwardDetails(Entities.OutwardDetails outward)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteOutwardDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outward.OutwardId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, outward.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, outward.DeletedByIP);

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
        /// <param name="outward"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool DeleteOutwardDetails(Entities.OutwardDetails outward, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteOutwardDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outward.OutwardId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, outward.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, outward.DeletedByIP);

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

        public List<Entities.OutwardDetails> GetAllOutwardDetails()
        {
            var outwards = new List<Entities.OutwardDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllOutwardDetails)) {

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var outwardGoodsDetails = new OutwardGoodsDetails();

                            var outwardDetails = new Entities.OutwardDetails
                            {
                                OutwardId = DRE.GetNullableInt32(reader, "outward_id", null),
                                PkgSlipId = DRE.GetNullableInt32(reader, "pkg_slip_id", null),
                                OutwardNo = DRE.GetNullableInt32(reader, "outward_no", null),
                                OutwardDate = DRE.GetNullableString(reader, "outward_date", null),
                                BaleNo = DRE.GetNullableString(reader, "bale_no", null),
                                TypeOfTransfer = DRE.GetNullableString(reader, "transfer_type", null),
                                FromLocation = DRE.GetNullableString(reader, "from_location", null),
                                ToLocation = DRE.GetNullableString(reader, "to_location", null),
                                FromToLocation = DRE.GetNullableString(reader,"from_to_location", null),
                                TransporterId = DRE.GetNullableInt32(reader, "transporter_id", null),
                                TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                                VehicleNo = DRE.GetNullableString(reader, "vehicle_no", null),
                                GoodsSentLocationId = DRE.GetNullableInt32(reader, "goods_sent_location_id", null),
                                GoodsSentLocationName = DRE.GetNullableString(reader, "goods_sent_location_name", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                //SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                                OutwardGoodsDetails = outwardGoodsDetails.GetOutwardGoodsDetailsByOutwardId(DRE.GetInt32(reader, "outward_id"))
                            };

                            outwards.Add(outwardDetails);
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

            return outwards;
        }

        public List<Entities.OutwardDetails> GetBaleNos()
        {
            var baleNos = new List<Entities.OutwardDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetBaleNosForOutward))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var baleNo = new Entities.OutwardDetails
                            {
                                PkgSlipId = DRE.GetNullableInt32(reader, "pkg_slip_id", null),
                                BaleNo = DRE.GetNullableString(reader, "bale_no", null),
                                PurchaseBillItemId = DRE.GetNullableInt32(reader, "purchase_bill_item_id", null)
                            };

                            baleNos.Add(baleNo);
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

            return baleNos;
        }

        public Entities.OutwardDetails GetPkgSlipAdditionalDetails(Int32 pkgSlipId)
        {
            var pkgSlipDetails = new Entities.OutwardDetails();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPkgSlipAdditionalDetailsByPkgSlipId))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlipId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var pkgSlip = new Entities.OutwardDetails
                            {
                                FromToLocation = DRE.GetNullableString(reader, "from_to_location", null),
                                FromLocationId = DRE.GetNullableInt32(reader, "from_location_id", null),
                                ToLocationId = DRE.GetNullableInt32(reader, "to_location_id", null),
                                TypeOfTransfer = DRE.GetNullableString(reader, "transfer_type", null),
                                ReferenceNo = DRE.GetNullableString(reader, "reference_no", null)
                            };

                            pkgSlipDetails = pkgSlip;
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

            return pkgSlipDetails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outward"></param>
        /// <returns></returns>
        private Int32 UpdateOutwardDetails(Entities.OutwardDetails outward)
        {
            var outwardId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateOutwardDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outward.OutwardId);
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, outward.PkgSlipId);
                    database.AddInParameter(dbCommand, "@outward_no", DbType.Int32, outward.OutwardNo);
                    database.AddInParameter(dbCommand, "@outward_date", DbType.String, outward.OutwardDate);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.String, outward.TransporterId);
                    database.AddInParameter(dbCommand, "@vehicle_no", DbType.String, outward.VehicleNo);
                    database.AddInParameter(dbCommand, "@location_id", DbType.Int32, outward.GoodsSentLocationId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, outward.BranchId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, outward.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, outward.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    outwardId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        outwardId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return outwardId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outward"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdateOutwardDetails(Entities.OutwardDetails outward, DbTransaction transaction)
        {
            var outwardId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateOutwardDetails))
                {
                    database.AddInParameter(dbCommand, "@outward_id", DbType.Int32, outward.OutwardId);
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, outward.PkgSlipId);
                    database.AddInParameter(dbCommand, "@outward_no", DbType.Int32, outward.OutwardNo);
                    database.AddInParameter(dbCommand, "@outward_date", DbType.String, outward.OutwardDate);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.String, outward.TransporterId);
                    database.AddInParameter(dbCommand, "@vehicle_no", DbType.String, outward.VehicleNo);
                    database.AddInParameter(dbCommand, "@location_id", DbType.Int32, outward.GoodsSentLocationId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, outward.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, outward.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, outward.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, outward.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    outwardId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        outwardId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return outwardId;
        }

        public Int32 SaveOutwardDetails(Entities.OutwardDetails outwardDetails)
        {
            var outwardId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var outwardGoodsId = 0;

                        if (outwardDetails != null)
                        {
                            if (outwardDetails.OutwardId == null || outwardDetails.OutwardId == 0)
                            {
                                outwardId = AddOutwardDetails(outwardDetails, transaction);
                            }
                            else
                            {
                                if (outwardDetails.IsDeleted == true)
                                {
                                    var result = DeleteOutwardDetails(outwardDetails, transaction);

                                    if (result)
                                    {
                                        outwardId = (Int32)outwardDetails.OutwardId;
                                    }
                                    else
                                    {
                                        outwardId = -1;
                                    }
                                }
                                else
                                {
                                    if (outwardDetails.ModifiedBy > 0 || outwardDetails.ModifiedBy != null)
                                    {
                                        outwardId = UpdateOutwardDetails(outwardDetails, transaction);
                                    }
                                }
                            }

                            if (outwardId > 0)
                            {
                                if (outwardDetails.OutwardGoodsDetails != null)
                                {
                                    foreach (Entities.OutwardGoodsDetails outwardGoods in outwardDetails.OutwardGoodsDetails)
                                    {
                                        outwardGoods.OutwardId = outwardId;

                                        OutwardGoodsDetails outwardGoodsDetails = new OutwardGoodsDetails();

                                        outwardGoodsId = outwardGoodsDetails.SaveOutwardGoodsDetails(outwardGoods, transaction);
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

            return outwardId;
        }
    }
}
