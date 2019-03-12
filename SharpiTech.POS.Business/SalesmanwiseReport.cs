using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace SharpiTech.POS.Business
{
    public class SalesmanwiseReport
    {
        private readonly DataModel.SalesmanwiseReport _salesmanwiseReport;

        public SalesmanwiseReport()
        {
            _salesmanwiseReport = new DataModel.SalesmanwiseReport();

        }

        public List<Entities.SalesmanwiseReport> GetDailySalesQtyReport(Int32? salesmanId, string salesBillDate)
        {

            return _salesmanwiseReport.GetDailySalesQtyReport(salesmanId, salesBillDate);
        }

        public List<Entities.SalesmanwiseReport> GetDailySalesQtyReportWithSaleRateAndPurchaseRate(Int32? salesmanId, string salesBillDate)
        {
            return _salesmanwiseReport.GetDailySalesQtyReportWithSaleRateAndPurchaseRate(salesmanId, salesBillDate);
        }

        public List<Entities.SalesmanwiseReport> GetSalesmanwiseItemwiseDailySalesValueReport(Int32? salesmanId, string salesBillDate)
        {
            return _salesmanwiseReport.GetSalesmanwiseItemwiseDailySalesValueReport(salesmanId, salesBillDate);
        }


    }
}


//public List<T> DataTableToList<T>(this DataTable table) where T : class, new()
//{
//    try
//    {
//        List<T> list = new List<T>();

//        foreach (var row in table.AsEnumerable())
//        {
//            T obj = new T();

//            foreach (var prop in obj.GetType().GetProperties())
//            {
//                try
//                {
//                    PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
//                    propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
//                }
//                catch
//                {
//                    continue;
//                }
//            }

//            list.Add(obj);
//        }

//        return list;
//    }
//    catch
//    {
//        return null;
//    }
//}