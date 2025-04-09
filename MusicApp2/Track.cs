using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace MusicApp2
{
    [Table("tracks")]
    public class Track : BaseModel
    {
        [PrimaryKey("trackid")]
        public int Id { get; set; }
        [Column("title")]
        public string title { get; set; }
        [Column("genreid")]
        public int genreID { get; set; }

        [Column("albumid")]
        public int albID { get; set; }
        [Column("artistid")]
        public int artistID { get; set; }
        [Column("labelid")]
        public int labelID { get; set; }

        public Track() { }
        public Track(int pId, string pTitle, int pGenreId, int pAlbId, int pArtistId, int pLabelId)
        {
            Id = pId;
            title = pTitle;
            genreID = pGenreId;
            albID = pAlbId;
            artistID = pArtistId;
            labelID = pLabelId;
        }
    }
}
