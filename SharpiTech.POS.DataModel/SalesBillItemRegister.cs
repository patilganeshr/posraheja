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
    public class SalesBillItemRegister
    {
        private readonly Database database;

        public SalesBillItemRegister()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegister()
        {
            var salesBillItemsRegister = new List<Entities.SalesBillItemRegister>();


            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillItemsRegisterComplete))
                {
                    using(IDataReader reader  = database.ExecuteReader(dbCommand))
                    {
                        salesBillItemsRegister = GetData(reader);
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

            return salesBillItemsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            var salesBillItemsRegister = new List<Entities.SalesBillItemRegister>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillItemsRegisterByWorkingPeriod))
                {
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        salesBillItemsRegister = GetData(reader);
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

            return salesBillItemsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByCustomer(Int32 customerId)
        {
            var salesBillItemsRegister = new List<Entities.SalesBillItemRegister>();
            
            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillItemsRegisterByCustomer))
                {
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, customerId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        salesBillItemsRegister = GetData(reader);
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

            return salesBillItemsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillItemRegister"></param>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByFromToDate(Entities.SalesBillItemRegister salesBillItemRegister)
        {
            var salesBillItemsRegister = new List<Entities.SalesBillItemRegister>();
            
            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillItemsRegisterByFromToDate))
                {
                    database.AddInParameter(dbCommand, "@from_date", DbType.String, salesBillItemRegister.FromDate);
                    database.AddInParameter(dbCommand, "@to_date", DbType.String, salesBillItemRegister.ToDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        salesBillItemsRegister = GetData(reader);
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

            return salesBillItemsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>        
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByCustomerAndWorkingPeriodId(Int32 customerId, Int32 workingPeriodId)
        {
            var salesBillItemsRegister = new List<Entities.SalesBillItemRegister>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillItemsRegisterByCustomerAndWorkingPeriod))
                {
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, customerId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        salesBillItemsRegister = GetData(reader);
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

            return salesBillItemsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesBillItemRegister"></param>
        /// <returns></returns>
        public List<Entities.SalesBillItemRegister> GetSalesBillItemRegisterByCustomerAndFromToDate(Entities.SalesBillItemRegister salesBillItemRegister)
        {
            var salesBillItemsRegister = new List<Entities.SalesBillItemRegister>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillItemsRegisterByCustomerAndFromToDate))
                {
                    database.AddInParameter(dbCommand, "@customer_id", DbType.Int32, salesBillItemRegister.CustomerId);
                    database.AddInParameter(dbCommand, "@from_date", DbType.String, salesBillItemRegister.FromDate);
                    database.AddInParameter(dbCommand, "@to_date", DbType.String, salesBillItemRegister.ToDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        salesBillItemsRegister = GetData(reader);
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

            return salesBillItemsRegister;
        }

        private List<Entities.SalesBillItemRegister> GetData(IDataReader reader)
        {
            var salesBillItemsRegister = new List<Entities.SalesBillItemRegister>();

            while (reader.Read())
            {
                var SalesBillItemRegister = new Entities.SalesBillItemRegister()
                {
                    SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", null),
                    SalesBillNo = DRE.GetNullableInt32(reader, "sales_bill_no", null),
                    SalesBillDate = DRE.GetNullableString(reader, "sales_bill_date", null),                    
                    CustomerName = DRE.GetNullableString(reader, "customer_name", null),
                    LRNo = DRE.GetNullableString(reader, "lr_no", null),
                    TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                    ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                    ItemName = DRE.GetNullableString(reader, "item_name", null),
                    SaleQty = DRE.GetNullableDecimal(reader, "sale_qty", null),
                    UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                    TaxableValue = DRE.GetNullableDecimal(reader, "taxable_value", null),
                    GSTAmount = DRE.GetNullableDecimal(reader, "gst_amount", null),
                    TotalItemAmount = DRE.GetNullableDecimal(reader, "total_item_amount", null),
                    RoundOffAmount = DRE.GetNullableDecimal(reader, "round_off_amount", null)
                };

                salesBillItemsRegister.Add(SalesBillItemRegister);
            }

            return salesBillItemsRegister;
        }
    }
}
