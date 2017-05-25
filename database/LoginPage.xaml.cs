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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace database
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            
            Data.Download();
        }

        private void nologin_button_Click(object sender, RoutedEventArgs e)
        {
            Logger.Instance.Log("Unauthorised user has appeared.");
            string s = null;
            NavigationService nav;
            MainPage CP = new MainPage(s);
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
            
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            LoginItselfPage CP = new LoginItselfPage();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            Data.Save();
        }

        private void newaccount_button_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            NavigationService nav;
            LoginItselfPage CP = new LoginItselfPage(s);
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void login_button_MouseEnter(object sender, MouseEventArgs e)
        {
            
            login_button.FontSize = 17;
        }

        private void login_button_MouseLeave(object sender, MouseEventArgs e)
        {
            
            login_button.FontSize = 14;
        }

        private void newaccount_button_MouseEnter(object sender, MouseEventArgs e)
        {
            newaccount_button.FontSize = 17;
        }

        private void newaccount_button_MouseLeave(object sender, MouseEventArgs e)
        {
            newaccount_button.FontSize = 14;
        }

        private void nologin_button_MouseEnter(object sender, MouseEventArgs e)
        {
            nologin_button.FontSize = 17;
        }

        private void nologin_button_MouseLeave(object sender, MouseEventArgs e)
        {
            nologin_button.FontSize = 14;
        }
    }
}
