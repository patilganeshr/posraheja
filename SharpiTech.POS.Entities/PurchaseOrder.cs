using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class PurchaseOrder : BaseEntity
    {
        [DatabaseColumn("purchase_order_id")]
        public Int32? PurchaseOrderId { get; set; }

        [DatabaseColumn("vendor_id")]
        public Int32? VendorId { get; set; }

        [DatabaseColumn("vendor_reference_no")]
        public string VendorReferenceNo { get; set; }

        [DatabaseColumn("purchase_order_no")]
        public string PurchaseOrderNo { get; set; }

        [DatabaseColumn("purchase_order_date")]
        public string PurchaseOrderDate { get; set; }

        [DatabaseColumn("payment_term_id")]
        public string PaymentTermId { get; set; }

        [DatabaseColumn("discount_rate_for_payment")]
        public decimal? DiscountRateForPayment { get; set; }

        [DatabaseColumn("discount_applicable_before_payment_days")]
        public decimal? DiscountApplicableBeforePaymentDays { get; set; }

        [DatabaseColumn("no_of_days_for_payment")]
        public Int32? NoOfDaysForPayment{ get; set; }

        public Int32? OrderStatusId { get; set; }

        public string TermShortCode { get; set; }

        public string OrderStatusName { get; set; }

        [DatabaseColumn("branch_id")]
        public Int32? BranchId { get; set; }
                
        public string VendorName { get; set; }

        public Int32? CompanyId { get; set; }
        
        public string CompanyName { get; set; }

        public string BranchName { get; set; }

        public List<Entities.PurchaseOrderItem> PurchaseOrderItems { get; set; }

    }
}
