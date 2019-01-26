using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class UserRole : BaseEntity
    {
        [DatabaseColumn("user_role_id")]
        public Int32 UserRoleId { get; set; }

        [DatabaseColumn("role_id")]
        public Int32 RoleId { get; set; }
    }
}
