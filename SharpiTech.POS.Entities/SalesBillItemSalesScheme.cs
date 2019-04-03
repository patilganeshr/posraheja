using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesBillItemSalesScheme
    {
        public Int32? SalesSchemeId { get; set; }

        public string SchemeName { get; set; }

        public decimal? DiscountPercent { get; set; }

        public decimal? DiscountAmount { get; set; }

    }
}
