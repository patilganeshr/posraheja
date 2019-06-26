using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesByValueReportInSalesPeriod
    {
        public string CompanyName { get; set; }

        public string BranchName { get; set; }

        public string SaleType { get; set; }

        public string BrandName { get; set; }

        public string ItemCategoryName { get; set; }

        public string ItemName { get; set; }

        public string TypeOfDiscount { get; set; }

        public decimal? SaleQty { get; set; }

        public string UnitCode { get; set; }

        public decimal? SaleRate { get; set; }

        public decimal? WholesaleRate { get; set; }

        public decimal? RetailRate { get; set; }


        public decimal? Amount { get; set; }

        public string SalesScheme { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? TotalItemAmount { get; set; }

        public string SalesBillDate { get; set; }

        public string Salesman { get; set; }

        public Int32? BrandId { get; set; }

        public Int32? ItemCategoryId { get; set; }

        public Int32? ItemId { get; set; }

        public Int32? SalesmanId { get; set; }

        public decimal? MinDiscountAmount { get; set; }

        public decimal? MaxDiscountAmount { get; set; }

        public string SalesBillFromDate { get; set; }

        public string SalesBillToDate { get; set; }

    }
}
