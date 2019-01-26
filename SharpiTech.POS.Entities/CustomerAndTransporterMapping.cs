using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class CustomerAndTransporterMapping : BaseEntity
    {
        [DatabaseColumn("mapping_id")]
        public Int32? MappingId { get; set; }

        [DatabaseColumn("customer_address_id")]
        public Int32? CustomerAddressId { get; set; }

        [DatabaseColumn("transporter_id")]
        public Int32? TransporterAddressId { get; set; }

        public string CustomerName { get; set; }

        public string TransporterName { get; set; }

    }
}
