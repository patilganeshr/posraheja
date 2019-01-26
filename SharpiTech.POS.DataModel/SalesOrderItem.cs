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
    public class SalesOrderItem
    {
        private readonly Database database;

        public SalesOrderItem()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddSalesOrderItem(Entities.SalesOrderItem salesOrderItem)
        {
            var salesOrderItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesOrderItem))
                {
                    database.AddInParameter(dbCommand, "@sales_order_item_id", DbType.Int32, salesOrderItem.SalesOrderItemId);
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrderItem.SalesOrderId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesOrderItem.ItemId);
                    database.AddInParameter(dbCommand, "@order_qty", DbType.Decimal, salesOrderItem.OrderQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, salesOrderItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Decimal, salesOrderItem.SaleRate);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesOrderItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesOrderItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesOrderItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesOrderItem.CreatedByIP);
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesOrderItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesOrderItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesOrderItemId;
        }

        private Int32 AddSalesOrderItem(Entities.SalesOrderItem salesOrderItem, DbTransaction transaction)
        {
            var salesOrderItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesOrderItem))
                {
                    database.AddInParameter(dbCommand, "@sales_order_item_id", DbType.Int32, salesOrderItem.SalesOrderItemId);
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrderItem.SalesOrderId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesOrderItem.ItemId);
                    database.AddInParameter(dbCommand, "@order_qty", DbType.Decimal, salesOrderItem.OrderQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, salesOrderItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Decimal, salesOrderItem.SaleRate);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesOrderItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesOrderItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesOrderItem.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesOrderItem.CreatedByIP);
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesOrderItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesOrderItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesOrderItemId;
        }

        private bool DeleteSalesOrderItem(Entities.SalesOrderItem salesOrderItem)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesOrderItem))
                {
                    database.AddInParameter(dbCommand, "@sales_order_item_id", DbType.Int32, salesOrderItem.SalesOrderItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesOrderItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesOrderItem.DeletedByIP);
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

        private bool DeleteSalesOrderItem(Entities.SalesOrderItem salesOrderItem, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesOrderItem))
                {
                    database.AddInParameter(dbCommand, "@sales_order_item_id", DbType.Int32, salesOrderItem.SalesOrderItemId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesOrderItem.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesOrderItem.DeletedByIP);
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

        public List<Entities.SalesOrderItem> GetSalesOrderItemsBySalesOrderId(Int32 salesOrderId)
        {
            var salesOrderItems = new List<Entities.SalesOrderItem>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesOrderItemsBySalesOrderId))
                {
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrderId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesOrderItem = new Entities.SalesOrderItem
                            {
                                SalesOrderItemId = DRE.GetNullableInt32(reader, "sales_order_item_id", null),
                                SalesOrderId = DRE.GetNullableInt32(reader, "sales_order_id", 0),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                OrderQty = DRE.GetNullableDecimal(reader, "order_qty", null),
                                UnitOfMeasurementId = DRE.GetNullableInt32(reader, "unit_of_measurement_id", null),
                                SaleRate = DRE.GetNullableDecimal(reader, "sale_rate", null),
                                GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", null),
                                GSTRate = DRE.GetNullableDecimal(reader, "gst_rate", null),
                                TaxId = DRE.GetNullableInt32(reader, "tax_id", null),
                                Amount = DRE.GetNullableDecimal(reader, "amount", null),
                                GSTAmount = DRE.GetNullableDecimal(reader, "gst_amount", null),
                                TotalItemAmount = DRE.GetNullableDecimal(reader, "total_item_amount", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            salesOrderItems.Add(salesOrderItem);
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

            return salesOrderItems;
        }
        
        private Int32 UpdateSalesOrderItem(Entities.SalesOrderItem salesOrderItem)
        {
            var salesOrderItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesOrderItem))
                {
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrderItem.SalesOrderItemId);
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrderItem.SalesOrderId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesOrderItem.ItemId);
                    database.AddInParameter(dbCommand, "@order_qty", DbType.Decimal, salesOrderItem.OrderQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, salesOrderItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Decimal, salesOrderItem.SaleRate);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesOrderItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesOrderItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesOrderItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesOrderItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesOrderItemId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesOrderItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesOrderItemId;
        }

        private Int32 UpdateSalesOrderItem(Entities.SalesOrderItem salesOrderItem, DbTransaction transaction)
        {
            var salesOrderItemId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesOrderItem))
                {
                    database.AddInParameter(dbCommand, "@sales_order_item_id", DbType.Int32, salesOrderItem.SalesOrderItemId);
                    database.AddInParameter(dbCommand, "@sales_order_id", DbType.Int32, salesOrderItem.SalesOrderId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, salesOrderItem.ItemId);
                    database.AddInParameter(dbCommand, "@order_qty", DbType.Decimal, salesOrderItem.OrderQty);
                    database.AddInParameter(dbCommand, "@unit_of_measurement_id", DbType.Int32, salesOrderItem.UnitOfMeasurementId);
                    database.AddInParameter(dbCommand, "@sale_rate", DbType.Decimal, salesOrderItem.SaleRate);
                    database.AddInParameter(dbCommand, "@tax_id", DbType.Int32, salesOrderItem.TaxId);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, salesOrderItem.GSTRateId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesOrderItem.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesOrderItem.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesOrderItemId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesOrderItemId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesOrderItemId;
        }

        public Int32 SaveSalesOrderItem(Entities.SalesOrderItem salesOrderItem)
        {
            var result = 0;

            if(salesOrderItem.SalesOrderItemId == null || salesOrderItem.SalesOrderItemId == 0)
            {
                result = AddSalesOrderItem(salesOrderItem);
            }
            else if(salesOrderItem.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesOrderItem(salesOrderItem));
            } 
            else if(salesOrderItem.ModifiedBy > 0)
            {
                result = UpdateSalesOrderItem(salesOrderItem);
            }

            return result;
        }

        public Int32 SaveSalesOrderItem(Entities.SalesOrderItem salesOrderItem, DbTransaction transaction)
        {
            var result = 0;

            if (salesOrderItem.SalesOrderItemId == null || salesOrderItem.SalesOrderItemId == 0)
            {
                result = AddSalesOrderItem(salesOrderItem, transaction);
            }
            else if (salesOrderItem.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesOrderItem(salesOrderItem, transaction));
            }
            else if (salesOrderItem.ModifiedBy > 0)
            {
                result = UpdateSalesOrderItem(salesOrderItem, transaction);
            }

            return result;
        }
    }
}
