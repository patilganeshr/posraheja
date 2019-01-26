using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesBillPaymentDetails : BaseEntity
    {
        [DatabaseColumn("sales_bill_payment_id")]
        public Int32? SalesBillPaymentId { get; set; }

        [DatabaseColumn("sales_bill_id")]
        public Int32? SalesBillId { get; set; }

        [DatabaseColumn("payment_settlement_id")]
        public Int32? PaymentSettlementId { get; set; }

        [DatabaseColumn("mode_of_payment_id")]
        public Int32? ModeOfPaymentId { get; set; }

        [DatabaseColumn("cash_amount")]
        public decimal? CashAmount { get; set; }

        [DatabaseColumn("credit_card_no")]
        public string CreditCardNo { get; set; }

        [DatabaseColumn("credit_card_amount")]
        public decimal? CreditCardAmount { get; set; }

        [DatabaseColumn("cheque_no")]
        public string ChequeNo { get; set; }

        [DatabaseColumn("cheque_date")]
        public string ChequeDate { get; set; }

        [DatabaseColumn("cheque_drawn_on")]
        public string ChequeDrawnOn { get; set; }

        [DatabaseColumn("cheque_amount")]
        public decimal? ChequeAmount { get; set; }

        [DatabaseColumn("net_banking_reference_no")]
        public string NetBankingReferenceNo { get; set; }

        [DatabaseColumn("net_banking_amount")]
        public decimal? NetBankingAmount { get; set; }

    }
}
