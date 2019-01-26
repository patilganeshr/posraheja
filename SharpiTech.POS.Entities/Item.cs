using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Item : BaseEntity
    {        
        [DatabaseColumn("item_id ")]
        public Int32? ItemId { get; set; }

        public Int32? BrandId { get; set; }

        [DatabaseColumn("item_category_id")]
        public Int32? ItemCategoryId { get; set; }

        [DatabaseColumn("item_code")]
        public string ItemCode { get; set; }

        [DatabaseColumn("item_name")]
        public string ItemName { get; set; }

        [DatabaseColumn("item_desc")]
        public string ItemDesc { get; set; }

        [DatabaseColumn("item_quality_id")]
        public Int32? ItemQualityId { get; set; }

        [DatabaseColumn("generate_item_code_auto")]
        public bool? GenerateItemCodeAuto { get; set; }

        [DatabaseColumn("unit_of_measurement_id")]
        public Int32? UnitOfMeasurementId { get; set; }

        [DatabaseColumn("opening_unit")]
        public Int32? OpeningUnit { get; set; }

        [DatabaseColumn("barcode_no")]
        public string BarcodeNo { get; set; }

        [DatabaseColumn("hsn_no")]
        public string HSNCode { get; set; }

        [DatabaseColumn("reorder_level")]
        public Int32? ReOrderLevel { get; set; }

        [DatabaseColumn("is_set")]
        public bool? IsSet { get; set; }

        public bool? IsSellAtNetRate { get; set; }

        public decimal? PurchaseRate { get; set; }

        public decimal? SaleRate { get; set; }

        public string BrandName { get; set; }

        public string ItemCategoryName { get; set; }

        public string ItemQualityName { get; set; }

        public string UnitCode { get; set; }

        public List<ItemSetSubItem> ItemSetSubItems { get; set; }

        public List<ItemPicture> ItemPictures { get; set; }

        public List<ItemRate> ItemRates { get; set; }

    }
}
