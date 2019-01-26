using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class State : BaseEntity
    {
        [DatabaseColumn("state_id")]
        public Int32? StateId { get; set; }

        [DatabaseColumn("state_name")]
        public string StateName { get; set; }

        [DatabaseColumn("state_code")]
        public string StateCode { get; set; }

        [DatabaseColumn("country_id")]
        public Int32? CountryId { get; set; }

        [DatabaseColumn("tin_no")]
        public string TINNo { get; set; }
    }
}
