using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletBox
{
    class Player
    {
        //fields
        private string _username;
        private int _score;

        //constructor
        Random rand = new Random();
        public Player(string user, int score)
        {

            Username = user;
            Score = score;
        }

        //properties (read-only)
        public string Username { get => _username; set => _username = value; }
        public int Score { get => _score; set => _score = value; }

        //methods

    }

}
