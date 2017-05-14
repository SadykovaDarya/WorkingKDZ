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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
            raceBox.ItemsSource = Data.race;
            natureBox.ItemsSource = Data.nature;
            alignmentBox.ItemsSource = Data.alignment;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        { int k = 0;
            List<TextBox> stats = new List<TextBox> { Strength, Constitution, Dexterity, Intelligence, Wisdom, Charisma };
            foreach (var item in stats)
            {
                int t;
                if ((int.TryParse(item.Text, out t) == false) || (int.Parse(item.Text) > 22)) k++;
            }
            if (raceBox.SelectedIndex == -1 || natureBox.SelectedIndex == -1 || alignmentBox.SelectedIndex == -1) { label_error.Content = "Error occured! Choose parameter from the fields."; }
            else if (nameBox.Text == "") { label_error.Content = "Error occured! Type name."; }
            else if (k>0 ) { label_error.Content = "Error occured! Characteristics have to be numerical and no more than 22."; }
            else
            { 
                for (int i = 0; i < stats.Count; i++)
                {
                    Data.stats[i] = int.Parse(stats[i].Text);
                }
                Characters hero = new Characters(nameBox.Text, raceBox.Text, natureBox.Text, alignmentBox.Text, Data.stats);
                Data.characters.Add(hero);
                Data.players[Data.number].Characters.Add(hero);
                nameBox.Text = "";
                raceBox.Text = "";
                natureBox.Text = "";
                alignmentBox.Text = "";
                foreach (var item in stats)
                {
                    item.Text = "";
                }
            }
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
