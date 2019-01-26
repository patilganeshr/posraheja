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
    public class TypeOfTransfer
    {
        public readonly Database database;

        public TypeOfTransfer()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.TypeOfTransfer> GetTransferTypes()
        {
            var transferTypes = new List<Entities.TypeOfTransfer>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetTypeOfTransfers))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var typeOfTransfer = new Entities.TypeOfTransfer
                            {
                                TypeOfTransferId = DRE.GetNullableInt32(reader, "type_of_transfer_id", null),
                                TransferType = DRE.GetNullableString(reader, "transfer_type", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null),
                                SrNo = DRE.GetNullableInt64(reader, "sr_no", null)
                            };

                            transferTypes.Add(typeOfTransfer);
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

            return transferTypes;
        }

    }
}
