using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesOrderItem : BaseEntity
    {
        [DatabaseColumn("sales_order_item_id")]
        public Int32? SalesOrderItemId { get; set; }

        [DatabaseColumn("sales_order_id")]
        public Int32? SalesOrderId { get; set; }

        [DatabaseColumn("item_id")]
        public Int32? ItemId { get; set; }

        [DatabaseColumn("sale_qty_in_pcs")]
        public decimal? SaleQtyInPcs { get; set; }

        [DatabaseColumn("sale_rate")]
        public decimal? SaleRate { get; set; }

        public decimal? OrderQty { get; set; }

        public Int32? UnitOfMeasurementId { get; set; }

        [DatabaseColumn("tax_id")]
        public Int32? TaxId { get; set; }

        [DatabaseColumn("rate_category_id")]
        public Int32? RateCategoryId { get; set; }

        [DatabaseColumn("gst_rate_id")]
        public Int32? GSTRateId { get; set; }

        public string ItemName { get; set; }

        public string TaxName { get; set; }

        public decimal? GSTRate { get; set; }

        public decimal? Amount { get; set; }

        public decimal? TaxAmount { get; set; }

        public decimal? GSTAmount { get; set; }

        public decimal? TotalItemAmount { get; set; }
    }
}
