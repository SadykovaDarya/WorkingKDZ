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
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            raceBox.ItemsSource = Data.race;
            natureBox.ItemsSource = Data.nature;
            alignmentBox.ItemsSource = Data.alignment;
            label_player.Content = "You are logged in as: " + Data.players[Data.number].Login;
        }

        private void button_Find_Click(object sender, RoutedEventArgs e)
        {   
            SearchResults_listBox.Items.Clear();
            SearchResults_listBox.Visibility = Visibility.Visible;
            Logger.Instance.Log("The search has been initiated.");
            foreach (var hero in Data.characters)
                {
                    if ((nameBox.Text==hero.Name|| nameBox.Text == "")&&(raceBox.Text == hero.Race || raceBox.Text == "") &&(natureBox.Text == hero.Nature || natureBox.Text == "") && (alignmentBox.Text == hero.Alignment || alignmentBox.Text == ""))
                    {
                    SearchResults_listBox.Items.Add(hero);
                    }
                }
            #region
            nameBox.Text = "";
            raceBox.Text = "";
            natureBox.Text = "";
            alignmentBox.Text = "";
            textBlock_race.Visibility = Visibility.Visible;
            textBlock_nature.Visibility = Visibility.Visible;
            textBlock_alignment.Visibility = Visibility.Visible;
            label_Copy.Visibility = Visibility.Visible;
            label_Copy1.Visibility = Visibility.Visible;
            label_Copy2.Visibility = Visibility.Visible;
            label_Copy3.Visibility = Visibility.Visible;
            label_Copy4.Visibility = Visibility.Visible;
            label_Copy5.Visibility = Visibility.Visible;
            label_Copy6.Visibility = Visibility.Visible;
            label_Copy7.Visibility = Visibility.Visible;
            label_Copy8.Visibility = Visibility.Visible;
            label_Copy9.Visibility = Visibility.Visible;
            #endregion
        }

        private void BackToMain_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            MainPage CP = new MainPage(Data.number);
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            Data.Save();
        }

        private void raceBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBlock_race.Visibility = Visibility.Hidden;
        }

        private void natureBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBlock_nature.Visibility = Visibility.Hidden;
        }

        private void alignmentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBlock_alignment.Visibility = Visibility.Hidden;
        }
    }
}
