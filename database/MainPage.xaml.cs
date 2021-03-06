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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(int number)
        {
            InitializeComponent();
            Data.characters.Clear();
            characters.Items.Clear();
            label_player.Content = "You are logged in as: "+Data.players[number].Login;


            foreach (var item in Data.players[number].Characters)
                    {
                        Data.characters.Add(item);
                    }

                foreach (var item in Data.characters)
                {
                    characters.Items.Add(item);
                }
              
            }

        public MainPage(string s)
        {
            InitializeComponent();
            characters.ItemsSource = Data.iconic;
            search.Visibility = Visibility.Hidden;
            delete.Visibility = Visibility.Hidden;
            Add.Visibility = Visibility.Hidden;
            change.Visibility = Visibility.Hidden;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            AddPage CP = new AddPage();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            SearchPage CP = new SearchPage();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void BackToWelcome_button_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService nav;
            LoginPage CP = new LoginPage();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (characters.SelectedItem != null)
            {
                Logger.Instance.Log("The character has been deleted.");
                Data.characters.RemoveAt(characters.SelectedIndex);
                Data.players[Data.number].Characters.RemoveAt(characters.SelectedIndex);
                characters.Items.RemoveAt(characters.SelectedIndex);
            }
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            Data.Save();
        }


        private void change_Click(object sender, RoutedEventArgs e)
        {
            if (characters.SelectedItem != null)
            {
                NavigationService nav;
                ChangePage CP = new ChangePage(characters.SelectedItem as Characters, characters.SelectedIndex, Data.players);
                nav = NavigationService.GetNavigationService(this);
                nav.Navigate(CP);
                
            }
            
        }
    }
}
