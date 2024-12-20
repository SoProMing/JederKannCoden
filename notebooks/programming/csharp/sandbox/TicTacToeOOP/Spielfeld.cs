using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeOOP
{
    internal class Spielfeld
    {
        Spielstein[,] data;

        public Spielfeld() {
            data = new Spielstein[3, 3];
        }

        public void male()
        {

        }

        // gibt false zurück, wenn Koordinate belegt
        public bool setze(Spielstein stein, int x, int y)
        {
            return false;
        }

        public Spielstein prüfe(int x, int y)
        {
            return null;
        }
    }
}
