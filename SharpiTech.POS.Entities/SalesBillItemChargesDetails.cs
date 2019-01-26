using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesBillItemChargesDetails : BaseEntity
    {
        [DatabaseColumn("sales_bill_item_charge_id")]
        public Int32? SalesBillItemChargeId { get; set; }

        [DatabaseColumn("sales_bill_item_id")]
        public Int32? SalesBillItemId { get; set; }

        [DatabaseColumn("charge_id")]
        public Int32? ChargeId { get; set; }

        [DatabaseColumn("charge_amount")]
        public decimal? ChargeAmount { get; set; }

        public bool? IsTaxInclusive { get; set;}

        [DatabaseColumn("gst_rate_id")]
        public Int32? GSTRateId { get; set; }

        [DatabaseColumn("tax_id")]
        public Int32? TaxId { get; set; }

        public string ChargeName { get; set; }

        public decimal? GSTRate { get; set; }

        public string GSTName { get; set; }

        public string TaxName { get; set; }
    }
}
