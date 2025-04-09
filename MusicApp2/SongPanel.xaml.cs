
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace MusicApp2
{
    /// <summary>
    /// Interaktionslogik für SongPanel.xaml
    /// </summary>
    public partial class SongPanel : UserControl
    {
        public SongPanel()
        {
            InitializeComponent();

        }
        Database db = new Database();
        int trackid;
        int trackid1;
        int trackid2;
        int trackid3;

        public string UserID;
        Profiles profiles;
       
        public async void SetPanel(SearchValue sv, string pUserID)
        {
            UserID = pUserID;

            if(profiles == null)
            { 
                profiles = await db.GetUserID(UserID);
                if (profiles == null)
                { 
                    db.NewProfile(UserID);
                }
                
            
            }

           
            List<Album> liAlb = new List<Album>();
            List<Track> liTra = new List<Track>();
            liTra = await db.GetTracksByValue(sv);
            liAlb = await db.GetAlbumsByValue(sv);

            if (liAlb.Count == 0 && liTra.Count == 0)
            {
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.Visibility = Visibility.Visible;
                SetAlbumPanel(liAlb);
                SetTracksPanel(liTra);
            }

        }
        public async void SetAlbumPanel(List<Album> liAlb)
        {
            int i = 0;
            if (liAlb.Count > 0)
            {
                this.leftPanel.Visibility = Visibility.Visible;

                foreach (Album album in liAlb)
                {
                    if (i == 0)
                    {

                        if (!string.IsNullOrWhiteSpace(album.picture))
                        {
                            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", album.picture);

                            if (File.Exists(imagePath))
                            {
                                var bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                                bitmap.EndInit();

                                AlbumPic.Visibility = Visibility.Visible;
                                AlbumPic.Source = bitmap;
                                SetAlbumContent(album);
                                i++;
                            }
                            else
                            {
                                AlbumPic.Visibility = Visibility.Hidden;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
        public async void SetAlbumContent(Album al)
        {
            int a = al.artistID;

            Artist artist = await db.GetArtistByID(a);
            leftPanelsubLabel.Content = al.Name;
            leftPanelLabel.Content = artist.name;

        }
        public /*async*/ void SetTracksPanel(List<Track> liTra)  /*Prüfen ob ich async in diesem Falle weglassen kann*/
        {
            int i = 0;

            if (liTra.Count > 0)
            {

                foreach (Track track in liTra)
                {

                    switch (i)
                    {
                        case 0:

                            SetRightSubPanels(i, track);
                            break;
                        case 1:

                            SetRightSubPanels(i, track);
                            break;
                        case 2:

                            SetRightSubPanels(i, track);
                            break;
                        case 3:
                            ;
                            SetRightSubPanels(i, track);
                            break;
                    }
                    i++;
                }
            }
        }


        public async void SetRightSubPanels(int a, Track tr)
        {
            rightPanel1.Visibility = Visibility.Hidden;
            rightPanel2.Visibility = Visibility.Hidden;
            rightPanel3.Visibility = Visibility.Hidden;
            rightPanel4.Visibility = Visibility.Hidden;
            Artist artist = await db.GetArtistByID(tr.artistID);

            if (artist != null)
            {
                switch (a)
                {
                    case 0:
                        SetPicturesRightSubPanels(a, tr);
                        trackid = tr.Id;
                        rightPanel1.Visibility = Visibility.Visible;
                        rightLabel1.Content = tr.title;
                        rightSubLabel1.Content = artist.name;
                        break;
                    case 1:
                        SetPicturesRightSubPanels(a, tr);
                        trackid1 = tr.Id;
                        rightPanel2.Visibility = Visibility.Visible;
                        rightLabel2.Content = tr.title;
                        rightSubLabel2.Content = artist.name;
                        break;

                    case 2:
                        SetPicturesRightSubPanels(a, tr);
                        trackid2 = tr.Id;
                        rightPanel3.Visibility = Visibility.Visible;
                        rightLabel3.Content = tr.title;
                        rightSubLabel3.Content = artist.name;
                        break;
                    case 3:
                        SetPicturesRightSubPanels(a, tr);
                        trackid3 = tr.Id;
                        rightPanel4.Visibility = Visibility.Visible;
                        rightLabel4.Content = tr.title;
                        rightSubLabel4.Content = artist.name;
                        break;
                }
            }

        }

        public async void SetPicturesRightSubPanels(int a, Track tr)
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

        private void rightLabel1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
           db.UpsertTrackPlay(UserID, trackid);
        }

        private void rightLabel2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            db.UpsertTrackPlay(UserID, trackid1);
        }

        private void rightLabel3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            db.UpsertTrackPlay(UserID, trackid2);
        }

        private void rightLabel4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            db.UpsertTrackPlay(UserID, trackid3);
        }
    }
}
