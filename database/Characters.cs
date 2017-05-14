using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{ [Serializable]
    public class Characters
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _race;
        public string Race
        {
            get { return _race; }
            set { _race = value; }
        }

        private string _nature;
        public string Nature
        {
            get { return _nature; }
            set { _nature = value; }
        }

        private string _alignment;
        public string Alighnment
        {
            get { return _alignment; }
            set { _alignment = value; }
        }

        private int[] _stats;

        public int[] Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }

        

        public Characters(string name, string race, string nature, string alignment, int[] stats)
        {
            _name = name;
            _race= race;
            _nature = nature;
            _alignment = alignment;
            _stats = stats;
        }
        public string Info
        {
            get
            {
                return $"{_name}-{_race}-{_nature}-{_alignment}-{_stats[0]}-{_stats[1]}-{_stats[2]}-{_stats[3]}-{_stats[4]}-{_stats[5]}";
            }
        }
    }
}
