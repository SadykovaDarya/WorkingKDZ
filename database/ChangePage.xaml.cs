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
    /// Логика взаимодействия для ChangePage.xaml
    /// </summary>
    public partial class ChangePage : Page
    {
        
        public ChangePage(Characters item, int index, List<Player> players)
        {
            InitializeComponent();
            raceBox.ItemsSource = Data.race;
            natureBox.ItemsSource = Data.nature;
            alignmentBox.ItemsSource = Data.alignment;

            nameBox.Text = Data.characters[index].Name;
            raceBox.Text = Data.characters[index].Race;
            natureBox.Text = Data.characters[index].Nature;
            alignmentBox.Text = Data.characters[index].Alighnment;
            List<TextBox> stats = new List<TextBox> { Strength, Constitution, Dexterity, Intelligence, Wisdom, Charisma };
            for (int i = 0; i < 6; i++)
            {
                stats[i].Text = Data.characters[index].Stats[i].ToString();
            }
            this.index = index;
        }
        int index;
        private void BackToMain_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            MainPage CP = new MainPage(Data.number);
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int k = 0;
            List<TextBox> stats = new List<TextBox> { Strength, Constitution, Dexterity, Intelligence, Wisdom, Charisma };
            foreach (var item in stats)
            {
                int t; 
                if ((int.TryParse(item.Text, out t) == false) || (int.Parse(item.Text) > 22)) k++;
            }
            if (nameBox.Text == "") { label_error.Content = "Error occured! Type name."; }
            else if (k > 0) { label_error.Content = "Error occured! Characteristics have to be numerical and no more than 22."; }
            else
            {
                Data.characters[index].Name = nameBox.Text;
                Data.characters[index].Race = raceBox.Text;
                Data.characters[index].Nature = natureBox.Text;
                Data.characters[index].Alighnment = alignmentBox.Text;
                for (int i = 0; i < 6; i++)
                {
                    Data.characters[index].Stats[i] = int.Parse(stats[i].Text);
                }
            }
        }

        private void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            Data.Save();
        }
    }
}
