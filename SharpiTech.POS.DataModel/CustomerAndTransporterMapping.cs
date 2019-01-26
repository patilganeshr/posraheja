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
    public class CustomerAndTransporterMapping
    {
        private readonly Database database;

        public CustomerAndTransporterMapping()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctm"></param>
        /// <returns></returns>
        private Int32 AddCustomerAndTransporterMapping(Entities.CustomerAndTransporterMapping ctm)
        {
            var mappingId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertCustomerAndTransporterMapping))
                {
                    database.AddInParameter(dbCommand, "@mapping_id", DbType.Int32, ctm.MappingId);
                    database.AddInParameter(dbCommand, "@customer_address_id", DbType.Int32, ctm.CustomerAddressId);
                    database.AddInParameter(dbCommand, "@transporter_address_id", DbType.Int32, ctm.TransporterAddressId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, ctm.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, ctm.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    mappingId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        mappingId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return mappingId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctm"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 AddCustomerAndTransporterMapping(Entities.CustomerAndTransporterMapping ctm, DbTransaction transaction)
        {
            var mappingId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertCustomerAndTransporterMapping))
                {
                    database.AddInParameter(dbCommand, "@mapping_id", DbType.Int32, ctm.MappingId);
                    database.AddInParameter(dbCommand, "@customer_address_id", DbType.Int32, ctm.CustomerAddressId);
                    database.AddInParameter(dbCommand, "@transporter_address_id", DbType.Int32, ctm.TransporterAddressId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, ctm.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, ctm.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    mappingId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        mappingId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return mappingId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctm"></param>
        /// <returns></returns>
        private bool DeleteCustomerAndTransporterMapping(Entities.CustomerAndTransporterMapping ctm)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteCustomerAndTransporterMapping))
                {
                    database.AddInParameter(dbCommand, "@mapping_id", DbType.Int32, ctm.MappingId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, ctm.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, ctm.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctm"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool DeleteCustomerAndTransporterMapping(Entities.CustomerAndTransporterMapping ctm, DbTransaction transaction)
        {
            var isDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteCustomerAndTransporterMapping))
                {
                    database.AddInParameter(dbCommand, "@mapping_id", DbType.Int32, ctm.MappingId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, ctm.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, ctm.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerAddressId"></param>
        /// <returns></returns>
        public List<Entities.CustomerAndTransporterMapping> GetTransportersListByCustomerAddressId(Int32 customerAddressId)
        {
            var transporters = new List<Entities.CustomerAndTransporterMapping>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetTransportersListByCustomerAddressId))
                {
                    database.AddInParameter(dbCommand, "@customer_address_id", DbType.Int32, customerAddressId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var transporter = new Entities.CustomerAndTransporterMapping
                            {
                                MappingId = DRE.GetNullableInt32(reader, "mapping_id", 0),
                                CustomerAddressId = DRE.GetNullableInt32(reader, "customer_address_id", 0),
                                CustomerName = DRE.GetNullableString(reader, "customer_name", null),
                                TransporterAddressId = DRE.GetNullableInt32(reader, "transporter_address_id", 0),
                                TransporterName = DRE.GetNullableString(reader, "transporter_name", null)
                            };

                            transporters.Add(transporter);
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



            return transporters;
        }


        public List<Entities.CustomerAndTransporterMapping> GetAllCustomerAndTransporterMapping()
        {
            var customerAndTransporters = new List<Entities.CustomerAndTransporterMapping>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllCustomerTransporterMapping))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var customerAndTransporter = new Entities.CustomerAndTransporterMapping
                            {
                                MappingId = DRE.GetNullableInt32(reader, "mapping_id", 0),
                                CustomerAddressId = DRE.GetNullableInt32(reader, "customer_address_id", 0),
                                CustomerName = DRE.GetNullableString(reader, "customer_name", null),
                                TransporterAddressId = DRE.GetNullableInt32(reader, "transporter_id", 0),
                                TransporterName = DRE.GetNullableString(reader, "transporter_name", null)
                            };

                            customerAndTransporters.Add(customerAndTransporter);
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

            return customerAndTransporters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctm"></param>
        /// <returns></returns>
        private Int32 UpdateCustomerAndTransporterMapping(Entities.CustomerAndTransporterMapping ctm)
        {
            var mappingId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateCustomerAndTransporterMapping))
                {
                    database.AddInParameter(dbCommand, "@mapping_id", DbType.Int32, ctm.MappingId);
                    database.AddInParameter(dbCommand, "@customer_address_id", DbType.Int32, ctm.CustomerAddressId);
                    database.AddInParameter(dbCommand, "@transporter_address_id", DbType.Int32, ctm.TransporterAddressId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, ctm.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, ctm.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    mappingId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        mappingId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return mappingId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctm"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private Int32 UpdateCustomerAndTransporterMapping(Entities.CustomerAndTransporterMapping ctm, DbTransaction transaction)
        {
            var mappingId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateCustomerAndTransporterMapping))
                {
                    database.AddInParameter(dbCommand, "@mapping_id", DbType.Int32, ctm.MappingId);
                    database.AddInParameter(dbCommand, "@customer_address_id", DbType.Int32, ctm.CustomerAddressId);
                    database.AddInParameter(dbCommand, "@transporter_address_id", DbType.Int32, ctm.TransporterAddressId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, ctm.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, ctm.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    mappingId = database.ExecuteNonQuery(dbCommand, transaction);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        mappingId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return mappingId;
        }

        public Int32 SaveCustomerAndTransporterMapping(Entities.CustomerAndTransporterMapping ctm)
        {
            var mappingId = 0;

            if (ctm.MappingId == null || ctm.MappingId == 0)
            {
                var result = false;//IsClientAddresseeNameExists((int)clientAddress.ClientId, clientAddress.ClientAddressName);

                if (result == false)
                {
                    mappingId = AddCustomerAndTransporterMapping(ctm);
                }
                else
                {
                    mappingId = -1;
                }
            }
            else if (ctm.IsDeleted == true)
            {
                var result = DeleteCustomerAndTransporterMapping(ctm);
            }
            else if (ctm.ModifiedBy > 0 || ctm.ModifiedBy != null)
            {
                mappingId = UpdateCustomerAndTransporterMapping(ctm);
            }

            return mappingId;
        }

        public Int32 SaveCustomerAndTransporterMapping(Entities.CustomerAndTransporterMapping ctm, DbTransaction transaction)
        {
            var mappingId = 0;

            if (ctm.MappingId == null || ctm.MappingId == 0)
            {
                var result = false;//IsClientAddresseeNameExists((int)clientAddress.ClientId, clientAddress.ClientAddressName);

                if (result == false)
                {
                    mappingId = AddCustomerAndTransporterMapping(ctm, transaction);
                }
                else
                {
                    mappingId = -1;
                }
            }
            else if (ctm.IsDeleted == true)
            {
                var result = DeleteCustomerAndTransporterMapping(ctm, transaction);
            }
            else if (ctm.ModifiedBy > 0 || ctm.ModifiedBy != null)
            {
                mappingId = UpdateCustomerAndTransporterMapping(ctm, transaction);
            }

            return mappingId;
        }
    }
}
