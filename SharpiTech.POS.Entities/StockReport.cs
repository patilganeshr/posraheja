using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class StockReport
    {
        public Int32? ItemId { get; set; }

        public string ItemName { get; set; }

        public Int32? ItemQualityId { get; set; }

        public string ItemQuality { get; set; }

        public Int32? BrandId { get; set; }

        public string BrandName { get; set; }

        public Int32? ItemCategoryId { get; set; }

        public string ItemCategoryName { get; set; }

        public Int32? VendorId { get; set; }

        public string VendorName { get; set; }

        public decimal? QtyInPcs { get; set; }

        public decimal? QtyInMtrs { get; set; }

        public Int32? LocationId { get; set; }

        public string LocationName { get; set; }

        public string CustomerCategoryName { get; set; }

        public decimal? FlatRate { get; set; }

        public decimal? CategoryA { get; set; }

        public decimal? CategoryC { get; set; }

        public decimal? StockQty { get; set; }

        public string UnitCode { get; set; }

        public decimal? PurchaseCost { get; set; }

    }
}
