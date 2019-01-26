using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class PurchaseBill : BaseEntity
    {
        [DatabaseColumn("purchase_bill_id")]
        public Int32? PurchaseBillId { get; set; }

        [DatabaseColumn("vendor_id")]
        public Int32? VendorId { get; set; }

        [DatabaseColumn("transporter_id")]
        public Int32? TransporterId { get; set; }

        [DatabaseColumn("purchase_bill_no")]
        public string PurchaseBillNo { get; set; }

        [DatabaseColumn("purchase_bill_date")]
        public string PurchaseBillDate { get; set; }

        [DatabaseColumn("challan_no")]
        public string ChallanNo { get; set; }

        [DatabaseColumn("truck_no")]
        public string TruckNo { get; set; }

        [DatabaseColumn("total_weight")]
        public decimal? TotalWeight { get; set; }

        [DatabaseColumn("gst_applicable")]
        public string GSTApplicable { get; set; }

        [DatabaseColumn("is_tax_inclusive")]
        public bool? IsTaxInclusive { get; set; }

        [DatabaseColumn("is_tax_round_off")]
        public bool? IsTaxRoundOff { get; set; }

        [DatabaseColumn("is_composition_bill")]
        public bool? IsCompositionBill { get; set; }

        [DatabaseColumn("is_sample")]
        public bool? IsSample { get; set; }

        public decimal? TotalGSTAmountAsPerVendorBill { get; set; }

        [DatabaseColumn("branch_id")]
        public Int32? BranchId { get; set; }

        public string BranchName { get; set; }

        public Int32? CompanyId { get; set; }

        public string CompanyName { get; set; }

        public decimal? TotalQty { get; set; }

        public string UnitOfMeasurement { get; set; }

        public decimal? TotalAmount { get; set; }

        public string VendorName { get; set; }

        public string TransporterName { get; set; }

        public List<Entities.PurchaseBillItem> PurchaseBillItems { get; set; }

        public List<Entities.PurchaseBillChargesDetails> PurchaseBillChargesDetails { get; set; }

    }
}
