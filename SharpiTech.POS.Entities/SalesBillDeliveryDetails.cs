using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class SalesBillDeliveryDetails : BaseEntity
    {
        [DatabaseColumn("sales_bill_delivery_id")]
        public Int32? SalesBillDeliveryId { get; set; }

        [DatabaseColumn("sales_bill_id")]
        public Int32? SalesBillId { get; set; }

        [DatabaseColumn("delivery_to")]
        public string DeliveryTo { get; set; }

        [DatabaseColumn("delivery_address")]
        public string DeliveryAddress { get; set; }

        [DatabaseColumn("transporter_id")]
        public Int32? TransporterId { get; set; }

        [DatabaseColumn("lr_no")]
        public string LRNo { get; set; }

        [DatabaseColumn("lr_date")]
        public string LRDate { get; set; }

        [DatabaseColumn("delivery_date")]
        public string DeliveryDate { get; set; }

        [DatabaseColumn("is_delivery_pending")]
        public bool? IsDeliveryPending { get; set; }

        public string TransporterName { get; set; }
    }
}
