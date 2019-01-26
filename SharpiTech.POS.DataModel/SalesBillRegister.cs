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
    public class SalesBillRegister
    {
        private readonly Database database;

        public SalesBillRegister()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.SalesBillRegister> GetSalesBillRegister()
        {
            var salesBillsRegister = new List<Entities.SalesBillRegister>();


            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillRegisterComplete))
                {
                    using(IDataReader reader  = database.ExecuteReader(dbCommand))
                    {
                        salesBillsRegister = GetData(reader);
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

            return salesBillsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            var salesBillsRegister = new List<Entities.SalesBillRegister>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillRegisterByWorkingPeriod))
                {
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        salesBillsRegister = GetData(reader);
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

            return salesBillsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByCustomer(Int32 customerId)
        {
            var salesBillsRegister = new List<Entities.SalesBillRegister>();
            
            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillRegisterByCustomer))
                {
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, customerId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        salesBillsRegister = GetData(reader);
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

            return salesBillsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillRegister"></param>
        /// <returns></returns>
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByFromToDate(Entities.SalesBillRegister salesBillRegister)
        {
            var salesBillsRegister = new List<Entities.SalesBillRegister>();
            
            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillRegisterByFromToDate))
                {
                    database.AddInParameter(dbCommand, "@from_date", DbType.String, salesBillRegister.FromDate);
                    database.AddInParameter(dbCommand, "@to_date", DbType.String, salesBillRegister.ToDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        salesBillsRegister = GetData(reader);
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

            return salesBillsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByCustomerAndWorkingPeriodId(Int32 customerId, Int32 workingPeriodId)
        {
            var salesBillsRegister = new List<Entities.SalesBillRegister>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillRegisterByCustomerAndWorkingPeriod))
                {
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, customerId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);                    

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        salesBillsRegister = GetData(reader);
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

            return salesBillsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillRegister"></param>
        /// <returns></returns>
        public List<Entities.SalesBillRegister> GetSalesBillRegisterByCustomerAndFromToDate(Entities.SalesBillRegister salesBillRegister)
        {
            var salesBillsRegister = new List<Entities.SalesBillRegister>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillRegisterByCustomerAndFromToDate))
                {
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, salesBillRegister.CustomerId);
                    database.AddInParameter(dbCommand, "@from_date", DbType.String, salesBillRegister.FromDate);
                    database.AddInParameter(dbCommand, "@to_date", DbType.String, salesBillRegister.ToDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        salesBillsRegister = GetData(reader);
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

            return salesBillsRegister;
        }

        private List<Entities.SalesBillRegister> GetData(IDataReader reader)
        {
            var salesBillsRegister = new List<Entities.SalesBillRegister>();

            while (reader.Read())
            {
                var SalesBillRegister = new Entities.SalesBillRegister
                {
                    SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", null),
                    SalesBillNo = DRE.GetNullableInt32(reader, "sales_bill_no", null),
                    SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),                    
                    CustomerName = DRE.GetNullableString(reader, "customer_name", null),
                    LRNo = DRE.GetNullableString(reader, "lr_no", null),
                    TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                    TaxableValue = DRE.GetNullableDecimal(reader, "taxable_value", null),
                    GSTAmount = DRE.GetNullableDecimal(reader, "gst_amount", null),
                    TotalItemAmount = DRE.GetNullableDecimal(reader, "total_item_amount", null),
                    RoundOffAmount = DRE.GetNullableDecimal(reader, "round_off_amount", null)
                };

                salesBillsRegister.Add(SalesBillRegister);
            }

            return salesBillsRegister;
        }
    }
}
