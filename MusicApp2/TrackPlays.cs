using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;


namespace MusicApp2
{
    [Table("track_plays")]
    public class TrackPlays : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public string user_id { get; set; }

        [Column("track_id")]
        public int track_id { get; set; }

        [Column("play_count")]
        public int play_count { get; set; }

        [Column("last_played")]
        public DateTime last_played { get; set; }

        public TrackPlays(int pId,string pUser_id, int pTrack_id)
        {
            Id = pId;       
            user_id = pUser_id;
            track_id = pTrack_id;

        }

            public TrackPlays()
        {
            
        }

    }

    
}
