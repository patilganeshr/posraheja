using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesReturnBillAdjustment : BaseEntity
    {
        public Int32? SalesReturnBillAdjustmentId { get; set; }

        public Int32? SalesReturnBillId { get; set; }

        public Int32? SalesBillId { get; set; }

        public string SalesBillNo { get; set; }

        public decimal? SalesBillTotalAmount { get; set; }

    }
}
