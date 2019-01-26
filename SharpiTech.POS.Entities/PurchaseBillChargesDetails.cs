using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class PurchaseBillChargesDetails : BaseEntity
    {
        [DatabaseColumn("sales_bill_charge_id")]
        public Int32? PurchaseBillChargeId { get; set; }

        [DatabaseColumn("sales_bill_id")]
        public Int32? PurchaseBillId { get; set; }

        [DatabaseColumn("charge_id")]
        public  Int32? ChargeId { get; set; }

        [DatabaseColumn("charge_amount")]
        public decimal? ChargeAmount { get; set; }

        [DatabaseColumn("is_tax_inclusive")]
        public bool? IsTaxInclusive { get; set; }

        [DatabaseColumn("gst_rate_id")]
        public Int32? GSTRateId { get; set; }

        [DatabaseColumn("tax_id")]
        public Int32? TaxId { get; set; }
        
        public string ChargeName { get; set; }

        public decimal? GSTRate { get; set; }

        public string GSTName { get; set; }

        public decimal? TaxableValue { get; set; }

        public decimal? GSTAmount { get; set; }

        public decimal? TotalAmount { get; set; }

    }
}
