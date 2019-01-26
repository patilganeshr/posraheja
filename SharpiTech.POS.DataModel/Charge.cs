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
    public class Charge
    {
        private readonly Database database;

        public Charge()
        {
            database = DBConnect.getDBConnection();
        }

        public Int32 AddCharge(Entities.Charge charge)
        {
            var chargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.InsertCharge))
                {
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, charge.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_name", DbType.String, charge.ChargeName);
                    database.AddInParameter(dbCommand, "@charge_desc", DbType.String, charge.ChargeDesc);
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, charge.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@created_by", DbType.Int32, charge.CreatedBy);
                    database.AddInParameter(dbCommand, "@created_by_ip", DbType.String, charge.CreatedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    chargeId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        chargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return chargeId;
        }

        public bool CheckChargeNameIsExists(string chargeName)
        {
            var isChargeNameExists = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.CheckChargeNameIsExists))
                {

                    database.AddInParameter(dbCommand, "@charge_name", DbType.String, chargeName);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            isChargeNameExists = DRE.GetBoolean(reader, "is_charge_name_exists");
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

            return isChargeNameExists;

        }

        private Boolean DeleteCharge(Entities.Charge charge)
        {
            var isChargeDeleted = false;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.DeleteCharge))
                {
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, charge.ChargeId);
                    database.AddInParameter(dbCommand, "@deleted_by", DbType.Int32, charge.DeletedBy);
                    database.AddInParameter(dbCommand, "@deleted_by_ip", DbType.String, charge.DeletedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Boolean, 0);

                    var result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        isChargeDeleted = Convert.ToBoolean(database.GetParameterValue(dbCommand, "@return_value"));
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

            return isChargeDeleted;
        }

        public List<Entities.Charge> GetAllCharges()
        {
            var charges = new List<Entities.Charge>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllCharges))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var charge = new Entities.Charge
                            {
                                ChargeId = DRE.GetNullableInt32(reader, "charge_id", 0),
                                ChargeName = DRE.GetNullableString(reader, "charge_name", null),
                                ChargeDesc = DRE.GetNullableString(reader, "charge_desc", null),
                                GSTCategoryId = DRE.GetNullableInt32(reader, "gst_category_id", null),
                                GSTCategoryName = DRE.GetNullableString(reader, "gst_category", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            charges.Add(charge);
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

            return charges;
        }

        public Entities.Charge GetChargeDetailsByChargeId(Int32 chargeId)
        {
            var chargeDetails = new Entities.Charge();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllCharges))
                {
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, chargeId);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var charge = new Entities.Charge
                            {
                                ChargeName = DRE.GetNullableString(reader, "charge_name", null),
                                ChargeDesc = DRE.GetNullableString(reader, "charge_desc", null),
                                GSTCategoryId = DRE.GetNullableInt32(reader, "gst_category_id", null),
                                GSTCategoryName = DRE.GetNullableString(reader, "gst_category_name", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null)
                            };

                            chargeDetails = charge;
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

            return chargeDetails;
        }

        public Entities.Charge GetChargeDetailsByChargeName(string chargeName)
        {
            var chargeDetails = new Entities.Charge();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllCharges))
                {
                    database.AddInParameter(dbCommand, "@charge_name", DbType.String, chargeName);

                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var charge = new Entities.Charge
                            {
                                ChargeName = DRE.GetNullableString(reader, "charge_name", null),
                                ChargeDesc = DRE.GetNullableString(reader, "charge_desc", null),
                                GSTCategoryId = DRE.GetNullableInt32(reader, "gst_category_id", null),
                                GSTCategoryName = DRE.GetNullableString(reader, "gst_category_name", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null)
                            };

                            chargeDetails = charge;
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

            return chargeDetails;
        }

        public Int32 UpdateCharge(Entities.Charge charge)
        {
            var chargeId = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.UpdateCharge))
                {
                    database.AddInParameter(dbCommand, "@charge_id", DbType.Int32, charge.ChargeId);
                    database.AddInParameter(dbCommand, "@charge_name", DbType.String, charge.ChargeName);
                    database.AddInParameter(dbCommand, "@charge_desc", DbType.String, charge.ChargeDesc);
                    database.AddInParameter(dbCommand, "@gst_category_id", DbType.Int32, charge.GSTCategoryId);
                    database.AddInParameter(dbCommand, "@modified_by", DbType.Int32, charge.ModifiedBy);
                    database.AddInParameter(dbCommand, "@modified_by_ip", DbType.String, charge.ModifiedByIP);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    chargeId = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        chargeId = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return chargeId;
        }

        public Int32 SaveCharge(Entities.Charge charge)
        {
            var chargeId = 0;

            if(charge.ChargeId == null || charge.ChargeId == 0)
            {
                var result = CheckChargeNameIsExists(charge.ChargeName);

                if (result == true)
                {
                    chargeId = -2;
                }
                else
                {
                    chargeId = AddCharge(charge);                    
                }
            }
            else if(charge.IsDeleted == true)
            {
                var result = DeleteCharge(charge);

                if (result == true)
                {
                    chargeId = 1;
                }
            }
            else if (charge.ChargeId > 0)
            {
                chargeId = UpdateCharge(charge);
            }

            return chargeId;
        }

    }
}
