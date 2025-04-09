using Newtonsoft.Json;
using Supabase;
using System.Windows;
using static Supabase.Postgrest.Constants;


namespace MusicApp2
{
    public class Database
    {
        private string _url;
        private string _key;
        private readonly SupabaseOptions _options;
        private Supabase.Client _supabase;

        public string Url { get => _url; set => _url = value; }
        public string Key { get => _key; set => _key = value; }

        public Database()
        {
            Url = Environment.GetEnvironmentVariable("URL");
            Key = Environment.GetEnvironmentVariable("KEY");

            _options = new SupabaseOptions
            {
                AutoConnectRealtime = true
            };
        }

        public async Task InitializeAsync()
        {
            _supabase = new Supabase.Client(Url, Key, _options);
            await _supabase.InitializeAsync();
        }

        public async Task<List<Album>> GetAlbumsByValue(SearchValue sv)
        {
            if (_supabase == null)
            {
                await InitializeAsync();
            }

            var response = await _supabase
                .From<Album>()
                .Filter("albumname", Operator.ILike, $"{sv.TextValue}%")
              .Order("albumname", Supabase.Postgrest.Constants.Ordering.Ascending)
                .Select("*")
                .Get();

            return response.Models;
        }

        public async Task<List<AlbumJs>> GetAlbums()
        {
            if (_supabase == null)
            {
                await InitializeAsync();
            }

            var response = await _supabase.Rpc("get_random_albums", new { count = 2 });

            var albums = JsonConvert.DeserializeObject<List<AlbumJs>>(response.Content, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            });

            return albums;
        }


        //    public async Task<List<Track>> GetTracks()
        //    {
        //        if (_supabase == null)
        //        {
        //            await InitializeAsync();
        //        }

        ////        var response = await _supabase
        //   .From<Track>()
        //.Select("*")
        //.Order("albumid", Ordering.Ascending) // Order by any column, the order will still be random
        //.Limit(2)
        //.Get();

        //        return response.Models;
        //    }

        public async Task<List<Track>> GetTracksByValue(SearchValue sv)
        {
            if (_supabase == null)
            {
                await InitializeAsync();
            }

            var response = await _supabase
                .From<Track>()
                .Filter("title", Operator.ILike, $"{sv.TextValue}%")
                .Order("title", Supabase.Postgrest.Constants.Ordering.Ascending)
                .Select("*")
                .Get();

            return response.Models;
        }

        public async Task<List<TrackPlays>> GetTrackPlay(string userId)
        {
            if (_supabase == null)
            {
                await InitializeAsync();
            }

            var response = await _supabase
                .From<TrackPlays>()
                .Filter("user_id", Operator.Equals, userId)
                .Order("last_played", Supabase.Postgrest.Constants.Ordering.Descending)
                .Select("*")
                .Get();

            return response.Models;
        }
        public async Task<Profiles> GetUserID(string id)
        {
            if (_supabase == null)
            {
                await InitializeAsync();
            }


            var response = await _supabase
                .From<Profiles>()
                .Select("*")
                .Filter("id", Operator.Equals, id)
                .Single();

            return response;

        }

        public async Task<Track> GetTrackByID(int id)
        {
            if (_supabase == null)
            {
                await InitializeAsync();
            }


            var response = await _supabase
                .From<Track>()
                .Select("*")
                .Filter("trackid", Operator.Equals, id)
                .Single();

            return response;

        }

        public async Task<Artist> GetArtistByID(int id)
        {
            if (_supabase == null)
            {
                await InitializeAsync();
            }

            var response = await _supabase
                .From<Artist>()
                .Select("*")
                .Filter("artistid", Operator.Equals, id)
                .Single();

            return response;
        }

        public async void NewProfile(string id)
        {
            if (_supabase == null)
            {
                await InitializeAsync();
            }
            var newProfile = new Profiles { Id = id };
            await _supabase
     .From<Profiles>()
     .Insert(newProfile);
        }

        public async Task<Album> GetAlbumByID(int id)
        {
            if (_supabase == null)
            {
                await InitializeAsync();
            }

            var response = await _supabase
                .From<Album>()
                .Select("*")
                .Filter("albumid", Operator.Equals, id)
                .Single();

            return response;
        }

        public async Task UpsertTrackPlay(string userId, int trackId)
        {
            if (_supabase == null)
            {
                await InitializeAsync();
            }
          
            try
            {
                var existingRecord = await _supabase
                    .From<TrackPlays>()
                    .Where(x => x.user_id == userId && x.track_id == trackId)
                    .Get();

                if (existingRecord.Models.Count > 0)
                {
                    var recordToUpdate = existingRecord.Models[0];
                    recordToUpdate.play_count++;
                    recordToUpdate.last_played = DateTime.UtcNow;

                    await _supabase
                        .From<TrackPlays>()
                        .Where(x => x.user_id == userId && x.track_id == trackId)
                        .Update(recordToUpdate);
                }
                else
                {
                    var newRecord = new TrackPlays
                    {
                        user_id = userId,
                        track_id = trackId,
                        play_count = 1,
                        last_played = DateTime.UtcNow
                    };

                    await _supabase.From<TrackPlays>().Insert(newRecord);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}");
            }
        }
    }
}
