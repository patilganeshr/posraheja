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
    public class StockInTransit
    {
        private readonly Database database;

        public StockInTransit()
        {
            database = DBConnect.getDBConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.StockInTransit> GetStockInTransitDetails()
        {
            var stockInTransits = new List<Entities.StockInTransit>();

            DbCommand dbCommand = null;

            try
            {
                using(dbCommand = database.GetStoredProcCommand(DBStoredProcedure.GetStockInTransitDetails))
                {
                    using(IDataReader reader = database.ExecuteReader(dbCommand))
                    {
                        while (reader.Read())
                        {
                            var stockInTransit = new Entities.StockInTransit()
                            {
                                VendorName =  DRE.GetNullableString(reader, "vendor_name", null),
                                ItemName = DRE.GetNullableString(reader, "item_name", null),
                                PurchaseBillNo = DRE.GetNullableString(reader, "purchase_bill_no", null),
                                PurchaseBillDate = DRE.GetNullableString(reader, "purchase_bill_date", null),
                                TransporterName = DRE.GetNullableString(reader, "transporter_name", null),
                                LRNo = DRE.GetNullableString(reader, "lr_no", null),
                                PurchaseQty = DRE.GetNullableDecimal(reader, "purchase_qty", null),
                                UnitCode= DRE.GetNullableString(reader, "unit_code", null),
                                PurchaseRate = DRE.GetNullableDecimal(reader, "purchase_rate", null),
                                TotalAmount = DRE.GetNullableDecimal(reader, "total_amount", null)
                            };

                            stockInTransits.Add(stockInTransit);
                        }
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

            return stockInTransits;
        }
    }
}
