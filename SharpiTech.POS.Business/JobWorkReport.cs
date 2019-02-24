using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class JobWorkReport
    {
        private readonly DataModel.JobWorkReport _jobWorkReport;

        public JobWorkReport()
        {
            _jobWorkReport = new DataModel.JobWorkReport();
        }


        public List<Entities.JobWorkItemSentToKaragir> GetJobWorkItemsSentToKaragir()
        {
            return _jobWorkReport.GetJobWorkItemsSentToKaragir();
        }

        public List<Entities.JobWorkItemsBalanceQtyReport> GetJobWorkItemsBalanceQtyDetails()
        {
            return _jobWorkReport.GetJobWorkItemsBalanceQtyDetails();
        }
    }
}
