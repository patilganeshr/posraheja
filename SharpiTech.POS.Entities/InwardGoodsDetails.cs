using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class InwardGoodsDetails : BaseEntity
    {
        [DatabaseColumn("inward_goods_id")]
        public Int32? InwardGoodsId { get; set; }

        [DatabaseColumn("inward_id")]
        public Int32? InwardId { get; set; }

        public Int32? ReferenceId { get; set; }

        public Int32? ReferenceNo { get; set; }

        public Int32? GoodsReceiptId { get; set; }

        public Int32? OutwardId { get; set; }

        public Int32? JobWorkId { get; set;}

        [DatabaseColumn("goods_receipt_item_id")]
        public Int32? GoodsReceiptItemId { get; set; }

        [DatabaseColumn("item_id")]
        public Int32? ItemId { get; set; }

        [DatabaseColumn("inward_qty")]
        public decimal? InwardQty { get; set; }

        public decimal? PkgQty { get; set; }

        [DatabaseColumn("unit_of_measurement_id")]
        public decimal? UnitOfMeasurementId { get; set; }

        [DatabaseColumn("inward_status")]
        public string InwardStatus { get; set; }

        public decimal? ReceivedQty { get; set; }

        public string ItemName { get; set; }

        public string UnitCode { get; set; }
    }
}
