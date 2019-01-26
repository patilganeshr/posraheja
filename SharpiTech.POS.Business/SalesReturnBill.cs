using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

using System.IO;
using System.Configuration;
using System.Web;
using System.Web.Configuration;

using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SharpiTech.POS.Business
{
    public class SalesReturnBill
    {
        private readonly DataModel.SalesReturnBill _salesReturnBill;

        public SalesReturnBill()
        {
            _salesReturnBill = new DataModel.SalesReturnBill();
        }

        public bool CheckSalesReturnBillNoIsExists(Entities.SalesReturnBill salesReturnBill)
        {
            return _salesReturnBill.CheckSalesReturnBillNoIsExists(salesReturnBill);
        }

            public List<Entities.SalesReturnBill> GetAllSalesReturnBill()
        {
            return _salesReturnBill.GetAllSalesReturnBills();
        }

        public List<Entities.SalesReturnBill> GetSalesReturnBillsBySalesType(Int32 salesTypeId)
        {
            return _salesReturnBill.GetSalesReturnBillsBySalesType(salesTypeId);
        }

        public List<Entities.SalesReturnBill> GetSalesReturnBillsByBranchWorkingPeriodAndSalesType(Int32 branchId, Int32 workingPeriodId, Int32 salesTypeId)
        {
            return _salesReturnBill.GetSalesReturnBillsByBranchWorkingPeriodAndSalesType(branchId, workingPeriodId, salesTypeId);
        }

        public List<Entities.SalesReturnBill> GetSalesBillsByConsignee(Int32 consigneeId)
        {
            return _salesReturnBill.GetSalesBillsByConsignee(consigneeId);
        }

        public List<Entities.ClientAddress> GetConsigneeFromSalesBills(Entities.SalesReturnBill salesReturnBill)
        {
            return _salesReturnBill.GetConsigneeFromSalesBills(salesReturnBill);
        }

        public Entities.SalesReturnBill GetSalesBillAdditionalDetails(Entities.SalesReturnBill salesReturnBill)
        {
            return _salesReturnBill.GetSalesBillAdditionalDetails(salesReturnBill);
        }
                
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBills"></param>
        /// <returns></returns>
        public Int32? SaveSalesReturnBill(Entities.SalesReturnBill salesReturnBills)
        {
            return _salesReturnBill.SaveSalesReturnBill(salesReturnBills);           
        }

        public string generateReport(Entities.SalesReturnBill salesReturnBill)
        {
            var report = new BuidReport();
            var reportEntity = new Entities.Report();
            var reportName = string.Empty;
            var folderName = string.Empty;
            //var serverPath = HttpContext.Current.Server.MapPath("../POS/");

            var parameters = new ArrayList();

            parameters.Add(salesReturnBill.SalesReturnBillId);

            if (salesReturnBill.SaleTypeId == 1)
            {

                folderName = "CashSalesReturnBills";

                if (salesReturnBill.BranchId == 1)
                {
                    reportName = "CashSalesReturnInvoice.rpt";
                }
                else
                {
                    reportName = "CashSalesReturnInvoice_A5.rpt";
                }
            }
            else
            {
                folderName = "CreditSalesReturnBills";
                reportName = "CreditSalesReturnInvoice.rpt";
            }

            var serverPath = HttpContext.Current.Server.MapPath("/POS/");
            reportEntity.DirectoryPath = serverPath + "ApplicationFiles/SalesReturn/Bills/" + Convert.ToString(salesReturnBill.BranchId) + "/" + folderName + "/";

            reportEntity.ReportPath = serverPath + "Reports/" + reportName;
            reportEntity.Parameters = parameters;
            reportEntity.FileStoragePath = reportEntity.DirectoryPath + "BillNo_" + Convert.ToString(salesReturnBill.SalesReturnBillNo) + ".pdf";

            return report.GenerateReport(reportEntity, CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        }

    }
}
