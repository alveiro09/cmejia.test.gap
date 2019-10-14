using Newtonsoft.Json;
using System;

namespace cmejia.test.gap.Application.ViewModel
{
    public class ClientVM
    {
        [JsonProperty(PropertyName = "clientId")]
        public int ClientId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "idNumber")]
        public int? Idnumber { get; set; }

        [JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }
    }
}