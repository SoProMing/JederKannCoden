using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_OOP
{
    internal class Spielfeld
    {
        Spielfigur[,] spielfeld;
        int höhe, breite;

        public Spielfeld( int höhe, int breite )
        {
            spielfeld = new Spielfigur[höhe, breite]; // 3, 3
            this.höhe = höhe;
            this.breite = breite;
        }

        public void Zeichnen()
        {
            // Spielfeld anzeigen
            for (var zeile = 0; zeile < 3; zeile++)
            {
                var feld1 = (spielfeld[zeile, 0] != null) ? spielfeld[zeile, 0].aussehen : ' ';
                var feld2 = (spielfeld[zeile, 1] != null) ? spielfeld[zeile, 1].aussehen : ' ';
                var feld3 = (spielfeld[zeile, 2] != null) ? spielfeld[zeile, 2].aussehen : ' ';
                Console.WriteLine($"{feld1} | {feld2} | {feld3}");
                if (zeile < 2) Console.WriteLine("---------");
            }
        }
    }
}
