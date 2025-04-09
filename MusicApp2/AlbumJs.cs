
using Newtonsoft.Json;

namespace MusicApp2
{
    public class AlbumJs
    {
        [JsonProperty("albumid")]
        public int Id { get; set; }
        [JsonProperty("albumname")]
        public String Name { get; set; }
        [JsonProperty("releaseyear")]
        public int releseYear { get; set; }
        [JsonProperty("genreid")]
        public int genreID { get; set; }
        [JsonProperty("labelid")]

        public int labelID { get; set; }
        [JsonProperty("artistid")]
        public int artistID { get; set; }
        [JsonProperty("picturepath")]

        public string picture { get; set; }
    }
}
