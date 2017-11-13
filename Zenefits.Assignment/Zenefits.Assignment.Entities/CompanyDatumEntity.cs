using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenefits.Assignment.Entities
{
    public class CompanyDatumEntity
    {
        [JsonProperty(PropertyName = "legal_name")]
        public string LegalName { get; set; }

        [JsonProperty(PropertyName = "legal_zip")]
        public string LegalZip { get; set; }

        [JsonProperty(PropertyName = "legal_street1")]
        public string LegalStreet1 { get; set; }

        [JsonProperty(PropertyName = "legal_street2")]
        public string LegalStreet2 { get; set; }

        [JsonProperty(PropertyName = "people")]
        public GenericPropertiesEntity People { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "object")]
        public string Object { get; set; }

        [JsonProperty(PropertyName = "locations")]
        public GenericPropertiesEntity Locations { get; set; }

        [JsonProperty(PropertyName = "departments")]
        public GenericPropertiesEntity Departments { get; set; }

        [JsonProperty(PropertyName = "legal_city")]
        public string LegalCity { get; set; }

        [JsonProperty(PropertyName = "ein")]
        public string Ein { get; set; }

        [JsonProperty(PropertyName = "logo_url")]
        public object LogoUrl { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "legal_state")]
        public string LegalState { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
