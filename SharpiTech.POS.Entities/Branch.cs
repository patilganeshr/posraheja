using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class Branch : BaseEntity
    {
        [DatabaseColumn("branch_id")]
        public Int32? BranchId { get; set; }

        [DatabaseColumn("company_id")]
        public Int32? CompanyId { get; set; }

        [DatabaseColumn("branch_name")]
        public string BranchName { get; set; }

        [DatabaseColumn("branch_address")]
        public string BranchAddress { get; set; }

        [DatabaseColumn("country_id")]
        public Int32? CountryId { get; set; }

        [DatabaseColumn("state_id")]
        public Int32? StateId { get; set; }

        [DatabaseColumn("city_id")]
        public Int32? CityId { get; set; }

        [DatabaseColumn("contact_person")]
        public string ContactPerson { get; set; }

        [DatabaseColumn("contact_no")]
        public string ContactNo { get; set; }

        [DatabaseColumn("email_id")]
        public string EmailId { get; set; }

        [DatabaseColumn("gstin_no")]
        public string GSTINNo { get; set; }

        public string CountryName { get; set; }

        public string StateName { get; set; }

        public string CityName { get; set; }
    }
}
