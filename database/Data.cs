using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    static public class Data
    {
     static public List<String> race = new List<string>{ "Human", "Dwarf", "Gnome", "Elve", "Halfling", "Orc" };
     static public List<String> nature = new List<string> {"Barabrian", "Bard", "Cleric", "Druid", "Fighter", "Wizard", "Monk", "Paladin", "Ranger", "Sorcerer", "Rogue", "Warlock"};
     static public List<String> alignment = new List<string> {"Lawful good", "Neutral good", "Chaotic good", "Lawful neutral", "True neutral", "Chaotic neutral", "Lawful evil", "Neutral evil", "Chaotic evil" };
     static public List<Characters> characters = new List<Characters> { };
     static public List<Player> players = new List<Player> {};
     static public int[] stats = new int[6];
     static public int number;
        static public void Save()
        {
            FileStream fs = new FileStream("input.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, players);
            
            fs.Close();
        }
        static public Boolean mark = true;
        static public void Download()
        {
            if (!mark) goto end;
            else
            {
                FileStream fs = new FileStream("input.bin", FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                mark = false;
                if (fs.Length == 0) { players = new List<Player> { }; }
                else
                {
                    players = (List<Player>)bf.Deserialize(fs);
                }
                fs.Close();
            }
            end:;
            }
    }
}
