using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Department : BaseEntity
    {
        [DatabaseColumn("department_id")]
        public Int32? DepartmentId { get; set; }

        [DatabaseColumn("department_name")]
        public string DepartmentName { get; set; }
        
    }
}
