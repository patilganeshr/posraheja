using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class TypeOfTransfer : BaseEntity
    {
        [DatabaseColumn("type_of_transfer_id")]
        public Int32? TypeOfTransferId { get; set; }

        [DatabaseColumn("transfer_type")]
        public string TransferType { get; set; }
        
    }
}
