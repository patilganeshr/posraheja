using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class LocationType : BaseEntity
    {
        public Int32? LoctionTypeId { get; set; }

        public string LocationTypeName { get; set; }

    }
}
