using System.Windows;
using System.Windows.Input;

namespace MusicApp2
{
 
    public partial class WindowLogin : Window
    {  
        public WindowLogin()
        {
            InitializeComponent();
            
            
        }

        Database db = new Database();
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        public string id;
       
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var client = new Supabase.Client(db.Url, db.Key);

            try
            {
                var signInResponse = await client.Auth.SignInWithPassword(TextBoxUser.Text, PasswordBoxUser.Password);
                id = signInResponse.User.Id;
               MainWindow window = new MainWindow(id);
                window.Show();
                this.Close();





            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong email oder password. Try again !");
            }
        }
    }
}
