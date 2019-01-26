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
    public class StockReport
    {
        private readonly Database database;

        public StockReport()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// Get Stock as On Date
        /// </summary>
        /// <returns>Will return a list of Stock Report.</returns>
        public List<Entities.StockReport> GetStockAsOnDate()
        {
            var stockList = new List<Entities.StockReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockReportAsOnDate))
                {

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stockReport = new Entities.StockReport
                            {
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                BrandName = DRE.GetNullableString(reader, "brand_name", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                QtyInPcs = DRE.GetNullableDecimal(reader, "qty_in_pcs", 0),
                                QtyInMtrs= DRE.GetNullableDecimal(reader, "qty_in_mtrs", 0),
                                LocationName = DRE.GetNullableString(reader, "location_name", null),
                                CategoryA = DRE.GetNullableDecimal(reader, "category_a", null),
                                CategoryC = DRE.GetNullableDecimal(reader, "category_c", null)
                            };

                            stockList.Add(stockReport);
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

            return stockList;
        }

        /// <summary>
        /// Get Stock As on Date by Item wise with Purchase Cost
        /// </summary>
        /// <returns>Will return a list of Stock Report.</returns>
        public List<Entities.StockReport> GetStockAsOnDateByItemwiseWithPurchaseCost()
        {
            var stockList = new List<Entities.StockReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockReportAsOnDateByItemWiseWithPurchaseCost))
                {

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stockReport = new Entities.StockReport
                            {
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                StockQty = DRE.GetNullableDecimal(reader, "stock_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                PurchaseCost = DRE.GetNullableDecimal(reader, "purchase_cost", null)
                            };

                            stockList.Add(stockReport);
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

            return stockList;
        }

        /// <summary>
        /// Get Stock Report as on date
        /// </summary>
        /// <returns>Will return a list of Stock Report.</returns>
        public List<Entities.StockReport> GetStockOfAllItems()
        {
            var stocks = new List<Entities.StockReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockAsOnDate))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stock = new Entities.StockReport()
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                StockQty = DRE.GetNullableDecimal(reader, "stock_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null)
                            };

                            stocks.Add(stock);
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

            return stocks;
        }

        /// <summary>
        /// Get Stock Report By Item Id
        /// </summary>
        /// <param name="itemId">Required an integer value as Item Id</param>
        /// <returns>Will return a list of Stock Report.</returns>
        public List<Entities.StockReport> GetStockByItemId(Int32 itemId)
        {
            var stocks = new List<Entities.StockReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockByItemId))
                {
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stock = new Entities.StockReport()
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                StockQty = DRE.GetNullableDecimal(reader, "stock_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null)
                            };

                            stocks.Add(stock);
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

            return stocks;
        }

        /// <summary>
        /// Get Stock Report By Item Name
        /// </summary>
        /// <param name="itemName">Required a string value as Item Name.</param>
        /// <returns>Will return a list of Stock Report.</returns>
        public List<Entities.StockReport> GetStockByItemName(string itemName)
        {
            var stocks = new List<Entities.StockReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockByItemName))
                {
                    database.AddInParameter(dbCommand, "@item_name", DbType.String, itemName);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stock = new Entities.StockReport()
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                StockQty = DRE.GetNullableDecimal(reader, "stock_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null)
                            };

                            stocks.Add(stock);
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

            return stocks;
        }

        /// <summary>
        /// Get Stock Report By Item Category Wise
        /// </summary>
        /// <returns>Will return a list of Stock Report.</returns>
        public List<Entities.StockReport> GetStockItemCategoryWise()
        {
            var stocks = new List<Entities.StockReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockItemCategoryWise))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stock = new Entities.StockReport()
                            {
                                ItemCategoryId = DRE.GetNullableInt32(reader, "item_category_id", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                StockQty = DRE.GetNullableDecimal(reader, "stock_qty", null)
                            };

                            stocks.Add(stock);
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

            return stocks;
        }

        /// <summary>
        /// Get Stock Report Item Categorywise By Item Category Id
        /// </summary>
        /// <param name="itemCategoryId">Required an integer value as Item Category Id.</param>
        /// <returns>Will return a list of Stock Report Entity.</returns>
        public List<Entities.StockReport> GetStockItemCategoryWiseByItemCategoryId(Int32 itemCategoryId)
        {
            var stocks = new List<Entities.StockReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockItemCategoryWiseByItemCategoryId))
                {
                    database.AddInParameter(dbCommand, "@item_category_id", DbType.Int32, itemCategoryId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stock = new Entities.StockReport()
                            {
                                ItemCategoryId = DRE.GetNullableInt32(reader, "item_category_id", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                StockQty = DRE.GetNullableDecimal(reader, "stock_qty", null)
                            };

                            stocks.Add(stock);
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

            return stocks;
        }

        /// <summary>
        /// Get Stock Report Item Category Wise and Item Wise
        /// </summary>
        /// <returns>Will return a list of Stock Report Entity.</returns>
        public List<Entities.StockReport> GetStockItemCategoryWiseAndItemQualityWise()
        {
            var stocks = new List<Entities.StockReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockItemCategorWiseAndItemQualityWise))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stock = new Entities.StockReport()
                            {
                                ItemCategoryId = DRE.GetNullableInt32(reader, "item_category_id", null),
                                ItemCategoryName = DRE.GetNullableString(reader, "item_category_name", null),
                                ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                StockQty = DRE.GetNullableDecimal(reader, "stock_qty", null)
                            };

                            stocks.Add(stock);
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

            return stocks;
        }

        /// <summary>
        /// Get Stock Location Wise Item Quality Wise and Item Wise
        /// </summary>
        /// <returns>Will return a list of Stock Report Entity.</returns>
        public List<Entities.StockReport> GetStockLocationWiseItemQualitWiseAndItemWise()
        {
            var stocks = new List<Entities.StockReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockLocationWiseItemQualityWiseAndItemWise))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stock = new Entities.StockReport()
                            {
                                ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                StockQty = DRE.GetNullableDecimal(reader, "stock_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                LocationId = DRE.GetNullableInt32(reader, "location_id", null),
                                LocationName = DRE.GetNullableString(reader, "location_name", null)
                            };

                            stocks.Add(stock);
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

            return stocks;
        }

        /// <summary>
        /// Get Stock Location Wise Item Wise By Item Id
        /// </summary>
        /// <param name="itemId">Required an integer value of Item Id.</param>
        /// <returns>Will return a list of Stock Report Entity.</returns>
        public List<Entities.StockReport> GetStockLocationWiseItemWiseByItemId(Int32 itemId)
        {
            var stocks = new List<Entities.StockReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockLocationWiseItemQualityWiseAndItemWise))
                {
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stock = new Entities.StockReport()
                            {
                                ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                StockQty = DRE.GetNullableDecimal(reader, "stock_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                LocationId = DRE.GetNullableInt32(reader, "location_id", null),
                                LocationName = DRE.GetNullableString(reader, "location_name", null)
                            };

                            stocks.Add(stock);
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

            return stocks;
        }

        /// <summary>
        /// Get Stock Report Location Wise Item Quality Wise and Item Wise
        /// </summary>
        /// <returns>Will return a list of Stock Report Entity.</returns>
        public List<Entities.StockReport> GetStockLocationWiseAndItemWiseByLoctionId(Int32 locationId)
        {
            var stocks = new List<Entities.StockReport>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockLocationWiseAndItemWiseByLocationId))
                {
                    database.AddInParameter(dbCommand, "@location_id", DbType.Int32, locationId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stock = new Entities.StockReport()
                            {
                                ItemQualityId = DRE.GetNullableInt32(reader, "item_quality_id", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                StockQty = DRE.GetNullableDecimal(reader, "stock_qty", null),
                                UnitCode = DRE.GetNullableString(reader, "unit_code", null),
                                LocationId = DRE.GetNullableInt32(reader, "location_id", null),
                                LocationName = DRE.GetNullableString(reader, "location_name", null)
                            };

                            stocks.Add(stock);
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

            return stocks;
        }

    }

}
