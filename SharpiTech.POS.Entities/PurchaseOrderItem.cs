using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class PurchaseOrderItem : BaseEntity
    {
        [DatabaseColumn("purchase_order_item_id")]
        public Int32? PurchaseOrderItemId { get; set; }

        [DatabaseColumn("purchase_order_id")]
        public Int32? PurchaseOrderId { get; set; }

        [DatabaseColumn("item_id")]
        public Int32? ItemId { get; set; }

        public Int32? DesignId { get; set; }

        public Int32? ColorId { get; set; }

        [DatabaseColumn("no_of_bales")]
        public Int32? NoOfBales { get; set; }

        [DatabaseColumn("order_qty")]
        public decimal? OrderQty { get; set; }

        [DatabaseColumn("unit_of_measurement_id")]
        public Int32? UnitOfMeasurementId { get; set; }

        public Int32? FabricCutOutLenght { get; set; }

        [DatabaseColumn("order_rate")]
        public decimal? OrderRate { get; set; }

        public string ItemName { get; set; }

        public string HSNCode { get; set; }

        public string UnitCode { get; set; }

        public bool? IsSet { get; set; }

        public Int32? ItemSetSubItemId { get; set; }

    }
}
