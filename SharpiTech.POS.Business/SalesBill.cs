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
    public class SalesBill
    {
        private readonly DataModel.SalesBill _salesBill;

        public SalesBill()
        {
            _salesBill = new DataModel.SalesBill();
        }

        public List<Entities.SalesBill> GetSalesBillsByBranchId(Int32 branchId, Int32 workingPeriodId)
        {
            return _salesBill.GetSalesBillsByBranchId(branchId, workingPeriodId);
        }

        public List<Entities.SalesBill> GetSalesBillsBySaleType(Int32 branchId, Int32 workingPeriodId, Int32 saleTypeId)
        {
            return _salesBill.GetSalesBillsBySaleType(branchId, workingPeriodId, saleTypeId);
        }

        public List<Entities.SalesBill> GetSalesBillsByCustomerId(Int32 customerId, Int32 workingPeriodId)
        {
            return _salesBill.GetSalesBillsByCustomerId(customerId, workingPeriodId);
        }

        public Entities.SalesBill GetSalesBillDetailsByWorkingPeriodSaleTypeAndSalesBillNo(Int32 workingPeriodId, Int32 saleTypeId, Int32 salesBillNo)
        {
            return _salesBill.GetSalesBillDetailsByWorkingPeriodSaleTypeAndSalesBillNo(workingPeriodId, saleTypeId, salesBillNo);
        }

        public Int32 SaveSalesBill(Entities.SalesBill salesBill)
        {
            return _salesBill.SaveSalesBill(salesBill);
        }
                
        public List<Entities.TypeOfSale> GetTypeOfSales()
        {
            return _salesBill.GetTypeOfSales();
        }

        public bool CheckSalesBillNoIsExists(Entities.SalesBill salesBill)
        {
            return _salesBill.CheckSalesBillNoIsExists(salesBill);
        }

        public Entities.SalesBillItem GetItemNameAsPerBarcode(Int32 goodsReceiptItemId)
        {
            return _salesBill.GetItemNameAsPerBarcode(goodsReceiptItemId);
        }

        public bool CancelSalesBill(Entities.SalesBill salesBill)
        {
            return _salesBill.CancelSalesBill(salesBill);
        }

        public Entities.SalesBillItem GetItemDetailsByItemId(Int32 itemId)
        {
            return _salesBill.GetItemDetailsByItemId(itemId);
        }

        public List<Entities.SalesBill> GetSaleRateHistoryByCustomerAndItem(Int32 customerId, Int32 itemId)
        {
            return _salesBill.GetSaleRateHistoryByCustomerAndItem(customerId, itemId);
        }

        public List<Entities.SaleItemRateHistory> GetItemRateHistory(Int32 customerId, Int32 itemId, Int32 saleTypeId)
        {
            return _salesBill.GetItemRateHistory(customerId, itemId, saleTypeId);
        }

        public string generateReport(Entities.SalesBill salesBill)
        {
            var report = new BuidReport();
            var reportEntity = new Entities.Report();
            var reportName = string.Empty;
            var folderName = string.Empty;
            //var serverPath = HttpContext.Current.Server.MapPath("../POS/");
            
            var parameters = new ArrayList();

            parameters.Add(salesBill.SalesBillId);

            if (salesBill.SaleTypeId == 1) {

                folderName = "CashSalesBills";

                if (salesBill.BranchId == 1)
                {
                    reportName = "CashSaleInvoice.rpt";
                    //reportName = "CashSaleInvoice_A5.rpt";
                }
                else
                {
                    reportName = "CashSaleInvoice_A5.rpt";
                }
            }
            else
            {
                folderName = "CreditSalesBills";
                reportName = "CreditSalesInvoice.rpt";
            }

            var serverPath = HttpContext.Current.Server.MapPath("/POS/");
            reportEntity.DirectoryPath = serverPath + "ApplicationFiles/Sales/Bills/" + Convert.ToString(salesBill.BranchId) + "/" + folderName + "/";

            reportEntity.ReportPath = serverPath + "Reports/" + reportName;
            reportEntity.Parameters = parameters;
            reportEntity.FileStoragePath = reportEntity.DirectoryPath + "BillNo_" + Convert.ToString(salesBill.SalesBillNo) + ".pdf";
            
            return report.GenerateReport(reportEntity, CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        }

        //public string generateReport(Int32 salesBillId)
        //{

        //    string result = "";

        //    string filePath = string.Empty;


        //    TableLogOnInfo _tableLogOnInfo = new TableLogOnInfo();
        //    ReportDocument _reportDocument = new ReportDocument();

        //    SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);

        //    ConnectionInfo _dbConnectionInfo = new ConnectionInfo();
        //    _tableLogOnInfo = new TableLogOnInfo();


        //    try
        //    {
        //        //_reportDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/Reports/CashSaleInvoice.rpt"));
        //        _reportDocument.Load(System.Web.HttpContext.Current.Server.MapPath("../../POS/Reports/CashSaleInvoice.rpt"));

        //        //Reading the db connection file
        //        string serverName = connectionStringBuilder.DataSource;
        //        string databaseName = connectionStringBuilder.InitialCatalog;
        //        string userId = connectionStringBuilder.UserID;
        //        string password = connectionStringBuilder.Password;

        //        _dbConnectionInfo.ServerName = serverName;
        //        _dbConnectionInfo.DatabaseName = databaseName;
        //        _dbConnectionInfo.UserID = userId;
        //        _dbConnectionInfo.Password = password;

        //        foreach (CrystalDecisions.CrystalReports.Engine.Table table in _reportDocument.Database.Tables)
        //        {
        //            _tableLogOnInfo = table.LogOnInfo;
        //            _tableLogOnInfo.ConnectionInfo = _dbConnectionInfo;
        //            table.ApplyLogOnInfo(_tableLogOnInfo);
        //        }

        //        _reportDocument.SetParameterValue(0, salesBillId);

        //        DiskFileDestinationOptions _diskFileDestinationOptions = new DiskFileDestinationOptions();

        //        PdfRtfWordFormatOptions _reportFormatOptions = new PdfRtfWordFormatOptions();

        //        ExportOptions _exportOptions = _reportDocument.ExportOptions;

        //        filePath = HttpContext.Current.Server.MapPath("../../POS/Sales/Bills/" +  "BillNo_" + salesBillId.ToString() + ".pdf");

        //        _diskFileDestinationOptions.DiskFileName =  filePath;
        //        _exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        //        _exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        //        _exportOptions.ExportDestinationOptions = _diskFileDestinationOptions;
        //        _exportOptions.ExportFormatOptions = _reportFormatOptions;

        //        _reportDocument.Export();

        //        _reportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, false, filePath);

        //        result = filePath;
        //    }
        //    catch (Exception ex)
        //    {
        //        result = "";

        //        throw new Exception("Error as " + ex.Message);
        //        //LogEntry.LogExceptions.WriteLog("ExportCrystalReportClassLibrary", ex.GetType().ToString(), ex.Message.ToString(), ex.Source.ToString(), "WEB");
        //    }
        //    finally
        //    {
        //        _reportDocument.Close();
        //    }

        //    return result;
        //}

    }
}
