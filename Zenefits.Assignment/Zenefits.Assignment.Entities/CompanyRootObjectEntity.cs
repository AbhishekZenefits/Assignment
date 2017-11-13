using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenefits.Assignment.Entities
{
    public class CompanyRootObjectEntity
    {
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "object")]
        public string Object { get; set; }

        [JsonProperty(PropertyName = "data")]
        public CompanyDataEntity Data { get; set; }

        [JsonProperty(PropertyName = "error")]
        public object Error { get; set; }
    }
}
