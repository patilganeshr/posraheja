using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class GoodsReceipt : BaseEntity
    {
        [DatabaseColumn("goods_receipt_id")]
        public Int32? GoodsReceiptId { get; set; }

        [DatabaseColumn("purchase_bill_id")]
        public Int32? PurchaseBillId { get; set; }

        [DatabaseColumn("goods_receipt_no")]
        public Int32? GoodsReceiptNo { get; set; }

        [DatabaseColumn("goods_receipt_date")]
        public string GoodsReceiptDate { get; set; }

        [DatabaseColumn("goods_received_location_id")]
        public Int32? GoodsReceivedLocationId { get; set; }

        [DatabaseColumn("branch_id")]
        public Int32? BranchId { get; set; }

        public string BranchName { get; set; }

        public string PurchaseBillNo { get; set; }

        public string PurchaseBillDate { get; set; }

        public decimal? TotalQtyReceived { get; set; }

        public string GoodsReceivedLocationName { get; set; }

        public string VendorName { get; set; }

        public Int32? VendorId { get; set; }

        public string TransporterName { get; set; }

        public Int32? TransporterId { get; set; }

        public string ChallanNo { get; set; }

        public string UnitCode { get; set; }

        public List<GoodsReceiptItem> GoodsReceiptItems { get; set; }
    }
}
