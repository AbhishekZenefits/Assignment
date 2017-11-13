using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zenefits.Assignment.Entities
{
    public class PeopleDatumEntity
    {
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "preferred_name")]
        public string PreferredName { get; set; }

        [JsonProperty(PropertyName = "manager")]
        public GenericPropertiesEntity Manager { get; set; }

        [JsonProperty(PropertyName = "postal_code")]
        public object PostalCode { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "city")]
        public object City { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "middle_name")]
        public object MiddleName { get; set; }

        [JsonProperty(PropertyName = "title")]
        public object Title { get; set; }

        [JsonProperty(PropertyName = "work_phone")]
        public string WorkPhone { get; set; }

        [JsonProperty(PropertyName = "personal_email")]
        public string PersonalEmail { get; set; }

        [JsonProperty(PropertyName = "state")]
        public object State { get; set; }

        [JsonProperty(PropertyName = "date_of_birth")]
        public string DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "location")]
        public GenericPropertiesEntity Location { get; set; }

        [JsonProperty(PropertyName = "subordinates")]
        public GenericPropertiesEntity Subordinates { get; set; }

        [JsonProperty(PropertyName = "department")]
        public GenericPropertiesEntity Department { get; set; }

        [JsonProperty(PropertyName = "employments")]
        public GenericPropertiesEntity employments { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "company")]
        public GenericPropertiesEntity Company { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "street1")]
        public object Street1 { get; set; }

        [JsonProperty(PropertyName = "street2")]
        public object Street2 { get; set; }

        [JsonProperty(PropertyName = "object")]
        public string Object { get; set; }

        [JsonProperty(PropertyName = "photo_thumbnail_url")]
        public object PhotoThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "personal_phone")]
        public string PersonalPhone { get; set; }

        [JsonProperty(PropertyName = "federal_filing_status")]
        public string FederalFilingStatus { get; set; }

        [JsonProperty(PropertyName = "work_email")]
        public string WorkEmail { get; set; }

        [JsonProperty(PropertyName = "photo_url")]
        public object PhotoUrl { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "country")]
        public object Country { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }
    }
}
