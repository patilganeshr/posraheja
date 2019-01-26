using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class StockDetails : BaseEntity
    {
        [DatabaseColumn("stock_id")]
        public Int32? StockId { get; set; }

        [DatabaseColumn("vendor_id")]
        public Int32? VendorId { get; set; }

        [DatabaseColumn("item_id")]
        public Int32? ItemId { get; set; }

        [DatabaseColumn("stock_date")]
        public string StockDate { get; set; }

        [DatabaseColumn("bale_no")]
        public string BaleNo { get; set;}

        [DatabaseColumn("lot_no")]
        public string LotNo { get; set; }

        [DatabaseColumn("purchase_rate")]
        public decimal? PurchaseRate { get; set; }

        [DatabaseColumn("received_qty_in_pcs")]
        public decimal? ReceivedQtyInPcs { get; set; }

        [DatabaseColumn("received_qty_in_mtrs")]
        public decimal? ReceivedQtyInMtrs { get; set; }

        [DatabaseColumn("goods_received_location_id")]
        public Int32? GoodsReceivedLocationId { get; set; }

        [DatabaseColumn("branch_id")]
        public Int32? BranchId { get; set; }

        public string VendorName { get; set; }

        public string ItemName { get; set; }

        public string ItemQualityName { get; set; }

        public string GoodsReceivedLocationName { get; set; }

        public string BranchName { get; set; }

    }
}
