using System.Collections.Generic;
using Newtonsoft.Json;
using SwapiMvvm.Data.Resources;

namespace SwapiMvvm.Data.Responses
{
    public class People
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("next")]
        public object Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Person> Results { get; set; }
    }
}
