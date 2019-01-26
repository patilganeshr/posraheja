using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SaleQtyReport
    {
        public string CompanyName { get; set; }
        
        public string BranchName { get; set; }

        public string SaleType { get; set; }

        public string MonthName { get; set; }

        public Int32? ItemCategoryId { get; set; }

        public string ItemCategoryName { get; set; }

        public string ItemQuality { get; set; }

        public string ItemName { get; set; }

        public decimal? SaleQty { get; set; }

        public string UnitCode { get; set; }

        public Int32? CompanyId { get; set; }

        public Int32? BranchId { get; set; }

        public Int32? MonthId { get; set; }

        public Int32? SaleTypeId { get; set; }

        public Int32? ItemQualityId { get; set; }

        public Int32? ItemId { get; set; }
    }
}
