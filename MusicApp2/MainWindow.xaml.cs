
using System.Windows;
using System.Windows.Controls;



namespace MusicApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {     Database db = new Database();
        List <Album> albums = new List <Album> ();
        string id;
        Profiles profiles;
        string Id { get => id; set => id = value; }

        public MainWindow(string pId)
        {
           InitializeComponent();
            Id = pId;
            ProposalPanelControl.SetTrackPlaysPanel(Id);
        
        }


        private async void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchValue sv = new SearchValue(SearchTextBox.Text);
                DisplResultsByValue(sv, Id);
                //FügePanelZumGrid(Grid2);
                ProposalPanelControl.Visibility = Visibility.Collapsed;
            }
            else
            {
                ProposalPanelControl.Visibility = Visibility.Visible;
                songPanelControl.Visibility = Visibility.Collapsed;
                TestPanelControl.Visibility = Visibility.Collapsed;
                //FügePanelZumGrid(Grid2);
            }
            }

        //private void FügePanelZumGrid(Grid grid)
        //{
        //    TestPanel neuesPanel = new TestPanel();
        //    neuesPanel.Visibility = Visibility.Visible;
        //    neuesPanel.Height = 100;
        //    neuesPanel.Width = 100;
        //    neuesPanel.VerticalAlignment = VerticalAlignment.Top;

          
        //    int panelCount = grid.Children.OfType<TestPanel>().Count();
        //    neuesPanel.Margin = new Thickness(0, panelCount * 25, 0, 0);
        //    neuesPanel.Margin = new Thickness(0, 5, 0, 0);
        //    TestPanelContainer.Children.Add(neuesPanel);
        //}

      
    }
}