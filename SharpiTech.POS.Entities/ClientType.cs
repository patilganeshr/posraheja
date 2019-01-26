using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ClientType : BaseEntity
    {
        [DatabaseColumn("client_type_id")]
        public Int32? ClientTypeId { get; set; }

        [DatabaseColumn("client_tyep_name")]
        public string ClientTypeName { get; set; }
        
    }
}
