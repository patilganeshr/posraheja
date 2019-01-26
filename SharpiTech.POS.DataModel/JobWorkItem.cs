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
    public class JobWorkItem
    {
        private readonly Database database;

        public JobWorkItem()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.JobWorkItem> GetPurchaseBillItems(Int32 purchaseBillId)
        {
            var purchaseBillItems = new List<Entities.JobWorkItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetJobWorkPurchaseBillItems))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var purchaseBillItem = new Entities.JobWorkItem()
                            {
                                PurchaseBillItemId = DRE.GetNullableInt32(reader, "purchase_bill_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                PurchaseQty = DRE.GetNullableDecimal(reader, "purchase_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null)
                            };

                            purchaseBillItems.Add(purchaseBillItem);
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

            return purchaseBillItems;
        }

        public List<Entities.JobWorkItem> GetJobWorkItemsFromInward(Int32 purchaseBillId, Int32 karagirId, Int32 goodsReceiptItemId)
        {
            var jobWorkItems = new List<Entities.JobWorkItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetJobWorkItemsByInward))
                {
                    database.AddInParameter(dbCommand, "@purchase_bill_id", DbType.Int32, purchaseBillId);
                    database.AddInParameter(dbCommand, "@karagir_id", DbType.Int32, karagirId);
                    database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, goodsReceiptItemId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var jobWorkItem = new Entities.JobWorkItem()
                            {
                                JobWorkItemId = DRE.GetNullableInt32(reader, "job_work_item_id", null),
                                JobWorkId = DRE.GetNullableInt32(reader, "job_work_id", null),
                                InwardId = DRE.GetNullableInt32(reader, "inward_id", null),
                                InwardGoodsId = DRE.GetNullableInt32(reader, "inward_goods_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                ItemQty = DRE.GetNullableDecimal(reader, "item_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                Rate = DRE.GetNullableDecimal(reader, "rate", null),
                                CutMtrs = DRE.GetNullableDecimal(reader, "cut_mtrs", null),
                                MtrsUsed = DRE.GetNullableDecimal(reader, "mtrs_used", null)
                            };

                            jobWorkItems.Add(jobWorkItem);
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

            return jobWorkItems;
        }

        public List<Entities.JobWorkItem> GetJobWorkItemsByJobWorkId(Int32 jobWorkId)
        {
            var jobWorkItems = new List<Entities.JobWorkItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetJobWorkItemsByJobWorkId))
                {
                    database.AddInParameter(dbCommand, "@job_work_id", DbType.Int32, jobWorkId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var jobWorkItem = new Entities.JobWorkItem()
                            {
                                JobWorkItemId = DRE.GetNullableInt32(reader, "job_work_item_id", null),
                                JobWorkId = DRE.GetNullableInt32(reader, "job_work_id", null),
                                InwardId = DRE.GetNullableInt32(reader, "inward_id", null),
                                InwardGoodsId = DRE.GetNullableInt32(reader, "inward_goods_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                ItemQty = DRE.GetNullableDecimal(reader, "item_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                Rate = DRE.GetNullableDecimal(reader, "rate", null),
                                CutMtrs = DRE.GetNullableDecimal(reader, "cut_mtrs", null),
                                MtrsUsed = DRE.GetNullableDecimal(reader, "mtrs_used", null)
                            };

                            jobWorkItems.Add(jobWorkItem);
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

            return jobWorkItems;
        }

        private Int32 AddJobWorkItem(Entities.JobWorkItem jobWorkItem, DbTransaction transaction)
        {
            var jobWorkItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertJobWorkItemsDetails))
                {
                    database.AddInParameter(dbCommand, "@job_work_item_id", DbType.Int32, jobWorkItem.JobWorkItemId);
                    database.AddInParameter(dbCommand, "@job_work_id", DbType.Int32, jobWorkItem.JobWorkId);
                    database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, jobWorkItem.InwardGoodsId);
                    database.AddInParameter(dbCommand, "@item_qty", DbType.Decimal, jobWorkItem.ItemQty);
                    database.AddInParameter(dbCommand, "@rate", DbType.Decimal, jobWorkItem.Rate);
                    database.AddInParameter(dbCommand, "@cut_mtrs", DbType.Decimal, jobWorkItem.CutMtrs);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, jobWorkItem.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, jobWorkItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, jobWorkItem.CreatedByIP);

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

        private bool DeleteJobWorkItem(Entities.JobWorkItem jobWorkItem, DbTransaction transaction)
        {
            var IsJobWorkItemDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteJobWorkItemsDetails))
                {
                    database.AddInParameter(dbCommand, "@job_work_item_id", DbType.Int32, jobWorkItem.JobWorkItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, jobWorkItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, jobWorkItem.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsJobWorkItemDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsJobWorkItemDeleted;
        }

        private Int32 UpdateJobWorkItem(Entities.JobWorkItem jobWorkItem, DbTransaction transaction)
        {
            var jobWorkItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateJobWorkItemsDetails))
                {
                    database.AddInParameter(dbCommand, "@job_work_item_id", DbType.Int32, jobWorkItem.JobWorkItemId);
                    database.AddInParameter(dbCommand, "@item_qty", DbType.Decimal, jobWorkItem.ItemQty);
                    database.AddInParameter(dbCommand, "@rate", DbType.Decimal, jobWorkItem.Rate);
                    database.AddInParameter(dbCommand, "@cut_mtrs", DbType.Decimal, jobWorkItem.CutMtrs);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, jobWorkItem.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, jobWorkItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, jobWorkItem.ModifiedByIP);

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

        public Int32 SaveJobWorkItem(Entities.JobWorkItem jobWorkItem, DbTransaction transaction)
        {
            var jobWorkItemId = 0;

            if (jobWorkItem.JobWorkItemId == null || jobWorkItem.JobWorkItemId == 0)
            {
                jobWorkItemId = AddJobWorkItem(jobWorkItem, transaction);
            }
            else
            {
                if (jobWorkItem.IsDeleted == true)
                {
                    jobWorkItemId = Convert.ToInt32(DeleteJobWorkItem(jobWorkItem, transaction));
                }
                else if (jobWorkItem.ModifiedBy != null || jobWorkItem.ModifiedBy > 0)
                {
                    jobWorkItemId = UpdateJobWorkItem(jobWorkItem, transaction);
                }
            }

            return jobWorkItemId;
        }

    }
}
