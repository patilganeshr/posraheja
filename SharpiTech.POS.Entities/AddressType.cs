using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class AddressType : BaseEntity
    {
        [DatabaseColumn("addres_type_id")]
        public Int32? AddressTypeId { get; set; }

        [DatabaseColumn("address_tyep_name")]
        public string AddressTypeName { get; set; }
        
    }
}
