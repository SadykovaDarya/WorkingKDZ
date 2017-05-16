using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{ [Serializable]
    public class Player
    {
        private string _login;
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private List<Characters> _characters =  new List<Characters>();
        public List<Characters> Characters 
        {
            get { return _characters; }
            set { _characters = value; }
        }
        public Player(string login, string password)
        {
            _login = login;
            _password = password;
        }
    } 
}
