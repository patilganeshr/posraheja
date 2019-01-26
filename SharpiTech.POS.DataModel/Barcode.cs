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
    public class Barcode
    {
        private readonly Database database;

        public Barcode()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.Barcode> GetVendors()
        {
            var vendors = new List<Entities.Barcode>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetVendorsForBarcode))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var barcode = new Entities.Barcode
                            {
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", 0),
                                VendorName = DRE.GetNullableString(reader, "vendor_name", null),
                                VendorCode = DRE.GetNullableString(reader, "vendor_code", null)                                
                            };

                            vendors.Add(barcode);
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

            return vendors;
        }

        public List<Entities.Barcode> GetItems(Int32 vendorId)
        {
            var items = new List<Entities.Barcode>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemsForBarcode))
                {
                    database.AddInParameter(dbCommand, "@vendor_id", DbType.Int32, vendorId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var item = new Entities.Barcode
                            {
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                ItemCode = DRE.GetNullableString(reader, "item_code", null)
                            };

                            items.Add(item);
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

            return items;
        }

        public List<Entities.Barcode> GetItemsFromGoodsReceipt()
        {
            var items = new List<Entities.Barcode>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemsForBarcodeAsPerGoodsReceived))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var item = new Entities.Barcode
                            {
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemCode = DRE.GetNullableString(reader, "item_code", null),
                                VendorCode = DRE.GetNullableString(reader, "vendor_code", null),
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", 0)
                            };

                            items.Add(item);
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

            return items;
        }

        public List<Entities.Barcode> GetItemsFromInwardOutward()
        {
            var items = new List<Entities.Barcode>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemsForBarcodeAsPerInwardOutward))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var item = new Entities.Barcode
                            {
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemCode = DRE.GetNullableString(reader, "item_code", null),
                                NoOfLabels = DRE.GetNullableInt32(reader, "no_of_labels", 0),
                                VendorCode = DRE.GetNullableString(reader, "vendor_code", null),
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", 0)
                            };

                            items.Add(item);
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

            return items;
        }

        public List<Entities.Barcode> SearchInwardNo(Int32 inwardNo)
        {
            var inwardNos = new List<Entities.Barcode>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.SearchInwardNo))
                {
                    database.AddInParameter(dbCommand, "@inward_no", DbType.Int32, inwardNo);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var inward = new Entities.Barcode()
                            {
                                InwardNo = DRE.GetNullableString(reader, "inward_no", null),
                                InwardId = DRE.GetNullableInt32(reader, "inward_id", null)                                
                            };

                            inwardNos.Add(inward);
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

            return inwardNos;
        }

        public List<Entities.Barcode> GetItemsByInwardId(Int32 inwardId)
        {
            var items = new List<Entities.Barcode>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetItemsForBarcodeByInwardId))
                {
                    database.AddInParameter(dbCommand, "@inward_id", DbType.Int32, inwardId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var item = new Entities.Barcode
                            {
                                InwardGoodsId = DRE.GetNullableInt32(reader, "inward_goods_id", null),
                                GoodsReceiptItemId = DRE.GetNullableInt32(reader, "goods_receipt_item_id", null),
                                ItemId = DRE.GetNullableInt32(reader, "item_id", 0),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                NoOfLabels = DRE.GetNullableInt32(reader, "no_of_labels", null),
                                VendorId = DRE.GetNullableInt32(reader, "vendor_id", null),
                                LocationType = DRE.GetNullableString(reader, "location_type", null)
                            };

                            items.Add(item);
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

            return items;
        }

        public bool DeleteBarcodeDetails()
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteBarcodeDetails))
                {
                    var result = database.ExecuteNonQuery(dbCommand);

                    if (result > 0)
                    {
                        isDeleted = true;
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

        public Int32 SaveBarcodeDetails(List<Entities.Barcode> barcodeList)
        {
            var barcodeId = 0;

            DbCommand dbCommand = null;

            var isDeleted = DeleteBarcodeDetails();

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertBarcodeDetails))
                {
                    if (barcodeList != null)
                    {
                        if (barcodeList.Count > 0)
                        {
                            foreach (Entities.Barcode barcode in barcodeList)
                            {
                                database.AddInParameter(dbCommand, "@item_id", DbType.Int32, barcode.ItemId);
                                database.AddInParameter(dbCommand, "@vendor_id", DbType.String, barcode.VendorId);
                                database.AddInParameter(dbCommand, "@no_of_labels", DbType.Int32, barcode.NoOfLabels);
                                database.AddInParameter(dbCommand, "@label_start_no", DbType.Int32, barcode.LabelStartNo);
                                database.AddInParameter(dbCommand, "@goods_receipt_item_id", DbType.Int32, barcode.GoodsReceiptItemId);
                                database.AddInParameter(dbCommand, "@print_label_continue", DbType.Boolean, barcode.PrintLabelContinue);
                                database.AddInParameter(dbCommand, "@inward_goods_id", DbType.Int32, barcode.InwardGoodsId);

                                database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                                barcodeId = database.ExecuteNonQuery(dbCommand);

                                if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                                {
                                    barcodeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));

                                    dbCommand.Parameters.Clear();
                                }
                            }
                        }
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

            return barcodeId;
        }

        
    }
}
