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
    public class SalesOrder
    {
        private readonly Database database;

        public SalesOrder()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddSalesOrder(Entities.SalesOrder salesOrder)
        {
            var salesOrderId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesOrder))
                {
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrder.SalesOrderId);
                    database.AddInParameter(dbCommand, "@sales_order_no", DbType.Int32, salesOrder.SalesOrderNo);
                    database.AddInParameter(dbCommand, "@sales_order_date", DbType.String, salesOrder.SalesOrderDate);
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, salesOrder.CustomerId);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, salesOrder.GSTApplicable);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, salesOrder.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesOrder.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesOrder.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesOrder.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesOrder.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesOrderId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesOrderId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesOrderId;
        }

        private Int32 AddSalesOrder(Entities.SalesOrder salesOrder, DbTransaction transaction)
        {
            var salesOrderId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesOrder))
                {
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrder.SalesOrderId);
                    database.AddInParameter(dbCommand, "@sales_order_no", DbType.Int32, salesOrder.SalesOrderNo);
                    database.AddInParameter(dbCommand, "@sales_order_date", DbType.String, salesOrder.SalesOrderDate);
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, salesOrder.CustomerId);
                    database.AddInParameter(dbCommand, "@gst_applicable", DbType.String, salesOrder.GSTApplicable);
                    database.AddInParameter(dbCommand, "@is_tax_inclusive", DbType.Boolean, salesOrder.IsTaxInclusive);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesOrder.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesOrder.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesOrder.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesOrder.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesOrderId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesOrderId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesOrderId;
        }

        private bool DeleteSalesOrder(Entities.SalesOrder salesOrder)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesOrder))
                {
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrder.SalesOrderId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesOrder.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesOrder.DeletedByIP);
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

        private bool DeleteSalesOrder(Entities.SalesOrder salesOrder, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesOrder))
                {
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrder.SalesOrderId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesOrder.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesOrder.DeletedByIP);
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

        public List<Entities.SalesOrder> GetAllSalesOrders()
        {
            var salesOrders = new List<Entities.SalesOrder>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllSalesOrders))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesOrderItem = new SalesOrderItem();

                            var salesOrder = new Entities.SalesOrder
                            {
                                SalesOrderId = DRE.GetNullableInt32(reader, "sales_order_id", 0),
                                SalesOrderNo = DRE.GetNullableInt32(reader, "sales_order_no", null),
                                SalesOrderDate = DRE.GetNullableString(reader, "sales_order_date", null),
                                SalesOrderNoSeries = DRE.GetNullableString(reader, "sales_order_no_series", null),
                                CustomerId = DRE.GetNullableInt32(reader, "customer_id", null),
                                CustomerName = DRE.GetNullableString(reader, "customer_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                GSTApplicable = DRE.GetNullableString(reader, "gst_applicable", null),
                                IsTaxInclusive = DRE.GetNullableBoolean(reader,"is_tax_inclusive", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                TotalOrderQty = DRE.GetNullableDecimal(reader, "total_order_qty", null),
                                TotalOrderAmount = DRE.GetNullableDecimal(reader, "total_order_amount", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                                SalesOrderItems = salesOrderItem.GetSalesOrderItemsBySalesOrderId(DRE.GetInt32(reader, "sales_order_id"))
                            };

                            salesOrders.Add(salesOrder);
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

            return salesOrders;
        }

        public List<Entities.SalesOrder> GetSalesOrdersByCustomerId(Int32 customerId)
        {
            var salesOrders = new List<Entities.SalesOrder>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesOrdersByCustomerId))
                {
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, customerId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesOrderItem = new SalesOrderItem();

                            var salesOrder = new Entities.SalesOrder
                            {
                                SalesOrderId = DRE.GetNullableInt32(reader, "sales_order_id", 0),
                                SalesOrderNo = DRE.GetNullableInt32(reader, "sales_order_no", null),
                                SalesOrderNoSeries = DRE.GetNullableString(reader, "sales_order_no_series", null),
                                CustomerId = DRE.GetNullableInt32(reader, "customer_id", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                                SalesOrderItems = salesOrderItem.GetSalesOrderItemsBySalesOrderId(DRE.GetInt32(reader, "sales_order_id"))
                            };

                            salesOrders.Add(salesOrder);
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

            return salesOrders;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesOrderId"></param>
        /// <returns></returns>
        public Entities.SalesOrder GetSalesOrderDetailsBySalesOrderId(Int32 salesOrderId)
        {
            var salesOrder = new Entities.SalesOrder();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesOrdersByCustomerId))
                {
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrderId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var _salesOrder = new Entities.SalesOrder
                            {
                                SalesOrderId = DRE.GetNullableInt32(reader, "sales_order_id", 0),
                                SalesOrderNo = DRE.GetNullableInt32(reader, "sales_order_no", null),
                                SalesOrderNoSeries = DRE.GetNullableString(reader, "sales_order_no_series", null),
                                SalesOrderDate = DRE.GetNullableString(reader, "sales_order_date", null),
                                CustomerId = DRE.GetNullableInt32(reader, "customer_id", null),
                                CustomerName = DRE.GetNullableString(reader, "customer_name", null),
                                GSTApplicable = DRE.GetNullableString(reader, "gst_applicable", null),
                                IsTaxInclusive = DRE.GetNullableBoolean(reader, "is_tax_inclusive", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null)
                            };

                            salesOrder = _salesOrder;
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

            return salesOrder;
        }

        private Int32 UpdateSalesOrder(Entities.SalesOrder salesOrder)
        {
            var salesOrderId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesOrder))
                {
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrder.SalesOrderId);
                    database.AddInParameter(dbCommand, "@sales_order_date", DbType.String, salesOrder.SalesOrderDate);
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, salesOrder.CustomerId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesOrder.CreatedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesOrder.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesOrderId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesOrderId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesOrderId;
        }

        private Int32 UpdateSalesOrder(Entities.SalesOrder salesOrder, DbTransaction transaction)
        {
            var salesOrderId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesOrder))
                {
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrder.SalesOrderId);
                    database.AddInParameter(dbCommand, "@sales_order_date", DbType.String, salesOrder.SalesOrderDate);
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, salesOrder.CustomerId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesOrder.CreatedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesOrder.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesOrderId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesOrderId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesOrderId;
        }

        public Int32 SaveSalesOrder(Entities.SalesOrder salesOrder)
        {
            var result = 0;

            if(salesOrder.SalesOrderId == null || salesOrder.SalesOrderId == 0)
            {
                result = AddSalesOrder(salesOrder);
            }
            else if(salesOrder.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesOrder(salesOrder));
            } 
            else if(salesOrder.ModifiedBy > 0)
            {
                result = UpdateSalesOrder(salesOrder);
            }

            return result;
        }

        public Int32 SaveSalesOrder(Entities.SalesOrder salesOrder, DbTransaction transaction)
        {
            var result = 0;

            if (salesOrder.SalesOrderId == null || salesOrder.SalesOrderId == 0)
            {
                result = AddSalesOrder(salesOrder, transaction);
            }
            else if (salesOrder.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesOrder(salesOrder, transaction));
            }
            else if (salesOrder.ModifiedBy > 0)
            {
                result = UpdateSalesOrder(salesOrder, transaction);
            }

            return result;
        }

        public Int32 SaveSalesOrder(List<Entities.SalesOrder> salesOrders)
        {
            var salesOrderId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var salesOrderItemId = 0;

                        if (salesOrders.Count > 0)
                        {
                            foreach (Entities.SalesOrder salesOrder in salesOrders)
                            {
                                if (salesOrder.SalesOrderId == null || salesOrder.SalesOrderId == 0)
                                {
                                    salesOrderId = AddSalesOrder(salesOrder, transaction);
                                }
                                else
                                {
                                    if (salesOrder.IsDeleted == true)
                                    {
                                        var result = DeleteSalesOrder(salesOrder, transaction);
                                    }
                                    else
                                    {
                                        if (salesOrder.ModifiedBy > 0 || salesOrder.ModifiedBy != null)
                                        {
                                            salesOrderId = UpdateSalesOrder(salesOrder, transaction);
                                        }
                                    }
                                }

                                if (salesOrderId > 0)
                                {
                                    foreach (Entities.SalesOrderItem salesOrderItem in salesOrder.SalesOrderItems)
                                    {
                                        salesOrderItem.SalesOrderId = salesOrderId;

                                        SalesOrderItem salesOrderItemDL = new SalesOrderItem();

                                        salesOrderItemId = salesOrderItemDL.SaveSalesOrderItem(salesOrderItem, transaction);
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

            return salesOrderId;
        }

    }
}
