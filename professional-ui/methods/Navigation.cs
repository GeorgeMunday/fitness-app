using System.Windows;
using System.Windows.Controls;

namespace professional_ui.methods
{
    public class Navigation
    {
        private readonly Border homeBorder;
        private readonly Border mainBorder2;
        private readonly Border mainBorder3;
        private readonly Border mainBorder4;
        private readonly Border loginBorder;
        private readonly Border unAutherisedBorder;

        public Navigation(Border home, Border b2, Border b3, Border b4, Border login, Border unauth)
        {
            homeBorder = home;
            mainBorder2 = b2;
            mainBorder3 = b3;
            mainBorder4 = b4;
            loginBorder = login;
            unAutherisedBorder = unauth;
        }

        public void Navigate(string route, bool IsLoggedIn)
        {
            homeBorder.Visibility = Visibility.Hidden;
            mainBorder2.Visibility = Visibility.Hidden;
            mainBorder3.Visibility = Visibility.Hidden;
            mainBorder4.Visibility = Visibility.Hidden;
            loginBorder.Visibility = Visibility.Hidden;
            unAutherisedBorder.Visibility = Visibility.Hidden;

            switch (route.ToLower())
            {
                case "home":
                    if (IsLoggedIn) homeBorder.Visibility = Visibility.Visible;
                    else homeBorder.Visibility = Visibility.Visible;
                    break;

                case "page2":
                    if (IsLoggedIn) mainBorder2.Visibility = Visibility.Visible;
                    else unAutherisedBorder.Visibility = Visibility.Visible;
                    break;

                case "page3":
                    if (IsLoggedIn) mainBorder3.Visibility = Visibility.Visible;
                    else unAutherisedBorder.Visibility = Visibility.Visible;
                    break;

                case "page4":
                    if (IsLoggedIn) mainBorder4.Visibility = Visibility.Visible;
                    else unAutherisedBorder.Visibility = Visibility.Visible;
                    break;

                case "login":
                    loginBorder.Visibility = Visibility.Visible;
                    break;

                default:
                    MessageBox.Show("Unknown route: " + route);
                    break;
            }
        }
    }
}
