using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class JobWorkItemMtrAdjustment
    {
        private readonly DataModel.JobWorkItemMtrAdjustment _jobWorkItemMtrAdjustment;

        public JobWorkItemMtrAdjustment()
        {
            _jobWorkItemMtrAdjustment = new DataModel.JobWorkItemMtrAdjustment();
        }

        public List<Entities.JobWorkItemMtrAdjustment> GetJobWorkItemReferenceNoDetails(Int32 pkgSlipId)
        {
            return _jobWorkItemMtrAdjustment.GetJobWorkItemReferenceNoDetails(pkgSlipId);
        }

    }
}
