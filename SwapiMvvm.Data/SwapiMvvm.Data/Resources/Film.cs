using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;

namespace SwapiMvvm.Data.Resources
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Film
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("episode_id")]
        public long EpisodeId { get; set; }

        [JsonProperty("opening_crawl")]
        public string OpeningCrawl { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("producer")]
        public string Producer { get; set; }

        [JsonProperty("release_date")]
        public DateTimeOffset ReleaseDate { get; set; }

        [JsonProperty("characters")]
        public List<Uri> Characters { get; set; }

        [JsonProperty("planets")]
        public List<Uri> Planets { get; set; }

        [JsonProperty("starships")]
        public List<Uri> Starships { get; set; }

        [JsonProperty("vehicles")]
        public List<Uri> Vehicles { get; set; }

        [JsonProperty("species")]
        public List<Uri> Species { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("edited")]
        public DateTimeOffset Edited { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        public override string ToString() => DebuggerDisplay;

        private string DebuggerDisplay =>
            $"#{Title,-30} {EpisodeId,-15} {ReleaseDate:d}";
    }
}
