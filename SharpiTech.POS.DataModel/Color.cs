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
    public class Color
    {
        private readonly Database database;

        public Color()
        {
            database = DBConnect.getDBConnection();
        }

        public List<Entities.Color> GetAllColorsName()
        {
            var colorsName = new List<Entities.Color>();

            try
            {
                using (DbCommand dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetAllColorsName))
                {
                    using (IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var color = new Entities.Color
                            {
                                ColorId = DRE.GetNullableInt32(reader, "color_id", 0),
                                ColorName = DRE.GetNullableString(reader, "color_name", null)
                            };

                            colorsName.Add(color);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return colorsName;
        }

    }
}
