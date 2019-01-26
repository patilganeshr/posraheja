using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class JobWorkController : ApiController
    {
        private readonly Business.JobWork _jobWork;

        public JobWorkController()
        {
            _jobWork = new Business.JobWork();
        }

        [Route("GetAllJobWorks")]
        public List<Entities.JobWork> GetAllJobWorks() {
            return _jobWork.GetAllJobWorks();
        }

        [Route("GetPurchaseBillNos")]
        public List<Entities.JobWork> GetPurchaseBillNos()
        {
            return _jobWork.GetPurchaseBillNos();
        }

        [Route("GetKaragirList/{purchaseBillId}")]
        public List<Entities.JobWork> GetKaragirList(Int32 purchaseBillId)
        {
            return _jobWork.GetKaragirList(purchaseBillId);
        }

        [Route("GetKaragirAndAdditionalDetails/{pkgSlipId}")]
        public Entities.JobWork GetKaragirAndAdditionalDetails(Int32 pkgSlipId)
        {
            return _jobWork.GetKaragirAndAdditionalDetails(pkgSlipId);
        }

        [HttpPost]
        [Route("SaveJobWork")]
        public Int32 SaveJobWork(Entities.JobWork jobWork)
        {
            return _jobWork.SaveJobWork(jobWork);
        }

        [HttpPost]
        [Route("PrintKaragirBill")]
        public string PrintKaragirBill(Entities.JobWork jobWork)
        {
            return _jobWork.generateReport(jobWork);
        }

    }
}
