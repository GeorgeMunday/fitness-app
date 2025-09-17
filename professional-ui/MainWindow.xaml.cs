using System;
using System.Windows;
using professional_ui.methods;

namespace professional_ui
{
    public partial class MainWindow : Window
    {
        public bool IsLoggedIn { get; private set; } = false;
        private readonly DataBaseServices dbService = new DataBaseServices();
        private Navigation navigator;
        private string currentUsername = "";

        public MainWindow()
        {
            InitializeComponent();
            navigator = new Navigation(homeBorder, MainBorder2, MainBorder3, MainBorder4, loginBorder, unAutherisedBorder);
            navigator.Navigate("login", IsLoggedIn);
        }
        private void homeBtn_Click(object sender, RoutedEventArgs e) => navigator.Navigate("home", IsLoggedIn);
        private void page2Btn_Click(object sender, RoutedEventArgs e) => navigator.Navigate("page2", IsLoggedIn);
        private void page3Btn_Click(object sender, RoutedEventArgs e) => navigator.Navigate("page3", IsLoggedIn);
        private void page4Btn_Click(object sender, RoutedEventArgs e) => navigator.Navigate("page4", IsLoggedIn);

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!IsLoggedIn)
            {
                navigator.Navigate("login", IsLoggedIn);
            }
            else
            {
                IsLoggedIn = false;
                currentUsername = "";
                navigator.Navigate("login", IsLoggedIn);
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
                currentUsername = username;
                navigator.Navigate("home", IsLoggedIn);
                var userData = dbService.getDataByUsername(currentUsername);
                if (userData.Count > 0)
                {
                    var user = userData[0];
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
