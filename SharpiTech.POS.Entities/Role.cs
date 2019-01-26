using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Role : BaseEntity
    {
        [DatabaseColumn("role_id")]
        public Int32? RoleId { get; set; }

        [DatabaseColumn("role_name")]
        public string RoleName { get; set; }

        [DatabaseColumn("role_desc")]
        public string RoleDesc { get; set; }
        
    }
}
