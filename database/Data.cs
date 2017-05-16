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
        static public List<String> race = new List<string> { "Human", "Dwarf", "Gnome", "Elve", "Halfling", "Orc" };
        static public List<String> nature = new List<string> { "Barabrian", "Bard", "Cleric", "Druid", "Fighter", "Wizard", "Monk", "Paladin", "Ranger", "Sorcerer", "Rogue", "Warlock" };
        static public List<String> alignment = new List<string> { "Lawful good", "Neutral good", "Chaotic good", "Lawful neutral", "True neutral", "Chaotic neutral", "Lawful evil", "Neutral evil", "Chaotic evil" };
        static public List<Characters> characters = new List<Characters> { };
        static public List<Player> players = new List<Player> { };
        static public int[] stats = new int[6];
        static public Characters j = new Characters("Josan", "Human", "Cleric", "Neutral good", new int[] { 14, 17, 11, 16, 20, 13 });
        static public Characters t = new Characters("Tordek", "Dwarf", "Fighter", "Chaotic neutral", new int[] { 20, 19, 15, 10, 10, 14 });
        static public Characters s = new Characters("Soveliss", "Elve", "Ranger", "Lawful evil", new int[] { 16, 18, 21, 17, 19, 13 });
        static public Characters l = new Characters("Lidda", "Halfling", "Rogue", "Chaotic good", new int[] { 13, 15, 22, 16, 13, 16});
        static public Characters e = new Characters("Eberk", "Dwarf", "Cleric", "True neutral", new int[] { 17, 15, 11, 18, 20, 15 });
        static public Characters k = new Characters("Krusk", "Orc", "Barbarian", "Chaotic evil", new int[] { 22, 21, 7, 6, 5, 10 });
        static public List<Characters> iconic = new List<Characters> {j,t,s,l,e,k };
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
