using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SharpiTech.POS.Business
{
    public class JobWork
    {
        private readonly DataModel.JobWork _jobWork;

        public JobWork()
        {
            _jobWork = new DataModel.JobWork();
        }

        public List<Entities.JobWork> GetAllJobWorks()
        {
            return _jobWork.GetAllJobWorks();
        }

        public List<Entities.JobWork> GetPurchaseBillNos()
        {
            return _jobWork.GetPurchaseBillNos();
        }

        public List<Entities.JobWork> GetKaragirList(Int32 purchaseBillId)
        {
            return _jobWork.GetKaragirList(purchaseBillId);
        }

        public Entities.JobWork GetKaragirAndAdditionalDetails(Int32 pkgSlipId)
        {
            return _jobWork.GetKaragirAndAdditionalDetails(pkgSlipId);
        }

        public Int32 SaveJobWork(Entities.JobWork jobWork)
        {
            return _jobWork.SaveJobWork(jobWork);
        }

        public string generateReport(Entities.JobWork jobWork)
        {
            var report = new BuidReport();
            var reportEntity = new Entities.Report();
            var reportName = string.Empty;
            var folderName = string.Empty;
            //var serverPath = HttpContext.Current.Server.MapPath("../POS/");

            var parameters = new ArrayList();

            parameters.Add(jobWork.KaragirBillNo);


            folderName = jobWork.BranchId.ToString() + "/" + jobWork.FinancialYear + "/";

                reportName = "KaragirBill.rpt";
            

            var serverPath = HttpContext.Current.Server.MapPath("/POS/");
            reportEntity.DirectoryPath = serverPath + "ApplicationFiles/JobWork/KaragirBills/" + folderName;

            reportEntity.ReportPath = serverPath + "Reports/" + reportName;
            reportEntity.Parameters = parameters;
            reportEntity.FileStoragePath = reportEntity.DirectoryPath + Convert.ToString(jobWork.KaragirBillNo) + ".pdf";

            return report.GenerateReport(reportEntity, CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        }

    }
}
