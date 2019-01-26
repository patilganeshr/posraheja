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
    public class ItemRate
    {
        private readonly Database database;

        public ItemRate()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddItemRate(Entities.ItemRate itemRate)
        {
            var itemRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertItemRate))
                {
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32, itemRate.ItemRateId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32,  itemRate.ItemId);
                    database.AddInParameter(dbCommand, "@purchase_rate", DbType.Decimal, itemRate.PurchaseRate);
                    database.AddInParameter(dbCommand, "@discount_percent", DbType.Decimal, itemRate.DiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, itemRate.DiscountAmount);
                    database.AddInParameter(dbCommand, "@transport_cost", DbType.Decimal, itemRate.TransportCost);
                    database.AddInParameter(dbCommand, "@labour_cost", DbType.Decimal, itemRate.LabourCost);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, itemRate.GSTRateId);
                    database.AddInParameter(dbCommand, "@rate_effective_from_date", DbType.String, itemRate.RateEffectiveFromDate);
                    database.AddInParameter(dbCommand, "@is_sell_at_net_rate", DbType.Boolean, itemRate.IsSellAtNetRate);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, itemRate.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, itemRate.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, itemRate.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemRateId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand,"@return_value") != DBNull.Value)
                    {
                        itemRateId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemRateId;
        }

        private Int32 AddItemRate(Entities.ItemRate itemRate, DbTransaction transaction)
        {
            var itemRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertItemRate))
                {
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32, itemRate.ItemRateId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemRate.ItemId);
                    database.AddInParameter(dbCommand, "@purchase_rate", DbType.Decimal, itemRate.PurchaseRate);
                    database.AddInParameter(dbCommand, "@discount_percent", DbType.Decimal, itemRate.DiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, itemRate.DiscountAmount);
                    database.AddInParameter(dbCommand, "@transport_cost", DbType.Decimal, itemRate.TransportCost);
                    database.AddInParameter(dbCommand, "@labour_cost", DbType.Decimal, itemRate.LabourCost);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, itemRate.GSTRateId);
                    database.AddInParameter(dbCommand, "@rate_effective_from_date", DbType.String, itemRate.RateEffectiveFromDate);
                    database.AddInParameter(dbCommand, "@is_sell_at_net_rate", DbType.Boolean, itemRate.IsSellAtNetRate);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, itemRate.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, itemRate.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, itemRate.CreatedByIP);
                    
                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemRateId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemRateId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemRateId;
        }


        private bool DeleteItemRate(Entities.ItemRate itemRate)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteItemRate))
                {
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32, itemRate.ItemRateId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemRate.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemRate.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

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

        private bool DeleteItemRate(Entities.ItemRate itemRate, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteItemRate))
                {
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32, itemRate.ItemRateId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, itemRate.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, itemRate.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

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

        public List<Entities.ItemRate> GetAllItemsRates()
        {
            var itemRates = new List<Entities.ItemRate>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllItemRates))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemRateForCustomerCategory = new ItemRateForCustomerCategory();

                            var itemRate = new Entities.ItemRate
                            {
                                ItemRateId = DRE.GetNullableInt32(reader, "item_rate_id", 0),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null), 
                                PurchaseRate =  DRE.GetNullableDecimal(reader, "purchase_rate", null),
                                DiscountPercent = DRE.GetNullableDecimal(reader, "discount_percent", null),
                                DiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null),
                                RateAfterDiscount = DRE.GetNullableDecimal(reader, "rate_after_discount", null),
                                TransportCost = DRE.GetNullableDecimal(reader, "transport_cost", null),
                                LabourCost = DRE.GetNullableDecimal(reader, "labour_cost", null),
                                CostOfGoods = DRE.GetNullableDecimal(reader, "cost_of_goods", null),
                                GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", null),
                                GSTRate = DRE.GetNullableDecimal(reader, "gst_rate", null),
                                GSTAmount = DRE.GetNullableDecimal(reader, "gst_amount", null),
                                TotalCost = DRE.GetNullableDecimal(reader, "total_cost", null),
                                IsSellAtNetRate = DRE.GetNullableBoolean(reader, "is_sell_at_net_rate", null),
                                RateEffectiveFromDate = DRE.GetNullableString(reader, "rate_effective_from_date", null),
                                RateEffectiveToDate = DRE.GetNullableString(reader, "rate_effective_to_date", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                                CustomerCategoryRates = itemRateForCustomerCategory.GetItemRatesForCustomerCategoryByItemRateId(DRE.GetInt32(reader,"item_rate_id"))
                            };

                            itemRates.Add(itemRate);
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

            return itemRates;
        }

        public List<Entities.ItemRate> GetItemsRatesByItemId(Int32 itemId)
        {
            var itemRates = new List<Entities.ItemRate>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemsRatesByItemId))
                {
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemRateForCustomerCategory = new ItemRateForCustomerCategory();

                            var itemRate = new Entities.ItemRate
                            {
                                ItemRateId = DRE.GetNullableInt32(reader, "item_rate_id", 0),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                ItemQuality = DRE.GetNullableString(reader, "item_quality", null),
                                PurchaseRate = DRE.GetNullableDecimal(reader, "purchase_rate", null),
                                DiscountPercent = DRE.GetNullableDecimal(reader, "discount_percent", null),
                                DiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null),
                                TransportCost = DRE.GetNullableDecimal(reader, "transport_cost", null),
                                LabourCost = DRE.GetNullableDecimal(reader, "labour_cost", null),
                                CostOfGoods = DRE.GetNullableDecimal(reader, "cost_of_goods", null),
                                GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", null),
                                GSTRate = DRE.GetNullableDecimal(reader, "gst_rate", null),
                                GSTAmount = DRE.GetNullableDecimal(reader, "gst_amount", null),
                                TotalCost = DRE.GetNullableDecimal(reader, "total_cost", null),
                                IsSellAtNetRate = DRE.GetNullableBoolean(reader, "is_sell_at_net_rate", null),
                                RateEffectiveFromDate = DRE.GetNullableString(reader, "rate_effective_from_date", null),
                                RateEffectiveToDate = DRE.GetNullableString(reader, "rate_effective_to_date", null),
                                RateAfterDiscount = DRE.GetNullableDecimal(reader, "rate_after_discount", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null),
                                CustomerCategoryRates = itemRateForCustomerCategory.GetItemRateForCustomerCategoryByItemId(itemId)
                            };

                            itemRates.Add(itemRate);
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

            return itemRates;
        }
        
        public Entities.ItemRate GetItemRateByItemRateId(Int32 itemRateId)
        {
            var itemRate = new Entities.ItemRate();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRateByItemRateId))
                {
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32, itemRateId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var _itemRate = new Entities.ItemRate
                            {
                                ItemRateId = DRE.GetNullableInt32(reader, "item_rate_id", 0),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                PurchaseRate = DRE.GetNullableDecimal(reader, "purchase_rate", null),
                                DiscountPercent = DRE.GetNullableDecimal(reader, "discount_percent", null),
                                DiscountAmount = DRE.GetNullableDecimal(reader, "discount_amount", null),
                                TransportCost = DRE.GetNullableDecimal(reader, "transport_cost", null),
                                LabourCost = DRE.GetNullableDecimal(reader, "labour_cost", null),
                                GSTRateId = DRE.GetNullableInt32(reader, "gst_rate_id", null),
                                GSTRate = DRE.GetNullableDecimal(reader, "gst_rate", null),
                                IsSellAtNetRate = DRE.GetNullableBoolean(reader, "is_sell_at_net_rate", null),
                                RateEffectiveFromDate = DRE.GetNullableString(reader, "rate_effective_from_date", null),
                                RateEffectiveToDate = DRE.GetNullableString(reader, "rate_effective_to_date", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null)
                            };

                             itemRate = _itemRate;
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

            return itemRate;
        }

        private Int32 UpdateItemRate(Entities.ItemRate itemRate)
        {
            var itemRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateItemRate))
                {
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32, itemRate.ItemRateId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemRate.ItemId);
                    database.AddInParameter(dbCommand, "@purchase_rate", DbType.Decimal, itemRate.PurchaseRate);
                    database.AddInParameter(dbCommand, "@discount_percent", DbType.Decimal, itemRate.DiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, itemRate.DiscountAmount);
                    database.AddInParameter(dbCommand, "@transport_cost", DbType.Decimal, itemRate.TransportCost);
                    database.AddInParameter(dbCommand, "@labour_cost", DbType.Decimal, itemRate.LabourCost);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, itemRate.GSTRateId);
                    database.AddInParameter(dbCommand, "@rate_effective_from_date", DbType.String, itemRate.RateEffectiveFromDate);
                    database.AddInParameter(dbCommand, "@is_sell_at_net_rate", DbType.Boolean, itemRate.IsSellAtNetRate);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, itemRate.WorkingPeriodId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, itemRate.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, itemRate.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemRateId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemRateId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemRateId;
        }

        private Int32 UpdateItemRate(Entities.ItemRate itemRate, DbTransaction transaction)
        {
            var itemRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateItemRate))
                {
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32, itemRate.ItemRateId);
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemRate.ItemId);
                    database.AddInParameter(dbCommand, "@purchase_rate", DbType.Decimal, itemRate.PurchaseRate);
                    database.AddInParameter(dbCommand, "@discount_percent", DbType.Decimal, itemRate.DiscountPercent);
                    database.AddInParameter(dbCommand, "@discount_amount", DbType.Decimal, itemRate.DiscountAmount);
                    database.AddInParameter(dbCommand, "@transport_cost", DbType.Decimal, itemRate.TransportCost);
                    database.AddInParameter(dbCommand, "@labour_cost", DbType.Decimal, itemRate.LabourCost);
                    database.AddInParameter(dbCommand, "@gst_rate_id", DbType.Int32, itemRate.GSTRateId);
                    database.AddInParameter(dbCommand, "@rate_effective_from_date", DbType.String, itemRate.RateEffectiveFromDate);
                    database.AddInParameter(dbCommand, "@is_sell_at_net_rate", DbType.Boolean, itemRate.IsSellAtNetRate);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, itemRate.WorkingPeriodId);                    
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, itemRate.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, itemRate.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    itemRateId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        itemRateId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return itemRateId;
        }

        public Int32 SaveItemRate(Entities.ItemRate itemRate)
        {
            var itemRateId = 0;

            if (itemRate.ItemRateId == null || itemRate.ItemRateId == 0)
            {
                itemRateId = AddItemRate(itemRate);
            }
            else if (itemRate.IsDeleted == true)
            {
                itemRateId = Convert.ToInt32(DeleteItemRate(itemRate));
            }
            else if(itemRate.ModifiedBy > 0 || itemRate.ModifiedBy != null)
            {
                itemRateId = UpdateItemRate(itemRate);
            }

            return itemRateId;
        }

        public Int32 SaveItemRate(List<Entities.ItemRate> itemRates)
        {
            var itemRateId = 0;

            var db = DBConnect.getDBConnection();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();

                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var customerCategoryItemRateId = 0;

                        if (itemRates != null)
                        {
                            if (itemRates.Count > 0)
                            {
                                foreach (Entities.ItemRate itemRate in itemRates)
                                {
                                    if (itemRate.ItemRateId == null || itemRate.ItemRateId == 0)
                                    {
                                        itemRateId = AddItemRate(itemRate, transaction);
                                    }
                                    else
                                    {
                                        if (itemRate.IsDeleted == true)
                                        {
                                            var result = DeleteItemRate(itemRate, transaction);

                                            if (result == true)
                                            {
                                                itemRateId = (int)itemRate.ItemRateId;
                                            }
                                        }
                                        else
                                        {
                                            if (itemRate.ModifiedBy > 0 || itemRate.ModifiedBy != null)
                                            {
                                                itemRateId = UpdateItemRate(itemRate, transaction);
                                            }
                                        }
                                    }

                                    if (itemRateId > 0)
                                    {
                                        if (itemRate.CustomerCategoryRates != null)
                                        {
                                            if (itemRate.CustomerCategoryRates.Count > 0)
                                            {
                                                foreach (Entities.ItemRateForCustomerCategory itemRateForCustomerCategory in itemRate.CustomerCategoryRates)
                                                {
                                                    itemRateForCustomerCategory.ItemRateId = itemRateId;

                                                    ItemRateForCustomerCategory ircc = new ItemRateForCustomerCategory();

                                                    customerCategoryItemRateId = ircc.SaveItemRateForCustomerCategory(itemRateForCustomerCategory, transaction);
                                                }
                                            }
                                        }
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

            return itemRateId;

        }

        public Int32 SaveItemRate(Entities.ItemRate itemRate, DbTransaction transaction)
        {
            var itemRateId = 0;
            var customerCategoryItemRateId = 0;

            if (itemRate.ItemRateId == null || itemRate.ItemRateId == 0)
            {
                itemRateId = AddItemRate(itemRate, transaction);
            }
            else if (itemRate.IsDeleted == true)
            {
                var result = DeleteItemRate(itemRate, transaction);

                if (result)
                {
                    itemRateId = Convert.ToInt32(itemRate.ItemRateId);
                }
            }
            else if (itemRate.ModifiedBy > 0 || itemRate.ModifiedBy != null)
            {
                itemRateId = UpdateItemRate(itemRate, transaction);
            }

            if (itemRateId > 0)
            {
                if (itemRate.CustomerCategoryRates != null)
                {
                    if (itemRate.CustomerCategoryRates.Count > 0)
                    {
                        foreach (Entities.ItemRateForCustomerCategory itemRateForCustomerCategory in itemRate.CustomerCategoryRates)
                        {
                            itemRateForCustomerCategory.ItemRateId = itemRateId;

                            ItemRateForCustomerCategory ircc = new ItemRateForCustomerCategory();

                            customerCategoryItemRateId = ircc.SaveItemRateForCustomerCategory(itemRateForCustomerCategory, transaction);
                        }
                    }
                }
            }

            return itemRateId;
        }


    }
}
