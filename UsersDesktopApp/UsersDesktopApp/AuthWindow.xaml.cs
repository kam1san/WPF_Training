using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace UsersDesktopApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();

            DoubleAnimation animation = new DoubleAnimation();
            //animation.From = 0;
            //animation.To = ;
            //animation.Duration = TimeSpan.FromSeconds(1);
            //LogInButton.BeginAnimation(Button.WidthProperty, animation);
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            string log = login.Text.Trim();
            string pass = password.Password.Trim();

            User authUser = null;
            using (AppContext db = new AppContext())
            {
                authUser = db.Users.Where(user => user.Login == log && user.Password == pass).FirstOrDefault();
            }

            if (authUser != null)
            {
                login.ToolTip = null;
                login.Background = Brushes.Transparent;
                password.ToolTip = null;
                password.Background = Brushes.Transparent;

                UserPage userpage = new UserPage();
                userpage.Show();
                this.Hide();
            }
            else
            {
                login.ToolTip = "Login or password do not match";
                login.Background = Brushes.LightGoldenrodYellow;
                password.ToolTip = "Login or password do not match";
                password.Background = Brushes.LightGoldenrodYellow;
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
    }
}
