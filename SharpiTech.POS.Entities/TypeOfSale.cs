using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class TypeOfSale : BaseEntity
    {
        [DatabaseColumn("sales_type_id")]
        public Int32? SaleTypeId { get; set; }

        [DatabaseColumn("sale_type")]
        public string SaleType { get; set; }

    }
}
