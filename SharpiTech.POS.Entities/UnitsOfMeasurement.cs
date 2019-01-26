using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class UnitsOfMeasurement : BaseEntity
    {
        [DatabaseColumn("unit_of_measurement_id")]
        public Int32? UnitOfMeasurementId { get; set; }

        [DatabaseColumn("unit_code")]
        public string UnitCode { get; set; }

        [DatabaseColumn("unit_code_desc")]
        public string UnitCodeDesc { get; set; }

        [DatabaseColumn("unit_type")]
        public string UnitType { get; set; }
        
    }
}
