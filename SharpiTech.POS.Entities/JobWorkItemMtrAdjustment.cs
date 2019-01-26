using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class JobWorkItemMtrAdjustment : BaseEntity
    {
        public Int32? JobWorkItemMtrAdjustmentId{ get; set; }

        public Int32? JobWorkId { get; set; }

        public string ReferenceNo { get; set; }

        public decimal? AdjustedMtrs { get; set; }
        
        public Int32? GoodsReceiptItemId { get; set; }

        public decimal? PkgQty { get; set; }

        public decimal? BalanceMtrs { get; set; }

    }
}
