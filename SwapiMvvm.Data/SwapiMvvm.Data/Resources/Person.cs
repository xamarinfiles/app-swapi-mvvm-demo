using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using SwapiMvvm.Data.Enums;

namespace SwapiMvvm.Data.Resources
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long Height { get; set; }

        [JsonProperty("mass")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public long Mass { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        [JsonProperty("gender")]
        //public Gender Gender { get; set; }
        public string Gender { get; set; }

        [JsonProperty("homeworld")]
        public Uri Homeworld { get; set; }

        [JsonProperty("films")]
        public List<Uri> Films { get; set; }

        [JsonProperty("species")]
        public List<Uri> Species { get; set; }

        [JsonProperty("vehicles")]
        public List<Uri> Vehicles { get; set; }

        [JsonProperty("starships")]
        public List<Uri> Starships { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("edited")]
        public DateTimeOffset Edited { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        public override string ToString() => DebuggerDisplay;

        private string DebuggerDisplay =>
            $"{Name,-30} {Gender,-15} {Films.Count}";
    }
}
