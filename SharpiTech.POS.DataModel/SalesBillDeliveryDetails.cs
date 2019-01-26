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
    public class SalesBillDeliveryDetails
    {
        private readonly Database database;

        public SalesBillDeliveryDetails()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deliveryDetails"></param>
        /// <returns></returns>
        private Int32 AddSalesBillDeliveryDetails(Entities.SalesBillDeliveryDetails deliveryDetails)
        {
            var salesBillDeliveryId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBillsDeliveryDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_delivery_id", DbType.Int32, deliveryDetails.SalesBillDeliveryId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, deliveryDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@delivery_to", DbType.String, deliveryDetails.DeliveryTo);
                    database.AddInParameter(dbCommand, "@delivery_address", DbType.String, deliveryDetails.DeliveryAddress);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, deliveryDetails.TransporterId);
                    database.AddInParameter(dbCommand, "@lr_no", DbType.String, deliveryDetails.LRNo);
                    database.AddInParameter(dbCommand, "@lr_date", DbType.String, deliveryDetails.LRDate);
                    database.AddInParameter(dbCommand, "@delivery_date", DbType.String, deliveryDetails.DeliveryDate);
                    database.AddInParameter(dbCommand, "@is_delivery_pending", DbType.Boolean, deliveryDetails.IsDeliveryPending);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, deliveryDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, deliveryDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, deliveryDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillDeliveryId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillDeliveryId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillDeliveryId;
        }

        private Int32 AddSalesBillDeliveryDetails(Entities.SalesBillDeliveryDetails deliveryDetails, DbTransaction transaction)
        {
            var salesBillDeliveryId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertSalesBillsDeliveryDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_delivery_id", DbType.Int32, deliveryDetails.SalesBillDeliveryId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, deliveryDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@delivery_to", DbType.String, deliveryDetails.DeliveryTo);
                    database.AddInParameter(dbCommand, "@delivery_address", DbType.String, deliveryDetails.DeliveryAddress);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, deliveryDetails.TransporterId);
                    database.AddInParameter(dbCommand, "@lr_no", DbType.String, deliveryDetails.LRNo);
                    database.AddInParameter(dbCommand, "@lr_date", DbType.String, deliveryDetails.LRDate);
                    database.AddInParameter(dbCommand, "@delivery_date", DbType.String, deliveryDetails.DeliveryDate);
                    database.AddInParameter(dbCommand, "@is_delivery_pending", DbType.Boolean, deliveryDetails.IsDeliveryPending);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, deliveryDetails.Remarks);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, deliveryDetails.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, deliveryDetails.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillDeliveryId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillDeliveryId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillDeliveryId;
        }

        private bool DeleteSalesBillDeliveryDetails(Entities.SalesBillDeliveryDetails deliveryDetails)
        {
            var IsDeliveryDetailsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBillsDeliveryDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_delivery_id", DbType.Int32, deliveryDetails.SalesBillDeliveryId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, deliveryDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, deliveryDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsDeliveryDetailsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsDeliveryDetailsDeleted;

        }

        private bool DeleteSalesBillDeliveryDetails(Entities.SalesBillDeliveryDetails deliveryDetails, DbTransaction transaction)
        {
            var IsDeliveryDetailsDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteSalesBillsDeliveryDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_delivery_id", DbType.Int32, deliveryDetails.SalesBillDeliveryId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, deliveryDetails.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, deliveryDetails.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        IsDeliveryDetailsDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return IsDeliveryDetailsDeleted;

        }

        public List<Entities.SalesBillDeliveryDetails> GetDeliveryDetailsBySalesBillId (Int32 salesBillId)
        {
            var salesBillDeliveryDetails = new List<Entities.SalesBillDeliveryDetails>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetSalesBillsDeliveryDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, salesBillId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var deliveryDetails = new Entities.SalesBillDeliveryDetails
                            {
                                SalesBillDeliveryId = DRE.GetNullableInt32(reader, "sales_bill_delivery_id", null),
                                SalesBillId = DRE.GetNullableInt32(reader, "sales_bill_id", 0),
                                DeliveryTo = DRE.GetNullableString(reader, "delivery_to", null),
                                DeliveryAddress = DRE.GetNullableString(reader, "delivery_address", null),
                                TransporterId = DRE.GetNullableInt32(reader, "transporter_id", null),
                                LRNo = DRE.GetNullableString(reader, "lr_no", null),
                                LRDate = DRE.GetNullableString(reader, "lr_date", null),
                                DeliveryDate = DRE.GetNullableString(reader, "delivery_date", null),
                                IsDeliveryPending = DRE.GetNullableBoolean(reader, "is_delivery_pending", null),
                                Remarks = DRE.GetNullableString(reader, "remarks", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null)
                            };

                            salesBillDeliveryDetails.Add(deliveryDetails);
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

            return salesBillDeliveryDetails;
        }

        private Int32 UpdateSalesBillDeliveryDetails(Entities.SalesBillDeliveryDetails deliveryDetails)
        {
            var salesBillDeliveryId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesBillsDeliveryDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_delivery_id", DbType.Int32, deliveryDetails.SalesBillDeliveryId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, deliveryDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@delivery_to", DbType.String, deliveryDetails.DeliveryTo);
                    database.AddInParameter(dbCommand, "@delivery_address", DbType.String, deliveryDetails.DeliveryAddress);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, deliveryDetails.TransporterId);
                    database.AddInParameter(dbCommand, "@lr_no", DbType.String, deliveryDetails.LRNo);
                    database.AddInParameter(dbCommand, "@lr_date", DbType.String, deliveryDetails.LRDate);
                    database.AddInParameter(dbCommand, "@delivery_date", DbType.String, deliveryDetails.DeliveryDate);
                    database.AddInParameter(dbCommand, "@is_delivery_pending", DbType.Boolean, deliveryDetails.IsDeliveryPending);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, deliveryDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, deliveryDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, deliveryDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillDeliveryId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillDeliveryId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillDeliveryId;
        }

        private Int32 UpdateSalesBillDeliveryDetails(Entities.SalesBillDeliveryDetails deliveryDetails, DbTransaction transaction)
        {
            var salesBillDeliveryId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateSalesBillsDeliveryDetails))
                {
                    database.AddInParameter(dbCommand, "@sales_bill_delivery_id", DbType.Int32, deliveryDetails.SalesBillDeliveryId);
                    database.AddInParameter(dbCommand, "@sales_bill_id", DbType.Int32, deliveryDetails.SalesBillId);
                    database.AddInParameter(dbCommand, "@delivery_to", DbType.String, deliveryDetails.DeliveryTo);
                    database.AddInParameter(dbCommand, "@delivery_address", DbType.String, deliveryDetails.DeliveryAddress);
                    database.AddInParameter(dbCommand, "@transporter_id", DbType.Int32, deliveryDetails.TransporterId);
                    database.AddInParameter(dbCommand, "@lr_no", DbType.String, deliveryDetails.LRNo);
                    database.AddInParameter(dbCommand, "@lr_date", DbType.String, deliveryDetails.LRDate);
                    database.AddInParameter(dbCommand, "@delivery_date", DbType.String, deliveryDetails.DeliveryDate);
                    database.AddInParameter(dbCommand, "@is_delivery_pending", DbType.Boolean, deliveryDetails.IsDeliveryPending);
                    database.AddInParameter(dbCommand, "@remarks", DbType.String, deliveryDetails.Remarks);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, deliveryDetails.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, deliveryDetails.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    salesBillDeliveryId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        salesBillDeliveryId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return salesBillDeliveryId;
        }

        public Int32 SaveSalesBillDeliveryDetails(Entities.SalesBillDeliveryDetails deliveryDetails, DbTransaction transaction)
        {
            var result = 0;

            if (deliveryDetails.SalesBillDeliveryId == null || deliveryDetails.SalesBillDeliveryId == 0)
            {
                result = AddSalesBillDeliveryDetails(deliveryDetails, transaction);
            }
            else if (deliveryDetails.IsDeleted == true)
            {
                result = Convert.ToInt32(DeleteSalesBillDeliveryDetails(deliveryDetails, transaction));
            }
            else if (deliveryDetails.ModifiedBy > 0)
            {
                result = UpdateSalesBillDeliveryDetails(deliveryDetails, transaction);
            }

            return result;
        }
    }
}
