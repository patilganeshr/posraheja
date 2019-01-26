using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ClientAddressContact : BaseEntity
    {
        [DatabaseColumn("contact_id")]
        public Int32? ContactId { get; set; }

        [DatabaseColumn("client_address_id")]
        public Int32? ClientAddressId { get; set; }

        [DatabaseColumn("client_address_name")]
        public string ClientAddressName { get; set; }

        [DatabaseColumn("contact_name")]
        public string ContactName { get; set; }

        [DatabaseColumn("department")]
        public string Department { get; set; }

        [DatabaseColumn("designation")]
        public string Designation { get; set; }

        [DatabaseColumn("contact_no")]
        public string ContactNo { get; set; }

        [DatabaseColumn("email_id")]
        public string EmailId { get; set; }

    }
}
