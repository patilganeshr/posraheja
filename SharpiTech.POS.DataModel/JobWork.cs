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
    public class JobWork
    {
        private readonly Database database;

        public JobWork()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.JobWork> GetAllJobWorks() {

            var jobWorks = new List<Entities.JobWork>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllJobWorkDetails))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var jobWorkItem = new JobWorkItem();

                            var jobWork = new Entities.JobWork()
                            {
                                JobWorkId = DRE.GetNullableInt32(reader, "job_work_id", null),
                                JobWorkNo = DRE.GetNullableInt32(reader, "job_work_no", null),
                                JobWorkDate = DRE.GetNullableString(reader, "job_work_date", null),
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                                PkgSlipId = DRE.GetNullableInt32(reader,"pkg_slip_id", null),
                                KaragirId = DRE.GetNullableInt32(reader, "karagir_id", null),
                                KaragirName = DRE.GetNullableString(reader, "karagir_name", null),
                                PurchaseQty = DRE.GetNullableDecimal(reader, "purchase_qty", null),
                                PkgQty = DRE.GetNullableDecimal(reader, "pkg_qty", null),
                                InwardQty = DRE.GetNullableDecimal(reader, "inward_qty", null),
                                AdjustedMtrs = DRE.GetNullableDecimal(reader, "adjusted_mtrs", null),
                                KaragirBillNo = DRE.GetNullableString(reader, "karagir_bill_no", null),
                                KaragirLocation = DRE.GetNullableString(reader, "karagir_location", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                JobWorkItems = jobWorkItem.GetJobWorkItemsByJobWorkId(DRE.GetInt32(reader, "job_work_id"))
                            };

                            jobWorks.Add(jobWork);
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

            return jobWorks;
        }

        public List<Entities.JobWork> GetPurchaseBillNos()
        {
            var purchaseBillNos = new List<Entities.JobWork>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetJobWorkPurchaseBillNos))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseBillNo = new Entities.JobWork()
                            {
                                PurchaseBillId = DRE.GetNullableInt32(reader, "purchase_bill_id", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null)
                            };

                            purchaseBillNos.Add(purchaseBillNo);
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

            return purchaseBillNos;
        }

        public List<Entities.JobWork> GetKaragirList(Int32 purchaseBillId)
        {
            var karagirs = new List<Entities.JobWork>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetJobWorkKaragirList))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var karagir = new Entities.JobWork()
                            {
                                KaragirId = DRE.GetNullableInt32(reader, "karagir_id", null),
                                KaragirName = DRE.GetNullableString(reader, "karagir_name", null),
                                PkgSlipId = DRE.GetNullableInt32(reader, "pkg_slip_id", null)
                            };

                            karagirs.Add(karagir);
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

            return karagirs;
        }

        public Entities.JobWork GetKaragirAndAdditionalDetails(Int32 pkgSlipId)
        {
            var jobWorkInfo = new Entities.JobWork();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetJobWorkKaragirDetails))
                {
                    database.AddInParameter(dbCommand, "@pkg_slip_id", DbType.Int32, pkgSlipId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var jobWork = new Entities.JobWork()
                            {
                                ReferenceNo = DRE.GetNullableString(reader, "reference_no", null),
                                KaragirId = DRE.GetNullableInt32(reader, "karagir_id", null),
                                KaragirName = DRE.GetNullableString(reader, "karagir_name", null),
                                KaragirLocation = DRE.GetNullableString(reader, "location_name", null)
                            };

                            jobWorkInfo = jobWork;
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

            return jobWorkInfo;
        }

        private Int32 AddJobWork(Entities.JobWork jobWork, DbTransaction transaction)
        {
            var jobWorkId = 0;

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertJobWorkDetails))
                {
                    database.AddInParameter(dbCommand, "@job_work_id", DbType.Int32, jobWork.JobWorkId);
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, jobWork.PurchaseBillId);
                    database.AddInParameter(dbCommand, "@karagir_id", DbType.Int32, jobWork.KaragirId);
                    database.AddInParameter(dbCommand, "@karagir_bill_no", DbType.String, jobWork.KaragirBillNo);
                    database.AddInParameter(dbCommand, "@job_work_no", DbType.Int32, jobWork.JobWorkNo);
                    database.AddInParameter(dbCommand, "@job_work_date", DbType.String, jobWork.JobWorkDate);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, jobWork.Remarks);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, jobWork.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, jobWork.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, jobWork.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, jobWork.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    jobWorkId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        jobWorkId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return jobWorkId;
        }

        private bool DeleteJobWork(Entities.JobWork jobWork, DbTransaction transaction)
        {
            var IsJobWorkDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteJobWorkDetails))
                {
                    database.AddInParameter(dbCommand, "@job_work_id", DbType.Int32, jobWork.JobWorkId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, jobWork.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, jobWork.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsJobWorkDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsJobWorkDeleted;
        }

        private Int32 UpdateJobWork(Entities.JobWork jobWork, DbTransaction transaction)
        {
            var jobWorkId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateJobWorkDetails))
                {
                    database.AddInParameter(dbCommand, "@job_work_id", DbType.Int32, jobWork.JobWorkId);
                    database.AddInParameter(dbCommand, "@job_work_no", DbType.Int32, jobWork.JobWorkNo);
                    database.AddInParameter(dbCommand, "@job_work_date", DbType.String, jobWork.JobWorkDate);
                    database.AddInParameter(dbCommand, "@karagir_bill_no", DbType.String, jobWork.KaragirBillNo);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, jobWork.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, jobWork.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, jobWork.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    jobWorkId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        jobWorkId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return jobWorkId;
        }

        public Int32 SaveJobWork(Entities.JobWork jobWork)
        {
            var jobWorkId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var jobWorkItemId = 0;
                        var jobWorkItemMtrAdjustmentId = 0;
                        
                        if (jobWork != null)
                        {
                            if (jobWork.JobWorkId == null || jobWork.JobWorkId == 0)
                            {
                                jobWorkId = AddJobWork(jobWork, transaction);
                            }
                            else
                            {
                                jobWorkId = Convert.ToInt32(jobWork.JobWorkId);

                                if (jobWork.IsDeleted == true)
                                {
                                    var result = DeleteJobWork(jobWork, transaction);

                                    if (result)
                                    {
                                        jobWorkId = (int)jobWork.JobWorkId;
                                    }
                                }
                                else
                                {
                                    if (jobWork.ModifiedBy > 0 || jobWork.ModifiedBy != null)
                                    {
                                        jobWorkId = UpdateJobWork(jobWork, transaction);
                                    }
                                }
                            }

                            if (jobWorkId > 0)
                            {
                                if (jobWork.JobWorkItems != null)
                                {
                                    foreach (Entities.JobWorkItem jobWorkItem in jobWork.JobWorkItems)
                                    {
                                        jobWorkItem.JobWorkId = jobWorkId;

                                        JobWorkItem jobWorkItemDL = new JobWorkItem();

                                        jobWorkItemId = jobWorkItemDL.SaveJobWorkItem(jobWorkItem, transaction);
                                    }

                                }

                                // Save Job Work Item Mtr Adjustment Details
                                if (jobWork.JobWorkItemMtrAdjustments != null)
                                {
                                    foreach (Entities.JobWorkItemMtrAdjustment jobWorkItemMtrAdjustment in jobWork.JobWorkItemMtrAdjustments)
                                    {
                                        jobWorkItemMtrAdjustment.JobWorkId = jobWorkId;

                                        JobWorkItemMtrAdjustment jobWorkItemMtrAdjDL = new JobWorkItemMtrAdjustment();

                                        jobWorkItemMtrAdjustmentId = jobWorkItemMtrAdjDL.SaveJobWorkItemMtrAdjustment(jobWorkItemMtrAdjustment, transaction);
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

            return jobWorkId;

        }

    }
}
