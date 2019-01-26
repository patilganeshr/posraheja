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
    public class PurchaseBillRegister
    {
        private readonly Database database;

        public PurchaseBillRegister()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegister()
        {
            var purchaseBillsRegister = new List<Entities.PurchaseBillRegister>();


            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillRegisterComplete))
                {
                    using(IDataReader reader  = database.ExecuteReader(dbCommand))
                    {
                        purchaseBillsRegister = GetData(reader);
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

            return purchaseBillsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            var purchaseBillsRegister = new List<Entities.PurchaseBillRegister>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillRegisterByWorkingPeriod))
                {
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        purchaseBillsRegister = GetData(reader);
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

            return purchaseBillsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByVendor(Int32 vendorId)
        {
            var purchaseBillsRegister = new List<Entities.PurchaseBillRegister>();
            
            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillRegisterByVendor))
                {
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        purchaseBillsRegister = GetData(reader);
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

            return purchaseBillsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillRegister"></param>
        /// <returns></returns>
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByPeriod(Entities.PurchaseBillRegister purchaseBillRegister)
        {
            var purchaseBillsRegister = new List<Entities.PurchaseBillRegister>();
            
            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillRegisterByPeriod))
                {
                    database.AddInParameter(dbCommand, "@from_date", DbType.String, purchaseBillRegister.FromDate);
                    database.AddInParameter(dbCommand, "@to_date", DbType.String, purchaseBillRegister.ToDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        purchaseBillsRegister = GetData(reader);
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

            return purchaseBillsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByWorkingPeriodAndVendor(Int32 workingPeriodId, Int32 vendorId)
        {
            var purchaseBillsRegister = new List<Entities.PurchaseBillRegister>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillRegisterByWorkingPeriodAndVendor))
                {
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        purchaseBillsRegister = GetData(reader);
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

            return purchaseBillsRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public List<Entities.PurchaseBillRegister> GetPurchaseBillRegisterByVendorAndFromToDate(Int32 vendorId, string fromDate, string toDate)
        {
            var purchaseBillsRegister = new List<Entities.PurchaseBillRegister>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetPurchaseBillRegisterByVendorAndFromToDate))
                {
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);
                    database.AddInParameter(dbCommand, "@from_date", DbType.String, fromDate);
                    database.AddInParameter(dbCommand, "@to_date", DbType.String, toDate);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        purchaseBillsRegister = GetData(reader);
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

            return purchaseBillsRegister;
        }

        private List<Entities.PurchaseBillRegister> GetData(IDataReader reader)
        {
            var purchaseBillsRegister = new List<Entities.PurchaseBillRegister>();

            while (reader.Read())
            {
                var purchaseBillRegister = new Entities.PurchaseBillRegister
                {
                    PurchaseBillDate = DRE.GetNullableString(reader, "purchase_bill_date", null),
                    PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                    VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                    LRNo = DRE.GetNullableString(reader, "lr_no", null),
                    TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                    ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                    ItemName = DRE.GetNullableString(reader, "item_name", null),
                    PurchaseQty = DRE.GetNullableDecimal(reader, "purchase_qty", null),
                    UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                    PurchaseRate = DRE.GetNullableDecimal(reader,  "purchase_rate", null),
                    AddLess = DRE.GetNullableDecimal(reader, "add_less", null),
                    TaxableValue = DRE.GetNullableDecimal(reader, "taxable_value", null),
                    GSTAmount = DRE.GetNullableDecimal(reader, "gst_amount", null),
                    TotalAmount = DRE.GetNullableDecimal(reader, "total_amount", null),
                    GoodsReceiptDate = DRE.GetNullableString(reader, "goods_receipt_date", null)
                };

                purchaseBillsRegister.Add(purchaseBillRegister);
            }

            return purchaseBillsRegister;
        }
    }
}
