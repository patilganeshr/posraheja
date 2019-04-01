using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesSchemeRegister : BaseEntity
    {
        public Int32? SalesSchemeId { get; set; }

        public Int32? BrandId { get; set; }

        public Int32? ItemCategoryId { get; set; }

        public Int32? ItemId { get; set; }

        public decimal? DiscountPercent { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? MaxDiscountAmount { get; set; }

        public Int32? BuyQty { get; set; }

        public Int32? FreeQty { get; set; }

        public string SaleStartDate { get; set; }

        public string SaleEndDate { get; set; }

        public Int32? BranchId { get; set; }

        public string BrandName { get; set; }

        public string ItemCategoryName { get; set; }

        public string ItemName { get; set; }

        public Int32? CompanyId { get; set; }

        public string BranchName { get; set; }

        public string CompanyName { get; set; }

    }
}
