using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class User : BaseEntity
    {
        [DatabaseColumn("user_id")]
        public Int32? UserId { get; set; }

        [DatabaseColumn("username")]
        public string Username { get; set; }

        [DatabaseColumn("password")]
        public string Password { get; set; }

        [DatabaseColumn("employee_id")]
        public Int32? EmployeeId { get; set; }

        [DatabaseColumn("role_id")]
        public Int32? RoleId { get; set; }
        
        [DatabaseColumn("role_name")]
        public string RoleName { get; set; }

        public string FullName { get; set; }

        public string VerifyUserSP
        {
            get
            {
                return "usp_users_verify_user";
            }
        }
    }
}
