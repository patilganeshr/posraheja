using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class VoucherSync
    {
        public string VoucherType { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string FromBillNo { get; set; }

        public string ToBillNo { get; set; }

        public string VoucherNo { get; set; }

        public string VoucherYr { get; set; }

        public string FromVoucherNo { get; set; }

        public string ToVoucherNo { get; set; }

        public Int32? WorkingPeriodId { get; set; }

    }
}
