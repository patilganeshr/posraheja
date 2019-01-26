using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesReturnBill : BaseEntity
    {
        public Int32? SalesReturnBillId { get; set; }

        public Int32? ConsigneeId { get; set; }

        public Int32? SalesReturnBillNo { get; set; }

        public string SalesReturnBillDate { get; set; }

        public Int32? SaleTypeId { get; set; }

        public Int32? SalesBillId { get; set; }

        public Int32? SalesBillNo { get; set; }

        public string SalesBillNoCustom { get; set; }

        public string SalesBillDate { get; set; }

        public string CustomerName { get; set; }

        public List<Entities.SalesReturnBillItem> SalesReturnBillItems { get; set; }

        public List<Entities.SalesReturnBillAdjustment> SalesReturnBillAdjustments { get; set; }

        public Int32? BranchId { get; set; }

        public Int32? CompanyId { get; set; }

        public string CompanyName { get; set; }

        public bool? IsTaxInclusive { get; set; }

        public string ConsigneeName { get; set; }

        public string SaleType { get; set; }

        public string BranchName { get; set; }

        public decimal? TotalReturnQty { get; set; }
        
        public decimal? SalesReturnTotalAmount { get; set; }

        public decimal? SalesBillTotalAmount { get; set; }

    }
}
