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
    public class TaxSlabSubHeads
    {
        public readonly Database database;

        public TaxSlabSubHeads()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.TaxSlab> GetTaxSlabs()
        {
            var taxSlabs = new List<Entities.TaxSlab>();

            DbCommand dbCommand = null;

            try
            {
                using (dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllTaxSlabs))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var taxSlab = new Entities.TaxSlab
                            {
                                TaxSlabId = DRE.GetNullableInt32(reader, "tax_slab_id", null),
                                TaxName = DRE.GetNullableString(reader, "tax_name", null),
                                TaxRate = DRE.GetNullableDecimal(reader, "tax_rate", null),
                                guid = DRE.GetNullableGuid(reader, "row_guid", null)                                
                            };

                            taxSlabs.Add(taxSlab);
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

            return taxSlabs;
        }
    }
}
