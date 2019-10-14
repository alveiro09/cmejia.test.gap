using Newtonsoft.Json;

namespace cmejia.test.gap.Application.ViewModel
{
    public class TypeCoveringVM
    {
        [JsonProperty(PropertyName = "typeCoveringId")]
        public int TypeCoveringId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty(PropertyName = "percentage")]
        public double? Percentage { get; set; }
    }
}
