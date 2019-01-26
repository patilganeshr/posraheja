using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Employee : BaseEntity
    {
        [DatabaseColumn("employee_id")]
        public Int32? EmployeeId { get; set; }

        [DatabaseColumn("employer_id")]
        public Int32? EmployerId { get; set; }

        [DatabaseColumn("employerName")]
        public string EmployerName { get; set; }

        [DatabaseColumn("first_name")]
        public string FirstName { get; set; }

        [DatabaseColumn("middle_name")]
        public string MiddleName { get; set; }

        [DatabaseColumn("last_name")]
        public string LastName { get; set; }
                
        [DatabaseColumn("gender")]
        public string Gender { get; set; }

        [DatabaseColumn("residential_address")]
        public string ResidentialAddress { get; set; }

        [DatabaseColumn("date_of_birth")]
        public string DateOfBirth { get; set; }

        [DatabaseColumn("contact_no_1")]
        public string ContactNo1 { get; set; }

        [DatabaseColumn("contact_no_2")]
        public string ContactNo2 { get; set; }

        [DatabaseColumn("mobile_no_1")]
        public string MobileNo1 { get; set; }

        [DatabaseColumn("mobile_no_2")]
        public string MobileNo2 { get; set; }

        [DatabaseColumn("email_id")]
        public string EmailId { get; set; }

        [DatabaseColumn("pan_no")]
        public string PANNo { get; set; }

        [DatabaseColumn("department_id")]
        public Int32? DepartmentId{ get; set; }

        public string FullName { get; set; }

        public string ContactNos { get; set; }
    }
}
