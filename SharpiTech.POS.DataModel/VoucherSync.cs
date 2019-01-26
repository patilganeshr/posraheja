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
    public class VoucherSync
    {
        private readonly Database database;

        public VoucherSync()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.VoucherType> GetVoucherType()
        {
            var voucherTypes = new List<Entities.VoucherType>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetVoucherType))
                {
                    
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var voucherType = new Entities.VoucherType()
                            {
                                VoucherTypeId = DRE.GetNullableInt32(reader, "voucher_type_id", 0),
                                TypeOfVoucher = DRE.GetNullableString(reader, "voucher_type", null)
                            };

                            voucherTypes.Add(voucherType);
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

            return voucherTypes;
        }

        public Int32 PostVoucherDataToTally(Entities.VoucherSync voucherSync)
        {
            var result = 0;

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.VoucherTallyTransfer))
                {
                    database.AddInParameter(dbCommand, "@voucher_type", DbType.String, voucherSync.VoucherType);
                    database.AddInParameter(dbCommand, "@from_date", DbType.String, voucherSync.FromDate);
                    database.AddInParameter(dbCommand, "@to_date", DbType.String, voucherSync.ToDate);
                    database.AddInParameter(dbCommand, "@from_voucher_no", DbType.String, voucherSync.FromVoucherNo);
                    database.AddInParameter(dbCommand, "@to_voucher_no", DbType.String, voucherSync.ToVoucherNo);
                    database.AddInParameter(dbCommand, "@working_period_id", DbType.Int32, voucherSync.WorkingPeriodId);

                    database.AddOutParameter(dbCommand, "@return_value", DbType.Int32, 0);

                    result = database.ExecuteNonQuery(dbCommand);

                    if (database.GetParameterValue(dbCommand, "@return_value") != DBNull.Value)
                    {
                        result = Convert.ToInt32(database.GetParameterValue(dbCommand, "@return_value"));
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

            return result;

        }


    }
}
