using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesReturnBillItem : BaseEntity
    {
        public Int32? SalesReturnBillItemId { get; set; }

        public Int32? SalesReturnBillId { get; set; }

        public Int32? SalesBillItemId { get; set; }

        public decimal? SaleQty { get; set; }

        public decimal? ReturnQty { get; set; }
        
        public string ItemRemarks { get; set; }

        public Int32? GoodsReceiptItemId { get; set; }

        public string HSNCode { get; set; }

        public string ItemName { get; set; }

        public Int32? ItemId { get; set; }

        public Int32? UnitOfMeasurementId { get; set; }
            
        public string UnitCode { get; set; }

        public decimal? SaleRate { get; set; }

        public string TypeOfDiscount { get; set; }

        public  decimal? CashDiscountPercent { get; set; }

        public decimal? DiscountAmount { get; set; }

        public bool? IsTaxInclusive { get; set; }

        public decimal? TaxableValue { get; set; }

        public decimal? TotalAmountAfterDiscount { get; set; }

        public Int32? GSTRateId { get; set; }

        public decimal? GSTRate { get; set; }

        public Int32? TaxId { get; set; }

        public string GSTName { get; set; }

        public decimal? GSTAmount { get; set; }

        public decimal? TotalItemAmount { get; set; }
        
    }
}
