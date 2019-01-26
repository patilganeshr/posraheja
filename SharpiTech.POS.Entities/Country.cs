using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Country : BaseEntity
    {
        [DatabaseColumn("country_id")]
        public Int32? CountryId { get; set; }

        [DatabaseColumn("country_name")]
        public string CountryName { get; set; }

        [DatabaseColumn("country_code")]
        public string CountryCode { get; set; }
    }
}
