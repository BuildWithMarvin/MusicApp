using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace MusicApp2
{
    [Table("profiles")]
    public class Profiles : BaseModel
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("display_name")]
        public string Name { get; set; }

        public Profiles()
        { }

        public Profiles(string pId, string pName)
        {
               Id = pId;
            Name = pName;

        }

    }
}
