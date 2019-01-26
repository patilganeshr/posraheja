using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class WorkingPeriod : BaseEntity
    {
        [DatabaseColumn("start_date")]
        public string StartDate { get; set; }

        [DatabaseColumn("end_date")]
        public string EndDate { get; set; }
        
    }
}
