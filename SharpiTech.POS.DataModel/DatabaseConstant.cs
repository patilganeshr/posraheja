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
    public class DatabaseConstant
    {
        private readonly Database database;

        public DatabaseConstant()
        {
            database = DBConnect.getDBConnection();
        }

        //public static string Connectionstring;
        //public static string StoredProcedureName;

        public List<Entities.DatabaseConstant> GetAllProcdures()
        {
            List<Entities.DatabaseConstant> databaseConstants = new List<Entities.DatabaseConstant>();

            DbCommand dbCommand = null;

            dbCommand = database.GetStoredProcCommand("usp_procedures_get_all_procedures");
            
            using (IDataReader reader = database.ExecuteReader(dbCommand))
            {
                while (reader.Read())
                {
                    var databaseConstant = new Entities.DatabaseConstant
                    {
                        TableName = DRE.GetNullableString(reader, "table_name", null),
                        ProcedureName = DRE.GetNullableString(reader, "procedure_name", null)
                    };

                    databaseConstants.Add(databaseConstant);
                }
            }

            return databaseConstants;
        }

    }

    
}
