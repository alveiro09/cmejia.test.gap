using Newtonsoft.Json;
using System;

namespace cmejia.test.gap.Application.ViewModel
{
    public class PolicyVM
    {
        [JsonProperty(PropertyName = "policyId")]
        public int PolicyId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "startVadilityTime")]
        public DateTime? StartVadilityTime { get; set; }

        [JsonProperty(PropertyName = "Coveragetime")]
        public int? coveragetime { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public double? price { get; set; }

    }
}
