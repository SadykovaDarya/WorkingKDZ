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
            
            nameBox.Text = "";
            raceBox.Text = "";
            natureBox.Text = "";
            alignmentBox.Text = "";
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
    }
}
