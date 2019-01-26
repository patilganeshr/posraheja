using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class InwardDetails : BaseEntity
    {
        [DatabaseColumn("inward_id")]
        public Int32? InwardId { get; set; }

        [DatabaseColumn("inward_no")]
        public Int32? InwardNo { get; set; }

        [DatabaseColumn("inward_date")]
        public string InwardDate { get; set; }

        [DatabaseColumn("reference_id")]
        public Int32? ReferenceId { get; set; }

        public string ReferenceNo { get; set; }

        public string ReferenceDate { get; set; }

        [DatabaseColumn("from_location_id")]
        public Int32? FromLocationId { get; set; }

        [DatabaseColumn("to_location_id")]
        public Int32? ToLocationId { get; set; }

        [DatabaseColumn("reference_type")]
        public string ReferenceType { get; set; }

        [DatabaseColumn("remarks")]
        public string remarks { get; set; }

        public string FromLocationName { get; set; }

        public string ToLocationName { get; set; }

        [DatabaseColumn("transporter_id")]
        public Int32? TransporterId { get; set; }

        public string TransporterName { get; set; }

        public string TypeOfTransfer { get; set; }

        public Int32? TypeOfTransferId { get; set; }

        [DatabaseColumn("vehicle_no")]
        public string VehicleNo { get; set; }

        public Int32? BranchId { get; set; }

        public string BranchName { get; set; }

        public Int32? CompanyId { get; set; }

        public string CompanyName { get; set; }

        public List<InwardGoodsDetails> InwardGoodsDetails { get; set; }

    }
}
