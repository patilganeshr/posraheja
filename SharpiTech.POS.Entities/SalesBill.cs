using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesBill : BaseEntity
    {
        [DatabaseColumn("sales_bill_id")]
        public Int32? SalesBillId { get; set; }

        [DatabaseColumn("sales_order_id")]
        public Int32? SalesOrderId { get; set; }

        [DatabaseColumn("sales_bill_no")]
        public Int32? SalesBillNo { get; set; }

        [DatabaseColumn("sales_order_no_series")]
        public string SalesBillNoSeries { get; set; }

        [DatabaseColumn("sales_bill_date")]
        public string SalesBillDate { get; set; }

        [DatabaseColumn("customer_id")]
        public Int32? CustomerId { get; set; }

        [DatabaseColumn("consignee_id")]
        public Int32? ConsigneeId { get; set; }

        [DatabaseColumn("salesman_id")]
        public Int32? SalesmanId { get; set; }

        [DatabaseColumn("sale_type_id")]
        public Int32? SaleTypeId { get; set; }

        [DatabaseColumn("branch_id")]
        public Int32? BranchId { get; set; }

        public Int32? CompanyId { get; set; }

        [DatabaseColumn("is_tax_inclusive")]
        public bool? IsTaxInclusive { get; set; }

        [DatabaseColumn("gst_applicable")]
        public string GSTApplicable { get; set; }

        public Int32? SalesOrderNo { get; set; }

        public string CustomerName { get; set; }

        public string ConsigneeName { get; set; }

        public string SalesmanName { get; set; }

        public string BranchName { get; set; }

        public string CompanyName { get; set; }

        public string SaleType { get; set; }

        public decimal? TotalSaleQty { get; set; }

        public decimal? TotalSaleAmount { get; set; }

        public decimal? SaleRate { get; set; }

        public List<SalesBillItem> SalesBillItems { get; set; }

        public List<Entities.SalesBillDeliveryDetails> SalesBillDeliveryDetails { get; set; }

        public List<Entities.SalesBillPaymentDetails> SalesBillPaymentDetails { get; set; }

        public List<Entities.SalesBillChargesDetails> SalesBillChargesDetails { get; set; }
    }
}
