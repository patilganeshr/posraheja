using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class OutwardGoodsDetails : BaseEntity
    {
        [DatabaseColumn("outward_goods_id")]
        public Int32? OutwardGoodsId { get; set; }

        [DatabaseColumn("outward_id")]
        public Int32? OutwardId { get; set; }

        [DatabaseColumn("pkg_slip_id")]
        public Int32? PkgSlipId { get; set; }

        public Int32? PkgSlipNo { get; set; }

        public string BaleNo { get; set; }

        public string PkgSlipDate { get; set; }

        public Int32? PkgSlipItemId { get; set; }

        public Int32? GoodsReceiptItemId { get; set; }

        public Int32? ItemId { get; set; }

        public string ItemName { get; set; }

        public decimal? TotalPkgSlipQty { get; set; }

        public Int32? UnitOfMeasurementId { get; set; }

        public string UnitCode { get; set; }
 
    }
}
