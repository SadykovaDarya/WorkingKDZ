using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для LoginItselfPage.xaml
    /// </summary>
    public partial class LoginItselfPage : Page
    {
        public LoginItselfPage()
        {
            InitializeComponent();
            
        }

        private void BackToLogin_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            LoginPage CP = new LoginPage();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password_textBox.Text));
            string h = Convert.ToBase64String(hash);


            for (int i = 0; i < Data.players.Count; i++)
            {
            
            
                if (login_textBox.Text == Data.players[i].Login && h == Data.players[i].Password)
                {
                    Data.number = i;
                    NavigationService nav;
                    MainPage CP = new MainPage(Data.number);
                    nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(CP);
                    goto shit;
                }
            }
            { error_label.Content = "Error occured! Wrong password or login."; login_textBox.Text = ""; password_textBox.Text = ""; }
        shit:;
        }

        private void newplayer_button_Click(object sender, RoutedEventArgs e)
        {
            Data.mark = false;
            if (login_textBox .Text!= "" && password_textBox .Text!= "")
            {
                MD5 md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password_textBox.Text));
                string h = Convert.ToBase64String(hash);
                Data.players.Add(new Player(login_textBox.Text, h));
                NavigationService nav;
                LoginPage CP = new LoginPage();
                nav = NavigationService.GetNavigationService(this);
                nav.Navigate(CP);
            }
            else error_label.Content = "Error occured! All fields must be filled.";
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            Data.Save();
        }
    }
}
