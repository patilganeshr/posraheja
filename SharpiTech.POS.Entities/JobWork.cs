using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class JobWork : BaseEntity
    {
        public Int32? JobWorkId { get; set; }

        public Int32? PurchaseBillId { get; set; }

        public string ReferenceNo { get; set; }

        public Int32? KaragirId { get; set; }

        public string KaragirBillNo { get; set; }

        public string JobWorkDate { get; set; }

        public Int32? JobWorkNo { get; set; }

        public Int32? BranchId { get; set; }

        public Int32? CompanyId { get; set; }

        public string PurchaseBillNo { get; set; }

        public Int32? PkgSlipId { get; set; }

        public string KaragirName { get; set; }

        public string KaragirLocation { get; set; }

        public decimal? PurchaseQty { get; set; }

        public decimal? InwardQty { get; set; }

        public decimal? PkgQty { get; set; }

        public decimal? AdjustedMtrs { get; set; }

        public List<JobWorkItem> JobWorkItems { get; set; }

        public List<JobWorkItemMtrAdjustment> JobWorkItemMtrAdjustments { get; set; }

    }
}
