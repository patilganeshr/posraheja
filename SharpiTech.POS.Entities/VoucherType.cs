using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class VoucherType : BaseEntity
    {
        public Int32? VoucherTypeId { get; set; }

        public string TypeOfVoucher { get; set; }
    }
}
