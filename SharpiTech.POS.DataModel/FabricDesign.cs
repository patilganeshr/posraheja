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
    public class FabricDesign
    {
        private readonly Database database;

        public FabricDesign()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.FabricDesign> GetAllFabricDesigns()
        {
            var designs = new List<Entities.FabricDesign>();

            try
            {
                using (DbCommand dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllColorsName))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var fabricDesign = new Entities.FabricDesign
                            {
                                FabricDesignId = DRE.GetNullableInt32(reader, "fabric_design_id", 0),
                                DesignName = DRE.GetNullableString(reader, "design_name", null),
                                DesignCode = DRE.GetNullableString(reader, "design_code", null)
                            };

                            designs.Add(fabricDesign);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return designs;
        }

    }
}
