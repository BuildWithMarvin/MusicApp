using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;



namespace MusicApp2
{
    /// <summary>
    /// Interaktionslogik für ProposalsWindow.xaml
    /// </summary>
    public partial class ProposalsWindow : UserControl
    {
        public ProposalsWindow()
        {
            InitializeComponent();
        }
        public string UserID;

        Database db = new Database();
        public async void SetTrackPlaysPanel(string pUserID)
        {
            int i = 0;
            int a = 0;
            UserID = pUserID;

            List<AlbumJs> LiAlb = new List<AlbumJs>();
            LiAlb = await db.GetAlbums();
            List<TrackPlays> LiTra = new List<TrackPlays>();

            LiTra = await db.GetTrackPlay(UserID);

            if (LiTra.Count > 0)
            {

                this.Visibility = Visibility.Visible;
                foreach (TrackPlays plays in LiTra)
                {

                    SetTrackPlaysLabel(plays, i);
                    i++;
                }
            }
            if (LiAlb.Count > 0)
            {
                foreach (AlbumJs album in LiAlb)
                {
                    SetAlbumRecommendedPanel(album, a);
                    a++;
                }

            }
        }
        public async void SetTrackPlaysLabel(TrackPlays tp, int a)
        {

            Track track;
            Artist artist;
            Album album;
            track = await db.GetTrackByID(tp.track_id);
            artist = await db.GetArtistByID(track.artistID);
            album = await db.GetAlbumByID(track.albID);



            switch (a)
            {
                case 0:
                    SetTrackPlaysPic(track, a);
                    Label1.Content = track.title;
                    SubLabel1.Content = artist.name;
                    break;
                case 1:
                    SetTrackPlaysPic(track, a);
                    Label2.Content = track.title;
                    SubLabel2.Content = artist.name;

                    break;
                case 2:
                    SetTrackPlaysPic(track, a);
                    Label3.Content = track.title;
                    SubLabel3.Content = artist.name;

                    break;
                case 3:
                    SetTrackPlaysPic(track, a);
                    Label4.Content = track.title;
                    SubLabel4.Content = artist.name;

                    break;
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

        public async void SetAlbumRecommendedPanel(AlbumJs album, int a)
        {

            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", album.picture);
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();

            switch (a)
            {
                case 0: AlbLabel1Pic.Source = bitmap; AlbLabel1.Content = album.Name; 
                    SetAlbumProposals(album, a); break;
                case 1: AlbLabel2Pic.Source = bitmap; AlbLabel2.Content = album.Name;
                    SetAlbumProposals(album, a); break;
            }

        }
    }

}