using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Employer : BaseEntity
    {
        [DatabaseColumn("employer_id")]
        public Int32? EmployerId { get; set; }

        [DatabaseColumn("employer_name")]
        public string EmployerName { get; set; }
    }
}
