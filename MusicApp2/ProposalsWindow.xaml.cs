using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Controls.Primitives;



namespace MusicApp2
{
    
    public partial class ProposalsWindow : UserControl
    {
        public ProposalsWindow()
        {
            InitializeComponent();
        }
        public string UserID;
        int trackid;
        int trackid1;
        int trackid2;
        int trackid3;
        int trackid4;
        int trackid5;
        int trackid6;
        int trackid7;
        int trackid8;
        int trackid9;
        int trackid10;
        int trackid11;

        int albid;
        int albid1;
        int albid2;
        int albid3;
        int albid4;
        int albid5;

        Database db = new Database();
        public async void createMusicPanels(string pUserID)
        {

            int a = 0;
            int b = 0;
            UserID = pUserID;
            this.Visibility = Visibility.Visible;
            List<AlbumJs> LiAlb = new List<AlbumJs>();
            LiAlb = await db.GetAlbums();

            List<TrackJs> LiTraJs = new List<TrackJs>();
            LiTraJs = await db.GetTracksRandom();



           
                

                    SetTrackPlays(UserID);
            
            if (LiAlb.Count > 0)
            {
                foreach (AlbumJs album in LiAlb)
                {
                    SetAlbumRecommendedPanel(album, a);
                    a++;
                }

            }

            if (LiTraJs.Count > 0)
            {
                foreach (TrackJs track in LiTraJs)
                {
                    SetTracksPanel(track, b);
                    b++;
                }

            }
        }
        public async void SetTrackPlays(string user)
        {
            int i = 0;
            Track track;
            Artist artist;
            Album album;
            List<TrackPlays> LiTra = new List<TrackPlays>();
            LiTra = await db.GetTrackPlay(UserID);
            if (LiTra.Count > 0)
            {
                foreach (TrackPlays tp in LiTra)
                {
                    switch (i)
                    {
                        case 0:
                            track = await db.GetTrackByID(tp.track_id);
                            artist = await db.GetArtistByID(track.artistID);
                            album = await db.GetAlbumByID(track.albID);
                            SetTrackPlaysPic(track, i);
                            Label1.Content = track.title;
                            SubLabel1.Content = artist.name;
                            trackid = track.Id;
                            break;
                        case 1:
                             track = await db.GetTrackByID(tp.track_id);
                            artist = await db.GetArtistByID(track.artistID);
                            album = await db.GetAlbumByID(track.albID);
                            SetTrackPlaysPic(track, i);
                            Label2.Content = track.title;
                            SubLabel2.Content = artist.name;
                            trackid1 = track.Id;
                            break;
                        case 2:
                            track = await db.GetTrackByID(tp.track_id);
                            artist = await db.GetArtistByID(track.artistID);
                            album = await db.GetAlbumByID(track.albID);
                            SetTrackPlaysPic(track, i);
                            Label3.Content = track.title;
                            SubLabel3.Content = artist.name;
                            trackid2 = track.Id;
                            break;
                        case 3:
                            
                            track = await db.GetTrackByID(tp.track_id);
                            artist = await db.GetArtistByID(track.artistID);
                            album = await db.GetAlbumByID(track.albID);
                            SetTrackPlaysPic(track, i);
                            Label4.Content = track.title;
                            SubLabel4.Content = artist.name;
                            trackid3 = track.Id;
                            break;
                        case 4:
                           
                            track = await db.GetTrackByID(tp.track_id);
                            artist = await db.GetArtistByID(track.artistID);
                            album = await db.GetAlbumByID(track.albID);
                            SetTrackPlaysPic(track, i);
                            Label5.Content = track.title;
                            SubLabel5.Content = artist.name;
                            trackid4 = track.Id;
                            break;
                        case 5:
                           
                            track = await db.GetTrackByID(tp.track_id);
                            artist = await db.GetArtistByID(track.artistID);
                            album = await db.GetAlbumByID(track.albID);
                            SetTrackPlaysPic(track, i);
                            Label6.Content = track.title;
                            SubLabel6.Content = artist.name;
                            trackid5 = track.Id;
                            break;
                    }
                    i++;
                }
            }



        }
        public async void SetTrackPlaysPic(Track track, int a)
        {
            Album album;

            album = await db.GetAlbumByID(track.albID);

            if (album != null && !string.IsNullOrWhiteSpace(album.picture))
            {
                string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", album.picture);

                if (File.Exists(imagePath))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                    bitmap.EndInit();

                    switch (a)
                    {
                        case 0:
                            Label1Pic.Source = bitmap;
                            break;
                        case 1:
                            Label2Pic.Source = bitmap;
                            break;
                        case 2:
                            Label3Pic.Source = bitmap;
                            break;
                        case 3:
                            Label4Pic.Source = bitmap;
                            break;
                        case 4:
                            Label5Pic.Source = bitmap;
                            break;
                        case 5:
                            Label6Pic.Source = bitmap;
                            break;
                    }

                }
            }
        }

        public async void SetAlbumProposals(AlbumJs album, int a)
        {
            Artist artist;

            artist = await db.GetArtistByID(album.artistID);

            if (artist != null && !string.IsNullOrWhiteSpace(artist.name))
            {

                switch (a)
                {
                    case 0:
                        AlbSubLabel1.Content = artist.name;
                        break;
                    case 1:
                        AlbSubLabel2.Content = artist.name;
                        break;
                }
            }
            else
            {

                switch (a)
                {
                    case 0:
                        AlbSubLabel1.Content = "Unknown Artist";
                        break;
                    case 1:
                        AlbSubLabel2.Content = "Unknown Artist";
                        break;
                }
            }
        }

