using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class PaymentSettlement : BaseEntity
    {
        [DatabaseColumn("payment_settlement_id")]
        public Int32? PaymentSettlementId { get; set; }

        [DatabaseColumn("payment_settlement")]
        public string SettlementOfPayment { get; set; }
    }
}
