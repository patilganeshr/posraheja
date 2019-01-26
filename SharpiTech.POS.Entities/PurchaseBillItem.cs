using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class PurchaseBillItem : BaseEntity
    {
        [DatabaseColumn("purchase_bill_item_id")]
        public Int32? PurchaseBillItemId { get; set; }

        [DatabaseColumn("purchase_bill_id")]
        public Int32? PurchaseBillId { get; set; }

        [DatabaseColumn("item_id")]
        public Int32? ItemId { get; set; }

        [DatabaseColumn("bale_no")]
        public string BaleNo { get; set; }

        [DatabaseColumn("lr_no")]
        public string LRNo { get; set; }

        [DatabaseColumn("purchase_qty_in_pcs")]
        public decimal? PurchaseQty { get; set; }

        [DatabaseColumn("unit_of_measurement_id")]
        public Int32? UnitOfMeasurementId { get; set; }

        [DatabaseColumn("purchase_rate")]
        public decimal? PurchaseRate { get; set; }

        [DatabaseColumn("type_of_discount")]
        public string TypeOfDiscount { get; set; }

        [DatabaseColumn("cash_discount_percent")]
        public decimal? CashDiscountPercent { get; set; }

        [DatabaseColumn("discount_amount")]
        public decimal? DiscountAmount { get; set; }

        [DatabaseColumn("gst_rate_id")]
        public Int32? GSTRateId { get; set; }

        [DatabaseColumn("tax_id")]
        public Int32? TaxId { get; set; }

        public decimal? GSTAmountAsPerVendorBill { get; set; }

        public string ItemName { get; set; }

        public string HSNCode { get; set; }

        public string UnitCode { get; set; }

        public bool? IsSet { get; set; }

        public Int32? ItemSetSubItemId { get; set; }

        public bool? IsSellAtNetRate { get; set; }

        public string GSTApplicable { get; set; }

        public string TaxName { get; set; }

        public decimal? GSTRate { get; set; }

        public decimal? Amount { get; set; }

        public decimal? GSTAmount { get; set; }

        public decimal? TaxableValue { get; set; }

        public decimal? TotalItemAmount { get; set; }

    }
}
