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
    public class JobWorkItemMtrAdjustment
    {
        private readonly Database database;

        public JobWorkItemMtrAdjustment()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.JobWorkItemMtrAdjustment> GetJobWorkItemReferenceNoDetails(Int32 pkgSlipId)
        {
            var jobWorkItemsMtrAdjustmentList = new List<Entities.JobWorkItemMtrAdjustment>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetJobWorkItemMtrAdjustmentDetails))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlipId);
                    
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var jobWorkItemMtrAdjustment = new Entities.JobWorkItemMtrAdjustment()
                            {
                                JobWorkItemMtrAdjustmentId = DRE.GetNullableInt32(reader, "job_work_item_mtr_adjustment_id", null),
                                ReferenceNo = DRE.GetNullableString(reader, "reference_no", null),
                                PkgQty = DRE.GetNullableDecimal(reader, "pkg_qty", null),
                                BalanceMtrs = DRE.GetNullableDecimal(reader, "balance_mtrs", null),
                                AdjustedMtrs = DRE.GetNullableDecimal(reader, "adjusted_mtrs", null)
                            };

                            jobWorkItemsMtrAdjustmentList.Add(jobWorkItemMtrAdjustment);
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

            return jobWorkItemsMtrAdjustmentList;
        }

        private Int32 AddJobWorkItemMtrAdjustment(Entities.JobWorkItemMtrAdjustment jobWorkItemMtrAdjustment, DbTransaction transaction)
        {
            var jobWorkItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertJobWorkItemMtrAdjustmentDetails))
                {
                    database.AddInParameter(dbCommand, "@job_work_id", DbType.Int32, jobWorkItemMtrAdjustment.JobWorkId);
                    database.AddInParameter(dbCommand, "@reference_no", DbType.Int32, jobWorkItemMtrAdjustment.ReferenceNo);
                    database.AddInParameter(dbCommand, "@adjusted_mtrs", DbType.Decimal, jobWorkItemMtrAdjustment.AdjustedMtrs);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, jobWorkItemMtrAdjustment.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, jobWorkItemMtrAdjustment.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    jobWorkItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        jobWorkItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return jobWorkItemId;
        }

        //private bool DeleteJobWorkItem(Entities.JobWorkItem jobWorkItem, DbTransaction transaction)
        //{
        //    var IsJobWorkItemDeleted = false;

        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteJobWorkItemsDetails))
        //        {
        //            database.AddInParameter(dbCommand, "@job_work_item_id", DbType.Int32, jobWorkItem.JobWorkItemId);
        //            database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, jobWorkItem.DeletedBy);
        //            database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, jobWorkItem.DeletedByIP);

        //            database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

        //            var result = database.ExecuteNonQuery(dbCommand, transaction);

        //            if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
        //            {
        //                IsJobWorkItemDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

        //    return IsJobWorkItemDeleted;
        //}

        //private Int32 UpdateJobWorkItem(Entities.JobWorkItem jobWorkItem, DbTransaction transaction)
        //{
        //    var jobWorkItemId = 0;

        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateJobWorkItemsDetails))
        //        {
        //            database.AddInParameter(dbCommand, "@job_work_item_id", DbType.Int32, jobWorkItem.JobWorkItemId);
        //            database.AddInParameter(dbCommand, "@item_qty", DbType.Decimal, jobWorkItem.ItemQty);
        //            database.AddInParameter(dbCommand, "@rate", DbType.Decimal, jobWorkItem.Rate);
        //            database.AddInParameter(dbCommand, "@cut_mtrs", DbType.Decimal, jobWorkItem.CutMtrs);
        //            database.AddInParameter(dbCommand, "@remarks", DbType.String, jobWorkItem.Remarks);
        //            database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, jobWorkItem.ModifiedBy);
        //            database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, jobWorkItem.ModifiedByIP);

        //            database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

        //            jobWorkItemId = database.ExecuteNonQuery(dbCommand, transaction);

        //            if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
        //            {
        //                jobWorkItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

        //    return jobWorkItemId;
        //}

        public Int32 SaveJobWorkItemMtrAdjustment(Entities.JobWorkItemMtrAdjustment jobWorkItemMtrAdjustment, DbTransaction transaction)
        {
            var jobWorkItemMtrAdjustmentId = 0;

            if (jobWorkItemMtrAdjustment.JobWorkItemMtrAdjustmentId == null || jobWorkItemMtrAdjustment.JobWorkItemMtrAdjustmentId == 0)
            {
                jobWorkItemMtrAdjustmentId = AddJobWorkItemMtrAdjustment(jobWorkItemMtrAdjustment, transaction);
            }
            else
            {
                //if (jobWorkItemMtrAdjustment.IsDeleted == true)
                //{
                //    jobWorkItemMtrAdjustmentId = Convert.ToInt32(DeleteJobWorkItem(jobWorkItem, transaction));
                //}
                //else if (jobWorkItem.ModifiedBy != null || jobWorkItem.ModifiedBy > 0)
                //{
                //    jobWorkItemId = UpdateJobWorkItem(jobWorkItem, transaction);
                //}
            }

            return jobWorkItemMtrAdjustmentId;
        }


    }
}
