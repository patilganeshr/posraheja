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
    public class SalesReturnBillAdjustment
    {
        private readonly Database database;

        public SalesReturnBillAdjustment()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddSalesReturnBillAdjustment(Entities.SalesReturnBillAdjustment salesReturnBillAdjustment)
        {
            var salesReturnBillAdjustmentId = 0;

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesReturnBillAdjustment))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_adjustment_id", DbType.Int32, salesReturnBillAdjustment.SalesReturnBillAdjustmentId);
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBillAdjustment.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesReturnBillAdjustment.SalesBillId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesReturnBillAdjustment.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesReturnBillAdjustment.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillAdjustmentId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillAdjustmentId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand = null;
            }

            return salesReturnBillAdjustmentId;
        }

        private Int32 AddSalesReturnBillAdjustment(Entities.SalesReturnBillAdjustment salesReturnBillAdjustment, DbTransaction transaction)
        {
            var salesReturnBillAdjustmentId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesReturnBillAdjustment))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_adjustment_id", DbType.Int32, salesReturnBillAdjustment.SalesReturnBillAdjustmentId);
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBillAdjustment.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesReturnBillAdjustment.SalesBillId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesReturnBillAdjustment.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesReturnBillAdjustment.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillAdjustmentId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillAdjustmentId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesReturnBillAdjustmentId;
        }

        private bool DeleteSalesReturnBillAdjustment(Entities.SalesReturnBillAdjustment salesReturnBillAdjustment)
        {
            var IsRecordDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesReturnBillAdjustment))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_adjustment_id", DbType.Int32, salesReturnBillAdjustment.SalesReturnBillAdjustmentId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesReturnBillAdjustment.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesReturnBillAdjustment.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

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

        private bool DeleteSalesReturnBillAdjustment(Entities.SalesReturnBillAdjustment salesReturnBillAdjustment, DbTransaction transaction)
        {
            var IsRecordDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesReturnBillAdjustment))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_adjustment_id", DbType.Int32, salesReturnBillAdjustment.SalesReturnBillAdjustmentId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesReturnBillAdjustment.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesReturnBillAdjustment.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

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

        public List<Entities.SalesReturnBillAdjustment> GetSalesReturnBillAdjustmentBySalesReturnBillId(Int32 salesReturnBillId)
        {
            var salesReturnBillAdjustments = new List<Entities.SalesReturnBillAdjustment>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesReturnBillAdjustmentBySalesBillReturnId))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesReturnBillAdjustment = new Entities.SalesReturnBillAdjustment()
                            {
                                SalesReturnBillAdjustmentId = DRE.GetNullableInt32(reader, "sales_return_bill_adjustment_id", null),
                                SalesReturnBillId = DRE.GetNullableInt32(reader, "sales_return_bill_id", null),
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", null),
                                SalesBillNo = DRE.GetNullableString(reader, "sales_bill_no", null),
                                SalesBillTotalAmount = DRE.GetNullableDecimal(reader, "sales_bill_total_amount", null)                                
                            };

                            salesReturnBillAdjustments.Add(salesReturnBillAdjustment);
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

            return salesReturnBillAdjustments;

        }

        private Int32 UpdateSalesReturnBillAdjustment(Entities.SalesReturnBillAdjustment salesReturnBillAdjustment)
        {
            var salesReturnBillAdjustmentId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesReturnBillAdjustment))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_adjustment_id", DbType.Int32, salesReturnBillAdjustment.SalesReturnBillAdjustmentId);
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBillAdjustment.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesReturnBillAdjustment.SalesBillId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesReturnBillAdjustment.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesReturnBillAdjustment.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillAdjustmentId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillAdjustmentId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesReturnBillAdjustmentId;
        }

        private Int32 UpdateSalesReturnBillAdjustment(Entities.SalesReturnBillAdjustment salesReturnBillAdjustment, DbTransaction transaction)
        {
            var salesReturnBillAdjustmentId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesReturnBillAdjustment))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_adjustment_id", DbType.Int32, salesReturnBillAdjustment.SalesReturnBillAdjustmentId);
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBillAdjustment.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesReturnBillAdjustment.SalesBillId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesReturnBillAdjustment.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesReturnBillAdjustment.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillAdjustmentId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillAdjustmentId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesReturnBillAdjustmentId;
        }

        public Int32 SaveSalesReturnBillAdjustment(Entities.SalesReturnBillAdjustment salesReturnBillAdjustment, DbTransaction transaction)
        {
            var result = 0;

            if (salesReturnBillAdjustment.SalesReturnBillAdjustmentId == null || salesReturnBillAdjustment.SalesReturnBillAdjustmentId == 0)
            {
                result = AddSalesReturnBillAdjustment(salesReturnBillAdjustment, transaction);
            }
            else if (salesReturnBillAdjustment.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesReturnBillAdjustment(salesReturnBillAdjustment, transaction));

                if (result == 1)
                {
                    result = Convert.ToInt32(salesReturnBillAdjustment.SalesReturnBillAdjustmentId);
                }
            }
            else if (salesReturnBillAdjustment.ModifiedBy > 0)
            {
                result = UpdateSalesReturnBillAdjustment(salesReturnBillAdjustment, transaction);
            }

            return result;
        }
    }
}
