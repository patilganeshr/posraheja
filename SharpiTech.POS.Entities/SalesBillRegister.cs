using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesBillRegister
    {
        public Int32? SalesBillId { get; set; }

        public Int32? SalesBillNo { get; set; }

        public string SalesBillDate { get; set; }

        public Int32? CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string LRNo { get; set; }

        public string TransporterName { get; set; }

        public decimal? TaxableValue { get; set; }

        public decimal? GSTAmount { get; set; }

        public decimal? TotalItemAmount { get; set; }

        public decimal? RoundOffAmount { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

    }
}
