using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;

namespace MusicApp2
{
    public class TrackJs
    {
        [JsonProperty("trackid")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("genreid")]
        public int genreID { get; set; }

        [JsonProperty("albumid")]
        public int albID { get; set; }
        [JsonProperty("artistid")]
        public int artistID { get; set; }
        [JsonProperty("labelid")]
        public int labelID { get; set; }

    }
}
