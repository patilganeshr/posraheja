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
    public class ItemRateForCustomerCategory
    {
        private readonly Database database;

        public ItemRateForCustomerCategory()
        {
            database = DBConnect.getDBConnection();
        }

        private Int32 AddItemRateForCustomerCategory(Entities.ItemRateForCustomerCategory ircc)
        {
            var customerCategoryItemRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertItemRatesForCustomerCategory))
                {
                    database.AddInParameter(dbCommand, "@customer_category_item_rate_id", DbType.Int32, ircc.CustomerCategoryItemRateId);
                    database.AddInParameter(dbCommand, "@customer_category_id", DbType.Int32, ircc.CustomerCategoryId);
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32,  ircc.ItemRateId);
                    database.AddInParameter(dbCommand, "@rate_in_percent", DbType.Decimal, ircc.RateInPercent);
                    database.AddInParameter(dbCommand, "@flat_rate", DbType.Decimal, ircc.FlatRate);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, ircc.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, ircc.CreatedByIP);                    

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    customerCategoryItemRateId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand,"@return_value") != DBNull.Value)
                    {
                        customerCategoryItemRateId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return customerCategoryItemRateId;
        }

        private Int32 AddItemRateForCustomerCategory(Entities.ItemRateForCustomerCategory ircc, DbTransaction transaction)
        {
            var customerCategoryItemRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertItemRatesForCustomerCategory))
                {
                    database.AddInParameter(dbCommand, "@customer_category_item_rate_id", DbType.Int32, ircc.CustomerCategoryItemRateId);
                    database.AddInParameter(dbCommand, "@customer_category_id", DbType.Int32, ircc.CustomerCategoryId);
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32, ircc.ItemRateId);
                    database.AddInParameter(dbCommand, "@rate_in_percent", DbType.Decimal, ircc.RateInPercent);
                    database.AddInParameter(dbCommand, "@flat_rate", DbType.Decimal, ircc.FlatRate);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, ircc.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, ircc.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    customerCategoryItemRateId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        customerCategoryItemRateId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return customerCategoryItemRateId;
        }

        private bool DeleteCustomerCategoryItemRate(Entities.ItemRateForCustomerCategory ircc)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteItemRatesForCustomerCategory))
                {
                    database.AddInParameter(dbCommand, "@customer_category_item_rate_id", DbType.Int32, ircc.CustomerCategoryItemRateId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, ircc.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, ircc.DeletedByIP);

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

        private bool DeleteCustomerCategoryItemRate(Entities.ItemRateForCustomerCategory ircc, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteItemRatesForCustomerCategory))
                {
                    database.AddInParameter(dbCommand, "@customer_category_item_rate_id", DbType.Int32, ircc.CustomerCategoryItemRateId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, ircc.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, ircc.DeletedByIP);

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

        public List<Entities.ItemRateForCustomerCategory> GetCustomerCategories()
        {
            var itemRates = new List<Entities.ItemRateForCustomerCategory>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRatesForCustomerCategoriesGetCustomerCategories))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemRate = new Entities.ItemRateForCustomerCategory
                            {
                                CustomerCategoryItemRateId = DRE.GetNullableInt32(reader, "customer_category_item_rate_id", null),
                                CustomerCategoryId = DRE.GetNullableInt32(reader, "customer_category_id", null),
                                CustomerCategoryName = DRE.GetNullableString(reader, "customer_category_name", null),
                                CustomerCategoryDesc = DRE.GetNullableString(reader, "customer_category_desc", null),
                                ItemRateId = DRE.GetNullableInt32(reader, "item_rate_id", 0),
                                RateInPercent = DRE.GetNullableDecimal(reader, "rate_in_percent", null),
                                FlatRate = DRE.GetNullableDecimal(reader, "flat_rate", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
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

        public List<Entities.ItemRateForCustomerCategory> GetItemRatesForCustomerCategoryByItemRateId(Int32 itemRateId)
        {
            var itemRateForCustomerCategories = new List<Entities.ItemRateForCustomerCategory>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRatesForCustomerCategoriesByItemRateId))
                {
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32, itemRateId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemRateForCustomerCategory = new Entities.ItemRateForCustomerCategory
                            {
                                CustomerCategoryItemRateId = DRE.GetNullableInt32(reader, "customer_category_item_rate_id", null),
                                CustomerCategoryId = DRE.GetNullableInt32(reader, "customer_category_id", null),
                                CustomerCategoryName = DRE.GetNullableString(reader, "customer_category_name", null),
                                ItemRateId = DRE.GetNullableInt32(reader, "item_rate_id", 0),
                                RateInPercent = DRE.GetNullableDecimal(reader, "rate_in_percent", null),
                                FlatRate = DRE.GetNullableDecimal(reader, "flat_rate", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            itemRateForCustomerCategories.Add(itemRateForCustomerCategory);
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

            return itemRateForCustomerCategories;
        }

        public List<Entities.ItemRateForCustomerCategory> GetItemRateForCustomerCategoryByItemId(Int32 itemId)
        {
            var itemRateForCustomerCategories = new List<Entities.ItemRateForCustomerCategory>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRatesForCustomerCategoryByItemId))
                {
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemRateForCustomerCategory = new Entities.ItemRateForCustomerCategory
                            {
                                CustomerCategoryItemRateId = DRE.GetNullableInt32(reader, "customer_category_item_rate_id", null),
                                CustomerCategoryId = DRE.GetNullableInt32(reader, "customer_category_id", null),
                                CustomerCategoryName = DRE.GetNullableString(reader, "customer_category_name", null),
                                ItemRateId = DRE.GetNullableInt32(reader, "item_rate_id", 0),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                RateInPercent =  DRE.GetNullableDecimal(reader, "rate_in_percent", null),
                                FlatRate = DRE.GetNullableDecimal(reader, "flat_rate", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null)                                
                            };

                            itemRateForCustomerCategories.Add(itemRateForCustomerCategory);
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

            return itemRateForCustomerCategories;
        }

        //public Entities.ItemRateForCustomerCategory GetItemRateByItemId(Int32 itemId)
        //{
        //    var itemRate = new Entities.ItemRate();

        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemRateByItemId))
        //        {
        //            database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);

        //            using (IDataReader reader = database.ExecuteReader(dbCommand))
        //            {
        //                while (reader.Read())
        //                {
        //                    var _itemRate = new Entities.ItemRate
        //                    {
        //                        ItemRateId = DRE.GetNullableInt32(reader, "item_rate_id", 0),
        //                        ItemId = DRE.GetNullableInt32(reader, "item_id", null),
        //                        ItemName = DRE.GetNullableString(reader, "item_name", null),
        //                        PurchaseRate = DRE.GetNullableDecimal(reader, "purchase_rate", null),
        //                        TransportRate = DRE.GetNullableDecimal(reader, "trasport_rate", null),
        //                        Labour_Rate = DRE.GetNullableDecimal(reader, "labour_rate", null),
        //                        guid = DRE.GetNullableGuid(reader, "row_guid", null)
        //                    };

        //                     itemRate = _itemRate;
        //                }
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

        //    return itemRate;
        //}

        private Int32 UpdateItemRateForCustomerCategory(Entities.ItemRateForCustomerCategory ircc)
        {
            var itemRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateItemRatesForCustomerCategory))
                {
                    database.AddInParameter(dbCommand, "@customer_category_item_rate_id", DbType.Int32, ircc.CustomerCategoryItemRateId);
                    database.AddInParameter(dbCommand, "@customer_category_id", DbType.Int32, ircc.CustomerCategoryId);
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32, ircc.ItemRateId);
                    database.AddInParameter(dbCommand, "@rate_in_percent", DbType.Decimal, ircc.RateInPercent);
                    database.AddInParameter(dbCommand, "@flat_rate", DbType.Decimal, ircc.FlatRate);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, ircc.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, ircc.ModifiedByIP);

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

        private Int32 UpdateItemRateForCustomerCategory(Entities.ItemRateForCustomerCategory ircc, DbTransaction transaction)
        {
            var itemRateId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateItemRatesForCustomerCategory))
                {
                    database.AddInParameter(dbCommand, "@customer_category_item_rate_id", DbType.Int32, ircc.CustomerCategoryItemRateId);
                    database.AddInParameter(dbCommand, "@customer_category_id", DbType.Int32, ircc.CustomerCategoryId);
                    database.AddInParameter(dbCommand, "@item_rate_id", DbType.Int32, ircc.ItemRateId);
                    database.AddInParameter(dbCommand, "@rate_in_percent", DbType.Decimal, ircc.RateInPercent);
                    database.AddInParameter(dbCommand, "@flat_rate", DbType.Decimal, ircc.FlatRate);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, ircc.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, ircc.ModifiedByIP);

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

        public Int32 SaveItemRateForCustomerCategory(Entities.ItemRateForCustomerCategory ircc)
        {
            var customerCategoryItemRateId = 0;

            if (ircc.CustomerCategoryItemRateId == null || ircc.CustomerCategoryItemRateId == 0)
            {
                customerCategoryItemRateId = AddItemRateForCustomerCategory(ircc);
            }
            else if (ircc.IsDeleted == true)
            {
                customerCategoryItemRateId = Convert.ToInt32(DeleteCustomerCategoryItemRate(ircc));
            }
            else if(ircc.ModifiedBy > 0 || ircc.ModifiedBy != null)
            {
                customerCategoryItemRateId = UpdateItemRateForCustomerCategory(ircc);
            }

            return customerCategoryItemRateId;
        }

        public Int32 SaveItemRateForCustomerCategory(Entities.ItemRateForCustomerCategory ircc, DbTransaction transaction)
        {
            var customerCategoryItemRateId = 0;

            if (ircc.CustomerCategoryItemRateId == null || ircc.CustomerCategoryItemRateId == 0)
            {
                customerCategoryItemRateId = AddItemRateForCustomerCategory(ircc, transaction);
            }
            else if (ircc.IsDeleted == true)
            {
                customerCategoryItemRateId = Convert.ToInt32(DeleteCustomerCategoryItemRate(ircc, transaction));
            }
            else if (ircc.ModifiedBy > 0 || ircc.ModifiedBy != null)
            {
                customerCategoryItemRateId = UpdateItemRateForCustomerCategory(ircc, transaction);
            }

            return customerCategoryItemRateId;
        }

        /// <summary>
        /// Get Wholesale and Retails Rates of Items for particular item 
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<Entities.ItemRateForSalesBills> GetWholesaleAndRetailRatesOfItems(Int32 itemId)
        {
            var itemRateList = new List<Entities.ItemRateForSalesBills>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetWholesaleAndRetailItemRatesByItemId))
                {
                    database.AddInParameter(dbCommand, "@item_id", DbType.Int32, itemId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemRate = new Entities.ItemRateForSalesBills
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                WholesaleRate = DRE.GetNullableDecimal(reader, "wholesale_rate", null),
                                RetailRate = DRE.GetNullableDecimal(reader, "retail_rate", null),
                                RateEffectiveFromDate = DRE.GetNullableString(reader, "rate_effective_from_date", null)
                            };

                            itemRateList.Add(itemRate);
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

            return itemRateList;
        }

        /// <summary>
        /// Get Wholesale and Retail Rates of All Items
        /// </summary>
        /// <returns></returns>
        public List<Entities.ItemRateForSalesBills> GetWholesaleAndRetailRatesOfAllItems()
        {
            var itemRateList = new List<Entities.ItemRateForSalesBills>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetWholesaleAndRetailItemRateForAllItems))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemRate = new Entities.ItemRateForSalesBills
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                WholesaleRate = DRE.GetNullableDecimal(reader, "wholesale_rate", null),
                                RetailRate = DRE.GetNullableDecimal(reader, "retails_rate", null),
                                RateEffectiveFromDate = DRE.GetNullableString(reader, "rate_effective_from_date", null)
                            };

                            itemRateList.Add(itemRate);
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

            return itemRateList;
        }

        /// <summary>
        /// Search items for Wholesale and Retail Rates by item name and quality
        /// </summary>
        /// <returns></returns>
        public List<Entities.ItemRateForSalesBills> SearchItemRatesByItemNameAndQuality(string itemName)
        {
            var itemRateList = new List<Entities.ItemRateForSalesBills>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.SearchItemRatesByItemNameAndQuality))
                {
                    database.AddInParameter(dbCommand, "@item_name", DbType.String, itemName);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemRate = new Entities.ItemRateForSalesBills
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null)                                
                            };

                            itemRateList.Add(itemRate);
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

            return itemRateList;
        }

        /// <summary>
        /// Get Wholesale and Retail Rates of Sales Bill Items 
        /// </summary>
        /// <param name="salesBillId"></param>
        /// <returns></returns>
        public List<Entities.ItemRateForSalesBills> GetWholesaleAndRetailsRatesOfSalesBillItem(Int32 salesBillId)
        {
            var itemRateList = new List<Entities.ItemRateForSalesBills>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetWholesaleAndRetailItemRatesBySalesBillId))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var itemRate = new Entities.ItemRateForSalesBills
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                WholesaleRate = DRE.GetNullableDecimal(reader, "wholesale_rate", null),
                                RetailRate = DRE.GetNullableDecimal(reader, "retails_rate", null),
                                RateEffectiveFromDate = DRE.GetNullableString(reader, "rate_effective_from_date", null)
                            };

                            itemRateList.Add(itemRate);
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

            return itemRateList;
        }

    }
}
