using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase;
using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace MusicApp2
{
    [Table("albums")]
    public class Album : BaseModel
    {
        [PrimaryKey("albumid")]
        public int Id { get; set; }
        [Column("albumname")]
        public String Name { get; set; }
        [Column("releaseyear")]
        public int releseYear { get; set; }
        [Column("genreid")]
        public int genreID { get; set; }
        [Column("labelid")]

        public int labelID { get; set; }
        [Column("artistid")]
        public int artistID { get; set; }
        [Column("picturepath")]

        public string picture { get; set; }


        public Album()
        {    }

        public Album(int pId, string pName, int pRelease, int pGenreId,int pLabelID, int pArtistId, string pPicture)
        {
                Id = pId;
            Name = pName;   
            releseYear = pRelease;
            genreID = pGenreId;
            labelID = pLabelID;
            artistID = pArtistId;
            picture = pPicture;
        }


    }

    
}
