using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesOrder: BaseEntity
    {
        [DatabaseColumn("sales_order_id")]
        public Int32? SalesOrderId { get; set; }

        [DatabaseColumn("sales_order_no")]
        public Int32? SalesOrderNo { get; set; }

        [DatabaseColumn("sales_order_no_series")]
        public string SalesOrderNoSeries { get; set; }

        [DatabaseColumn("sales_order_date")]
        public string SalesOrderDate { get; set; }

        [DatabaseColumn("customer_id")]
        public Int32? CustomerId { get; set; }

        [DatabaseColumn("branch_id")]
        public Int32? BranchId { get; set; }

        [DatabaseColumn("gst_applicable")]
        public string GSTApplicable { get; set; }

        public bool? IsTaxInclusive { get; set; }

        public string CustomerName { get; set; }

        public string BranchName { get; set; }

        public decimal? TotalOrderQty { get; set; }

        public decimal? TotalOrderAmount { get; set; }

        public List<SalesOrderItem> SalesOrderItems { get; set; }
    }
}
