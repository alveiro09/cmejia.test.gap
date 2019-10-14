using Newtonsoft.Json;

namespace cmejia.test.gap.Application.ViewModel
{
    public class TypeRiskVM
    {
        [JsonProperty(PropertyName = "typeRiskId")]
        public int TypeRiskId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
