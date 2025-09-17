using System;
using System.Text;
using System.Windows;
using System.Data.SQLite;

namespace professional_ui
{
    public partial class MainWindow : Window
    {
        public bool IsLoggedIn { get; private set; } = false;
        private readonly string connectionString;
        private readonly methods.DataBaseServices dbService = new methods.DataBaseServices();
        private string currentUsername = "";


        public MainWindow()
        {
            InitializeComponent();
            string dbPath = @"C:\Users\geoge\OneDrive\Desktop\dbs\new.db";
            connectionString = $"Data Source={dbPath};Version=3;";
        }
        // navigation between pages 
        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsLoggedIn)
            {
                homeBorder.Visibility = Visibility.Visible;
                MainBorder2.Visibility = Visibility.Hidden;
                MainBorder3.Visibility = Visibility.Hidden;
                MainBorder4.Visibility = Visibility.Hidden;
                loginBorder.Visibility = Visibility.Hidden;
            }
            else
            {
                unAutherisedBorder.Visibility = Visibility.Visible;
                loginBorder.Visibility = Visibility.Hidden;
            }
        }

        private void page2Btn_Click(object sender, RoutedEventArgs e)
        {
            if (IsLoggedIn)
            {
                homeBorder.Visibility = Visibility.Hidden;
                MainBorder2.Visibility = Visibility.Visible;
                MainBorder3.Visibility = Visibility.Hidden;
                MainBorder4.Visibility = Visibility.Hidden;
                loginBorder.Visibility = Visibility.Hidden;
            }
            else
            {
                unAutherisedBorder.Visibility = Visibility.Visible;
                loginBorder.Visibility = Visibility.Hidden;
            }
        }

        private void page3Btn_Click(object sender, RoutedEventArgs e)
        {
            if (IsLoggedIn)
            {
                homeBorder.Visibility = Visibility.Hidden;
                MainBorder2.Visibility = Visibility.Hidden;
                MainBorder3.Visibility = Visibility.Visible;
                MainBorder4.Visibility = Visibility.Hidden;
                loginBorder.Visibility = Visibility.Hidden;
            }
            else
            {
                unAutherisedBorder.Visibility = Visibility.Visible;
                loginBorder.Visibility = Visibility.Hidden;
            }          
        }

        private void page4Btn_Click(object sender, RoutedEventArgs e)
        {
            if (IsLoggedIn)
            {
                homeBorder.Visibility = Visibility.Hidden;
                MainBorder2.Visibility = Visibility.Hidden;
                MainBorder3.Visibility = Visibility.Hidden;
                MainBorder4.Visibility = Visibility.Visible;
                loginBorder.Visibility = Visibility.Hidden;
            }
            else
            {
                unAutherisedBorder.Visibility = Visibility.Visible;
                loginBorder.Visibility = Visibility.Hidden;
            }
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!IsLoggedIn)
            {
                homeBorder.Visibility = Visibility.Hidden;
                MainBorder2.Visibility = Visibility.Hidden;
                MainBorder3.Visibility = Visibility.Hidden;
                MainBorder4.Visibility = Visibility.Hidden;
                loginBorder.Visibility = Visibility.Visible;
                unAutherisedBorder.Visibility= Visibility.Hidden;
            }
            else
            {
                IsLoggedIn = false;
                loginBtn_Click(sender, e);
            }
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.Trim();

            if (dbService.loginUser(username, password))
            {
                txtUsername.Text = string.Empty;
                txtPassword.Password = string.Empty;
                IsLoggedIn = true;
                homeBtn_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

    }
}
