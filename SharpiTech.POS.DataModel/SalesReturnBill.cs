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
using System.IO;

namespace SharpiTech.POS.DataModel
{
    public class SalesReturnBill
    {
        private readonly Database database;

        public SalesReturnBill()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBill"></param>
        /// <returns></returns>
        private Int32 AddSalesReturnBill(Entities.SalesReturnBill salesReturnBill)
        {
            var salesReturnBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesReturnBill))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBill.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@consignee_id", DbType.Int32, salesReturnBill.ConsigneeId);
                    database.AddInParameter(dbCommand, "@sales_return_bill_no", DbType.Int32, salesReturnBill.SalesReturnBillNo);
                    database.AddInParameter(dbCommand, "@sales_return_bill_date", DbType.String, salesReturnBill.SalesReturnBillDate);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesReturnBill.Remarks);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesReturnBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesReturnBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, salesReturnBill.SaleTypeId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesReturnBill.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesReturnBill.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesReturnBillId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBill"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddSalesReturnBill(Entities.SalesReturnBill salesReturnBill, DbTransaction transaction)
        {
            var salesReturnBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesReturnBill))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBill.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@consignee_id", DbType.Int32, salesReturnBill.ConsigneeId);
                    database.AddInParameter(dbCommand, "@sales_return_bill_no", DbType.Int32, salesReturnBill.SalesReturnBillNo);
                    database.AddInParameter(dbCommand, "@sales_return_bill_date", DbType.String, salesReturnBill.SalesReturnBillDate);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesReturnBill.Remarks);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesReturnBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesReturnBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, salesReturnBill.SaleTypeId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, salesReturnBill.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, salesReturnBill.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //FileStream objFilestream = new FileStream(string.Format("{0}\\{1}", @"E:\WWWRoot", "POSLOG"), FileMode.Append, FileAccess.Write);
                //StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
                //objStreamWriter.WriteLine(ex.Message.ToString() + ' ' + ex.StackTrace);
                //objStreamWriter.Close();
                //objFilestream.Close();

            }
            finally
            {
                dbCommand = null;
            }

            return salesReturnBillId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBill"></param>
        /// <returns></returns>
        private bool DeleteSalesReturnBill(Entities.SalesReturnBill salesReturnBill)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesReturnBill))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBill.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesReturnBill.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesReturnBill.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return isDeleted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBill"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool DeleteSalesReturnBill(Entities.SalesReturnBill salesReturnBill, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesReturnBill))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBill.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, salesReturnBill.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, salesReturnBill.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return isDeleted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBill"></param>
        /// <returns></returns>
        private Int32 UpdateSalesReturnBill(Entities.SalesReturnBill salesReturnBill)
        {
            var salesReturnBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesReturnBill))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBill.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@sales_return_bill_no", DbType.Int32, salesReturnBill.SalesReturnBillNo);
                    database.AddInParameter(dbCommand, "@sales_return_bill_date", DbType.String, salesReturnBill.SalesReturnBillDate);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesReturnBill.Remarks);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesReturnBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesReturnBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, salesReturnBill.SaleTypeId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesReturnBill.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesReturnBill.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesReturnBillId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBill"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdateSalesReturnBill(Entities.SalesReturnBill salesReturnBill, DbTransaction transaction)
        {
            var salesReturnBillId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesReturnBill))
                {
                    database.AddInParameter(dbCommand, "@sales_return_bill_id", DbType.Int32, salesReturnBill.SalesReturnBillId);
                    database.AddInParameter(dbCommand, "@sales_return_bill_no", DbType.Int32, salesReturnBill.SalesReturnBillNo);
                    database.AddInParameter(dbCommand, "@sales_return_bill_date", DbType.String, salesReturnBill.SalesReturnBillDate);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, salesReturnBill.Remarks);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesReturnBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesReturnBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, salesReturnBill.SaleTypeId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, salesReturnBill.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, salesReturnBill.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesReturnBillId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesReturnBillId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesReturnBillId;
        }

        public bool CheckSalesReturnBillNoIsExists(Entities.SalesReturnBill salesReturnBill)
        {
            bool isBillNoExists = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckSalesReturnBillNoIsExists))
                {
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesReturnBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesReturnBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, salesReturnBill.SaleTypeId);
                    database.AddInParameter(dbCommand, "@sales_return_bill_no", DbType.Int32, salesReturnBill.SalesReturnBillNo);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            isBillNoExists = DRE.GetBoolean(reader, "is_bill_no_exists");
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

            return isBillNoExists;
        }

        public Entities.SalesReturnBill GetSalesBillAdditionalDetails(Entities.SalesReturnBill salesReturnBill)
        {
            var salesBillDetails = new Entities.SalesReturnBill();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillAdditaionalDetails))
                {
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesReturnBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesReturnBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, salesReturnBill.SaleTypeId);
                    database.AddInParameter(dbCommand, "@sales_bill_no", DbType.Int32, salesReturnBill.SalesBillNo);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesBill = new Entities.SalesReturnBill
                            {
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", null),
                                SalesBillNo = DRE.GetNullableInt32(reader, "sales_bill_no", null),
                                SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),
                                CustomerName = DRE.GetNullableString(reader, "customer_name", null),
                                ConsigneeName = DRE.GetNullableString(reader, "consignee_name", null),
                                IsTaxInclusive = DRE.GetNullableBoolean(reader, "is_tax_inclusive", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null)
                            };

                            salesBillDetails = salesBill;
                        }
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

            return salesBillDetails;

        }

        public List<Entities.SalesReturnBill> GetAllSalesReturnBills()
        {
            var salesReturnBills = new List<Entities.SalesReturnBill>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllSalesReturnBills))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            SalesReturnBillItem salesReturnBillItem = new SalesReturnBillItem();

                            var salesReturnBill = new Entities.SalesReturnBill
                            {
                                SalesReturnBillId = DRE.GetNullableInt32(reader, "sales_return_bill_id", 0),
                                SalesReturnBillNo = DRE.GetNullableInt32(reader, "sales_return_bill_no", 0),
                                SalesReturnBillDate = DRE.GetNullableString(reader, "sales_return_bill_date", null),
                                ConsigneeId = DRE.GetNullableInt32(reader, "consignee_id", null),
                                ConsigneeName = DRE.GetNullableString(reader, "consignee_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                SaleTypeId = DRE.GetNullableInt32(reader, "sale_type_id", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                TotalReturnQty = DRE.GetNullableDecimal(reader, "total_return_qty", null),
                                SalesReturnTotalAmount = DRE.GetNullableDecimal(reader, "sales_return_total_amount", null),
                                SalesReturnBillItems = salesReturnBillItem.GetSalesReturnBillItemsBySalesReturnBillId(reader.GetInt32(reader.GetOrdinal("sales_return_bill_id"))) 
                            };

                            salesReturnBills.Add(salesReturnBill);
                        }
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

            return salesReturnBills;
        }

        public List<Entities.SalesReturnBill> GetSalesReturnBillsBySalesType(Int32 salesTypeId)
        {
            var salesReturnBills = new List<Entities.SalesReturnBill>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesReturnBillsBySalesType))
                {
                    database.AddInParameter(dbCommand, "@sales_type_id", DbType.Int32, salesTypeId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            SalesReturnBillItem salesReturnBillItem = new SalesReturnBillItem();

                            var salesReturnBill = new Entities.SalesReturnBill
                            {
                                SalesReturnBillId = DRE.GetNullableInt32(reader, "sales_return_bill_id", 0),
                                SalesReturnBillNo = DRE.GetNullableInt32(reader, "sales_return_bill_no", 0),
                                SalesReturnBillDate = DRE.GetNullableString(reader, "sales_return_bill_date", null),
                                ConsigneeId = DRE.GetNullableInt32(reader, "consignee_id", null),
                                ConsigneeName = DRE.GetNullableString(reader, "consignee_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                SaleTypeId = DRE.GetNullableInt32(reader, "sale_type_id", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                TotalReturnQty = DRE.GetNullableDecimal(reader, "total_return_qty", null),
                                SalesReturnTotalAmount = DRE.GetNullableDecimal(reader, "sales_return_total_amount", null),
                                SalesReturnBillItems = salesReturnBillItem.GetSalesReturnBillItemsBySalesReturnBillId(reader.GetInt32(reader.GetOrdinal("sales_return_bill_id")))
                            };

                            salesReturnBills.Add(salesReturnBill);
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

            return salesReturnBills;
        }

        public List<Entities.SalesReturnBill> GetSalesReturnBillsByBranchWorkingPeriodAndSalesType(Int32 branchId, Int32 workingPeriodId, Int32 salesTypeId)
        {
            var salesReturnBills = new List<Entities.SalesReturnBill>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesReturnBillsByBranchWorkingPeriodAndSalesType))
                {
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, branchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);
                    database.AddInParameter(dbCommand, "@sales_type_id", DbType.Int32, salesTypeId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            SalesReturnBillItem salesReturnBillItem = new SalesReturnBillItem();
                            SalesReturnBillAdjustment salesReturnBillAdjustment = new SalesReturnBillAdjustment();
                            
                            var salesReturnBill = new Entities.SalesReturnBill
                            {
                                SalesReturnBillId = DRE.GetNullableInt32(reader, "sales_return_bill_id", 0),
                                SalesReturnBillNo = DRE.GetNullableInt32(reader, "sales_return_bill_no", 0),
                                SalesReturnBillDate = DRE.GetNullableString(reader, "sales_return_bill_date", null),
                                ConsigneeId = DRE.GetNullableInt32(reader, "consignee_id", null),
                                ConsigneeName = DRE.GetNullableString(reader, "consignee_name", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                CompanyName = DRE.GetNullableString(reader, "company_name", null),
                                CompanyId = DRE.GetNullableInt32(reader, "company_id",null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader,"working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                IsDeleted = DRE.GetNullableBoolean(reader, "is_deleted", null),
                                SaleType = DRE.GetNullableString(reader, "sale_type", null),
                                SaleTypeId = DRE.GetNullableInt32(reader, "sale_type_id", null),
                                TotalReturnQty = DRE.GetNullableDecimal(reader, "total_return_qty", null),
                                SalesReturnTotalAmount = DRE.GetNullableDecimal(reader, "sales_return_total_amount", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                SalesReturnBillItems = salesReturnBillItem.GetSalesReturnBillItemsBySalesReturnBillId(reader.GetInt32(reader.GetOrdinal("sales_return_bill_id"))),
                                SalesReturnBillAdjustments = salesReturnBillAdjustment.GetSalesReturnBillAdjustmentBySalesReturnBillId(reader.GetInt32(reader.GetOrdinal("sales_return_bill_id")))
                            };

                            salesReturnBills.Add(salesReturnBill);
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

            return salesReturnBills;
        }
        
        public List<Entities.ClientAddress> GetConsigneeFromSalesBills(Entities.SalesReturnBill salesReturnBill)
        {
            var consignees = new List<Entities.ClientAddress>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetConsigneeFromSalesBills))
                {
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, salesReturnBill.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, salesReturnBill.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@sale_type_id", DbType.Int32, salesReturnBill.SaleTypeId);

                    using(IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var consignee = new Entities.ClientAddress()
                            {
                                ClientAddressId = DRE.GetNullableInt32(reader, "client_address_id", null),
                                ClientAddressName = DRE.GetNullableString(reader, "client_address_name", null)
                            };

                            consignees.Add(consignee);
                        }
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

            return consignees;
        }

        public List<Entities.SalesReturnBill> GetSalesBillsByConsignee(Int32 consigneeId)
        {
            var salesBills = new List<Entities.SalesReturnBill>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillsByConsignee))
                {
                    database.AddInParameter(dbCommand, "@consignee_id", DbType.Int32, consigneeId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var salesBill = new Entities.SalesReturnBill()
                            {
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", null),
                                SalesBillNoCustom = DRE.GetNullableString(reader, "sales_bill_no", null),
                                SalesBillTotalAmount = DRE.GetNullableDecimal(reader, "sales_bill_total_amount", null)
                            };

                            salesBills.Add(salesBill);
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

            return salesBills;
        }

        public Int32 SaveSalesReturnBill(Entities.SalesReturnBill salesReturnBill)
        {
            var salesReturnBillId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var salesReturnBillItemID = 0;
                        var salesReturnBillAdjustmentId = 0;

                        if (salesReturnBill != null)
                        {
                            if (salesReturnBill.SalesReturnBillId == null || salesReturnBill.SalesReturnBillId == 0)
                            {
                                salesReturnBillId = AddSalesReturnBill(salesReturnBill, transaction);
                            }
                            else
                            {
                                if (salesReturnBill.IsDeleted == true)
                                {
                                    var result = DeleteSalesReturnBill(salesReturnBill, transaction);

                                    salesReturnBillId = Convert.ToInt32(salesReturnBill.SalesReturnBillId);
                                }
                                else
                                {
                                    if (salesReturnBill.ModifiedBy > 0 || salesReturnBill.ModifiedBy != null)
                                    {
                                        salesReturnBillId = UpdateSalesReturnBill(salesReturnBill, transaction);

                                        // If records failed to save
                                        if (salesReturnBillId < 0)
                                        {
                                            salesReturnBillId = -1;
                                        }
                                    }
                                }
                            }

                            if (salesReturnBillId > 0)
                            {
                                // Save sales bill return items
                                foreach (Entities.SalesReturnBillItem salesReturnBillItem in salesReturnBill.SalesReturnBillItems)
                                {
                                    salesReturnBillItem.SalesReturnBillId = salesReturnBillId;

                                    SalesReturnBillItem salesReturnBillItemDL = new SalesReturnBillItem();

                                    salesReturnBillItemID = salesReturnBillItemDL.SaveSalesBillReturnItem(salesReturnBillItem, transaction);

                                    // If records failed to save
                                    if (salesReturnBillItemID < 0)
                                    {
                                        salesReturnBillId = -1;
                                    }

                                }
                            }

                            if (salesReturnBillId > 0)
                            {
                                if (salesReturnBill.SalesReturnBillAdjustments != null)
                                {

                                    // Save sales bill return adjustment
                                    foreach (Entities.SalesReturnBillAdjustment salesReturnBillAdjustment in salesReturnBill.SalesReturnBillAdjustments)
                                    {
                                        salesReturnBillAdjustment.SalesReturnBillId = salesReturnBillId;

                                        SalesReturnBillAdjustment salesReturnBillAdjustmentDL = new SalesReturnBillAdjustment();

                                        salesReturnBillAdjustmentId = salesReturnBillAdjustmentDL.SaveSalesReturnBillAdjustment(salesReturnBillAdjustment, transaction);

                                        // If records failed to save
                                        if (salesReturnBillAdjustmentId < 0)
                                        {
                                            salesReturnBillId = -1;
                                        }

                                    }
                                }
                            }
                        }

                        if (salesReturnBillId > 0)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
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

            return salesReturnBillId;
        }
    }
}
