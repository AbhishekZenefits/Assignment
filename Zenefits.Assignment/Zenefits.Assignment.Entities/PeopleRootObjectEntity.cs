using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zenefits.Assignment.Entities
{
    public class PeopleRootObjectEntity
    {
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "object")]
        public string Object { get; set; }

        [JsonProperty(PropertyName = "data")]
        public PeopleDataEntity Data { get; set; }

        [JsonProperty(PropertyName = "error")]
        public object Error { get; set; }
    }
}
