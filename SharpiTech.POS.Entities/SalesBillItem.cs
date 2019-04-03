using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesBillItem : BaseEntity
    {
        [DatabaseColumn("sales_bill_item_id")]
        public Int32? SalesBillItemId { get; set; }

        [DatabaseColumn("sales_bill_id")]
        public Int32? SalesBillId { get; set; }

        [DatabaseColumn("goods_receipt_item_id")]
        public Int32? GoodsReceiptItemId { get; set; }

        public Int32? InwardGoodsId { get; set; }

        [DatabaseColumn("item_id")]
        public Int32? ItemId { get; set; }

        [DatabaseColumn("sale_qty")]
        public decimal? SaleQty { get; set; }

        [DatabaseColumn("unit_of_measurement_id")]
        public decimal? UnitOfMeasurementId { get; set; }

        [DatabaseColumn("sale_rate")]
        public decimal? SaleRate { get; set; }

        [DatabaseColumn("type_of_discount")]
        public string TypeOfDiscount { get; set; }

        [DatabaseColumn("cash_discount_percent")]
        public decimal? CashDiscountPercent { get; set; }

        [DatabaseColumn("discount_amount")]
        public decimal? DiscountAmount { get; set; }

        [DatabaseColumn("tax_id")]
        public Int32? TaxId { get; set; }

        [DatabaseColumn("gst_rate_id")]
        public Int32? GSTRateId { get; set; }

        public string ItemName { get; set; }

        public string HSNCode { get; set; }

        public string TaxName { get; set; }

        public string GSTName { get; set; }

        public decimal? GSTRate { get; set; }

        public decimal? Amount { get; set; }

        public decimal? TotalAmountAfterDiscount { get; set; }

        public decimal? TaxableValue { get; set; }

        public decimal? GSTAmount { get; set; }

        public decimal? TotalItemAmount { get; set; }

        public string RateAdjustment { get; set; }

        public string RateAdjustmentRemarks { get; set; }

        public string UnitCode { get; set; }

        public decimal? StockQty { get; set; }

        public bool? IsSet { get; set; }

        public bool? IsSellAtNetRate { get; set; }

        public List<Entities.SalesBillItemSalesScheme> SalesSchemes { get; set; }

        public List<Entities.SalesBillItemChargesDetails> SalesBillItemCharges { get; set; }

        public Int32? SalesSchemeId { get; set; }

        public string SchemeName { get; set; }

        public decimal? SchemeDiscountPercent { get; set; }

        public decimal? SchemeDiscountAmount { get; set; }

    }
}
