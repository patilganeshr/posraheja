using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Client : BaseEntity
    {
        [DatabaseColumn("client_type_id")]
        public Int32? ClientTypeId { get; set; }

        [DatabaseColumn("client_type_name")]
        public string ClientTypeName { get; set; }

        [DatabaseColumn("client_id")]
        public Int32? ClientId { get; set; }

        [DatabaseColumn("client_code")]
        public string ClientCode { get; set; }

        [DatabaseColumn("client_name")]
        public string ClientName { get; set; }

        [DatabaseColumn("pan_no")]
        public string PANNo { get; set; }

        public string GSTNo { get; set; }

        public List<SharpiTech.POS.Entities.ClientAddress> ClientAddressess { get; set; }

    }
}
