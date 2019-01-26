using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class ClientAddress : BaseEntity
    {
        [DatabaseColumn("address_type_id")]
        public Int32? AddressTypeId { get; set; }

        [DatabaseColumn("address_type_name")]
        public string AddressType { get; set; }

        [DatabaseColumn("client_address_code")]
        public string ClientAddressCode { get; set; }

        [DatabaseColumn("client_address_id")]
        public Int32? ClientAddressId { get; set; }

        [DatabaseColumn("client_id")]
        public Int32? ClientId { get; set; }

        [DatabaseColumn("client_type_id")]
        public Int32? ClientTypeId { get; set; }

        [DatabaseColumn("client_type")]
        public string ClientType { get; set; }

        [DatabaseColumn("client_address_name")]
        public string ClientAddressName { get; set; }

        [DatabaseColumn("address")]
        public string Address { get; set; }

        [DatabaseColumn("client_name")]
        public string ClientName { get; set; }

        [DatabaseColumn("country_id")]
        public Int32? CountryId { get; set; }

        [DatabaseColumn("state_id")]
        public Int32? StateId { get; set; }

        [DatabaseColumn("city_id")]
        public Int32? CityId { get; set; }

        [DatabaseColumn("area")]
        public string Area { get; set; }

        [DatabaseColumn("pin_code")]
        public string PinCode { get; set; }

        [DatabaseColumn("tel_no")]
        public string TelNo { get; set; }

        [DatabaseColumn("fax_no")]
        public string FaxNo { get; set; }

        [DatabaseColumn("email_id")]
        public string EmailId { get; set; }

        [DatabaseColumn("contact_nos")]
        public string ContactNos { get; set; }

        [DatabaseColumn("service_tax_no")]
        public string ServiceTaxNo { get; set; }

        [DatabaseColumn("vat_no")]
        public string VATNo { get; set; }

        [DatabaseColumn("tin_no")]
        public string TINNo { get; set; }

        [DatabaseColumn("pan_no")]
        public string PANNo { get; set; }

        [DatabaseColumn("gst_no")]
        public string GSTNo { get; set; }

        [DatabaseColumn("country_name")]
        public string CountryName { get; set; }

        [DatabaseColumn("country_code")]
        public string CountryCode { get; set; }

        [DatabaseColumn("state_name")]
        public string StateName { get; set; }
        
        [DatabaseColumn("state_code")]
        public string StateCode { get; set; }

        [DatabaseColumn("city_name")]
        public string CityName { get; set; }
        
        public List<Entities.CustomerAndTransporterMapping> CustomerAndTransporterMapping { get; set; }
    }
}
