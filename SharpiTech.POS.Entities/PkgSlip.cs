using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class PkgSlip : BaseEntity
    {
        [DatabaseColumn("pkg_slip_id")]
        public Int32? PkgSlipId { get; set; }

        [DatabaseColumn("pkg_slip_no")]
        public Int32? PkgSlipNo { get; set; }

        [DatabaseColumn("pkg_slip_date")]
        public string PkgSlipDate { get; set; }

        [DatabaseColumn("bale_no")]
        public String BaleNo { get; set; }

        [DatabaseColumn("from_location_id")]
        public Int32? FromLocationId { get; set; }

        public string FromLocation { get; set; }

        public Int32? ToLocationId { get; set; }

        public string ToLocation { get; set; }

        [DatabaseColumn("type_of_transfer_id")]
        public Int32? TypeOfTransferId { get; set; }

        public string TransferType { get; set; }

        public Int32? KaragirId { get; set; }

        public string KaragirName { get; set; }

        public string ReferenceNo { get; set; }

        [DatabaseColumn("branch_id")]
        public Int32? BranchId { get; set; }

        public string BranchName { get; set; }

        public Int32? CompanyId { get; set; }

        public string CompanyName { get; set; }

        public Int32? VendorId { get; set; }

        public string VendorName { get; set; }

        public Int32? PurchaseBillId { get; set; }

        public string PurchaseBillNo { get; set; }

        public decimal? TotalPkgSlipQty { get; set; }

        public List<PkgSlipItem> PkgSlipItems { get; set; }
        
    }
}
