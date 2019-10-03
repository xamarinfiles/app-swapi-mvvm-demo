using Newtonsoft.Json;
using System.Collections.Generic;
using SwapiMvvm.Data.Resources;

namespace SwapiMvvm.Data.Responses
{
    public class Films
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public object Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Film> Results { get; set; }
    }
}
