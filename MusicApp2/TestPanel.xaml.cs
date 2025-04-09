using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace MusicApp2
{
    /// <summary>
    /// Interaktionslogik für TestPanel.xaml
    /// </summary>
    public partial class TestPanel : UserControl
    {
        public TestPanel()
        {
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage()
        {
            try
            {
                
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                string imagePath = "images/AppIcon.png";
                bitmap.UriSource = new Uri(imagePath, UriKind.Relative);
                bitmap.EndInit();

               
                AppIconImage.Source = bitmap;

                if (bitmap.IsDownloading || bitmap.PixelWidth == 0 || bitmap.PixelHeight == 0)
                {
                    throw new Exception("Das Bild konnte nicht geladen werden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden des Bildes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
