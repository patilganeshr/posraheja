using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class GoodsReceiptItem : BaseEntity
    {
        [DatabaseColumn("goods_receipt_item_id")]
        public Int32? GoodsReceiptItemId { get; set; }

        [DatabaseColumn("goods_receipt_id")]
        public Int32? GoodsReceiptId { get; set; }

        [DatabaseColumn("purchase_bill_item_id")]
        public Int32? PurchaseBillItemId { get; set; }
                
        public Int32? ItemId { get; set; }

        [DatabaseColumn("received_qty")]
        public decimal? ReceivedQty { get; set; }

        [DatabaseColumn("unit_of_measurement_id")]
        public Int32? UnitOfMeasurementId { get; set; }

        public string BaleNo { get; set; }

        public string LRNo { get; set; }

        [DatabaseColumn("goods_received_location_id")]
        public Int32? GoodsReceivedLocationId { get; set; }

        public decimal? PurchaseQty { get; set; }

        public string ItemName { get; set; }

        public string UnitCode { get; set; }

        public string GoodsReceivedLocationName { get; set; }
                
    }
}
