using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class City : BaseEntity
    {
        [DatabaseColumn("city_id")]
        public Int32? CityId { get; set; }

        [DatabaseColumn("city_name")]
        public string CityName { get; set; }

        [DatabaseColumn("state_id")]
        public Int32? StateId { get; set; }

        public bool? IsCityNameExists { get; set; }
    }
}