        public /*async*/ void SetTracksPanel(TrackJs track, int b)  /*Prüfen ob ich async in diesem Falle weglassen kann*/
        {
            switch (b)
            {
                case 0:

                    SetRightSubPanels(b, track);
                    break;
                case 1:

                    SetRightSubPanels(b, track);
                    break;

                case 2:

                    SetRightSubPanels(b, track);
                    break;
                case 3:

                    SetRightSubPanels(b, track);
                    break;
                case 4:

                    SetRightSubPanels(b, track);
                    break;
                case 5:

                    SetRightSubPanels(b, track);
                    break;
            }
        }

        public async void SetRightSubPanels(int a, TrackJs tr)
        {
            Artist artist = await db.GetArtistByID(tr.artistID);
            switch (a)
            {
                case 0:
                    SetPicturesTrackProposals(a, tr);
                    TrackLabel1.Content = tr.title;
                    TrackSubLabel1.Content = artist.name;
                    trackid6 = tr.Id;
                    break;
                case 1:
                    SetPicturesTrackProposals(a, tr);
                    TrackLabel2.Content = tr.title;
                    TrackSubLabel2.Content = artist.name;
                    trackid7 = tr.Id;
                    break;
                case 2:
                    SetPicturesTrackProposals(a, tr);
                    TrackLabel3.Content = tr.title;
                    TrackSubLabel3.Content = artist.name;
                    trackid8 = tr.Id;
                    break;
                case 3:
                    SetPicturesTrackProposals(a, tr);
                    TrackLabel4.Content = tr.title;
                    TrackSubLabel4.Content = artist.name;
                    trackid9 = tr.Id;
                    break;
                case 4:
                    SetPicturesTrackProposals(a, tr);
                    TrackLabel5.Content = tr.title;
                    TrackSubLabel5.Content = artist.name;
                    trackid10 = tr.Id;
                    break;
                case 5:
                    SetPicturesTrackProposals(a, tr);
                    TrackLabel6.Content = tr.title;
                    TrackSubLabel6.Content = artist.name;
                    trackid11 = tr.Id;
                    break;


            }
        }

        public async void SetPicturesTrackProposals(int a, TrackJs tr)
        {
            Album album = await db.GetAlbumByID(tr.albID);
            if (album != null && !string.IsNullOrWhiteSpace(album.picture))
            {

                string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", album.picture);

                if (File.Exists(imagePath))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                    bitmap.EndInit();

                    switch (a)
                    {
                        case 0:
                            TrackLabel1Pic.Source = bitmap;
                            break;
                        case 1:
                            TrackLabel2Pic.Source = bitmap;
                            break;
                        case 2:
                            TrackLabel3Pic.Source = bitmap;
                            break;
                        case 3:
                            TrackLabel4Pic.Source = bitmap;
                            break;
                        case 4:
                            TrackLabel5Pic.Source = bitmap;
                            break;
                        case 5:
                            TrackLabel6Pic.Source = bitmap;
                            break;

                    }
                }
            }
        }

        public async void SetAlbumRecommendedPanel(AlbumJs album, int a)
        {
            var bitmap = new BitmapImage();
            string imagePath = null;
            if (album != null && !string.IsNullOrWhiteSpace(album.picture))
            {
                imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", album.picture);
                if (File.Exists(imagePath))
                {

                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                    bitmap.EndInit();

                }
            }
            else
            {
                imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "images\\AppIcon.png");

                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                bitmap.EndInit();

            }

            switch (a)
            {
                case 0:
                    AlbLabel1Pic.Source = bitmap;
                    AlbLabel1.Content = album.Name;
                    albid = album.Id;
                    SetAlbumProposals(album, a); break;
                case 1:
                    AlbLabel2Pic.Source = bitmap;
                    AlbLabel2.Content = album.Name;
                    albid1 = album.Id;
                    SetAlbumProposals(album, a); break;
                case 2:
                    AlbLabel3Pic.Source = bitmap;
                    AlbLabel3.Content = album.Name;
                    albid2 = album.Id;
                    SetAlbumProposals(album, a); break;
                case 3:
                    AlbLabel4Pic.Source = bitmap;
                    AlbLabel4.Content = album.Name;
                    albid3 = album.Id;
                    SetAlbumProposals(album, a); break;
                case 4:
                    AlbLabel5Pic.Source = bitmap;
                    AlbLabel5.Content = album.Name;
                    albid4 = album.Id;
                    SetAlbumProposals(album, a); break;
                case 5:
                    AlbLabel6Pic.Source = bitmap;
                    AlbLabel6.Content = album.Name;
                    albid5 = album.Id;
                    SetAlbumProposals(album, a); break;
            }


        }

        private void Label2_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            db.UpsertTrackPlay(UserID, trackid1);
            SetTrackPlays(UserID);
        }

        private void Label1_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            db.UpsertTrackPlay(UserID, trackid);
            SetTrackPlays(UserID);

        }

        private void Label3_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            db.UpsertTrackPlay(UserID, trackid2);
            SetTrackPlays(UserID);
        }

        private void Label4_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            db.UpsertTrackPlay(UserID, trackid3);
            SetTrackPlays(UserID);
        }

        private void Label5_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            db.UpsertTrackPlay(UserID, trackid4);
            SetTrackPlays(UserID);
        }

        private void Label6_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            db.UpsertTrackPlay(UserID, trackid5);
            SetTrackPlays(UserID);
        }
    }

}