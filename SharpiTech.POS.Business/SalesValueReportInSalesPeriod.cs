using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class SalesValueReportInSalesPeriod
    {
        private readonly DataModel.SalesValueReportInSalesPeriod _salesValueReport;
        public SalesValueReportInSalesPeriod()
        {
            _salesValueReport = new DataModel.SalesValueReportInSalesPeriod();
        }

        public List<Entities.SalesByValueReportInSalesPeriod> GetSalesValueReport()
        {
            return _salesValueReport.GetSalesByValueReportInSalesPeriods();
        }

    }
}
