using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;


namespace MusicApp2
{
    [Table("artists")]     
    
    public class Artist : BaseModel
    {
        [PrimaryKey ("artistid")]
        public int id { get; set; }
        [Column("artistname")]
        public string name { get; set; } 
        [Column("genreId")]

        public int genreId { get; set; }
        [Column("picture")]

        public string picture { get; set; }
        

        public Artist()
        { }

        public Artist(int pId, string pName, int pGenreId, string pPicture)
        { 
          id = pId; 
            name = pName;
            genreId = pGenreId;
            picture = pPicture;
 }



    }
}
