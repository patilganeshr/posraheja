using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class OutwardDetails : BaseEntity
    {
        [DatabaseColumn("outward_id")]
        public Int32? OutwardId { get; set; }

        [DatabaseColumn("pkg_slip_id")]
        public Int32? PkgSlipId { get; set; }

        [DatabaseColumn("outward_no")]
        public Int32? OutwardNo { get; set; }

        [DatabaseColumn("outward_date")]
        public string OutwardDate { get; set; }

        [DatabaseColumn("transporter_id")]
        public Int32? TransporterId { get; set; }

        [DatabaseColumn("vehicle_no")]
        public string VehicleNo { get; set; }

        [DatabaseColumn("branch_id")]
        public Int32? GoodsSentLocationId { get; set; }

        public string TransporterName { get; set; }

        public string GoodsSentLocationName { get; set; }

        public Int32? CompanyId { get; set; }

        public string CompanyName { get; set; }

        public Int32? BranchId { get; set; }

        public string BranchName { get; set; }

        public string BaleNo { get; set; }

        public Int32? PurchaseBillItemId { get; set; }

        public string FromToLocation { get; set; }

        public  string FromLocation { get; set; }

        public Int32? FromLocationId { get; set; }

        public Int32? ToLocationId { get; set; }

        public string ToLocation { get; set; }

        public string TypeOfTransfer { get; set; }
        
        public string ReferenceNo { get; set; }

        public List<OutwardGoodsDetails> OutwardGoodsDetails { get; set; }

        
    }
}
