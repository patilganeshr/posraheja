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
    public class StockDetails
    {
        private readonly Database database;

        public StockDetails()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockDetails"></param>
        /// <returns></returns>
        private Int32 AddStockDetails(Entities.StockDetails stockDetails)
        {
            var stockId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertStockDetails))
                {
                    database.AddInParameter(dbCommand, "@stock_id", DbType.Int32, stockDetails.StockId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, stockDetails.VendorId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, stockDetails.ItemId);
                    database.AddInParameter(dbCommand, "@stock_date", DbType.String, stockDetails.StockDate);
                    database.AddInParameter(dbCommand, "@bale_no", DbType.String, stockDetails.BaleNo);
                    database.AddInParameter(dbCommand, "@lot_no", DbType.String, stockDetails.LotNo);
                    database.AddInParameter(dbCommand, "@purchase_rate", DbType.Decimal, stockDetails.PurchaseRate);
                    database.AddInParameter(dbCommand, "@received_qty_in_pcs", DbType.Decimal, stockDetails.ReceivedQtyInPcs);
                    database.AddInParameter(dbCommand, "@received_qty_in_mtrs", DbType.Decimal, stockDetails.ReceivedQtyInMtrs);
                    database.AddInParameter(dbCommand, "@goods_received_location_id", DbType.Int32, stockDetails.GoodsReceivedLocationId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, stockDetails.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, stockDetails.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, stockDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, stockDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    stockId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        stockId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return stockId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockDetails"></param>
        /// <returns></returns>
        private bool DeleteStockDetails(Entities.StockDetails stockDetails)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteStockDetails))
                {
                    database.AddInParameter(dbCommand, "@stock_id", DbType.Int32, stockDetails.StockId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, stockDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, stockDetails.DeletedByIP);

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

        public List<Entities.StockDetails> GetStockDetails()
        {
            var stockItems = new List<Entities.StockDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockDetails))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stock = new Entities.StockDetails
                            {
                                StockId = DRE.GetNullableInt32(reader, "stock_id", null),
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                ItemQualityName = DRE.GetNullableString(reader, "item_quality_name", null),
                                StockDate = DRE.GetNullableString(reader, "stock_date", null),
                                BaleNo = DRE.GetNullableString(reader,"bale_no", null),
                                LotNo = DRE.GetNullableString(reader, "lot_no", null),
                                PurchaseRate = DRE.GetNullableDecimal(reader, "purchase_rate", null),
                                ReceivedQtyInPcs = DRE.GetNullableDecimal(reader, "received_qty_in_pcs", null),
                                ReceivedQtyInMtrs = DRE.GetNullableDecimal(reader, "received_qty_in_mtrs", null),
                                GoodsReceivedLocationId = DRE.GetNullableInt32(reader, "goods_received_location_id", null),
                                GoodsReceivedLocationName = DRE.GetNullableString(reader, "goods_received_location_name", null),
                                BranchId = DRE.GetNullableInt32(reader, "branch_id", null),
                                BranchName = DRE.GetNullableString(reader, "branch_name", null),
                                WorkingPeriodId = DRE.GetNullableInt32(reader, "working_period_id", null),
                                FinancialYear = DRE.GetNullableString(reader, "financial_year", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)                                
                            };

                            stockItems.Add(stock);
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

            return stockItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockDetails"></param>
        /// <returns></returns>
        private Int32 UpdateStockDetails(Entities.StockDetails stockDetails)
        {
            var stockId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateStockDetails))
                {
                    database.AddInParameter(dbCommand, "@stock_id", DbType.Int32, stockDetails.StockId);
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, stockDetails.VendorId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, stockDetails.ItemId);
                    database.AddInParameter(dbCommand, "@stock_date", DbType.String, stockDetails.StockDate);
                    database.AddInParameter(dbCommand, "@bale_no", DbType.String, stockDetails.BaleNo);
                    database.AddInParameter(dbCommand, "@lot_no", DbType.String, stockDetails.LotNo);
                    database.AddInParameter(dbCommand, "@purchase_rate", DbType.Decimal, stockDetails.PurchaseRate);
                    database.AddInParameter(dbCommand, "@received_qty_in_pcs", DbType.Decimal, stockDetails.ReceivedQtyInPcs);
                    database.AddInParameter(dbCommand, "@received_qty_in_mtrs", DbType.Decimal, stockDetails.ReceivedQtyInMtrs);
                    database.AddInParameter(dbCommand, "@goods_received_location_id", DbType.Int32, stockDetails.GoodsReceivedLocationId);
                    database.AddInParameter(dbCommand, "@branch_id", DbType.Int32, stockDetails.BranchId);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, stockDetails.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, stockDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, stockDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    stockId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        stockId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return stockId;
        }

        public Int32 SaveStockDetails(Entities.StockDetails stockDetails)
        {
            var stockId = 0;

            if(stockDetails.StockId == null || stockDetails.StockId == 0)
            {
                stockId = AddStockDetails(stockDetails);
            }
            else if (stockDetails.ModifiedBy > 0)
            {
                stockId = UpdateStockDetails(stockDetails);
            }
            else if (stockDetails.IsDeleted == true)
            {
                stockId  = Convert.ToInt32(DeleteStockDetails(stockDetails));
            }

            return stockId;
        }
    }
}
