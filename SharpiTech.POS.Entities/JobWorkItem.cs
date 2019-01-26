using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class JobWorkItem : BaseEntity
    {
        public Int32? JobWorkItemId { get; set; }

        public Int32? JobWorkId { get; set; }

        public Int32? InwardId { get; set; }

        public Int32? InwardGoodsId { get; set; }

        public decimal? ItemQty { get; set; }

        public decimal? Rate { get; set; }

        public decimal? CutMtrs { get; set; }

        public decimal? MtrsUsed { get; set; }

        public Int32? PurchaseBillItemId { get; set; }

        public Int32? ItemId { get; set; }

        public string ItemName { get; set; }

        public decimal? PurchaseQty { get; set; }

        public string UnitCode { get; set; }

        public Int32? GoodsReceiptItemId { get; set; }


    }
}
