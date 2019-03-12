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
    public class ItemRateRegister
    {
        private readonly Database database;

        public ItemRateRegister()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.ItemRateRegister> GetItemRateRegister()
        {
            var itemRatesRegister = new List<Entities.ItemRateRegister>();
            
            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRateRegisterComplete))
                {
                    using(IDataReader reader  = database.ExecuteReader(dbCommand))
                    {
                        itemRatesRegister = GetData(reader);
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

            return itemRatesRegister;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        public List<Entities.ItemRateRegister> GetItemRateRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            var itemRatesRegister = new List<Entities.ItemRateRegister>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRateRegisterComplete))
                {
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        itemRatesRegister = GetData(reader);
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

            return itemRatesRegister;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vendorId"></param>
        ///// <returns></returns>
        //public List<Entities.ItemRateRegister> GetItemRateRegisterByVendor(Int32 vendorId)
        //{
        //    var itemRatesRegister = new List<Entities.ItemRateRegister>();
            
        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRateRegisterByVendor))
        //        {
        //            database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);

        //            using (IDataReader reader = database.ExecuteReader(dbCommand))
        //            {
        //                itemRatesRegister = GetData(reader);
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

        //    return itemRatesRegister;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ItemRateRegister"></param>
        ///// <returns></returns>
        //public List<Entities.ItemRateRegister> GetItemRateRegisterByPeriod(Entities.ItemRateRegister ItemRateRegister)
        //{
        //    var itemRatesRegister = new List<Entities.ItemRateRegister>();
            
        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRateRegisterByPeriod))
        //        {
        //            database.AddInParameter(dbCommand, "@from_date", DbType.String, ItemRateRegister.FromDate);
        //            database.AddInParameter(dbCommand, "@to_date", DbType.String, ItemRateRegister.ToDate);

        //            using (IDataReader reader = database.ExecuteReader(dbCommand))
        //            {
        //                itemRatesRegister = GetData(reader);
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

        //    return itemRatesRegister;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vendorId"></param>
        ///// <param name="workingPeriodId"></param>
        ///// <returns></returns>
        //public List<Entities.ItemRateRegister> GetItemRateRegisterByWorkingPeriodAndVendor(Int32 workingPeriodId, Int32 vendorId)
        //{
        //    var itemRatesRegister = new List<Entities.ItemRateRegister>();

        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRateRegisterByWorkingPeriodAndVendor))
        //        {
        //            database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, workingPeriodId);
        //            database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);

        //            using (IDataReader reader = database.ExecuteReader(dbCommand))
        //            {
        //                itemRatesRegister = GetData(reader);
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

        //    return itemRatesRegister;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="vendorId"></param>
        ///// <returns></returns>
        //public List<Entities.ItemRateRegister> GetItemRateRegisterByVendorAndFromToDate(Int32 vendorId, string fromDate, string toDate)
        //{
        //    var itemRatesRegister = new List<Entities.ItemRateRegister>();

        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRateRegisterByVendorAndFromToDate))
        //        {
        //            database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);
        //            database.AddInParameter(dbCommand, "@from_date", DbType.String, fromDate);
        //            database.AddInParameter(dbCommand, "@to_date", DbType.String, toDate);

        //            using (IDataReader reader = database.ExecuteReader(dbCommand))
        //            {
        //                itemRatesRegister = GetData(reader);
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

        //    return itemRatesRegister;
        //}

        private List<Entities.ItemRateRegister> GetData(IDataReader reader)
        {
            var itemRatesRegister = new List<Entities.ItemRateRegister>();

            while (reader.Read())
            {
                var ItemRateRegister = new Entities.ItemRateRegister
                {
                    ItemCode = DRE.GetNullableString(reader, "item_code", null),
                    ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                    BrandName = DRE.GetNullableString(reader, "brand_name", null),
                    ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                    ItemName = DRE.GetNullableString(reader, "item_name", null),
                    PurchaseRate = DRE.GetNullableDecimal(reader, "purchase_rate", null),
                    TotalExps= DRE.GetNullableDecimal(reader, "total_exps", null),
                    WholesaleRate = DRE.GetNullableDecimal(reader, "w_rate", null),
                    RetailRate = DRE.GetNullableDecimal(reader, "r_rate", null),
                    RateEffectiveFromDate = DRE.GetNullableString(reader, "rate_effective_from_date", null)
                };

                itemRatesRegister.Add(ItemRateRegister);
            }

            return itemRatesRegister;
        }

        public List<Entities.ItemMargin> GetItemMarginByCategorywiseQualitywiseCostwise()
        {
            var itemwiseMarginList = new List<Entities.ItemMargin>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemMarginReportByCategorywiseQualitywiseCostwise))
                {

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {

                            var itemMargin = new Entities.ItemMargin()
                            {
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                PurchaseRate = DRE.GetNullableDecimal(reader, "purchase_rate", null),
                                LandingCost = DRE.GetNullableDecimal(reader, "landing_cost", null),
                                WholesaleRate = DRE.GetNullableDecimal(reader, "wholesale_rate", null),
                                RetailRate = DRE.GetNullableDecimal(reader, "retail_rate", null),
                                Margin = DRE.GetNullableDecimal(reader, "margin", null)
                            };

                            itemwiseMarginList.Add(itemMargin);
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

            return itemwiseMarginList;

        }
    }
}
