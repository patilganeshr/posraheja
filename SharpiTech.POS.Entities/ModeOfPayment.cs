using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ModeOfPayment : BaseEntity
    {
        [DatabaseColumn("mode_of_payment_id")]
        public Int32? ModeOfPaymentId { get; set; }

        [DatabaseColumn("mode_of_payment")]
        public string PaymentMode { get; set; }
    }
}
