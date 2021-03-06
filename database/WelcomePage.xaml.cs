﻿using System;
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
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void characters_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            MainPage CP = new MainPage(Data.number);
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void BackToLogin_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            LoginPage CP = new LoginPage();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            Data.Save();
        }
    }
}
