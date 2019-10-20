using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class PkgSlipItem : BaseEntity
    {
        [DatabaseColumn("pkg_slip_item_id")]
        public Int32? PkgSlipItemId { get; set; }

        [DatabaseColumn("pkg_slip_id")]
        public Int32? PkgSlipId { get; set; }

        [DatabaseColumn("item_id")]
        public Int32? ItemId { get; set; }

        [DatabaseColumn("pkg_qty_in_pcs")]
        public decimal? PkgQty { get; set; }

        public string BaleNo { get; set; }

        public string ItemName { get; set; }

        public decimal? TotalPkgQty { get; }

        public Int32? GoodsReceiptItemId { get; set; }

        public Int32? InwardGoodsId { get; set; }

        public Int32? ItemQualityId { get; set; }

        public string ItemQuality { get; set; }

        public Int32? UnitOfMeasurementId { get; set; }

        public string UnitCode { get; set; }

        public decimal? ReceivedQty { get; set; }

    }
}
