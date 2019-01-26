using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SaleItemRateHistory
    {
        public string CustomerName { get; set; }

        public Int32? SalesBillId { get; set; }

        public Int32? SalesBillNo { get; set; }

        public string SalesBillDate { get; set; }

        public Int32? SaleTypeId { get; set; }

        public Int32? ItemId { get; set; }

        public decimal? SaleRate { get; set; }

    }
}
