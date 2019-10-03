using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwapiMvvm.Data.Responses
{
    public class Species
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public object Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Resources.Species> Results { get; set; }
    }
}
